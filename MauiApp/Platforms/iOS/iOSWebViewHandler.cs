using CoreLocation;
using Foundation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using WebKit;

namespace SPOneHRApp;

/// <summary>
/// Custom iOS WebView handler that:
///  - Auto-grants geolocation permission to the web page
///  - Enables camera access for selfie punch-in
///  - Sets custom User-Agent so wfhTracking.js knows it's in the native app
///  - Enables inline media playback (needed for camera preview)
/// </summary>
public class iOSWebViewHandler : WebViewHandler
{
    // CLLocationManager must be kept alive at class level — if released, GPS stops
    private static CLLocationManager? _locationManager;

    protected override WKWebView CreatePlatformView()
    {
        var config = new WKWebViewConfiguration
        {
            AllowsInlineMediaPlayback      = true,
            MediaTypesRequiringUserActionForPlayback = WKAudiovisualMediaTypes.None,
        };

        // Inject JS bridge objects for iOS (mirrors Android's window.AndroidBridge)
        var userScript = new WKUserScript(
            new NSString(IOSBridgeScript.Script),
            WKUserScriptInjectionTime.AtDocumentStart,
            false
        );
        config.UserContentController.AddUserScript(userScript);

        var webView = new WKWebView(CoreGraphics.CGRect.Empty, config);

        // Custom User-Agent — wfhTracking.js uses this to detect the native app
        webView.CustomUserAgent =
            $"Mozilla/5.0 (iPhone; CPU iPhone OS 17_0 like Mac OS X) " +
            $"AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 " +
            $"SPOneHR-iOS/{AppConstants.AppVersion}";

        // Start location manager so the device has GPS ready
        _locationManager = new CLLocationManager();
        _locationManager.RequestAlwaysAuthorization();
        _locationManager.StartUpdatingLocation();

        return webView;
    }
}

/// <summary>
/// JavaScript injected at page load on iOS.
/// Provides window.AndroidBridge shim so the existing wfhTracking.js works
/// without any changes — it calls window.AndroidBridge.startNativeTracking(empId)
/// and we forward it to the iOS native tracking service.
/// </summary>
internal static class IOSBridgeScript
{
    public const string Script = """
        window.AndroidBridge = {
            isNativeApp:          function() { return true; },
            getAppVersion:        function() { return '1.0.0'; },
            getDeviceInfo:        function() { return 'iOS Device'; },
            startNativeTracking:  function(empId) {
                window.location.href = 'onehr://startTracking?empId=' + empId;
            },
            stopNativeTracking:   function() {
                window.location.href = 'onehr://stopTracking';
            }
        };
        """;
}
