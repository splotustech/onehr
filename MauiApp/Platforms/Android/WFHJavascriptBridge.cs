using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Webkit;
using Java.Interop;

namespace SPOneHRApp;

/// <summary>
/// Injected into the WebView as window.AndroidBridge.
/// The existing wfhTracking.js calls:
///   window.AndroidBridge.startNativeTracking(empId)
///   window.AndroidBridge.stopNativeTracking()
///   window.AndroidBridge.isNativeApp()
///   window.AndroidBridge.getDeviceInfo()
/// These bridge calls start/stop the WFHLocationService background GPS service.
/// </summary>
public class WFHJavascriptBridge : Java.Lang.Object
{
    private readonly Context _context;
    private readonly string  _serverUrl;

    public WFHJavascriptBridge(Context context, string serverUrl)
    {
        _context   = context;
        _serverUrl = serverUrl;
    }

    [JavascriptInterface]
    [Export("startNativeTracking")]
    public void StartNativeTracking(int empId)
    {
        Android.Util.Log.Info("WFHBridge", $"startNativeTracking called for EmpId={empId}");

        var intent = new Intent(_context, typeof(WFHLocationService));
        intent.SetAction(WFHLocationService.ActionStart);
        intent.PutExtra(WFHLocationService.ExtraEmpId,     empId);
        intent.PutExtra(WFHLocationService.ExtraServerUrl, _serverUrl);
        _context.StartForegroundService(intent);
    }

    [JavascriptInterface]
    [Export("stopNativeTracking")]
    public void StopNativeTracking()
    {
        Android.Util.Log.Info("WFHBridge", "stopNativeTracking called");
        var intent = new Intent(_context, typeof(WFHLocationService));
        intent.SetAction(WFHLocationService.ActionStop);
        _context.StartService(intent);
    }

    [JavascriptInterface]
    [Export("isNativeApp")]
    public bool IsNativeApp() => true;

    [JavascriptInterface]
    [Export("getDeviceInfo")]
    public string GetDeviceInfo() =>
        $"{Build.Manufacturer} {Build.Model} (Android {Build.VERSION.Release})";

    [JavascriptInterface]
    [Export("getAppVersion")]
    public string GetAppVersion() => AppConstants.AppVersion;

    /// <summary>
    /// Called by window.downloadFile() in the web app when running inside the APK.
    /// Saves the base64-encoded file to the Android Downloads folder and shows a toast.
    /// </summary>
    [JavascriptInterface]
    [Export("downloadFile")]
    public void DownloadFile(string fileName, string contentType, string base64Data)
    {
        try
        {
            var bytes = Convert.FromBase64String(base64Data);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
            {
                // Android 10+ — use MediaStore (no storage permission needed)
                var values = new ContentValues();
                values.Put(MediaStore.IMediaColumns.DisplayName, fileName);
                values.Put(MediaStore.IMediaColumns.MimeType, contentType);
                values.Put(MediaStore.IMediaColumns.RelativePath,
                    Android.OS.Environment.DirectoryDownloads);

                var resolver = _context.ContentResolver!;
                var uri = resolver.Insert(MediaStore.Downloads.ExternalContentUri!, values);
                if (uri != null)
                {
                    using var stream = resolver.OpenOutputStream(uri);
                    stream?.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                // Android 8/9 — write directly to public Downloads folder
                var dir = Android.OS.Environment
                    .GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads)!
                    .AbsolutePath;
                System.IO.File.WriteAllBytes(System.IO.Path.Combine(dir, fileName), bytes);
            }

            ShowToast($"✅ Saved to Downloads: {fileName}");
        }
        catch (Exception ex)
        {
            Android.Util.Log.Error("WFHBridge", $"downloadFile failed: {ex.Message}");
            ShowToast("❌ Download failed. Please try again.");
        }
    }

    private void ShowToast(string message)
    {
        var activity = Platform.CurrentActivity;
        activity?.RunOnUiThread(() =>
            Android.Widget.Toast.MakeText(_context, message,
                Android.Widget.ToastLength.Long)?.Show());
    }
}
