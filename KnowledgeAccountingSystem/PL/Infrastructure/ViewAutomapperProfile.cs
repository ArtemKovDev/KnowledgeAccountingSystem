using AutoMapper;
using BLL.Models;
using BLL.Models.Account;
using Microsoft.AspNetCore.Identity;
using PL.ViewModels.Account;
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
            CreateMap<UserRolesModel, UserRoles>();
            CreateMap<LogonModel, Logon>();
            CreateMap<RegisterModel, Register>();
            CreateMap<UpdateUserModel, UserModel>();
            CreateMap<FilterSearchModel, FilterSearch>();
            CreateMap<IdentityRole, RoleModel>();
        }
    }
}
