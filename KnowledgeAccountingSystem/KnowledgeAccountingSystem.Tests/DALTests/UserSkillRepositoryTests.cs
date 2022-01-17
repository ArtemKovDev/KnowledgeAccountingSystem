using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Tests.DALTests
{
    [TestFixture]
    public class UserSkillRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task UserSkillRepository_GetById(int id)
        {

            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);

            var userSkill = await userSkillRepository.GetByIdAsync(id);

            var expected = ExpectedUserSkills.FirstOrDefault(x => x.Id == id);
            Assert.That(userSkill,
                Is.EqualTo(expected).Using(new UserSkillEqualityComparer()));
        }

        [Test]
        public async Task UserSkillRepository_FindAll()
        {
            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);

            var userSkills = userSkillRepository.FindAll();

            Assert.That(userSkills,
                Is.EqualTo(ExpectedUserSkills).Using(new UserSkillEqualityComparer()));
        }

        [Test]
        public async Task UserSkillRepository_AddAsync_()
        {
            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);
            var userSkill = new UserSkill { Id = 3 };

            await userSkillRepository.AddAsync(userSkill);
            await context.SaveChangesAsync();

            Assert.That(context.UserSkills.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task UserSkillRepository_DeleteByIdAsync_DeletesEntity()
        {
            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);

            await userSkillRepository.DeleteByIdAsync(1);
            await context.SaveChangesAsync();

            Assert.That(context.UserSkills.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task UserSkillRepository_Update_UpdatesEntity()
        {
            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);

            var userSkill = new UserSkill
            {
                Id = 1,
                UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                SkillId = 6,
                KnowledgeLevelId = 3
            };

            userSkillRepository.Update(userSkill);
            await context.SaveChangesAsync();

            Assert.That(userSkill, Is.EqualTo(
                new UserSkill
                {
                    Id = 1,
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    SkillId = 6,
                    KnowledgeLevelId = 3
                })
                .Using(new UserSkillEqualityComparer()));
        }

        [Test]
        public async Task UserSkillRepository_GetAllWithDetails()
        {
            await using var context = new ApplicationDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userSkillRepository = new UserSkillRepository(context);

            var userSkills = userSkillRepository.GetAllWithDetails();

            Assert.That(userSkills,
                Is.EqualTo(ExpectedUserSkills).Using(new UserSkillEqualityComparer()));
            Assert.That(userSkills.Select(x => x.User).OrderBy(x => x.Id),
                Is.EqualTo(ExpectedUsers).Using(new UserEqualityComparer()));
            Assert.That(userSkills.Select(x => x.Skill).OrderBy(x => x.Id),
                Is.EqualTo(ExpectedSkills).Using(new SkillEqualityComparer()));
            Assert.That(userSkills.Select(x => x.KnowledgeLevel).OrderBy(x => x.Id),
                Is.EqualTo(ExpectedKnowledgeLevels).Using(new KnowledgeLevelEqualityComparer()));
        }

        private static IEnumerable<UserSkill> ExpectedUserSkills =>
            new[]
            {
                new UserSkill
                {
                    Id = 1,
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    SkillId = 6,
                    KnowledgeLevelId = 2
                },
                new UserSkill
                {
                    Id = 2,
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    SkillId = 10,
                    KnowledgeLevelId = 3
                }
            };

        private static IEnumerable<User> ExpectedUsers =>
            new[]
            {
                new User
                {
                    Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    Email = "manager@gmail.com"
                },
                new User
                {
                    Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    Email = "manager@gmail.com"
                }
            };

        private static IEnumerable<Skill> ExpectedSkills =>
            new[]
            {
                new Skill() { Id=6, Name = "SQL", Description = "Structured query language for databases", CategoryId = 1 },
                new Skill() { Id=10, Name = "Windows", Description = "A desktop operating system", CategoryId = 2 },
            };

        private static IEnumerable<KnowledgeLevel> ExpectedKnowledgeLevels =>
            new[]
            {
                new KnowledgeLevel() { Id=2, Name = "Medium", Description = "Good theoretical knowledge, practical skills"},
                new KnowledgeLevel() { Id=3, Name = "Experienced", Description = "Excellent theoretical knowledge, practical" +
                " skills, work experience of more than 1 year"}
            };
    }
}
