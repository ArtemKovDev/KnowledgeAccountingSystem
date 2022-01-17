using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public SkillCategory Category { get; set; }

        public ICollection<UserSkill> Users { get; set; }
    }
}
