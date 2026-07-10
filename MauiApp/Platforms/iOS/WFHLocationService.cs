using CoreLocation;
using Foundation;
using UIKit;
using UserNotifications;

namespace SPOneHRApp;

/// <summary>
/// iOS background GPS tracking service.
/// Uses CLLocationManager with "Always" authorization so tracking continues
/// even when the app is backgrounded, screen is locked, or phone is sleeping.
///
/// Sends GPS pings to /api/wfh/locationPing every ~20 seconds.
/// Shows a persistent local notification while tracking is active.
/// </summary>
public class WFHLocationService : NSObject, ICLLocationManagerDelegate
{
    public static WFHLocationService Instance { get; } = new();

    private CLLocationManager? _locationManager;
    private System.Timers.Timer? _pingTimer;
    private int  _empId;
    private bool _isTracking;
    private double _lastLat, _lastLon;
    private int _pingCount;

    private WFHLocationService() { }

    // ── Start Tracking ─────────────────────────────────────────────────────

    public void StartTracking(int empId)
    {
        if (_isTracking) return;

        _empId      = empId;
        _isTracking = true;
        _pingCount  = 0;

        // Save state so BootReceiver can restart tracking after app relaunch
        NSUserDefaults.StandardUserDefaults.SetBool(true, "wfh_is_tracking");
        NSUserDefaults.StandardUserDefaults.SetInt(empId, "wfh_emp_id");
        NSUserDefaults.StandardUserDefaults.Synchronize();

        SetupLocationManager();
        ShowTrackingNotification();
        StartPingTimer();

        Console.WriteLine($"[WFHService-iOS] Tracking started for EmpId={empId}");
    }

    // ── Stop Tracking ──────────────────────────────────────────────────────

    public void StopTracking()
    {
        if (!_isTracking) return;
        _isTracking = false;

        _pingTimer?.Stop();
        _pingTimer?.Dispose();
        _pingTimer = null;

        _locationManager?.StopUpdatingLocation();
        _locationManager = null;

        NSUserDefaults.StandardUserDefaults.SetBool(false, "wfh_is_tracking");
        NSUserDefaults.StandardUserDefaults.Synchronize();

        UNUserNotificationCenter.Current.RemoveAllDeliveredNotifications();
        UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();

        Console.WriteLine("[WFHService-iOS] Tracking stopped");
    }

    public bool IsTracking => _isTracking;

    // ── CLLocationManager Setup ────────────────────────────────────────────

    private void SetupLocationManager()
    {
        _locationManager = new CLLocationManager
        {
            Delegate                   = this,
            DesiredAccuracy            = CLLocation.AccuracyBest,
            DistanceFilter             = 10,        // receive updates every 10 metres
            PausesLocationUpdatesAutomatically = false,
            AllowsBackgroundLocationUpdates    = true,  // KEY: keeps GPS alive in background
            ShowsBackgroundLocationIndicator   = true,  // Blue status bar indicator (iOS 11+)
        };

        // AuthorizationStatus is an instance property in iOS SDK 26+
        var authStatus = _locationManager.AuthorizationStatus;
        if (authStatus == CLAuthorizationStatus.AuthorizedAlways ||
            authStatus == CLAuthorizationStatus.AuthorizedWhenInUse)
        {
            _locationManager.StartUpdatingLocation();
        }
        else
        {
            _locationManager.RequestAlwaysAuthorization();
        }
    }

    // ── CLLocationManagerDelegate ──────────────────────────────────────────

    [Export("locationManager:didUpdateLocations:")]
    public void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
    {
        var loc = locations.LastOrDefault();
        if (loc == null) return;

        _lastLat = loc.Coordinate.Latitude;
        _lastLon = loc.Coordinate.Longitude;

        Console.WriteLine($"[WFHService-iOS] Location: {_lastLat:F6}, {_lastLon:F6} ±{loc.HorizontalAccuracy:F0}m");
    }

    [Export("locationManager:didChangeAuthorizationStatus:")]
    public void AuthorizationChanged(CLLocationManager manager, CLAuthorizationStatus status)
    {
        Console.WriteLine($"[WFHService-iOS] Auth status: {status}");
        if (status == CLAuthorizationStatus.AuthorizedAlways ||
            status == CLAuthorizationStatus.AuthorizedWhenInUse)
        {
            manager.StartUpdatingLocation();
        }
    }

    [Export("locationManager:didFailWithError:")]
    public void Failed(CLLocationManager manager, NSError error)
    {
        Console.WriteLine($"[WFHService-iOS] Location error: {error.LocalizedDescription}");
    }

    // ── Ping Timer (every 20 seconds) ──────────────────────────────────────

    private void StartPingTimer()
    {
        _pingTimer = new System.Timers.Timer(AppConstants.PingIntervalMs);
        _pingTimer.Elapsed += async (_, _) => await SendPingAsync();
        _pingTimer.AutoReset = true;
        _pingTimer.Start();

        // Send first ping immediately (3 second delay for GPS warm-up)
        Task.Delay(3000).ContinueWith(_ => SendPingAsync());
    }

    private async Task SendPingAsync()
    {
        if (!_isTracking || _lastLat == 0) return;

        try
        {
            var payload = new
            {
                employeeId = _empId,
                latitude   = _lastLat,
                longitude  = _lastLon,
                deviceName = $"{UIDevice.CurrentDevice.Model} (iOS {UIDevice.CurrentDevice.SystemVersion})",
                browser    = $"SP OneHR iOS App v{AppConstants.AppVersion}",
                ipAddress  = ""
            };

            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
            var json    = System.Text.Json.JsonSerializer.Serialize(payload);
            var body    = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var url     = $"{AppConstants.ServerUrl}/api/wfh/locationPing";

            var response = await client.PostAsync(url, body);
            _pingCount++;

            Console.WriteLine($"[WFHService-iOS] Ping #{_pingCount}: {(response.IsSuccessStatusCode ? "OK" : $"Error {response.StatusCode}")}");

            // Update notification with ping count
            MainThread.BeginInvokeOnMainThread(ShowTrackingNotification);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[WFHService-iOS] Ping error: {ex.Message}");
        }
    }

    // ── Persistent Notification ────────────────────────────────────────────

    private void ShowTrackingNotification()
    {
        var content = new UNMutableNotificationContent
        {
            Title    = "SP OneHR — WFH Tracking Active",
            Body     = $"Your location is being monitored for attendance. Ping #{_pingCount}",
            Sound    = null,   // silent — no sound for persistent service notification
        };

        // Deliver immediately (no trigger = instant)
        var request = UNNotificationRequest.FromIdentifier(
            "wfh_tracking",
            content,
            null   // null trigger = deliver immediately
        );

        UNUserNotificationCenter.Current.RemovePendingNotificationRequests(new[] { "wfh_tracking" });
        UNUserNotificationCenter.Current.AddNotificationRequest(request, err =>
        {
            if (err != null)
                Console.WriteLine($"[WFHService-iOS] Notification error: {err.LocalizedDescription}");
        });
    }
}
