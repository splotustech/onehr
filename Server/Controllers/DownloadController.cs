using Microsoft.AspNetCore.Mvc;

namespace SMART_HRMS_SYSTEM.Server.Controllers;

[Route("api/download")]
[ApiController]
public class DownloadController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<DownloadController> _logger;

    public DownloadController(IWebHostEnvironment env, ILogger<DownloadController> logger)
    {
        _env = env;
        _logger = logger;
    }

    /// <summary>
    /// Streams SpOneHR.apk from wwwroot/downloads/ with correct headers.
    /// Bypasses IIS MIME-type filtering and Request Filtering completely.
    /// </summary>
    [HttpGet("apk")]
    public IActionResult DownloadApk()
    {
        var filePath = Path.Combine(_env.WebRootPath, "downloads", "SpOneHR.apk");

        if (!System.IO.File.Exists(filePath))
        {
            _logger.LogWarning("APK download requested but file not found at: {Path}", filePath);
            return NotFound(new
            {
                success  = false,
                message  = "Android APK is not available yet. Please contact your administrator.",
                filePath = "/downloads/SpOneHR.apk"
            });
        }

        _logger.LogInformation("APK downloaded by {IP}", HttpContext.Connection.RemoteIpAddress);

        // PhysicalFile streams the file with correct Content-Type and Content-Disposition
        return PhysicalFile(
            physicalPath:  filePath,
            contentType:   "application/vnd.android.package-archive",
            fileDownloadName: "SpOneHR.apk",
            enableRangeProcessing: true  // allows resume on interrupted download
        );
    }

    /// <summary>
    /// Returns APK file info — size, last modified — so UI can display it.
    /// </summary>
    [HttpGet("apk/info")]
    public IActionResult GetApkInfo()
    {
        var filePath = Path.Combine(_env.WebRootPath, "downloads", "SpOneHR.apk");

        if (!System.IO.File.Exists(filePath))
            return Ok(new { exists = false });

        var info = new FileInfo(filePath);
        return Ok(new
        {
            exists      = true,
            sizeMb      = Math.Round(info.Length / 1048576.0, 1),
            lastUpdated = info.LastWriteTime.ToString("dd MMM yyyy")
        });
    }
}
