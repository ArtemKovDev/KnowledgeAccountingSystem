﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels.KnowledgeLevels
{
    public class CreateKnowledgeLevelModel
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
