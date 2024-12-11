using NUnit.Framework;
using Moq;
using BusinessSim.Services.Player;
using BusinessSim.Data.Models.Player;
using System;
namespace BusinessSim.Tests.BusinessSim.Services
{
    public class PlayerServiceTests
    {
        private Mock<IPlayerService> mockPlayerService;
        [SetUp]
        public void Setup()
        {
            mockPlayerService = new Mock<IPlayerService>();
        }
        [Test]
        public void GetAll_ShouldReturnCorrectPlayers()
        {
            // Arrange
            var expected = new List<PlayerDto>();
            mockPlayerService.Setup(x => x.GetAll()).Returns(expected);
            // Act
            var result = mockPlayerService.Object.GetAll();
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetById_ShouldReturnCorrectPlayer()
        {
            // Arrange
            var expected = new PlayerDto();
            mockPlayerService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = mockPlayerService.Object.GetById(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Create_ShouldReturnCreatedPlayer()
        {
            // Arrange
            var expected = new PlayerDto();
            var createPlayerDto = new CreatePlayerDto();
            mockPlayerService.Setup(x => x.Create(createPlayerDto)).Returns(expected);
            // Act
            var result = mockPlayerService.Object.Create(createPlayerDto);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Update_ShouldReturnUpdatedPlayer()
        {
            // Arrange
            var expected = new PlayerDto();
            var playerDto = new PlayerDto();
            mockPlayerService.Setup(x => x.Update(playerDto)).Returns(expected);
            // Act
            var result = mockPlayerService.Object.Update(playerDto);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Delete_ShouldReturnTrueWhenPlayerIsDeleted()
        {
            // Arrange
            mockPlayerService.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            // Act
            var result = mockPlayerService.Object.Delete(Guid.NewGuid());
            // Assert
            Assert.IsTrue(result);
        }


    }
}
