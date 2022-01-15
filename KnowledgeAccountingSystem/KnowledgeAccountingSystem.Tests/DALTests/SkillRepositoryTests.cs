using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Tests.DALTests
{
    [TestFixture]
    public class SkillRepositoryTests
    {
        [Test]
        public void SkillRepository_FindAll_ReturnsAllValues()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                var skills = skillRepository.FindAll();

                Assert.AreEqual(18, skills.Count(), message: "FindAll method works incorrect");
            }
        }

        [Test]
        public async Task SkillRepository_GetById_ReturnsSingleValue()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                var skill = await skillRepository.GetByIdAsync(1);

                Assert.AreEqual(1, skill.Id, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual("PHP", skill.Name, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual("Script Language for WeB", skill.Description, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual(1, skill.CategoryId, message: "GetByIdAsync method works incorrect");
            }
        }

        [Test]
        public async Task SkillRepository_AddAsync_AddsValueToDatabase()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);
                var skill = new Skill() { Id = 19 };

                await skillRepository.AddAsync(skill);
                await context.SaveChangesAsync();

                Assert.AreEqual(19, context.Skills.Count(), message: "AddAsync method works incorrect");
            }
        }

        [Test]
        public async Task SkillRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                await skillRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(17, context.Skills.Count(), message: "DeleteByIdAsync works incorrect ");
            }
        }

        [Test]
        public async Task SkillRepository_Update_UpdatesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                var skill = new Skill() { Id = 1, Name = "Test", Description = "TestTest", CategoryId = 3 };

                skillRepository.Update(skill);
                await context.SaveChangesAsync();

                Assert.AreEqual(1, skill.Id, message: "Update method works incorrect ");
                Assert.AreEqual("Test", skill.Name, message: "Update method works incorrect ");
                Assert.AreEqual("TestTest", skill.Description, message: "Update method works incorrect ");
                Assert.AreEqual(3, skill.CategoryId, message: "Update method works incorrect ");
            }
        }

        [Test]
        public async Task SkillRepository_GetByIdWithDetailsAsync_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedUsersInSkill = 0;
                var skillRepository = new SkillRepository(context);
                var skillWithIncludes = await skillRepository.GetByIdWithDetailsAsync(1);

                var actualCount = skillWithIncludes.Users.Count;
                var actualCategory = skillWithIncludes.Category;

                Assert.AreEqual(expectedUsersInSkill, actualCount, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
                Assert.That(actualCategory,
                Is.EqualTo(ExpectedSkillCategory).Using(new SkillCategoryEqualityComparer()));
            }
        }

        [Test]
        public void SkillCategoryRepository_GetAllWithDetails_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedUsersInSkill = 0;
                var skillRepository = new SkillRepository(context);
                var skillsWithIncludes = skillRepository.GetAllWithDetails();

                var actualCount = skillsWithIncludes.FirstOrDefault().Users.Count;
                var actualCategory = skillsWithIncludes.FirstOrDefault().Category;

                Assert.AreEqual(expectedUsersInSkill, actualCount, message: "GetAllWithDetails method doesnt't return included entities");
                Assert.That(actualCategory,
                Is.EqualTo(ExpectedSkillCategory).Using(new SkillCategoryEqualityComparer()));
            }
        }

        private static SkillCategory ExpectedSkillCategory => new SkillCategory() { Id = 1, Name = "Programming languages" };
    }
}
