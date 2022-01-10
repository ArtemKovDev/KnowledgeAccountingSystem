using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class UserSkillModel
    {
        public int Id { get; set; }

        [Required]
        public int SkillId { get; set; }

        [Required]
        public int KnowledgeLevelId { get; set; }

        public Skill Skill { get; set; }

        public KnowledgeLevel KnowledgeLevel { get; set; }
    }
}
