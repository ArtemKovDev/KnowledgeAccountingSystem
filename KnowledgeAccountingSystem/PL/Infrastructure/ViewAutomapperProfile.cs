using AutoMapper;
using BLL.Models.Account;
using Microsoft.AspNetCore.Identity;
using PL.ViewModels.Account;

namespace PL.Infrastructure
{
    /// <summary>
    /// Provide a named configuration for maps ViewModels to DTO
    /// </summary>
    public class ViewAutomapperProfile : Profile
    {
        public ViewAutomapperProfile()
        {
            CreateMap<UserRolesModel, UserRoles>();
            CreateMap<LogonModel, Logon>();
            CreateMap<RegisterModel, Register>();
            CreateMap<IdentityRole, RoleModel>();
        }
    }
}
