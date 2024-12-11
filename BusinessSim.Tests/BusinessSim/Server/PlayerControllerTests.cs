using BusinessSim.Data.Models.Player;
using BusinessSim.Data.Models.Response;
using BusinessSim.Server.Controllers;
using BusinessSim.Services.Player;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BusinessSim.Tests.BusinessSim.Server
{
    [TestFixture]
    public class PlayerControllerTests
    {
        private Mock<IPlayerService> _mockPlayerService;
        private PlayerController _controller;
        [SetUp]
        public void SetUp()
        {
            _mockPlayerService = new Mock<IPlayerService>();
            _controller = new PlayerController(_mockPlayerService.Object);
        }
        [Test]
        public void GetById_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var expectedPlayer = new PlayerDto { Id = playerId };
            _mockPlayerService.Setup(s => s.GetById(playerId)).Returns(expectedPlayer);
            // Act
            var result = _controller.GetById(playerId);
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseDto = okResult.Value as ResponseDto<PlayerDto>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(expectedPlayer, responseDto.Data);
        }
        // Add similar tests for other methods of the PlayerController class
        [Test]
        public void CreatePlayer_WhenCalled_ReturnsCreatedResult()
        {
            // Arrange
            var playerDto = new CreatePlayerDto { Name = "John Doe" };
            var createdPlayer = new PlayerDto { Id = Guid.NewGuid(), Name = playerDto.Name };
            _mockPlayerService.Setup(s => s.Create(playerDto)).Returns(createdPlayer);
            // Act
            var result = _controller.CreatePlayer(playerDto);
            // Assert
            var createdResult = result as OkObjectResult;
            Assert.IsNotNull(createdResult);
            var responseDto = createdResult.Value as ResponseDto<PlayerDto>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(createdPlayer, responseDto.Data);
        }
        
        [Test]
        public void UpdatePlayer_WhenCalled_ReturnsUpdatedResult()
        {
            // Arrange
            var playerDto = new PlayerDto { Id = Guid.NewGuid(), Name = "Jane Doe" };
            var updatedPlayer = new PlayerDto { Id = playerDto.Id, Name = "Jane Smith" };
            _mockPlayerService.Setup(s => s.Update(playerDto)).Returns(updatedPlayer);
            // Act
            var result = _controller.UpdatePlayer(playerDto);
            // Assert
            var updatedResult = result as OkObjectResult;
            Assert.IsNotNull(updatedResult);
            var responseDto = updatedResult.Value as ResponseDto<PlayerDto>;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual(updatedPlayer, responseDto.Data);
        }
        
        [Test]
        public void DeletePlayer_ExistingPlayer_ReturnsDeletedResult()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            _mockPlayerService.Setup(s => s.Delete(playerId)).Returns(true);
            // Act
            var result = _controller.DeletePlayer(playerId);
            // Assert
            var deletedResult = result as OkObjectResult;
            Assert.IsNotNull(deletedResult);
            var responseDto = deletedResult.Value as ResponseDto;
            Assert.IsNotNull(responseDto);
            Assert.IsTrue(responseDto.IsSuccessful);
            Assert.AreEqual($"Player with id {playerId} deleted successfully", responseDto.Message);
        }
    }
}
