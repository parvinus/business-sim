using BusinessSim.Data.Enumerations;
using BusinessSim.Data.Models.Business;
using BusinessSim.Data.Models.Response;
using BusinessSim.Server.Controllers;
using BusinessSim.Services.Business;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BusinessSim.Tests.BusinessSim.Server
{
    [TestFixture]
    public class BusinessControllerTests
    {
        private Mock<IBusinessService> _mockBusinessService;
        private BusinessController _controller;
        [SetUp]
        public void SetUp()
        {
            _mockBusinessService = new Mock<IBusinessService>();
            _controller = new BusinessController(_mockBusinessService.Object);
        }
        [Test]
        public void GetAll_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var expectedBusinesses = new List<BusinessDto> { new BusinessDto() };
            _mockBusinessService.Setup(s => s.GetAll()).Returns(expectedBusinesses);
            // Act
            var result = _controller.GetAll();
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseDto = okResult.Value as ResponseDto<List<BusinessDto>>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(expectedBusinesses, responseDto.Data);
        }
        // Add similar tests for other methods of the BusinessController class
        
        [Test]
        public void GetByPlayer_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var expectedBusinesses = new List<BusinessDto> { new BusinessDto() };
            _mockBusinessService.Setup(s => s.GetByPlayer(playerId)).Returns(expectedBusinesses);
            // Act
            var result = _controller.GetByPlayer(playerId);
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseDto = okResult.Value as ResponseDto<List<BusinessDto>>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(expectedBusinesses, responseDto.Data);
        }
        
        [Test]
        public void GetById_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var businessId = Guid.NewGuid();
            var expectedBusiness = new BusinessDto { Id = businessId };
            _mockBusinessService.Setup(s => s.GetById(businessId)).Returns(expectedBusiness);
            // Act
            var result = _controller.GetById(businessId);
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseDto = okResult.Value as ResponseDto<BusinessDto>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(expectedBusiness, responseDto.Data);
        }
        
        [Test]
        public void Create_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var createBusinessDto = new CreateBusinessDto
            {
                PlayerId = Guid.NewGuid(), Name = "New Business", Industry = Industry.Farming
            };
            var expectedBusiness = new BusinessDto
            {
                Id = Guid.NewGuid(),
                PlayerId = createBusinessDto.PlayerId,
                Name = createBusinessDto.Name,
                Industry = createBusinessDto.Industry
            };
            _mockBusinessService.Setup(s => s.Create(createBusinessDto)).Returns(expectedBusiness);
            // Act
            var result = _controller.Create(createBusinessDto);
            // Assert
            var createdResult = result as OkObjectResult;
            
            Assert.IsNotNull(createdResult);
            var responseDto = createdResult.Value as ResponseDto<BusinessDto>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(expectedBusiness, responseDto.Data);
        }
        
        [Test]
        public void Delete_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var businessId = Guid.NewGuid();
            _mockBusinessService.Setup(s => s.Delete(businessId)).Returns(true);
            // Act
            var result = _controller.Delete(businessId);
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseDto = okResult.Value as ResponseDto;
            Assert.IsNotNull(responseDto);
            Assert.IsTrue(responseDto.IsSuccessful);
        }
    }

}
