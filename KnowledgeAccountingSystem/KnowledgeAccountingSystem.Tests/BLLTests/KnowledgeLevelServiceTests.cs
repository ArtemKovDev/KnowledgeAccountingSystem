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
    public class KnowledgeLevelServiceTests
    {
        [Test]
        public void KnowledgeLevelService_GetAll_ReturnsKnowledgeLevelModels()
        {
            var expected = GetTestKnowledgeLevelModels().ToList();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.KnowledgeLevelRepository.FindAll())
                .Returns(GetTestKnowledgeLevelEntities().AsQueryable);
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = knowledgeLevelService.GetAll().ToList();

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Description, actual[i].Description);
            }
        }

        private IEnumerable<KnowledgeLevel> GetTestKnowledgeLevelEntities()
        {
            return new List<KnowledgeLevel>()
            {
                new KnowledgeLevel() { Id=1, Name = "Beginner", Description = "Basic theoretical knowledge"},
                new KnowledgeLevel() { Id=2, Name = "Medium", Description = "Good theoretical knowledge, practical skills"}
            };
        }


        [Test]
        public async Task KnowledgeLevelService_GetByIdAsync_ReturnsKnowledgeLevelModel()
        {
            var expected = GetTestKnowledgeLevelModels().First();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.KnowledgeLevelRepository.GetByIdWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(GetTestKnowledgeLevelEntities().First);
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            var actual = await knowledgeLevelService.GetByIdAsync(1);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
        }

        private IEnumerable<KnowledgeLevelModel> GetTestKnowledgeLevelModels()
        {
            return new List<KnowledgeLevelModel>()
            {
                new KnowledgeLevelModel() { Id=1, Name = "Beginner", Description = "Basic theoretical knowledge"},
                new KnowledgeLevelModel() { Id=2, Name = "Medium", Description = "Good theoretical knowledge, practical skills"}
            };
        }

        [Test]
        public async Task KnowledgeLevelService_AddAsync_AddsModel()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.AddAsync(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var knowledgeLevel = new KnowledgeLevelModel { Name = "TestName", Description = "TestDescription" };

            //Act
            await knowledgeLevelService.AddAsync(knowledgeLevel);

            //Assert
            mockUnitOfWork.Verify(x => x.KnowledgeLevelRepository.AddAsync(It.Is<KnowledgeLevel>(b => b.Name == knowledgeLevel.Name && b.Description == knowledgeLevel.Description)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void KnowledgeLevelService_AddAsync_ThrowsKASExceptionWithEmptyName()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.AddAsync(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var knowledgeLevel = new KnowledgeLevelModel { Name = "", Description = "TestDescription" };

            Assert.ThrowsAsync<KASException>(() => knowledgeLevelService.AddAsync(knowledgeLevel));
        }

        [Test]
        public void KnowledgeLevelService_AddAsync_ThrowsKASExceptionWithEmptyDescription()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.AddAsync(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var knowledgeLevel = new KnowledgeLevelModel { Name = "TestName", Description = "" };

            Assert.ThrowsAsync<KASException>(() => knowledgeLevelService.AddAsync(knowledgeLevel));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        public async Task KnowledgeLevelService_DeleteByIdAsync_DeletesKnowledgeLevel(int knowledgeLevelId)
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.DeleteByIdAsync(It.IsAny<int>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await knowledgeLevelService.DeleteByIdAsync(knowledgeLevelId);

            //Assert
            mockUnitOfWork.Verify(x => x.KnowledgeLevelRepository.DeleteByIdAsync(knowledgeLevelId), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task KnowledgeLevelService_UpdateAsync_UpdatesKnowledgeLevel()
        {
            //Arrange
            var knowledgeLevel = new KnowledgeLevelModel { Id = 1, Name = "TestName", Description = "TestDescription" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.Update(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //Act
            await knowledgeLevelService.UpdateAsync(knowledgeLevel);

            //Assert
            mockUnitOfWork.Verify(x => x.KnowledgeLevelRepository.Update(It.Is<KnowledgeLevel>(b => b.Name == knowledgeLevel.Name && b.Description == knowledgeLevel.Description)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void KnowledgeLevelService_UpdateAsync_ThrowsKASExceptionWithEmptyId()
        {
            //Arrange
            var knowledgeLevel = new KnowledgeLevelModel { Id = null, Name = "TestName", Description = "TestDescription" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.Update(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => knowledgeLevelService.UpdateAsync(knowledgeLevel));
        }

        [Test]
        public void KnowledgeLevelService_UpdateAsync_ThrowsKASExceptionWithEmptyName()
        {
            //Arrange
            var knowledgeLevel = new KnowledgeLevelModel { Id = 1, Name = "", Description = "TestDescription" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.Update(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => knowledgeLevelService.UpdateAsync(knowledgeLevel));
        }

        [Test]
        public void KnowledgeLevelService_UpdateAsync_ThrowsKASExceptionWithEmptyDescription()
        {
            //Arrange
            var knowledgeLevel = new KnowledgeLevelModel { Id = 1, Name = "TestName", Description = "" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.KnowledgeLevelRepository.Update(It.IsAny<KnowledgeLevel>()));
            var knowledgeLevelService = new KnowledgeLevelService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

            Assert.ThrowsAsync<KASException>(() => knowledgeLevelService.UpdateAsync(knowledgeLevel));
        }
    }
}
