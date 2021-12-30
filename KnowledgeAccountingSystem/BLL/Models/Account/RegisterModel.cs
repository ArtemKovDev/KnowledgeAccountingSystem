using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
 
        [Required]
        public string Password { get; set; }
 
        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PlaceOfWork { get; set; }
        public string Education { get; set; }
    }
}
