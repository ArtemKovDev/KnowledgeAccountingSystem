using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class KnowledgeLevel : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}
