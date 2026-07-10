using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLoginInfo
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? EmployeeId { get; set; }

    public string? Role { get; set; }

    public bool? MailSendStatus { get; set; }

    public bool? OtpSendStatus { get; set; }

    public int? RoleId { get; set; }

    public virtual TblEmplyeeInfo? Employee { get; set; }

    public virtual TblRoleInfo? RoleNavigation { get; set; }
}
