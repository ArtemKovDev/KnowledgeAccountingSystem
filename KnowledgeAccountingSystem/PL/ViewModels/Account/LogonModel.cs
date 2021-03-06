using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class LogonModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
