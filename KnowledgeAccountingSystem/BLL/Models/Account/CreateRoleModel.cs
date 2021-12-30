using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Account
{
    public class CreateRoleModel
    {
        [Required, MinLength(5), MaxLength(20)]
        public string RoleName { get; set; }
    }
}
