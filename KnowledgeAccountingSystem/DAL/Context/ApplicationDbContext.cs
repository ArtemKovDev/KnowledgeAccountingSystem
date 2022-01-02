using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string MANAGER_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string MANAGER_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            const string USER_ROLE_ID = "7c9e6679-7425-40de-944b-e07fc1f90ae7";

            modelBuilder.Entity<Skill>().HasData(
                new Skill[]
                {
                    new Skill() { Id=1, Name = "PHP", Description = "Script Language for WeB" },
                    new Skill() { Id=2, Name = "C#", Description = "OOP Language for WeB" },
                    new Skill() { Id=3, Name = "Python", Description = "Script Language for WeB" },
                    new Skill() { Id=4, Name = "C", Description = "Language for system" }
                });

            modelBuilder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = MANAGER_ROLE_ID,
                    Name = "manager",
                    NormalizedName = "MANAGER"
                }
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = MANAGER_ID,
                UserName = "manager@gmail.com",
                NormalizedUserName = "MANAGER@GMAIL.COM",
                Email = "manager@gmail.com",
                NormalizedEmail = "MANAGER@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Manager123$"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = MANAGER_ROLE_ID,
                UserId = MANAGER_ID
            });
        }
    }
}
