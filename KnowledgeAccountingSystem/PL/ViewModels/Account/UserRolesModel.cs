using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class UserRolesModel
    {
        [Required]
        public string Email { get; set; }
        [Required, MinLength(1)]
        public string[] Roles { get; set; }
    }
}
