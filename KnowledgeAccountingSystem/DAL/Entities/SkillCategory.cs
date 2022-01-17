using System.Collections.Generic;

namespace DAL.Entities
{
    public class SkillCategory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
