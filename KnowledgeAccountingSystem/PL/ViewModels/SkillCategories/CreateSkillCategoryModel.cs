using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels.SkillCategories
{
    public class CreateSkillCategoryModel
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
    }
}
