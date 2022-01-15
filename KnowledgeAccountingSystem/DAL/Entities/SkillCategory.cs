﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class SkillCategory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
