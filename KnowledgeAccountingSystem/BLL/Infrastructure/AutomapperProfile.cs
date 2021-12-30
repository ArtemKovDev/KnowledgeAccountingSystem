using AutoMapper;
using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Skill, SkillModel>()
                .ReverseMap();
        }
    }
}
