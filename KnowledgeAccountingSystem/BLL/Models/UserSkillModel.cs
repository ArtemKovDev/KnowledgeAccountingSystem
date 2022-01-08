using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserSkillModel
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public int KnowledgeLevelId { get; set; }

        public Skill Skill { get; set; }

        public KnowledgeLevel KnowledgeLevel { get; set; }
    }
}
