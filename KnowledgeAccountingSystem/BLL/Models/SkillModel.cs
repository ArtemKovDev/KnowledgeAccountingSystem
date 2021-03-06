using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class SkillModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }
    }
}
