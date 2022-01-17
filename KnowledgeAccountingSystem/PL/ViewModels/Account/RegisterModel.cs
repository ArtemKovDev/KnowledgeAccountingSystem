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
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Place of work is required")]
        public string PlaceOfWork { get; set; }
        [Required(ErrorMessage = "Education name is required")]
        public string Education { get; set; }
    }
}
