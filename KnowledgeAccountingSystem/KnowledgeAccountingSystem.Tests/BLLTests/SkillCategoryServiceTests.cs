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
    public class SkillCategoryServiceTests
    {
        [Test]
        public void SkillCategoryService_GetAll_ReturnsSkillCategoryModels()
        {
            var expected = GetTestSkillCategoryModels().ToList();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.SkillCategoryRepository.FindAll())
                .Returns(GetTestSkillCategoryEntities().AsQueryable);
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = skillCategoryService.GetAll().ToList();

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
            }
        }

        private IEnumerable<SkillCategory> GetTestSkillCategoryEntities()
        {
            return new List<SkillCategory>()
            {
                new SkillCategory() { Id=1, Name = "Programming languages"},
                new SkillCategory() { Id=2, Name = "Operating systems"},
                new SkillCategory() { Id=3, Name = "Platforms"}
            };
        }


        [Test]
        public async Task SkillCategoryService_GetByIdAsync_ReturnsSkillCategoryModel()
        {
            var expected = GetTestSkillCategoryModels().First();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.SkillCategoryRepository.GetByIdWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(GetTestSkillCategoryEntities().First);
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = await skillCategoryService.GetByIdAsync(1);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        private IEnumerable<SkillCategoryModel> GetTestSkillCategoryModels()
        {
            return new List<SkillCategoryModel>()
            {
                new SkillCategoryModel() { Id=1, Name = "Programming languages"},
                new SkillCategoryModel() { Id=2, Name = "Operating systems"},
                new SkillCategoryModel() { Id=3, Name = "Platforms"}
            };
        }

        [Test]
        public async Task SkillCategoryService_AddAsync_AddsModel()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillCategoryRepository.AddAsync(It.IsAny<SkillCategory>()));
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skillCategory = new SkillCategoryModel { Name = "TestCategory" };

            //Act
            await skillCategoryService.AddAsync(skillCategory);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillCategoryRepository.AddAsync(It.Is<SkillCategory>(b => b.Name == skillCategory.Name)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void SkillCategoryService_AddAsync_ThrowsKASExceptionWithEmptyName()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillCategoryRepository.AddAsync(It.IsAny<SkillCategory>()));
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var skillCategory = new SkillCategoryModel { Name = "" };

            Assert.ThrowsAsync<KASException>(() => skillCategoryService.AddAsync(skillCategory));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        public async Task SkillCategoryService_DeleteByIdAsync_DeletesSkillCategory(int skillCategoryId)
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillCategoryRepository.DeleteByIdAsync(It.IsAny<int>()));
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await skillCategoryService.DeleteByIdAsync(skillCategoryId);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillCategoryRepository.DeleteByIdAsync(skillCategoryId), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task SkillCategoryService_UpdateAsync_UpdatesSkillCategory()
        {
            //Arrange
            var skillCategory = new SkillCategoryModel { Id = 1, Name = "Test"};
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillCategoryRepository.Update(It.IsAny<SkillCategory>()));
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await skillCategoryService.UpdateAsync(skillCategory);

            //Assert
            mockUnitOfWork.Verify(x => x.SkillCategoryRepository.Update(It.Is<SkillCategory>(b => b.Name == skillCategory.Name)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void SkillCategoryService_UpdateAsync_ThrowsKASExceptionWithEmptyName()
        {
            //Arrange
            var skillCategory = new SkillCategoryModel { Id = 1, Name = "" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SkillCategoryRepository.Update(It.IsAny<SkillCategory>()));
            var skillCategoryService = new SkillCategoryService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => skillCategoryService.UpdateAsync(skillCategory));
        }
    }
}
