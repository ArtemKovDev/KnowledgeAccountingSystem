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
    /// <summary>
    /// Define method for service configuring
    /// </summary>
    public class ServiceConfigurator
    {
        /// <summary>
        /// Add services of BLL
        /// </summary>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DAL.Infrastructure.ServiceConfigurator.ConfigureServices(services, configuration);

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IKnowledgeLevelService, KnowledgeLevelService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }

}
