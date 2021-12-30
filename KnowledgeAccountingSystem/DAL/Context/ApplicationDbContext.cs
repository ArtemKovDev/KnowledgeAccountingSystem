using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<PersonSkill> PersonSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Skill>().HasData(
                new Skill[]
                {
                    new Skill() { Id=1, Name = "PHP", Description = "Script Language for WeB" },
                    new Skill() { Id=2, Name = "C#", Description = "OOP Language for WeB" },
                    new Skill() { Id=3, Name = "Python", Description = "Script Language for WeB" },
                    new Skill() { Id=4, Name = "C", Description = "Language for system" }
                });
        }
    }
}
