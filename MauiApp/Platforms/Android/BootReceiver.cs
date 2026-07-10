using Android.App;
using Android.Content;

namespace SPOneHRApp;

/// <summary>
/// Restarts the WFH tracking service if the phone reboots during an active WFH session.
/// </summary>
[BroadcastReceiver(Enabled = true, Exported = true)]
[IntentFilter(new[] { Intent.ActionBootCompleted, "android.intent.action.QUICKBOOT_POWERON" })]
public class BootReceiver : BroadcastReceiver
{
    public override void OnReceive(Context? context, Intent? intent)
    {
        if (context == null) return;

        // Check SharedPreferences for an active tracking session
        var prefs = context.GetSharedPreferences("wfh_prefs", FileCreationMode.Private);
        bool isTracking = prefs?.GetBoolean("is_tracking", false) ?? false;
        int  empId      = prefs?.GetInt("emp_id", 0) ?? 0;
        string serverUrl = prefs?.GetString("server_url", AppConstants.ServerUrl) ?? AppConstants.ServerUrl;

        if (isTracking && empId > 0)
        {
            Android.Util.Log.Info("BootReceiver", $"Resuming WFH tracking for EmpId={empId} after reboot");

            var serviceIntent = new Intent(context, typeof(WFHLocationService));
            serviceIntent.SetAction(WFHLocationService.ActionStart);
            serviceIntent.PutExtra(WFHLocationService.ExtraEmpId, empId);
            serviceIntent.PutExtra(WFHLocationService.ExtraServerUrl, serverUrl);
            context.StartForegroundService(serviceIntent);
        }
    }
}
