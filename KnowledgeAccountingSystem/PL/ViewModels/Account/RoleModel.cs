using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Account
{
    public class RoleModel
    {
        [Required, MinLength(5), MaxLength(20)]
        public string Name { get; set; }
    }
}
