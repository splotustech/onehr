package com.splotus.smarthrms

import android.content.Context
import android.content.Intent
import android.os.Build
import android.util.Log
import android.webkit.JavascriptInterface

/**
 * JavaScript ↔ Android Bridge
 *
 * Injected into the WebView as window.AndroidBridge
 * The existing wfhTracking.js calls these methods when running inside the Android app.
 *
 * Web calls:  window.AndroidBridge.startNativeTracking(empId)
 *             window.AndroidBridge.stopNativeTracking()
 *             window.AndroidBridge.isNativeApp()
 *             window.AndroidBridge.getAppVersion()
 */
class WFHJavascriptBridge(
    private val context: Context,
    private val serverUrl: String
) {
    companion object {
        const val BRIDGE_NAME = "AndroidBridge"
        const val TAG = "WFHBridge"
    }

    /**
     * Called by wfhTracking.js after WFH punch-in.
     * Starts the background location service.
     */
    @JavascriptInterface
    fun startNativeTracking(empId: Int) {
        Log.i(TAG, "startNativeTracking called for EmpId=$empId")

        val intent = Intent(context, WFHLocationService::class.java).apply {
            action = WFHLocationService.ACTION_START
            putExtra(WFHLocationService.EXTRA_EMP_ID, empId)
            putExtra(WFHLocationService.EXTRA_SERVER_URL, serverUrl)
        }

        // startForegroundService() required for API 26+; use startService() on older devices
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            context.startForegroundService(intent)
        } else {
            context.startService(intent)
        }
    }

    /**
     * Called by wfhTracking.js after WFH punch-out.
     * Stops the background location service.
     */
    @JavascriptInterface
    fun stopNativeTracking() {
        Log.i(TAG, "stopNativeTracking called")

        val intent = Intent(context, WFHLocationService::class.java).apply {
            action = WFHLocationService.ACTION_STOP
        }
        context.startService(intent)
    }

    /**
     * JavaScript uses this to detect it is running inside the Android app.
     * Returns true — if this method exists on window.AndroidBridge, it's a native app.
     */
    @JavascriptInterface
    fun isNativeApp(): Boolean = true

    /**
     * Returns device info string for GPS ping metadata.
     */
    @JavascriptInterface
    fun getDeviceInfo(): String = "${Build.MANUFACTURER} ${Build.MODEL} (Android ${Build.VERSION.RELEASE})"

    /**
     * Returns app version for GPS ping metadata.
     */
    @JavascriptInterface
    fun getAppVersion(): String = BuildConfig.VERSION_NAME
}
