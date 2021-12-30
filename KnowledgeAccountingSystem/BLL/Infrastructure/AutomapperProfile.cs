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
                .ForMember(dest => dest.PersonIds, opt => opt.MapFrom(src => src.Persons.Select(x => x.PersonId)))
                .ReverseMap();
        }
    }
}
