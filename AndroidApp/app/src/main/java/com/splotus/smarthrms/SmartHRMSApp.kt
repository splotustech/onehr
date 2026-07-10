package com.splotus.smarthrms

import android.app.Application
import android.app.NotificationChannel
import android.app.NotificationManager
import android.os.Build

class SmartHRMSApp : Application() {

    companion object {
        const val WFH_CHANNEL_ID   = "wfh_tracking_channel"
        const val ALERT_CHANNEL_ID = "wfh_alert_channel"
    }

    override fun onCreate() {
        super.onCreate()
        createNotificationChannels()
    }

    private fun createNotificationChannels() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            val manager = getSystemService(NotificationManager::class.java)

            // Persistent low-priority channel for tracking notification
            val trackingChannel = NotificationChannel(
                WFH_CHANNEL_ID,
                getString(R.string.notification_channel_name),
                NotificationManager.IMPORTANCE_LOW
            ).apply {
                description = getString(R.string.notification_channel_desc)
                setShowBadge(false)
                enableVibration(false)
                enableLights(false)
            }

            // High-priority channel for auto-out alerts
            val alertChannel = NotificationChannel(
                ALERT_CHANNEL_ID,
                "WFH Location Alerts",
                NotificationManager.IMPORTANCE_HIGH
            ).apply {
                description = "Alerts when employee leaves assigned WFH location"
            }

            manager.createNotificationChannel(trackingChannel)
            manager.createNotificationChannel(alertChannel)
        }
    }
}
