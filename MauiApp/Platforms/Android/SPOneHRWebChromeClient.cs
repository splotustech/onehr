using Android.Webkit;

namespace SPOneHRApp;

/// <summary>
/// Custom WebChromeClient â€” auto-grants GPS and camera permissions
/// to the Blazor PWA page so it can use selfie capture and location.
/// </summary>
public class SPOneHRWebChromeClient : WebChromeClient
{
    // Auto-grant GPS permission to the web page
    // (native GPS is handled by WFHLocationService, but web page still uses
    //  navigator.geolocation for the initial punch-in location)
    public override void OnGeolocationPermissionsShowPrompt(
        string? origin,
        GeolocationPermissions.ICallback? callback)
    {
        callback?.Invoke(origin, true, false);
    }

    // Auto-grant camera/microphone permission (for selfie punch-in)
    public override void OnPermissionRequest(PermissionRequest? request)
    {
        request?.Grant(request.GetResources());
    }
}
