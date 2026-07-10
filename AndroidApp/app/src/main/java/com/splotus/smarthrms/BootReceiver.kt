package com.splotus.smarthrms

import android.content.BroadcastReceiver
import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.os.Build
import android.util.Log

/**
 * Restarts the WFH Location Service automatically after device reboot.
 *
 * Only restarts if there was an active tracking session before the reboot.
 * Tracking state is persisted in SharedPreferences by the main app.
 */
class BootReceiver : BroadcastReceiver() {

    companion object {
        const val TAG = "BootReceiver"
        const val PREFS_NAME = "wfh_tracking_prefs"
        const val KEY_IS_TRACKING = "is_tracking"
        const val KEY_EMP_ID = "emp_id"
        const val KEY_SERVER_URL = "server_url"
    }

    override fun onReceive(context: Context, intent: Intent) {
        val action = intent.action
        if (action != Intent.ACTION_BOOT_COMPLETED &&
            action != "android.intent.action.QUICKBOOT_POWERON") return

        Log.i(TAG, "Device booted — checking if WFH tracking should resume")

        val prefs: SharedPreferences = context.getSharedPreferences(PREFS_NAME, Context.MODE_PRIVATE)
        val isTracking = prefs.getBoolean(KEY_IS_TRACKING, false)
        val empId = prefs.getInt(KEY_EMP_ID, 0)
        val serverUrl = prefs.getString(KEY_SERVER_URL, BuildConfig.SERVER_URL) ?: BuildConfig.SERVER_URL

        if (isTracking && empId > 0) {
            Log.i(TAG, "Resuming WFH tracking for EmpId=$empId after reboot")
            val serviceIntent = Intent(context, WFHLocationService::class.java).apply {
                action = WFHLocationService.ACTION_START
                putExtra(WFHLocationService.EXTRA_EMP_ID, empId)
                putExtra(WFHLocationService.EXTRA_SERVER_URL, serverUrl)
            }
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                context.startForegroundService(serviceIntent)
            } else {
                context.startService(serviceIntent)
            }
        } else {
            Log.i(TAG, "No active WFH tracking session — not restarting service")
        }
    }
}
