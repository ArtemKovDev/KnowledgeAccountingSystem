using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
 
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirm { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PlaceOfWork { get; set; }
        [Required]
        public string Education { get; set; }
    }
}
