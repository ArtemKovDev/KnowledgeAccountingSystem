using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Role name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }
    }
}
