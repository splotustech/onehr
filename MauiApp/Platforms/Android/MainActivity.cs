using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace SPOneHRApp;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges =
        ConfigChanges.ScreenSize |
        ConfigChanges.Orientation |
        ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize |
        ConfigChanges.Density |
        ConfigChanges.Keyboard |
        ConfigChanges.KeyboardHidden)]
public class MainActivity : MauiAppCompatActivity
{
    private const int PermissionRequestCode = 100;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RequestAllPermissions();
    }

    private void RequestAllPermissions()
    {
        var permissionsToRequest = new List<string>();

        // Notification permission (Android 13+)
        if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
        {
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.PostNotifications)
                != Permission.Granted)
                permissionsToRequest.Add(Android.Manifest.Permission.PostNotifications);
        }

        // Fine location
        if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation)
            != Permission.Granted)
        {
            permissionsToRequest.Add(Android.Manifest.Permission.AccessFineLocation);
            permissionsToRequest.Add(Android.Manifest.Permission.AccessCoarseLocation);
        }

        if (permissionsToRequest.Count > 0)
        {
            ActivityCompat.RequestPermissions(this,
                permissionsToRequest.ToArray(), PermissionRequestCode);
        }
        else
        {
            // Fine location already granted â€” request background location separately
            RequestBackgroundLocation();
        }
    }

    public override void OnRequestPermissionsResult(
        int requestCode, string[] permissions, Permission[] grantResults)
    {
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        if (requestCode == PermissionRequestCode)
        {
            bool fineGranted = grantResults.Any(r => r == Permission.Granted);
            if (fineGranted)
                RequestBackgroundLocation();
        }
    }

    private void RequestBackgroundLocation()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
        {
            if (ContextCompat.CheckSelfPermission(this,
                Android.Manifest.Permission.AccessBackgroundLocation) != Permission.Granted)
            {
                // Show rationale before requesting background location
                new AlertDialog.Builder(this)
                    .SetTitle("Background Location Required")
                    .SetMessage(
                        "SP OneHR needs to track your location in the background " +
                        "while you work from home.\n\n" +
                        "On the next screen, please select:\n\"Allow all the time\"")
                    .SetPositiveButton("OK", (s, e) =>
                    {
                        ActivityCompat.RequestPermissions(this,
                            new[] { Android.Manifest.Permission.AccessBackgroundLocation },
                            PermissionRequestCode + 1);
                    })
                    .SetNegativeButton("Not Now", (s, e) => { })
                    .Show();
            }
        }
    }
}
