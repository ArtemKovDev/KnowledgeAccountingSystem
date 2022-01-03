using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels.Skills
{
    public class CreateUserSkillModel
    {
        [Required]
        public int SkillId { get; set; }

        [Required]
        public int KnowledgeLevelId { get; set; }
    }
}
