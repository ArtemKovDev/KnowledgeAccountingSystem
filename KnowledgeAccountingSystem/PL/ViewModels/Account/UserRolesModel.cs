using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class UserRolesModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Role is required"), MinLength(1)]
        public string[] Roles { get; set; }
    }
}
