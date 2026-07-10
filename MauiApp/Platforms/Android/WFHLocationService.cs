using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ALoc = Android.Locations;   // alias avoids ambiguity with MAUI Location type

namespace SPOneHRApp;

[Service(ForegroundServiceType = ForegroundService.TypeLocation)]
public class WFHLocationService : Service, ALoc.ILocationListener
{
    public const string ActionStart    = "com.splotuss.START_WFH_TRACKING";
    public const string ActionStop     = "com.splotuss.STOP_WFH_TRACKING";
    public const string ExtraEmpId     = "emp_id";
    public const string ExtraServerUrl = "server_url";

    private ALoc.LocationManager?    _locationManager;
    private CancellationTokenSource? _cts;

    private readonly HttpClient _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    private int    _empId       = 0;
    private string _serverUrl   = "";
    private double _lastLat     = 0;
    private double _lastLon     = 0;
    private int    _pingCount   = 0;
    private bool   _hasLocation = false;

    // ── Service Lifecycle ─────────────────────────────────────────────────

    public override void OnCreate()
    {
        base.OnCreate();
        _locationManager = GetSystemService(LocationService) as ALoc.LocationManager;
    }

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        switch (intent?.Action)
        {
            case ActionStart:
                _empId     = intent.GetIntExtra(ExtraEmpId, 0);
                _serverUrl = intent.GetStringExtra(ExtraServerUrl) ?? AppConstants.ServerUrl;

                if (_empId <= 0) { StopSelf(); return StartCommandResult.NotSticky; }

                StartForeground(AppConstants.NotifId,
                    BuildNotification("WFH Tracking Active", "Initialising GPS..."));
                StartLocationUpdates();
                StartPingLoop();

                Android.Util.Log.Info("WFHService", $"Tracking started — EmpId={_empId}");
                break;

            case ActionStop:
                StopTracking();
                break;
        }

        return StartCommandResult.Sticky;
    }

    public override void OnDestroy()
    {
        StopTracking();
        base.OnDestroy();
    }

    public override IBinder? OnBind(Intent? intent) => null;

    // ── GPS Updates ───────────────────────────────────────────────────────

    private void StartLocationUpdates()
    {
        try
        {
            if (_locationManager?.IsProviderEnabled(ALoc.LocationManager.GpsProvider) == true)
            {
                _locationManager.RequestLocationUpdates(
                    ALoc.LocationManager.GpsProvider,
                    15_000L, 10f, this, Android.OS.Looper.MainLooper);
            }

            if (_locationManager?.IsProviderEnabled(ALoc.LocationManager.NetworkProvider) == true)
            {
                _locationManager.RequestLocationUpdates(
                    ALoc.LocationManager.NetworkProvider,
                    15_000L, 10f, this, Android.OS.Looper.MainLooper);
            }

            Android.Util.Log.Info("WFHService", "Location updates registered");
        }
        catch (Exception ex)
        {
            Android.Util.Log.Error("WFHService", $"Location update error: {ex.Message}");
        }
    }

    // ── ILocationListener ─────────────────────────────────────────────────

    public void OnLocationChanged(ALoc.Location location)
    {
        _lastLat     = location.Latitude;
        _lastLon     = location.Longitude;
        _hasLocation = true;
        Android.Util.Log.Debug("WFHService",
            $"GPS: {_lastLat:F6}, {_lastLon:F6} acc={location.Accuracy:F0}m");
    }

    public void OnProviderEnabled(string provider)  =>
        Android.Util.Log.Info("WFHService", $"Provider enabled: {provider}");

    public void OnProviderDisabled(string provider) =>
        Android.Util.Log.Warn("WFHService", $"Provider disabled: {provider}");

    // Required by ILocationListener — no-op for modern Android
    public void OnStatusChanged(string? provider, ALoc.Availability status, Android.OS.Bundle? extras) { }

    // ── Ping Loop ─────────────────────────────────────────────────────────

    private void StartPingLoop()
    {
        _cts = new CancellationTokenSource();
        _ = PingLoop(_cts.Token);
    }

    private async Task PingLoop(CancellationToken ct)
    {
        await Task.Delay(3_000, ct);  // warm-up for first GPS fix

        while (!ct.IsCancellationRequested)
        {
            if (_hasLocation)
                await SendPing(_lastLat, _lastLon, ct);

            UpdateNotification();
            await Task.Delay(AppConstants.PingIntervalMs, ct);
        }
    }

    private async Task SendPing(double lat, double lon, CancellationToken ct)
    {
        try
        {
            var payload = new
            {
                employeeId = _empId,
                latitude   = lat,
                longitude  = lon,
                deviceName = $"{Android.OS.Build.Manufacturer} {Android.OS.Build.Model}",
                browser    = $"SP OneHR MAUI v{AppConstants.AppVersion}",
                ipAddress  = ""
            };

            var json = JsonSerializer.Serialize(payload);
            using var content  = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(
                $"{_serverUrl}/api/wfh/locationPing", content, ct);

            _pingCount++;
            Android.Util.Log.Debug("WFHService",
                $"Ping #{_pingCount} HTTP {(int)response.StatusCode} | {lat:F5},{lon:F5}");
        }
        catch (Exception ex) when (!ct.IsCancellationRequested)
        {
            Android.Util.Log.Warn("WFHService", $"Ping error: {ex.Message}");
        }
    }

    // ── Notification ──────────────────────────────────────────────────────

    private Notification BuildNotification(string title, string text)
    {
        CreateNotificationChannel();

        var tapIntent = new Intent(this, typeof(MainActivity));
        var pendingTap = PendingIntent.GetActivity(this, 0, tapIntent,
            PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable)!;

        var stopIntent = new Intent(this, typeof(WFHLocationService));
        stopIntent.SetAction(ActionStop);
        var pendingStop = PendingIntent.GetService(this, 1, stopIntent,
            PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable)!;

        return new NotificationCompat.Builder(this, AppConstants.NotifChannelId)
            .SetContentTitle(title)
            .SetContentText(text)
            .SetSmallIcon(Resource.Drawable.ic_notification)
            .SetContentIntent(pendingTap)
            .AddAction(Resource.Drawable.ic_notification, "Stop", pendingStop)
            .SetOngoing(true)
            .SetPriority(NotificationCompat.PriorityLow)
            .SetVisibility(NotificationCompat.VisibilityPublic)
            .Build();
    }

    private void UpdateNotification()
    {
        var mgr = GetSystemService(NotificationService) as Android.App.NotificationManager;
        mgr?.Notify(AppConstants.NotifId, BuildNotification(
            "SP OneHR — WFH Tracking",
            _hasLocation
                ? $"Ping #{_pingCount} | {_lastLat:F4}, {_lastLon:F4}"
                : "Acquiring GPS..."));
    }

    private void CreateNotificationChannel()
    {
        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
        {
            var channel = new Android.App.NotificationChannel(
                AppConstants.NotifChannelId,
                AppConstants.NotifChannelName,
                Android.App.NotificationImportance.Low)
            {
                Description = "Shows while WFH GPS tracking is active"
            };
            channel.SetShowBadge(false);
            var mgr = GetSystemService(NotificationService) as Android.App.NotificationManager;
            mgr?.CreateNotificationChannel(channel);
        }
    }

    // ── Stop ──────────────────────────────────────────────────────────────

    private void StopTracking()
    {
        _cts?.Cancel();
        _locationManager?.RemoveUpdates(this);
        StopForeground(StopForegroundFlags.Remove);
        StopSelf();
        Android.Util.Log.Info("WFHService", "Tracking stopped");
    }
}
