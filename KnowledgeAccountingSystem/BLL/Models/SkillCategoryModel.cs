using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class SkillCategoryModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
