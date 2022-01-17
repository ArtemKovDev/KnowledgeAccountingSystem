using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Tests.DALTests
{
    [TestFixture]
    public class KnowledgeLevelRepositoryTests
    {
        [Test]
        public void KnowledgeLevelRepository_FindAll_ReturnsAllValues()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);

                var knowledgeLevels = knowledgeLevelRepository.FindAll();

                Assert.AreEqual(4, knowledgeLevels.Count(), message: "FindAll method works incorrect");
            }
        }

        [Test]
        public async Task KnowledgeLevelRepository_GetById_ReturnsSingleValue()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);

                var knowledgeLevel = await knowledgeLevelRepository.GetByIdAsync(1);

                Assert.AreEqual(1, knowledgeLevel.Id, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual("Beginner", knowledgeLevel.Name, message: "GetByIdAsync method works incorrect");
                Assert.AreEqual("Basic theoretical knowledge", knowledgeLevel.Description, message: "GetByIdAsync method works incorrect");
            }
        }

        [Test]
        public async Task KnowledgeLevelRepository_AddAsync_AddsValueToDatabase()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);
                var knowledgeLevel = new KnowledgeLevel() { Id = 5 };

                await knowledgeLevelRepository.AddAsync(knowledgeLevel);
                await context.SaveChangesAsync();

                Assert.AreEqual(5, context.KnowledgeLevels.Count(), message: "AddAsync method works incorrect");
            }
        }

        [Test]
        public async Task KnowledgeLevelRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);

                await knowledgeLevelRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(3, context.KnowledgeLevels.Count(), message: "DeleteByIdAsync works incorrect ");
            }
        }

        [Test]
        public async Task KnowledgeLevelRepository_Update_UpdatesEntity()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);

                var knowledgeLevel = new KnowledgeLevel() { Id = 1, Name = "Test", Description = "TestTest" };

                knowledgeLevelRepository.Update(knowledgeLevel);
                await context.SaveChangesAsync();

                Assert.AreEqual(1, knowledgeLevel.Id, message: "Update method works incorrect ");
                Assert.AreEqual("Test", knowledgeLevel.Name, message: "Update method works incorrect ");
                Assert.AreEqual("TestTest", knowledgeLevel.Description, message: "Update method works incorrect ");
            }
        }

        [Test]
        public async Task KnowledgeLevelRepository_GetByIdWithDetailsAsync_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedUserSkillsInKnowledgeLevel = 1;
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);
                var knowledgeLevelWithIncludes = await knowledgeLevelRepository.GetByIdWithDetailsAsync(2);

                var actual = knowledgeLevelWithIncludes.UserSkills.Count;

                Assert.AreEqual(expectedUserSkillsInKnowledgeLevel, actual, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
            }
        }

        [Test]
        public void KnowledgeLevelRepository_GetAllWithDetails_ReturnsWithIncludedEntities()
        {
            using (var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var expectedUserSkillsInKnowledgeLevel = 0;
                var knowledgeLevelRepository = new KnowledgeLevelRepository(context);
                var knowledgeLevelWithIncludes = knowledgeLevelRepository.GetAllWithDetails();

                var actual = knowledgeLevelWithIncludes.FirstOrDefault().UserSkills.Count;

                Assert.AreEqual(expectedUserSkillsInKnowledgeLevel, actual, message: "GetAllWithDetails method doesnt't return included entities");
            }
        }
    }
}
