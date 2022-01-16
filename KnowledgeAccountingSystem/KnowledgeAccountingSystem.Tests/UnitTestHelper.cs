using AutoMapper;
using BLL.Infrastructure;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeAccountingSystem.Tests
{
    internal static class UnitTestHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(ApplicationDbContext context)
        {
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
