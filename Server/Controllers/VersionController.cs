using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace SMART_HRMS_SYSTEM.Server.Controllers;

[Route("api/version")]
[ApiController]
public class VersionController : ControllerBase
{
    private readonly IConfiguration _config;

    public VersionController(IConfiguration config)
    {
        _config = config;
    }

    // ── Website version (Blazor auto-update) ──────────────────────────────
    // Returns the server DLL build timestamp — changes automatically on every deploy.
    // The Blazor MainLayout polls this every 60 seconds to detect a new deployment.
    [HttpGet]
    public IActionResult GetVersion()
    {
        Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        Response.Headers["Pragma"]        = "no-cache";
        Response.Headers["Expires"]       = "0";

        var dllPath   = Assembly.GetExecutingAssembly().Location;
        var buildTime = System.IO.File.GetLastWriteTimeUtc(dllPath);
        var version   = buildTime.ToString("yyyyMMddHHmm");

        return Ok(new
        {
            version   = version,
            label     = buildTime.ToString("dd MMM yyyy HH:mm") + " UTC",
            timestamp = DateTime.UtcNow
        });
    }

    // ── Android APK version (mobile app auto-update check) ────────────────
    // The mobile app calls this on startup.
    // If the returned version is higher than the installed version,
    // the app shows an "Update Available" dialog pointing to the download URL.
    //
    // To release a new APK:
    //   1. Build new APK → copy to wwwroot/downloads/SpOneHR.apk
    //   2. Bump "AndroidApp:Version" in appsettings.json (e.g. "1.1" → "1.2")
    //   3. Redeploy website — the mobile app will detect the change on next startup.
    [HttpGet("android")]
    public IActionResult GetAndroidVersion()
    {
        Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";

        var version      = _config["AndroidApp:Version"]      ?? "1.0";
        var downloadUrl  = _config["AndroidApp:DownloadUrl"]  ?? "https://onehr.splotustech.com/api/download/apk";
        var notes        = _config["AndroidApp:ReleaseNotes"] ?? "";
        var forceUpdate  = bool.TryParse(_config["AndroidApp:ForceUpdate"], out var f) && f;

        return Ok(new
        {
            version      = version,
            downloadUrl  = downloadUrl,
            releaseNotes = notes,
            forceUpdate  = forceUpdate
        });
    }
}
