package com.splotus.smarthrms

import android.app.*
import android.content.Intent
import android.content.pm.ServiceInfo
import android.os.*
import android.util.Log
import androidx.core.app.NotificationCompat
import com.google.android.gms.location.*
import kotlinx.coroutines.*
import okhttp3.*
import okhttp3.MediaType.Companion.toMediaType
import okhttp3.RequestBody.Companion.toRequestBody
import org.json.JSONObject
import java.util.concurrent.TimeUnit

/**
 * Foreground Service that runs background GPS tracking even when:
 * - App is in background
 * - Screen is locked / off
 * - Phone is on charge and idle
 *
 * Sends GPS pings to /api/wfh/locationPing every 20 seconds.
 * Shows a persistent notification (Android OS requirement for background services).
 */
class WFHLocationService : Service() {

    companion object {
        const val TAG = "WFHLocationService"

        // Intent actions
        const val ACTION_START = "com.splotus.smarthrms.START_TRACKING"
        const val ACTION_STOP  = "com.splotus.smarthrms.STOP_TRACKING"

        // Intent extras
        const val EXTRA_EMP_ID     = "emp_id"
        const val EXTRA_SERVER_URL = "server_url"

        const val NOTIFICATION_ID = 1001
    }

    private lateinit var fusedLocationClient: FusedLocationProviderClient
    private lateinit var locationCallback: LocationCallback
    private var locationCallbackRegistered = false

    private val serviceScope = CoroutineScope(Dispatchers.IO + SupervisorJob())

    private val httpClient = OkHttpClient.Builder()
        .connectTimeout(10, TimeUnit.SECONDS)
        .readTimeout(10, TimeUnit.SECONDS)
        .writeTimeout(10, TimeUnit.SECONDS)
        .retryOnConnectionFailure(true)
        .build()

    // State
    private var empId: Int = 0
    private var serverUrl: String = ""
    private var lastLat: Double = 0.0
    private var lastLon: Double = 0.0
    private var pingCount: Int = 0
    private var lastPingSuccessful: Boolean = false

    // Wake lock to prevent CPU sleep between pings
    private var wakeLock: PowerManager.WakeLock? = null

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    override fun onCreate() {
        super.onCreate()
        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this)
        Log.i(TAG, "WFH Location Service created")
    }

    override fun onStartCommand(intent: Intent?, flags: Int, startId: Int): Int {
        Log.i(TAG, "onStartCommand: action=${intent?.action}")

        when (intent?.action) {
            ACTION_START -> {
                empId     = intent.getIntExtra(EXTRA_EMP_ID, 0)
                serverUrl = intent.getStringExtra(EXTRA_SERVER_URL) ?: BuildConfig.SERVER_URL

                if (empId <= 0) {
                    Log.e(TAG, "Invalid empId. Stopping service.")
                    stopSelf()
                    return START_NOT_STICKY
                }

                acquireWakeLock()
                startForeground()
                startLocationUpdates()
                Log.i(TAG, "WFH tracking started for EmpId=$empId, Server=$serverUrl")
            }

            ACTION_STOP -> {
                Log.i(TAG, "Stopping WFH tracking for EmpId=$empId")
                stopTracking()
            }
        }

        // START_STICKY: If OS kills the service (memory pressure), restart it automatically
        return START_STICKY
    }

    override fun onDestroy() {
        super.onDestroy()
        stopTracking()
        Log.i(TAG, "WFH Location Service destroyed")
    }

    override fun onBind(intent: Intent?): IBinder? = null

    // ── Foreground Notification ────────────────────────────────────────────────

    private fun startForeground() {
        val notification = buildNotification(
            "WFH GPS tracking is active",
            "Your attendance location is being monitored every 20 seconds"
        )

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
            startForeground(NOTIFICATION_ID, notification, ServiceInfo.FOREGROUND_SERVICE_TYPE_LOCATION)
        } else {
            startForeground(NOTIFICATION_ID, notification)
        }
    }

    private fun buildNotification(title: String, text: String): Notification {
        val tapIntent = Intent(this, MainActivity::class.java).apply {
            flags = Intent.FLAG_ACTIVITY_SINGLE_TOP
        }
        val pendingTap = PendingIntent.getActivity(
            this, 0, tapIntent,
            PendingIntent.FLAG_UPDATE_CURRENT or PendingIntent.FLAG_IMMUTABLE
        )

        return NotificationCompat.Builder(this, SmartHRMSApp.WFH_CHANNEL_ID)
            .setContentTitle(title)
            .setContentText(text)
            .setSmallIcon(R.drawable.ic_tracking)
            .setContentIntent(pendingTap)
            .setOngoing(true)           // Cannot be dismissed by swipe
            .setPriority(NotificationCompat.PRIORITY_LOW)
            .setCategory(NotificationCompat.CATEGORY_SERVICE)
            .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
            // No "Stop Tracking" action — tracking can only be stopped from inside the app
            .setSubText("Ping #$pingCount | ${if (lastPingSuccessful) "OK" else "Connecting..."}")
            .build()
    }

    private fun updateNotification() {
        val manager = getSystemService(NotificationManager::class.java)
        manager.notify(NOTIFICATION_ID, buildNotification(
            "SP OneHR — WFH Tracking Active",
            "Ping #$pingCount | Last: ${java.text.SimpleDateFormat("hh:mm:ss a", java.util.Locale.getDefault()).format(java.util.Date())}"
        ))
    }

    // ── GPS Location Updates ───────────────────────────────────────────────────

    private fun startLocationUpdates() {
        val request = LocationRequest.Builder(
            Priority.PRIORITY_HIGH_ACCURACY,
            20_000L    // Request location every 20 seconds
        ).apply {
            setMinUpdateIntervalMillis(15_000L)    // Fastest: 15 seconds
            setMaxUpdateDelayMillis(30_000L)       // Allow batching up to 30 sec
            setGranularity(Granularity.GRANULARITY_FINE)
            setWaitForAccurateLocation(false)       // Don't wait — use best available
        }.build()

        locationCallback = object : LocationCallback() {
            override fun onLocationResult(result: LocationResult) {
                val location = result.lastLocation ?: return
                lastLat = location.latitude
                lastLon = location.longitude

                Log.d(TAG, "Location update: lat=$lastLat, lon=$lastLon, accuracy=${location.accuracy}m")

                serviceScope.launch {
                    sendPingToServer(
                        lat      = location.latitude,
                        lon      = location.longitude,
                        accuracy = location.accuracy
                    )
                }
            }

            override fun onLocationAvailability(availability: LocationAvailability) {
                if (!availability.isLocationAvailable) {
                    Log.w(TAG, "Location not available — GPS may be disabled")
                }
            }
        }

        try {
            fusedLocationClient.requestLocationUpdates(
                request,
                locationCallback,
                Looper.getMainLooper()
            )
            locationCallbackRegistered = true
            Log.i(TAG, "Location updates registered (every 20 seconds)")
        } catch (e: SecurityException) {
            Log.e(TAG, "Location permission denied: ${e.message}")
            stopSelf()
        }
    }

    private fun stopLocationUpdates() {
        if (locationCallbackRegistered && ::locationCallback.isInitialized) {
            fusedLocationClient.removeLocationUpdates(locationCallback)
            locationCallbackRegistered = false
            Log.i(TAG, "Location updates removed")
        }
    }

    // ── HTTP Ping to Server ────────────────────────────────────────────────────

    private suspend fun sendPingToServer(lat: Double, lon: Double, accuracy: Float) {
        try {
            val deviceModel = "${Build.MANUFACTURER} ${Build.MODEL}"

            val json = JSONObject().apply {
                put("employeeId", empId)
                put("latitude",   lat)
                put("longitude",  lon)
                put("deviceName", deviceModel)
                put("browser",    "SP OneHR Android App v${BuildConfig.VERSION_NAME}")
                put("ipAddress",  "")
            }

            val body = json.toString().toRequestBody("application/json; charset=utf-8".toMediaType())

            val request = Request.Builder()
                .url("$serverUrl/api/wfh/locationPing")
                .post(body)
                .addHeader("User-Agent", "SPOneHR-Android/${BuildConfig.VERSION_NAME}")
                .build()

            httpClient.newCall(request).execute().use { response ->
                pingCount++
                lastPingSuccessful = response.isSuccessful

                if (response.isSuccessful) {
                    val responseBody = response.body?.string() ?: ""
                    Log.d(TAG, "Ping #$pingCount OK | ${response.code} | lat=$lat, lon=$lon | acc=${accuracy}m | $responseBody")
                } else {
                    Log.w(TAG, "Ping #$pingCount failed: HTTP ${response.code}")
                }

                // Update notification with ping count
                withContext(Dispatchers.Main) { updateNotification() }
            }
        } catch (e: Exception) {
            lastPingSuccessful = false
            Log.e(TAG, "Ping error: ${e.javaClass.simpleName} — ${e.message}")
            // Don't crash — just log and continue. Next ping will retry automatically.
        }
    }

    // ── Wake Lock ──────────────────────────────────────────────────────────────

    private fun acquireWakeLock() {
        val pm = getSystemService(POWER_SERVICE) as PowerManager
        wakeLock = pm.newWakeLock(
            PowerManager.PARTIAL_WAKE_LOCK,
            "SPOneHR:WFHTracking"
        ).apply {
            // Acquire indefinitely — released when stopTracking() is called
            acquire(12 * 60 * 60 * 1000L) // Max 12 hours (full workday)
        }
        Log.i(TAG, "Wake lock acquired")
    }

    private fun releaseWakeLock() {
        wakeLock?.let {
            if (it.isHeld) {
                it.release()
                Log.i(TAG, "Wake lock released")
            }
        }
        wakeLock = null
    }

    // ── Stop Everything ────────────────────────────────────────────────────────

    private fun stopTracking() {
        stopLocationUpdates()
        releaseWakeLock()
        serviceScope.cancel()
        stopForeground(STOP_FOREGROUND_REMOVE)
        stopSelf()
    }
}
