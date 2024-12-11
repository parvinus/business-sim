using NUnit.Framework;
using Moq;
using BusinessSim.Services.Business;
using BusinessSim.Data.Models.Business;
using System;
namespace BusinessSim.Tests.BusinessSim.Services
{
    public class BusinessServiceTests
    {
        private Mock<IBusinessService> _mockBusinessService;
        [SetUp]
        public void Setup()
        {
            _mockBusinessService = new Mock<IBusinessService>();
        }
        [Test]
        public void GetAll_ShouldReturnCorrectBusinesses()
        {
            // Arrange
            var expected = new List<BusinessDto>();
            _mockBusinessService.Setup(x => x.GetAll()).Returns(expected);
            // Act
            var result = _mockBusinessService.Object.GetAll();
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetByPlayer_ShouldReturnCorrectBusinesses()
        {
            // Arrange
            var expected = new List<BusinessDto>();
            _mockBusinessService.Setup(x => x.GetByPlayer(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = _mockBusinessService.Object.GetByPlayer(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetById_ShouldReturnCorrectBusiness()
        {
            // Arrange
            var expected = new BusinessDto();
            _mockBusinessService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = _mockBusinessService.Object.GetById(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Create_ShouldReturnCreatedBusiness()
        {
            // Arrange
            var expected = new BusinessDto();
            var createBusinessDto = new CreateBusinessDto();
            _mockBusinessService.Setup(x => x.Create(createBusinessDto)).Returns(expected);
            // Act
            var result = _mockBusinessService.Object.Create(createBusinessDto);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Delete_ShouldReturnTrueWhenBusinessIsDeleted()
        {
            // Arrange
            _mockBusinessService.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            // Act
            var result = _mockBusinessService.Object.Delete(Guid.NewGuid());
            // Assert
            Assert.IsTrue(result);
        }
    }
}
