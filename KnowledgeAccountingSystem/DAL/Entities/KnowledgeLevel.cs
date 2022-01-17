using System.Collections.Generic;

namespace DAL.Entities
{
    public class KnowledgeLevel : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}
