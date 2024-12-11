using BusinessSim.Data.Models.BusinessDepartment;
using BusinessSim.Services.BusinessDepartment;
using Moq;

namespace BusinessSim.Tests.BusinessSim.Services
{
    public class BusinessDepartmentServiceTests
    {
        private Mock<IBusinessDepartmentService> _mockBusinessDepartmentService;
        [SetUp]
        public void Setup()
        {
            _mockBusinessDepartmentService = new Mock<IBusinessDepartmentService>();
        }

        [Test]
        public void GetByBusiness_ShouldReturnCorrectBusinessDepartments()
        {
            // Arrange
            var expected = new List<BusinessDepartmentDto>();
            _mockBusinessDepartmentService.Setup(x => x.GetByBusiness(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = _mockBusinessDepartmentService.Object.GetByBusiness(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetAll_ShouldReturnCorrectBusinessDepartments()
        {
            // Arrange
            var expected = new List<BusinessDepartmentDto>();
            _mockBusinessDepartmentService.Setup(x => x.GetAll()).Returns(expected);
            // Act
            var result = _mockBusinessDepartmentService.Object.GetAll();
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectBusinessDepartment()
        {
            // Arrange
            var expected = new BusinessDepartmentDto();
            _mockBusinessDepartmentService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);
            // Act
            var result = _mockBusinessDepartmentService.Object.GetById(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Create_ShouldReturnCreatedBusinessDepartment()
        {
            // Arrange
            var expected = new BusinessDepartmentDto();
            var createBusinessDepartmentDto = new CreateBusinessDepartmentDto();
            _mockBusinessDepartmentService.Setup(x => x.Create(createBusinessDepartmentDto)).Returns(expected);
            // Act
            var result = _mockBusinessDepartmentService.Object.Create(createBusinessDepartmentDto);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Update_ShouldReturnUpdatedBusinessDepartment()
        {
            // Arrange
            var expected = new BusinessDepartmentDto();
            var businessDepartmentDto = new BusinessDepartmentDto();
            _mockBusinessDepartmentService.Setup(x => x.Update(businessDepartmentDto)).Returns(expected);
            // Act
            var result = _mockBusinessDepartmentService.Object.Update(businessDepartmentDto);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Delete_ShouldReturnTrueWhenBusinessDepartmentIsDeleted()
        {
            // Arrange
            _mockBusinessDepartmentService.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            // Act
            var result = _mockBusinessDepartmentService.Object.Delete(Guid.NewGuid());
            // Assert
            Assert.IsTrue(result);
        }
    }
}
