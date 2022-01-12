using BLL.Interfaces;
using BLL.Services;
using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public class ServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DAL.Infrastructure.ServiceConfigurator.ConfigureServices(services, configuration);

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IKnowledgeLevelService, KnowledgeLevelService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }

}
