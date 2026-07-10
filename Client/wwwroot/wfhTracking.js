/**
 * WFH GPS Tracking Module
 * Sends a GPS ping to the server every 20 seconds while the employee is punched in (WFH mode).
 * Handles: permission denied, GPS disabled, offline/retry, background tab, screen wake lock.
 *
 * ── BACKGROUND LIMITATION ──────────────────────────────────────────────────────
 * Blazor PWA runs in the browser tab. JavaScript timers ARE throttled or stopped:
 *   - Tab minimized (desktop): timers throttled to ~1 min by Chrome
 *   - Mobile background       : killed by OS after ~30 sec
 *   - Screen locked / sleep   : stopped
 *   - Browser closed          : stopped
 *
 * MITIGATIONS implemented here:
 *   1. Screen Wake Lock API  — prevents sleep while tab is active
 *   2. visibilitychange      — sends immediate catch-up ping when tab regains focus
 *   3. online event          — resumes after internet reconnects
 *   4. Beacon API fallback   — sends final ping even when page is unloading
 *   5. Server-side gap detection (via /api/wfh/locationPing LastPingTime field)
 * ───────────────────────────────────────────────────────────────────────────────
 */
window.wfhTracking = (() => {

    let _pingIntervalId = null;
    let _watchId = null;
    let _empId = null;
    let _retryCount = 0;
    const MAX_RETRIES = 5;
    const PING_INTERVAL_MS = 20000; // 20 seconds

    // Screen Wake Lock
    let _wakeLock = null;

    // Current best position from watchPosition
    let _currentLat = null;
    let _currentLon = null;
    let _positionAge = null;

    function _log(msg) {
        console.log(`[WFH-TRACKING] ${new Date().toLocaleTimeString()} | ${msg}`);
    }

    function _getDeviceInfo() {
        return {
            deviceName: navigator.platform || 'Unknown',
            browser: (() => {
                const ua = navigator.userAgent;
                if (ua.includes('Edg/'))    return 'Microsoft Edge';
                if (ua.includes('Chrome'))  return 'Google Chrome';
                if (ua.includes('Firefox')) return 'Mozilla Firefox';
                if (ua.includes('Safari'))  return 'Apple Safari';
                return 'Unknown Browser';
            })()
        };
    }

    async function _getIp() {
        try {
            const res = await fetch('https://api.ipify.org?format=json', { signal: AbortSignal.timeout(4000) });
            const data = await res.json();
            return data.ip || '';
        } catch { return ''; }
    }

    function _startGpsWatch() {
        if (!navigator.geolocation) {
            _log('Geolocation not supported.');
            return;
        }

        _watchId = navigator.geolocation.watchPosition(
            (pos) => {
                _currentLat = pos.coords.latitude;
                _currentLon = pos.coords.longitude;
                _positionAge = new Date();
                _retryCount = 0;
                _log(`GPS updated: ${_currentLat.toFixed(6)}, ${_currentLon.toFixed(6)} (acc: ${pos.coords.accuracy.toFixed(0)}m)`);
            },
            (err) => {
                _log(`GPS watch error [${err.code}]: ${err.message}`);
                if (err.code === 1) {
                    // PERMISSION_DENIED — stop trying
                    _log('GPS permission denied. Stopping WFH tracking.');
                    stopTracking();
                }
                // POSITION_UNAVAILABLE or TIMEOUT — keep retrying via interval
            },
            { enableHighAccuracy: true, timeout: 15000, maximumAge: 5000 }
        );
    }

    async function _sendPing() {
        if (_currentLat === null || _currentLon === null) {
            _log('No GPS position yet — attempting fresh get...');
            try {
                const pos = await _getFreshPosition();
                _currentLat = pos.latitude;
                _currentLon = pos.longitude;
            } catch (e) {
                _log(`Could not get position: ${e}`);
                _retryCount++;
                if (_retryCount >= MAX_RETRIES) {
                    _log('Max retries reached. Pausing pings.');
                }
                return;
            }
        }

        // Reject stale positions (older than 2 minutes)
        if (_positionAge && (new Date() - _positionAge) > 120000) {
            _log('GPS position is stale. Skipping ping.');
            return;
        }

        const { deviceName, browser } = _getDeviceInfo();

        const payload = {
            employeeId: _empId,
            latitude: _currentLat,
            longitude: _currentLon,
            deviceName,
            browser,
            ipAddress: ''
        };

        try {
            const resp = await fetch('/api/wfh/locationPing', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
                signal: AbortSignal.timeout(10000)
            });

            if (resp.ok) {
                const data = await resp.json();
                _log(`Ping OK | ${data.distance?.toFixed(0)}m | Status: ${data.currentStatus} | Event: ${data.eventTriggered || 'none'}`);
                _retryCount = 0;
            } else {
                _log(`Ping failed: HTTP ${resp.status}`);
            }
        } catch (err) {
            _retryCount++;
            if (err.name === 'TimeoutError' || err.name === 'NetworkError' || !navigator.onLine) {
                _log(`Offline or timeout. Retry ${_retryCount}/${MAX_RETRIES}.`);
            } else {
                _log(`Ping error: ${err.message}`);
            }
        }
    }

    function _getFreshPosition() {
        return new Promise((resolve, reject) => {
            if (!navigator.geolocation) { reject('Not supported'); return; }
            navigator.geolocation.getCurrentPosition(
                (p) => resolve({ latitude: p.coords.latitude, longitude: p.coords.longitude }),
                (e) => reject(e.message),
                { enableHighAccuracy: true, timeout: 12000, maximumAge: 0 }
            );
        });
    }

    // ─── Screen Wake Lock ──────────────────────────────────────────────────

    async function _acquireWakeLock() {
        if (!('wakeLock' in navigator)) {
            _log('Screen Wake Lock not supported (older browser).');
            return;
        }
        try {
            _wakeLock = await navigator.wakeLock.request('screen');
            _log('Screen Wake Lock acquired — screen will not sleep.');
            _wakeLock.addEventListener('release', () => {
                _log('Wake Lock released (system or tab hidden).');
                _wakeLock = null;
            });
        } catch (err) {
            _log(`Wake Lock error: ${err.name} — ${err.message}`);
        }
    }

    async function _releaseWakeLock() {
        if (_wakeLock) {
            await _wakeLock.release();
            _wakeLock = null;
            _log('Wake Lock released by app.');
        }
    }

    // Re-acquire wake lock when tab becomes visible again
    document.addEventListener('visibilitychange', async () => {
        if (document.visibilityState === 'visible') {
            if (_pingIntervalId) {
                _log('Tab visible again — sending catch-up ping and re-acquiring Wake Lock.');
                await _acquireWakeLock();
                _sendPing();
            }
        } else {
            // Tab hidden — wake lock is automatically released by browser
            _log('Tab hidden — Wake Lock may be released by browser (OS restriction).');
        }
    });

    // ─── Page Unload — Beacon Fallback ─────────────────────────────────────
    // Sends one final ping using sendBeacon (works even during page unload)
    window.addEventListener('beforeunload', () => {
        if (_pingIntervalId && _empId && _currentLat !== null) {
            const { deviceName, browser } = _getDeviceInfo();
            const payload = JSON.stringify({
                employeeId: _empId,
                latitude: _currentLat,
                longitude: _currentLon,
                deviceName,
                browser,
                ipAddress: ''
            });
            navigator.sendBeacon('/api/wfh/locationPing', new Blob([payload], { type: 'application/json' }));
            _log('Beacon sent on page unload.');
        }
    });

    // ─── Android Native App Detection ─────────────────────────────────────────

    function _isAndroidNativeApp() {
        return !!(window.AndroidBridge && typeof window.AndroidBridge.isNativeApp === 'function'
            && window.AndroidBridge.isNativeApp());
    }

    // ─── Public API ────────────────────────────────────────────────────────

    async function startTracking(empId) {
        if (_pingIntervalId) {
            _log('Tracking already active.');
            return;
        }

        _empId = empId;
        _retryCount = 0;

        // ── Path A: Running inside Android native app ───────────────────────
        // The native WFHLocationService handles GPS in background — even when
        // screen is off, app is backgrounded, or phone is sleeping.
        if (_isAndroidNativeApp()) {
            _log('Android native app detected — delegating GPS to native WFHLocationService.');

            try {
                const deviceInfo = window.AndroidBridge.getDeviceInfo();
                const appVersion = window.AndroidBridge.getAppVersion();

                // Notify server to open the session record
                await fetch('/api/wfh/startTracking', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        employeeId: parseInt(empId),
                        deviceName: deviceInfo,
                        browser: `SP OneHR Android App v${appVersion}`,
                        ipAddress: ''
                    })
                });
                _log('Server tracking session opened.');
            } catch (e) {
                _log(`startTracking server call failed: ${e.message}`);
            }

            // Tell the Android native layer to start the foreground GPS service
            window.AndroidBridge.startNativeTracking(parseInt(empId));
            _log('Native GPS service started. Background tracking active.');

            // Mark as active (with a sentinel so stopTracking knows to call native)
            _pingIntervalId = 'NATIVE';
            return;
        }

        // ── Path B: Browser / PWA — use JavaScript GPS ─────────────────────
        _log(`Starting WFH GPS tracking (browser mode) for Employee ${empId}`);

        // Acquire screen wake lock to prevent sleep
        await _acquireWakeLock();

        if (!navigator.geolocation) {
            _log('Geolocation not supported by browser.');
            return;
        }

        // Notify server to open tracking session
        try {
            const { deviceName, browser } = _getDeviceInfo();
            const ip = await _getIp();
            const resp = await fetch('/api/wfh/startTracking', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ employeeId: empId, deviceName, browser, ipAddress: ip })
            });
            if (resp.ok) {
                const data = await resp.json();
                _log(`Session opened | TrackingId: ${data.trackingId} | Radius: ${data.allowedRadius}m`);
            } else {
                _log(`startTracking API failed: ${resp.status}`);
            }
        } catch (e) {
            _log(`startTracking call error: ${e.message}`);
        }

        // Start GPS watch for continuous updates
        _startGpsWatch();

        // First ping immediately (slight delay to let GPS warm up)
        setTimeout(() => _sendPing(), 3000);

        // Ping every 20 seconds
        _pingIntervalId = setInterval(() => _sendPing(), PING_INTERVAL_MS);
        _log('Ping interval started (every 20 seconds).');
    }

    async function stopTracking() {
        _log(`Stopping WFH GPS tracking for Employee ${_empId}`);

        // ── Android native path ──────────────────────────────────────────────
        if (_pingIntervalId === 'NATIVE') {
            _pingIntervalId = null;
            if (_isAndroidNativeApp()) {
                window.AndroidBridge.stopNativeTracking();
                _log('Native GPS service stopped.');
            }
            _empId = null;
            return;
        }

        // ── Browser path ─────────────────────────────────────────────────────
        if (_pingIntervalId) { clearInterval(_pingIntervalId); _pingIntervalId = null; }
        if (_watchId !== null) { navigator.geolocation.clearWatch(_watchId); _watchId = null; }

        // Release wake lock
        await _releaseWakeLock();

        _currentLat = null;
        _currentLon = null;
        _retryCount = 0;

        if (_empId) {
            try {
                await fetch('/api/wfh/stopTracking', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ employeeId: _empId })
                });
                _log('Tracking session closed on server.');
            } catch (e) {
                _log(`stopTracking call error: ${e.message}`);
            }
        }

        _empId = null;
    }

    function isTracking() {
        return _pingIntervalId !== null; // true for both 'NATIVE' and numeric interval ID
    }

    // Handle going online after being offline
    window.addEventListener('online', () => {
        if (_pingIntervalId) {
            _log('Back online — resuming pings.');
            _retryCount = 0;
            _sendPing();
        }
    });

    return { startTracking, stopTracking, isTracking };
})();
