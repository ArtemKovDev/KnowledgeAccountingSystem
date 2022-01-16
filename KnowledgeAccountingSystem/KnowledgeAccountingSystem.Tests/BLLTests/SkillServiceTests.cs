using BLL.Models;
using BLL.Services;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Tests.BLLTests
{
    [TestFixture]
    public class SkillServiceTests
    {
        [Test]
        public void SkillService_GetAll_ReturnsSkillModels()
        {
            var expected = GetTestSkillModels().ToList();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.SkillRepository.FindAll())
                .Returns(GetTestSkillEntities().AsQueryable);
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = skillService.GetAll().ToList();

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Description, actual[i].Description);
                Assert.AreEqual(expected[i].CategoryId, actual[i].CategoryId);
            }
        }

        private IEnumerable<Skill> GetTestSkillEntities()
        {
            return new List<Skill>()
            {
                new Skill() { Id=1, Name = "PHP", Description = "Script Language for WeB", CategoryId = 1 },
                new Skill() { Id=2, Name = "C#", Description = "OOP Language for web and desktop", CategoryId = 1 },
                new Skill() { Id=3, Name = "Python", Description = "Script Language for WeB and Data Science", CategoryId = 1 }
            };
        }


        [Test]
        public async Task SkillService_GetByIdAsync_ReturnsSkillModel()
        {
            var expected = GetTestSkillModels().First();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.SkillRepository.GetByIdWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(GetTestSkillEntities().First);
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = await skillService.GetByIdAsync(1);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CategoryId, actual.CategoryId);
        }

        private IEnumerable<SkillModel> GetTestSkillModels()
        {
            return new List<SkillModel>()
            {
                new SkillModel() { Id=1, Name = "PHP", Description = "Script Language for WeB", CategoryId = 1 },
                new SkillModel() { Id=2, Name = "C#", Description = "OOP Language for web and desktop", CategoryId = 1 },
                new SkillModel() { Id=3, Name = "Python", Description = "Script Language for WeB and Data Science", CategoryId = 1 }
            };
        }

        [Test]
        public async Task SkillService_AddAsync_AddsModel()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.AddAsync(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skill = new SkillModel { Name = "TestCategory", Description = "TestDescription", CategoryId = 2 };

            //Act
            await skillService.AddAsync(skill);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillRepository.AddAsync(It.Is<Skill>(b => b.Name == skill.Name && b.Description == skill.Description && b.CategoryId == skill.CategoryId)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void SkillService_AddAsync_ThrowsKASExceptionWithEmptyName()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.AddAsync(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skill = new SkillModel { Name = "", Description = "TestDescription", CategoryId = 2 };

            Assert.ThrowsAsync<KASException>(() => skillService.AddAsync(skill));
        }

        [Test]
        public void SkillService_AddAsync_ThrowsKASExceptionWithEmptyDescription()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.AddAsync(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skill = new SkillModel { Name = "TestName", Description = "", CategoryId = 2 };

            Assert.ThrowsAsync<KASException>(() => skillService.AddAsync(skill));
        }

        [Test]
        public void SkillService_AddAsync_ThrowsKASExceptionWithEmptyCategoryId()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.AddAsync(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skill = new SkillModel { Name = "TestName", Description = "TestDescription", CategoryId = null };

            Assert.ThrowsAsync<KASException>(() => skillService.AddAsync(skill));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        public async Task SkillService_DeleteByIdAsync_DeletesSkill(int skillId)
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.DeleteByIdAsync(It.IsAny<int>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await skillService.DeleteByIdAsync(skillId);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillRepository.DeleteByIdAsync(skillId), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task SkillService_UpdateAsync_UpdatesSkillCategory()
        {
            //Arrange
            var skill = new SkillModel { Id = 1, Name = "TestCategory", Description = "TestDescription", CategoryId = 2 };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.Update(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await skillService.UpdateAsync(skill);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillRepository.Update(It.Is<Skill>(b => b.Name == skill.Name && b.Description == skill.Description && b.CategoryId == skill.CategoryId)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void SkillService_UpdateAsync_ThrowsKASExceptionWithEmptyId()
        {
            //Arrange
            var skill = new SkillModel { Id = null, Name = "TestCategory", Description = "TestDescription", CategoryId = 2 };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.Update(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => skillService.UpdateAsync(skill));
        }

        [Test]
        public void SkillService_UpdateAsync_ThrowsKASExceptionWithEmptyName()
        {
            //Arrange
            var skill = new SkillModel { Id = 1, Name = "", Description = "TestDescription", CategoryId = 2 };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.Update(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => skillService.UpdateAsync(skill));
        }

        [Test]
        public void SkillService_UpdateAsync_ThrowsKASExceptionWithEmptyDescription()
        {
            //Arrange
            var skill = new SkillModel { Id = 1, Name = "TestCategory", Description = "", CategoryId = 2 };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.Update(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => skillService.UpdateAsync(skill));
        }

        [Test]
        public void SkillService_UpdateAsync_ThrowsKASExceptionWithEmptyCategoryId()
        {
            //Arrange
            var skill = new SkillModel { Id = 1, Name = "TestCategory", Description = "TestDescription", CategoryId = null };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillRepository.Update(It.IsAny<Skill>()));
            var skillService = new SkillService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => skillService.UpdateAsync(skill));
        }
    }
}

