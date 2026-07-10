namespace SPOneHRApp;

/// <summary>
/// Central config — update ServerUrl before building the APK.
/// </summary>
public static class AppConstants
{
    // ── CHANGE THIS to your production server URL before building ──────────
    public const string ServerUrl = "https://onehr.splotustech.com";

    // App info shown in notifications and About screen
    public const string AppName       = "ONE HR";
    public const string AppVersion    = "1.1";   // Must match AndroidApp:Version in appsettings.json
    public const string PackageName   = "com.splotuss.smarthrms";

    // Notification channel
    public const string NotifChannelId   = "wfh_tracking_channel";
    public const string NotifChannelName = "WFH GPS Tracking";
    public const int    NotifId          = 1001;

    // GPS tracking interval (milliseconds)
    public const int PingIntervalMs = 20_000;   // 20 seconds
}
