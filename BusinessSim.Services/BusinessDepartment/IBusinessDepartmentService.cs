using BusinessSim.Data.Models.BusinessDepartment;

namespace BusinessSim.Services.BusinessDepartment
{
    public interface IBusinessDepartmentService
    {
        List<BusinessDepartmentDto> GetByBusiness(Guid businessId);
        List<BusinessDepartmentDto> GetAll();
        BusinessDepartmentDto GetById(Guid id);
        BusinessDepartmentDto Create(CreateBusinessDepartmentDto  businessDepartmentDto);
        BusinessDepartmentDto Update(BusinessDepartmentDto businessDepartmentDto);
        bool Delete(Guid id);
    }
}
