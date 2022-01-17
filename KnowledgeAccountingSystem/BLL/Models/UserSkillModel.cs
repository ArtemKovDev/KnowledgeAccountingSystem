using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class UserSkillModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill is required")]
        public int? SkillId { get; set; }

        [Required(ErrorMessage = "KnowledgeLevel is required")]
        public int? KnowledgeLevelId { get; set; }
    }
}
