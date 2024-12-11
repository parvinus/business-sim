using BusinessSim.Data.Enumerations;
using BusinessSim.Data.Models.BankAccount;
using BusinessSim.Data.Models.Response;
using BusinessSim.Server.Controllers;
using BusinessSim.Services.BankAccount;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
public class BankAccountControllerTests
{
    private Mock<IBankAccountService> _mockBankAccountService;
    private BankAccountController _controller;
    [SetUp]
    public void SetUp()
    {
        _mockBankAccountService = new Mock<IBankAccountService>();
        _controller = new BankAccountController(_mockBankAccountService.Object);
    }
    [Test]
    public void GetByPlayerId_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var playerId = Guid.NewGuid();
        var expectedBankAccounts = new List<BankAccountDto> { new BankAccountDto() };
        _mockBankAccountService.Setup(s => s.GetByParentId(playerId, AccountType.Player)).Returns(expectedBankAccounts);
        // Act
        var result = _controller.GetByPlayerId(playerId);
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var responseDto = okResult.Value as ResponseDto<List<BankAccountDto>>;
        Assert.IsNotNull(responseDto);
        Assert.AreEqual(expectedBankAccounts, responseDto.Data);
    }
    // Add similar tests for other methods of the BankAccountController class
    
    [Test]
    public void GetById_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var accountId = Guid.NewGuid();
        var expectedBankAccount = new BankAccountDto { Id = accountId };
        _mockBankAccountService.Setup(s => s.GetById(accountId)).Returns(expectedBankAccount);
        // Act
        var result = _controller.GetById(accountId);
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var responseDto = okResult.Value as ResponseDto<BankAccountDto>;
        Assert.IsNotNull(responseDto);
        Assert.AreEqual(expectedBankAccount, responseDto.Data);
    }
    
    [Test]
    public void UpdateBalance_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var accountId = Guid.NewGuid();
        var newBalance = 1000m;
        var expectedBankAccount = new BankAccountDto { Id = accountId, Balance = newBalance };
        _mockBankAccountService.Setup(s => s.UpdateBalance(accountId, newBalance)).Returns(expectedBankAccount);
        // Act
        var result = _controller.UpdateBalance(accountId, newBalance);
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var responseDto = okResult.Value as ResponseDto<BankAccountDto>;
        Assert.IsNotNull(responseDto);
        Assert.AreEqual(expectedBankAccount, responseDto.Data);
    }
    
    [Test]
    public void CreateBankAccount_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var createDto = new CreateBankAccountDto
        {
            Name = "Test Account",
            Balance = 500m,
            Type = AccountType.Player,
            ParentId = Guid.NewGuid(),
            CurrencyUnit = CurrencyUnit.Usd
        };
        var expectedBankAccount = new BankAccountDto
        {
            Id = Guid.NewGuid(),
            Name = createDto.Name,
            Balance = createDto.Balance,
            Type = createDto.Type,
            ParentId = createDto.ParentId,
            CurrencyUnit = createDto.CurrencyUnit
        };
        _mockBankAccountService.Setup(s => s.Create(createDto)).Returns(expectedBankAccount);
        // Act
        var result = _controller.CreateBankAccount(createDto);
        // Assert
        var createdResult = result as OkObjectResult;
        Assert.IsNotNull(createdResult);
        var responseDto = createdResult.Value as ResponseDto<BankAccountDto>;
        Assert.IsNotNull(responseDto);
        Assert.AreEqual(expectedBankAccount, responseDto.Data);
    }
    
    [Test]
    public void DeleteBankAccount_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var accountId = Guid.NewGuid();
        _mockBankAccountService.Setup(s => s.Delete(accountId)).Returns(true);
        // Act
        var result = _controller.DeleteBankAccount(accountId);
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var statusCode = okResult.StatusCode;
        Assert.AreEqual(statusCode, 200);
    }
    
    [Test]
    public void UpdateBankAccount_WhenCalled_ReturnsExpectedResult()
    {
        // Arrange
        var updateDto = new BankAccountDto
        {
            Id = Guid.NewGuid(),
            Name = "Updated Account",
            Balance = 1500m,
            Type = AccountType.Business,
            ParentId = Guid.NewGuid(),
            CurrencyUnit = CurrencyUnit.Btc
        };
        var expectedBankAccount = new BankAccountDto
        {
            Id = updateDto.Id,
            Name = updateDto.Name,
            Balance = updateDto.Balance,
            Type = updateDto.Type,
            ParentId = updateDto.ParentId,
            CurrencyUnit = updateDto.CurrencyUnit
        };
        _mockBankAccountService.Setup(s => s.Update(updateDto)).Returns(expectedBankAccount);
        // Act
        var result = _controller.UpdateBankAccount(updateDto);
        // Assert
        var updatedResult = result as OkObjectResult;
        Assert.IsNotNull(updatedResult);
        var responseDto = updatedResult.Value as ResponseDto<BankAccountDto>;
        Assert.IsNotNull(responseDto);
        Assert.AreEqual(expectedBankAccount, responseDto.Data);
    }
}
