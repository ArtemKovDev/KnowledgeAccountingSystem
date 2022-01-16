using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class SkillCategoryModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
