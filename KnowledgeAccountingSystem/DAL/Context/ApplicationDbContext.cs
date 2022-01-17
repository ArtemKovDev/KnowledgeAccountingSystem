using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<KnowledgeLevel> KnowledgeLevels { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string MANAGER_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string MANAGER_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            const string USER_ROLE_ID = "7c9e6679-7425-40de-944b-e07fc1f90ae7";

            modelBuilder.Entity<SkillCategory>().HasData(
                new SkillCategory[]
                {
                    new SkillCategory() { Id=1, Name = "Programming languages"},
                    new SkillCategory() { Id=2, Name = "Operating systems"},
                    new SkillCategory() { Id=3, Name = "Platforms"},
                    new SkillCategory() { Id=4, Name = "Databases"},
                    new SkillCategory() { Id=5, Name = "Design"},
                });

            modelBuilder.Entity<KnowledgeLevel>().HasData(
                new KnowledgeLevel[]
                {
                    new KnowledgeLevel() { Id=1, Name = "Beginner", Description = "Basic theoretical knowledge"},
                    new KnowledgeLevel() { Id=2, Name = "Medium", Description = "Good theoretical knowledge, practical skills"},
                    new KnowledgeLevel() { Id=3, Name = "Experienced", Description = "Excellent theoretical knowledge, practical" +
                    " skills, work experience of more than 1 year"},
                    new KnowledgeLevel() { Id=4, Name = "Expert", Description = "Expert theoretical knowledge, practical skills," +
                    " work experience more than 3 years, completed more than 1 project with key requirements for this skill"}
                });

            modelBuilder.Entity<Skill>().HasData(
                new Skill[]
                {
                    new Skill() { Id=1, Name = "PHP", Description = "Script Language for WeB", CategoryId = 1 },
                    new Skill() { Id=2, Name = "C#", Description = "OOP Language for web and desktop", CategoryId = 1 },
                    new Skill() { Id=3, Name = "Python", Description = "Script Language for WeB and Data Science", CategoryId = 1 },
                    new Skill() { Id=4, Name = "C++", Description = "Language for system programming", CategoryId = 1 },
                    new Skill() { Id=5, Name = "Java", Description = "OOP Language for web and desktop", CategoryId = 1 },
                    new Skill() { Id=6, Name = "SQL", Description = "Structured query language for databases", CategoryId = 1 },
                    new Skill() { Id=7, Name = "Android", Description = "A mobile operating system", CategoryId = 2 },
                    new Skill() { Id=8, Name = "Mac OS", Description = "A mobile operating system", CategoryId = 2 },
                    new Skill() { Id=9, Name = "Unix / Linux / Solaris", Description = "A desktop operating systems", CategoryId = 2 },
                    new Skill() { Id=10, Name = "Windows", Description = "A desktop operating system", CategoryId = 2 },
                    new Skill() { Id=11, Name = "AZURE", Description = "Microsoft's public cloud computing platform", CategoryId = 3 },
                    new Skill() { Id=12, Name = "AMAZON", Description = "A comprehensive, evolving cloud computing platform", CategoryId = 3 },
                    new Skill() { Id=13, Name = "Microsoft SQL Server", Description = "RDBMS developed by Microsoft Corporation", CategoryId = 4 },
                    new Skill() { Id=14, Name = "MySQL", Description = "RDBMS developed by Oracle Corporation", CategoryId = 4 },
                    new Skill() { Id=15, Name = "NoSQL", Description = "Non-relational databases", CategoryId = 4 },
                    new Skill() { Id=16, Name = "3D Modelling", Description = "The process of developing a mathematical " +
                    "coordinate-based representation of any surface of an object", CategoryId = 5 },
                    new Skill() { Id=17, Name = "User Testing", Description = "A process that is used to test the interface" +
                    " and functions of a website, application, mobile app or service", CategoryId = 5 },
                    new Skill() { Id=18, Name = "Visual Design", Description = "Aims to improve a design's/product's aesthetic" +
                    " appeal and usability with suitable images, typography, space, layout and color.", CategoryId = 5 },
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
                SecurityStamp = string.Empty,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PlaceOfWork = "TestPlace",
                Education = "TestEducation"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = MANAGER_ROLE_ID,
                    UserId = MANAGER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = MANAGER_ID
                }
            });

            modelBuilder.Entity<UserSkill>().HasData(new[]
            {
                new UserSkill
                {
                    Id = 1,
                    UserId = MANAGER_ID,
                    SkillId = 6,
                    KnowledgeLevelId = 2
                },
                new UserSkill
                {
                    Id = 2,
                    UserId = MANAGER_ID,
                    SkillId = 10,
                    KnowledgeLevelId = 3
                }
            });
        }
    }
}
