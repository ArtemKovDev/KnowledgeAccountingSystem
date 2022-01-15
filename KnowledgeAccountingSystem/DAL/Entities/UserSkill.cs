using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class UserSkill : BaseEntity
    {
        public string UserId { get; set; }

        public int SkillId { get; set; }

        public int KnowledgeLevelId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }

        [ForeignKey("KnowledgeLevelId")]
        public KnowledgeLevel KnowledgeLevel { get; set; }
    }
}
