using AutoMapper;
using BLL.Models;
using BLL.Models.Account;
using PL.ViewModels.Account;
using PL.ViewModels.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Infrastructure
{
    public class ViewAutomapperProfile : Profile
    {
        public ViewAutomapperProfile()
        {
            CreateMap<AssignUserToRoleModel, AssignUserToRoles>();
            CreateMap<LogonModel, Logon>();
            CreateMap<RegisterModel, Register>();
            CreateMap<CreateSkillModel, SkillModel>();
        }
    }
}
