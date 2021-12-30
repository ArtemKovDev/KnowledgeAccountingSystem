using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class CreateRoleModel
    {
        [Required, MinLength(5), MaxLength(20)]
        public string RoleName { get; set; }
    }
}
