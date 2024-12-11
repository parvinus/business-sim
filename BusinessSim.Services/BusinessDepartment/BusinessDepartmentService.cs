using AutoMapper;
using BusinessSim.Data.Contexts;
using BusinessSim.Data.Models.BusinessDepartment;
using Microsoft.Extensions.Configuration;

namespace BusinessSim.Services.BusinessDepartment
{
    public class BusinessDepartmentService(IConfiguration configuration, IMapper mapper) : IBusinessDepartmentService
    {
        private readonly BusinessSimDbContext _context = new(configuration);

        public List<BusinessDepartmentDto> GetByBusiness(Guid businessId)
        {
            var departments = _context.BusinessDepartments
                .Where(bd => bd.BusinessId == businessId)
                .ToList();

            return mapper.Map<List<BusinessDepartmentDto>>(departments);
        }

        public List<BusinessDepartmentDto> GetAll()
        {
            var departments = _context.BusinessDepartments
                .ToList();

            return mapper.Map<List<BusinessDepartmentDto>>(departments);
        }

        public BusinessDepartmentDto GetById(Guid id)
        {
            var department = _context.BusinessDepartments
                .FirstOrDefault(bd => bd.Id == id);

            return mapper.Map<BusinessDepartmentDto>(department);
        }

        public BusinessDepartmentDto Create(CreateBusinessDepartmentDto businessDepartmentDto)
        {
            var department = mapper.Map<Data.Entities.BusinessDepartment>(businessDepartmentDto);
            _context.BusinessDepartments.Add(department);
            _context.SaveChanges();
            
            return mapper.Map<BusinessDepartmentDto>(department);
        }

        public BusinessDepartmentDto Update(BusinessDepartmentDto businessDepartmentDto)
        {
            var department = mapper.Map<Data.Entities.BusinessDepartment>(businessDepartmentDto);
            
            _context.BusinessDepartments.Update(department);
            _context.SaveChanges();

            return mapper.Map<BusinessDepartmentDto>(department);
        }

        public bool Delete(Guid id)
        {
            var department = _context.BusinessDepartments
                .FirstOrDefault(bd => bd.Id == id);

            if (department == null)
            {
                return false;
            }
            
            _context.BusinessDepartments.Remove(department);
            return _context.SaveChanges() > 0;
        }
    }
}
