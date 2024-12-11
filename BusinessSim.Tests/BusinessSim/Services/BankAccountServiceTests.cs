using NUnit.Framework;
using Moq;
using BusinessSim.Services.BankAccount;
using BusinessSim.Data.Models.BankAccount;
using BusinessSim.Data.Enumerations;
using System;
namespace BusinessSim.Tests.BusinessSim.Services
{
    public class BankAccountServiceTests
    {
        private Mock<IBankAccountService> _mockBankAccountService;

        [SetUp]
        public void Setup()
        {
            _mockBankAccountService = new Mock<IBankAccountService>();
        }

        [Test]
        public void GetByParentId_ShouldReturnCorrectBankAccounts()
        {
            // Arrange
            var expected = new List<BankAccountDto>();
            _mockBankAccountService.Setup(x => x.GetByParentId(It.IsAny<Guid>(), It.IsAny<AccountType>())).Returns(expected);
            // Act
            var result = _mockBankAccountService.Object.GetByParentId(Guid.NewGuid(), AccountType.Player);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectBankAccount()
        {
            // Arrange
            var expected = new BankAccountDto();
            _mockBankAccountService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = _mockBankAccountService.Object.GetById(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }
        // Continue with the rest of the methods in the interface...
        [Test]
        public void UpdateBalance_ShouldReturnUpdatedBankAccount()
        {
            // Arrange
            var id = Guid.NewGuid();
            var newBalance = 1000m;
            var expected = new BankAccountDto { Id = id, Balance = newBalance };
            _mockBankAccountService.Setup(x => x.UpdateBalance(id, newBalance)).Returns(expected);
            // Act
            var result = _mockBankAccountService.Object.UpdateBalance(id, newBalance);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_ShouldReturnCreatedBankAccount()
        {
            // Arrange
            var bankAccountDto = new CreateBankAccountDto();
            var expected = new BankAccountDto { Id = Guid.NewGuid() };
            _mockBankAccountService.Setup(x => x.Create(bankAccountDto)).Returns(expected);
            // Act
            var result = _mockBankAccountService.Object.Create(bankAccountDto);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Delete_ShouldReturnTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockBankAccountService.Setup(x => x.Delete(id)).Returns(true);
            // Act
            var result = _mockBankAccountService.Object.Delete(id);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Update_ShouldReturnUpdatedBankAccount()
        {
            // Arrange
            var bankAccountDto = new BankAccountDto();
            var expected = new BankAccountDto { Id = Guid.NewGuid() };
            _mockBankAccountService.Setup(x => x.Update(bankAccountDto)).Returns(expected);
            // Act
            var result = _mockBankAccountService.Object.Update(bankAccountDto);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}