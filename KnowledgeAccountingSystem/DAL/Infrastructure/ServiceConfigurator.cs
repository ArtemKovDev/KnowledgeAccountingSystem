using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Infrastructure
{
    /// <summary>
    /// Define method for service configuring
    /// </summary>
    public class ServiceConfigurator
    {
        /// <summary>
        /// Add services of DAL
        /// </summary>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AccountingDB")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
            services.AddScoped<IKnowledgeLevelRepository, KnowledgeLevelRepository>();
            services.AddScoped<IUserSkillRepository, UserSkillRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }

}
