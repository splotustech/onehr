using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using SMART_HRMS_SYSTEM.Shared;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using System.Linq;
using System.Text.Json;
using WebPush;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    // हे डिटेल्स तुम्हाला तुमच्या VAPID Keys ने रिप्लेस करावे लागतील
    string subject = "mailto:yuvaraj.lotustech@gmail.com";
    string publicKey = "BPdHp1GBJ5-_apY5jYru_kiZuBja89HxGcZCsLFa06nsT1zaeGkrtz1EpXI1WM7ijcQ8So5DqNXTKH8wEUmcGJM";
    string privateKey = "q_5BI5ysQ0htTvREN-TswnqYLMovVjaGZ1sSWZXK184";

    private readonly LotusTechCrmliveContext _context;

    public NotificationsController(LotusTechCrmliveContext context)
    {
        _context = context;
    }

    [HttpPost("subscribe")]
    public async Task<IActionResult> Subscribe([FromBody] PushSubscriptionModel sub)
    {
        // ✅ Proper await
        var data = await _context.TblPushSubscriptions
            .Where(t => t.EmpId == sub.EmpId)
            .OrderByDescending(t => t.Id)
            .FirstOrDefaultAsync();

        if (data == null)
        {
            // ✅ INSERT
            var subscription = new TblPushSubscription
            {
                EmpId = sub.EmpId,
                Endpoint = sub.Endpoint,
                P256dh = sub.P256dh,
                Auth = sub.Auth,
                Department = sub.Department,
                CreatedOn = DateTime.Now
            };

            _context.TblPushSubscriptions.Add(subscription);
        }
        else
        {
            // ✅ UPDATE existing record
            data.Endpoint = sub.Endpoint;
            data.P256dh = sub.P256dh;
            data.Auth = sub.Auth;
            data.Department = sub.Department;
            data.CreatedOn = DateTime.Now;

            _context.TblPushSubscriptions.Update(data);
        }

        await _context.SaveChangesAsync();

        return Ok();
    }

    // 2. Send Push Notification (हे Outpass Save API मधून कॉल करा)
    [HttpPost("sendHRNotification")]
    public async Task<IActionResult> SendHRPushNotification([FromBody] NotificationRequest request)
    {
        try
        {
            var subscriptions = await _context.TblPushSubscriptions
                .Where(x => x.Department == "Human  Resources")
                .ToListAsync();

            if (!subscriptions.Any())
                return NotFound("No subscriptions found");

            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();

            var payload = JsonSerializer.Serialize(new
            {
                title = request.Title,
                message = request.Body,
                url = request.Link
            });

            foreach (var sub in subscriptions)
            {
                try
                {
                    var pushSubscription = new PushSubscription(
                        sub.Endpoint,
                        sub.P256dh,
                        sub.Auth
                    );

                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                }
                catch (WebPushException ex)
                {
                    if (ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                        ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        _context.TblPushSubscriptions.Remove(sub);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost("sendEmployeeNotification")]
    public async Task<IActionResult> SendEmployeePushNotification([FromBody] NotificationRequest request)
    {
        try
        {
            // ✅ Get ALL subscriptions (multiple devices support)
            var subscriptions = await _context.TblPushSubscriptions
                .Where(x => x.EmpId == request.EmpId)
                .ToListAsync();

            if (subscriptions == null || !subscriptions.Any())
                return NotFound("No subscriptions found");

            // ✅ Optional: Get employee name
            var empName = await _context.TblEmplyeeInfos
                .Where(x => x.Id == request.EmpId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();

            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();

            // ✅ Payload
            var payload = JsonSerializer.Serialize(new
            {
                //title = "Outpass Request Approved",
                //message = $"{empName} Outpass has been approved.",
                //url = "/attendance"
                title = request.Title,
                message = request.Body,
                url = request.Link // यावर क्लिक केल्यावर HR या पेजवर जाईल

            });

            // ✅ Send to all devices
            foreach (var sub in subscriptions)
            {
                try
                {
                    var pushSubscription = new PushSubscription(
                        sub.Endpoint,
                        sub.P256dh,
                        sub.Auth
                    );

                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                }
                catch (WebPushException ex)
                {
                    // 🔥 Remove invalid subscription (VERY IMPORTANT)
                    if (ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                        ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        _context.TblPushSubscriptions.Remove(sub);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    // 3. WebJob Reminder API (रोज सकाळी 9:45 वाजता कॉल करण्यासाठी)
    [HttpGet("sendMissingPunchInReminder")]
    public async Task<IActionResult> SendMissingPunchInReminder()
    {
        try
        {
            var today = DateTime.Today;

            // 1. ज्यांनी आज Punch-In केले आहे त्यांचे Employee Ids मिळवा
            var punchedInEmpIds = await _context.AttendanceLogs
                .Where(x => x.Date == today ) // इथे तुमच्या डेट कॉलमचे नाव तपासा (उदा. PunchInTime.Date)
                .Select(x => x.EmployeeId)
                .Distinct()
                .ToListAsync();

            // 2. ज्यांनी आज Punch-In केले *नाहीये*, त्यांचे सर्व Subscriptions काढा
          
            var missingPunchSubscriptions = _context.TblPushSubscriptions
   .AsEnumerable() // 🔥 important
   .Where(sub => !punchedInEmpIds.Contains(Convert.ToInt32(sub.EmpId)))
   .ToList();
            if (!missingPunchSubscriptions.Any())
                return Ok(new { message = "All employees have already punched in, or no subscriptions found." });

            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();

            // 3. नोटिफिकेशनचा मेसेज तयार करा
            var payload = JsonSerializer.Serialize(new
            {
                title = "⏰ Attendance Reminder",
                message = "You haven't punched in yet! It's past 9:40 AM. Please mark your attendance now.",
                url = "/attendance" // नोटिफिकेशनवर क्लिक केल्यावर ॲपच्या अटेंडन्स पेजवर जाईल
            });

            int successCount = 0;

            // 4. सर्वांना लूप लावून नोटिफिकेशन पाठवा
            foreach (var sub in missingPunchSubscriptions)
            {
                try
                {
                    var pushSubscription = new PushSubscription(
                        sub.Endpoint,
                        sub.P256dh,
                        sub.Auth
                    );

                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                    successCount++;
                }
                catch (WebPushException ex)
                {
                    // जर युजरने नोटिफिकेशन ब्लॉक केले असेल किंवा ब्राउझरचा डेटा डिलीट केला असेल
                    if (ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                        ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        _context.TblPushSubscriptions.Remove(sub);
                    }
                }
            }

            // Expire झालेले (Remove केलेले) टोकन्स डेटाबेसमधून काढून टाका
            await _context.SaveChangesAsync();

            return Ok(new { success = true, notifiedCount = successCount });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    // 4. WebJob Reminder API (रोज संध्याकाळी 6:10 वाजता कॉल करण्यासाठी)
    [HttpGet("sendMissingPunchOutReminder")]
    public async Task<IActionResult> SendMissingPunchOutReminder()
    {
        try
        {
            var today = DateTime.Today;

            // 1. ज्यांनी आज Punch-In केले आहे, पण Punch-Out केले *नाहीये* (PunchOutTime == null) त्यांचे Ids मिळवा
            var missingPunchOutEmpIds = await _context.AttendanceLogs
                .Where(x => x.Date == today && x.PunchOutTime == null) // Punch-Out रिकामा आहे का ते तपासले
                .Select(x => x.EmployeeId)
                .Distinct()
                .ToListAsync();

            if (!missingPunchOutEmpIds.Any())
                return Ok(new { message = "All employees have already punched out, or no one punched in today." });

            // 2. ज्यांनी Punch-Out केले नाहीये, त्यांचे सर्व Subscriptions काढा
           var missingPunchOutSubscriptions = _context.TblPushSubscriptions
    .AsEnumerable() // 🔥 important
    .Where(sub => missingPunchOutEmpIds.Contains(Convert.ToInt32(sub.EmpId)))
    .ToList();

            if (!missingPunchOutSubscriptions.Any())
                return Ok(new { message = "Employees missing punch-out found, but no active push subscriptions for them." });

            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();

            // 3. नोटिफिकेशनचा मेसेज तयार करा
            var payload = JsonSerializer.Serialize(new
            {
                title = "⏰ Punch Out Reminder",
                message = "Your shift is over! It's past 6:00 PM. Don't forget to Punch Out.",
                url = "/attendance" // नोटिफिकेशनवर क्लिक केल्यावर ॲपच्या अटेंडन्स पेजवर जाईल
            });

            int successCount = 0;

            // 4. सर्वांना लूप लावून नोटिफिकेशन पाठवा
            foreach (var sub in missingPunchOutSubscriptions)
            {
                try
                {
                    var pushSubscription = new PushSubscription(
                        sub.Endpoint,
                        sub.P256dh,
                        sub.Auth
                    );

                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                    successCount++;
                }
                catch (WebPushException ex)
                {
                    // जर युजरने ब्राउझरचा डेटा डिलीट केला असेल
                    if (ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                        ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        _context.TblPushSubscriptions.Remove(sub);
                    }
                }
            }

            // Expire झालेले टोकन्स डेटाबेसमधून काढून टाका
            await _context.SaveChangesAsync();

            return Ok(new { success = true, notifiedCount = successCount });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
   