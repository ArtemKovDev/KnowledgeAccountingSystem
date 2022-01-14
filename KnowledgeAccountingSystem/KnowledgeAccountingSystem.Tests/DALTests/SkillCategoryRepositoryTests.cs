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
    public class SkillCategoryRepositoryTests
    {
        [Test]
        public void SkillCategoryRepository_FindAll_ReturnsAllValues()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillCategoryRepository = new SkillCategoryRepository(context);

                var skillCategories = skillCategoryRepository.FindAll();

                Assert.AreEqual(5, skillCategories.Count(), message: "FindAll method works incorrect");
            }
        }

        [Test]
        public async Task SkillCategoryRepository_GetById_ReturnsSingleValue()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillCategoryRepository = new SkillCategoryRepository(context);

                var skillCategory = await skillCategoryRepository.GetByIdAsync(1);

                Assert.AreEqual(1, skillCategory.Id, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual("Programming languages", skillCategory.Name, message: "GetByIdAsync method works incorrect");
            }
        }

        [Test]
        public async Task SkillCategoryRepository_AddAsync_AddsValueToDatabase()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillCategoryRepository = new SkillCategoryRepository(context);
                var skillCategory = new SkillCategory() { Id = 6 };

                await skillCategoryRepository.AddAsync(skillCategory);
                await context.SaveChangesAsync();

                Assert.AreEqual(6, context.SkillCategories.Count(), message: "AddAsync method works incorrect");
            }
        }

        [Test]
        public async Task SkillCategoryRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillCategoryRepository = new SkillCategoryRepository(context);

                await skillCategoryRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(4, context.KnowledgeLevels.Count(), message: "DeleteByIdAsync works incorrect ");
            }
        }

        [Test]
        public async Task SkillCategoryRepository_Update_UpdatesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillCategoryRepository = new SkillCategoryRepository(context);

                var skillCategory = new SkillCategory() { Id = 1, Name = "Test"};

                skillCategoryRepository.Update(skillCategory);
                await context.SaveChangesAsync();

                Assert.AreEqual(1, skillCategory.Id, message: "Update method works incorrect ");
                Assert.AreEqual("Test", skillCategory.Name, message: "Update method works incorrect ");
            }
        }

        [Test]
        public async Task SkillCategoryRepository_GetByIdWithDetailsAsync_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedSkillsInCategory = 6;
                var skillCategoryRepository = new SkillCategoryRepository(context);
                var skillCategoryWithIncludes = await skillCategoryRepository.GetByIdWithDetailsAsync(1);

                var actual = skillCategoryWithIncludes.Skills.Count;

                Assert.AreEqual(expectedSkillsInCategory, actual, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
            }
        }

        [Test]
        public void SkillCategoryRepository_GetAllWithDetails_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedSkillsInCategory = 6;
                var skillCategoryRepository = new SkillCategoryRepository(context);
                var skillCategoryWithIncludes = skillCategoryRepository.GetAllWithDetails();

                var actual = skillCategoryWithIncludes.FirstOrDefault().Skills.Count;

                Assert.AreEqual(expectedSkillsInCategory, actual, message: "GetAllWithDetails method doesnt't return included entities");
            }
        }
    }
}
