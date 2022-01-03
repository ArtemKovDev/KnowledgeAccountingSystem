using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserSkillModel
    {
        public int SkillId { get; set; }

        public string SkillName { get; set; }

        public string SkillDescription { get; set; }

        public int KnowledgeLevelId { get; set; }

        public string KnowledgeLevel { get; set; }
    }
}
