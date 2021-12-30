using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class LogonModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
