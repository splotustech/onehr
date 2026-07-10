package com.splotus.smarthrms

import android.Manifest
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.net.ConnectivityManager
import android.net.Network
import android.net.NetworkCapabilities
import android.net.NetworkRequest
import android.net.http.SslError
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.view.View
import android.webkit.*
import android.widget.LinearLayout
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.ContextCompat
import com.splotus.smarthrms.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    companion object {
        const val TAG = "MainActivity"
    }

    private lateinit var binding: ActivityMainBinding
    private val serverUrl = BuildConfig.SERVER_URL

    // Permission launcher for fine + coarse location
    private val locationPermLauncher = registerForActivityResult(
        ActivityResultContracts.RequestMultiplePermissions()
    ) { results ->
        val fineGranted = results[Manifest.permission.ACCESS_FINE_LOCATION] == true
        if (fineGranted) {
            // After fine location, request background location separately (Android 10+)
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
                requestBackgroundLocationPermission()
            }
        } else {
            showLocationPermissionDialog()
        }
    }

    // Separate launcher for background location (must be requested after fine location)
    private val backgroundPermLauncher = registerForActivityResult(
        ActivityResultContracts.RequestPermission()
    ) { granted ->
        if (granted) {
            Log.i(TAG, "Background location permission granted")
        } else {
            Log.w(TAG, "Background location permission denied — tracking will not work with screen off")
            showBackgroundPermissionDialog()
        }
    }

    // Notification permission (Android 13+)
    private val notifPermLauncher = registerForActivityResult(
        ActivityResultContracts.RequestPermission()
    ) { granted ->
        Log.i(TAG, "Notification permission: $granted")
    }

    // ── Lifecycle ──────────────────────────────────────────────────────────────

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setupWebView()
        setupNetworkMonitor()
        requestPermissionsInSequence()

        binding.webView.loadUrl(serverUrl)
    }

    override fun onPause() {
        super.onPause()
        // Release camera when app goes to background so other apps can use it.
        // The JS stopVideo() stops all MediaStream tracks, preventing "camera in use" errors.
        binding.webView.evaluateJavascript("if(typeof window.stopVideo==='function')window.stopVideo();", null)
        binding.webView.onPause()
    }

    override fun onResume() {
        super.onResume()
        binding.webView.onResume()
    }

    override fun onBackPressed() {
        if (binding.webView.canGoBack()) {
            binding.webView.goBack()
        } else {
            super.onBackPressed()
        }
    }

    // ── WebView Setup ──────────────────────────────────────────────────────────

    private fun setupWebView() {
        binding.webView.settings.apply {
            javaScriptEnabled          = true
            domStorageEnabled          = true    // localStorage — Blazor auth tokens
            databaseEnabled            = true
            allowFileAccess            = true
            allowContentAccess         = true
            setSupportZoom(false)
            builtInZoomControls        = false
            displayZoomControls        = false
            loadWithOverviewMode       = true
            useWideViewPort            = true
            mediaPlaybackRequiresUserGesture = false  // Camera for selfie
            // Identify as Android app so wfhTracking.js can detect it
            userAgentString = userAgentString +
                    " SPOneHR-Android/${BuildConfig.VERSION_NAME}"
        }

        // Grant GPS permission automatically to the web page (native handles it)
        binding.webView.webChromeClient = object : WebChromeClient() {

            override fun onGeolocationPermissionsShowPrompt(
                origin: String,
                callback: GeolocationPermissions.Callback
            ) {
                callback.invoke(origin, true, false)
            }

            // Allow camera access for selfie capture
            override fun onPermissionRequest(request: PermissionRequest?) {
                request?.grant(request.resources)
            }

            override fun onProgressChanged(view: WebView?, newProgress: Int) {
                if (newProgress == 100) {
                    binding.loadingView.visibility = View.GONE
                }
            }
        }

        binding.webView.webViewClient = object : WebViewClient() {

            override fun onPageStarted(view: WebView?, url: String?, favicon: Bitmap?) {
                binding.loadingView.visibility = View.VISIBLE
            }

            override fun onPageFinished(view: WebView?, url: String?) {
                binding.loadingView.visibility = View.GONE
                Log.d(TAG, "Page loaded: $url")
            }

            override fun onReceivedError(
                view: WebView?,
                request: WebResourceRequest?,
                error: WebResourceError?
            ) {
                if (request?.isForMainFrame == true) {
                    Log.e(TAG, "WebView error: ${error?.description}")
                    // Show cached version or retry page
                    view?.loadUrl("about:blank")
                    view?.loadUrl(serverUrl)
                }
            }

            // Allow self-signed certs in DEBUG builds only
            override fun onReceivedSslError(
                view: WebView?,
                handler: SslErrorHandler?,
                error: SslError?
            ) {
                if (BuildConfig.DEBUG) {
                    handler?.proceed()
                } else {
                    handler?.cancel()
                    Log.e(TAG, "SSL error in production: ${error?.primaryError}")
                }
            }
        }

        // Inject JavaScript bridge so web code can call Android native functions
        binding.webView.addJavascriptInterface(
            WFHJavascriptBridge(this, serverUrl),
            WFHJavascriptBridge.BRIDGE_NAME
        )

        // Enable WebView debugging in debug builds (Chrome DevTools via chrome://inspect)
        WebView.setWebContentsDebuggingEnabled(BuildConfig.DEBUG)
    }

    // ── Network Monitor ────────────────────────────────────────────────────────

    private fun setupNetworkMonitor() {
        val cm = getSystemService(ConnectivityManager::class.java)
        val request = NetworkRequest.Builder()
            .addCapability(NetworkCapabilities.NET_CAPABILITY_INTERNET)
            .build()

        cm.registerNetworkCallback(request, object : ConnectivityManager.NetworkCallback() {
            override fun onAvailable(network: Network) {
                runOnUiThread {
                    binding.offlineBanner.visibility = View.GONE
                    // Reload page if it was showing an error
                    if (binding.webView.url.isNullOrEmpty() || binding.webView.url == "about:blank") {
                        binding.webView.loadUrl(serverUrl)
                    }
                }
            }

            override fun onLost(network: Network) {
                runOnUiThread {
                    binding.offlineBanner.visibility = View.VISIBLE
                }
            }
        })
    }

    // ── Permissions ────────────────────────────────────────────────────────────

    private fun requestPermissionsInSequence() {
        // Step 1: Notification permission (Android 13+)
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            if (ContextCompat.checkSelfPermission(this, Manifest.permission.POST_NOTIFICATIONS)
                != PackageManager.PERMISSION_GRANTED) {
                notifPermLauncher.launch(Manifest.permission.POST_NOTIFICATIONS)
            }
        }

        // Step 2: Fine + Coarse location
        val permsToRequest = mutableListOf<String>()
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION)
            != PackageManager.PERMISSION_GRANTED) {
            permsToRequest.add(Manifest.permission.ACCESS_FINE_LOCATION)
            permsToRequest.add(Manifest.permission.ACCESS_COARSE_LOCATION)
        }

        if (permsToRequest.isNotEmpty()) {
            locationPermLauncher.launch(permsToRequest.toTypedArray())
        } else if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
            // Fine location already granted — check background
            requestBackgroundLocationPermission()
        }
    }

    private fun requestBackgroundLocationPermission() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
            val bgGranted = ContextCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_BACKGROUND_LOCATION
            ) == PackageManager.PERMISSION_GRANTED

            if (!bgGranted) {
                // Show explanation before requesting (Google Play requires this)
                AlertDialog.Builder(this)
                    .setTitle("Background Location Required")
                    .setMessage(
                        "SP OneHR needs to track your location in the background " +
                        "while you are working from home.\n\n" +
                        "On the next screen, please select:\n" +
                        "\"Allow all the time\""
                    )
                    .setPositiveButton("OK") { _, _ ->
                        backgroundPermLauncher.launch(
                            Manifest.permission.ACCESS_BACKGROUND_LOCATION
                        )
                    }
                    .setNegativeButton("Not Now", null)
                    .show()
            }
        }
    }

    private fun showLocationPermissionDialog() {
        AlertDialog.Builder(this)
            .setTitle("Location Permission Required")
            .setMessage(
                "SP OneHR requires location access for WFH attendance tracking.\n\n" +
                "Please go to Settings → App Permissions → Location and grant access."
            )
            .setPositiveButton("OK", null)
            .show()
    }

    private fun showBackgroundPermissionDialog() {
        AlertDialog.Builder(this)
            .setTitle("Background Tracking Limited")
            .setMessage(
                "Background location is not enabled.\n\n" +
                "GPS tracking will pause when the screen is off.\n\n" +
                "To enable: Settings → Apps → SP OneHR → Permissions → Location → Allow all the time"
            )
            .setPositiveButton("OK", null)
            .show()
    }
}
