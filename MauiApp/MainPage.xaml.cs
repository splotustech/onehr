using Microsoft.Maui.Networking;
using System.Text.Json;

namespace SPOneHRApp;

public partial class MainPage : ContentPage
{
    private bool _updateCheckDone = false;

    public MainPage()
    {
        InitializeComponent();

        // Load the production Blazor PWA
        webView.Source = new UrlWebViewSource { Url = AppConstants.ServerUrl };

        // Wire up WebView Android bridge after handler is ready
        webView.HandlerChanged += OnWebViewHandlerChanged;

        // Monitor connectivity for offline banner
        Connectivity.ConnectivityChanged += OnConnectivityChanged;

#if IOS
        webView.Navigating += OnWebViewNavigating;
#endif
    }

    // ── Lifecycle ──────────────────────────────────────────────────────────

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Check for APK update once per app session (5 second delay so login loads first)
        if (!_updateCheckDone)
        {
            _updateCheckDone = true;
            Task.Delay(5000).ContinueWith(_ => CheckForUpdateAsync());
        }
    }

    // ── Auto-Update Check ──────────────────────────────────────────────────
    // Calls /api/version/android on every startup.
    // If server version > installed version → shows update dialog.
    // For website/Blazor changes: NO update needed — WebView loads new code automatically.
    // For APK changes (GPS service, permissions, etc.): this dialog prompts reinstall.

    private async Task CheckForUpdateAsync()
    {
        try
        {
            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(8) };
            var json   = await client.GetStringAsync($"{AppConstants.ServerUrl}/api/version/android");
            var info   = JsonSerializer.Deserialize<AppUpdateInfo>(json,
                             new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (info == null) return;

            bool isNewer = IsNewerVersion(info.Version, AppConstants.AppVersion);
            if (!isNewer) return;

            await MainThread.InvokeOnMainThreadAsync(() =>
                ShowUpdateDialogAsync(info));
        }
        catch (Exception ex)
        {
            // Silent fail — update check should never crash the app
            Console.WriteLine($"[UpdateCheck] Failed: {ex.Message}");
        }
    }

    private async Task ShowUpdateDialogAsync(AppUpdateInfo info)
    {
        string message =
            $"A new version of SP OneHR is available.\n\n" +
            $"Installed : v{AppConstants.AppVersion}\n" +
            $"New       : v{info.Version}\n";

        if (!string.IsNullOrWhiteSpace(info.ReleaseNotes))
            message += $"\nWhat's new:\n{info.ReleaseNotes}";

        if (info.ForceUpdate)
        {
            // Force update — only "Update Now" button, app cannot be used until updated
            await DisplayAlert("Update Required", message + "\n\nPlease update to continue.", "Update Now");
            OpenDownloadUrl(info.DownloadUrl);
        }
        else
        {
            // Optional update — user can choose to skip
            bool accepted = await DisplayAlert("Update Available", message, "Update Now", "Later");
            if (accepted)
                OpenDownloadUrl(info.DownloadUrl);
        }
    }

    private void OpenDownloadUrl(string url)
    {
        // Opens the APK download URL in the device browser.
        // Android downloads the APK → automatically offers to install it.
        // User must have "Install from unknown sources" enabled for this app.
        try
        {
            Launcher.OpenAsync(new Uri(url));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[UpdateCheck] Could not open URL: {ex.Message}");
        }
    }

    // Compares semantic versions like "1.0", "1.1", "2.0"
    // Returns true if serverVersion is strictly greater than installedVersion
    private static bool IsNewerVersion(string serverVersion, string installedVersion)
    {
        try
        {
            // Pad to 2 parts so System.Version can parse "1.1" correctly
            static Version Parse(string v)
            {
                var parts = v.Split('.');
                return parts.Length == 1
                    ? new Version(int.Parse(parts[0]), 0)
                    : new Version(v);
            }
            return Parse(serverVersion) > Parse(installedVersion);
        }
        catch
        {
            return false;
        }
    }

    // ── Android WebView Bridge ─────────────────────────────────────────────

    private void OnWebViewHandlerChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (webView.Handler?.PlatformView is Android.Webkit.WebView nativeWebView)
        {
            nativeWebView.Settings.JavaScriptEnabled  = true;
            nativeWebView.Settings.DomStorageEnabled  = true;
            nativeWebView.Settings.AllowFileAccess    = true;
            nativeWebView.Settings.MediaPlaybackRequiresUserGesture = false;

            nativeWebView.Settings.UserAgentString =
                nativeWebView.Settings.UserAgentString
                + $" SPOneHR-MAUI/{AppConstants.AppVersion}";

            nativeWebView.SetWebChromeClient(new SPOneHRWebChromeClient());

            nativeWebView.AddJavascriptInterface(
                new WFHJavascriptBridge(Platform.CurrentActivity!, AppConstants.ServerUrl),
                "AndroidBridge");
        }
#endif
    }

    // ── Network Monitor ────────────────────────────────────────────────────

    private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            bool isOnline = e.NetworkAccess == NetworkAccess.Internet;
            offlineBanner.IsVisible = !isOnline;

            if (isOnline && (webView.Source as UrlWebViewSource)?.Url == null)
                webView.Source = new UrlWebViewSource { Url = AppConstants.ServerUrl };
        });
    }

    // ── Back Button ────────────────────────────────────────────────────────

    protected override bool OnBackButtonPressed()
    {
        if (webView.CanGoBack)
        {
            webView.GoBack();
            return true;
        }
        return false;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Connectivity.ConnectivityChanged -= OnConnectivityChanged;
    }

    // ── iOS Bridge URL Handler ─────────────────────────────────────────────
#if IOS
    private void OnWebViewNavigating(object? sender, WebNavigatingEventArgs e)
    {
        if (!e.Url.StartsWith("onehr://")) return;
        e.Cancel = true;

        var uri   = new Uri(e.Url);
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

        switch (uri.Host)
        {
            case "startTracking":
                if (int.TryParse(query["empId"], out int empId))
                    WFHLocationService.Instance.StartTracking(empId);
                break;
            case "stopTracking":
                WFHLocationService.Instance.StopTracking();
                break;
        }
    }
#endif
}

// ── Model for /api/version/android response ────────────────────────────────

public class AppUpdateInfo
{
    public string Version      { get; set; } = "";
    public string DownloadUrl  { get; set; } = "";
    public string ReleaseNotes { get; set; } = "";
    public bool   ForceUpdate  { get; set; }
}
