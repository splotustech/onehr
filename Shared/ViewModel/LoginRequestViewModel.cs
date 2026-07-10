using System.ComponentModel.DataAnnotations;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class LoginRequestViewModel
    {
        [Required(ErrorMessage = " Please Enter UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = " Please Enter Password")]
        public string Password { get; set; }
    }
}