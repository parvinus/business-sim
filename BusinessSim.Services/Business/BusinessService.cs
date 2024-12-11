using AutoMapper;
using BusinessSim.Data.Contexts;
using BusinessSim.Data.Models.Business;
using Microsoft.Extensions.Configuration;

namespace BusinessSim.Services.Business
{
    public class BusinessService(IConfiguration configuration, IMapper mapper) : IBusinessService
    {
        private readonly BusinessSimDbContext _context = new(configuration);

        public List<BusinessDto> GetAll()
        {
            var businesses = _context.Businesses.ToList();
            return mapper.Map<List<BusinessDto>>(businesses);
        }

        public List<BusinessDto> GetByPlayer(Guid playerId)
        {
            var businesses = _context.Businesses
                .Where(b => b.PlayerId == playerId)
                .ToList();

            return businesses.Any() 
                ? mapper.Map<List<BusinessDto>>(businesses) 
                : [];
        }

        public BusinessDto GetById(Guid id)
        {
            var business = _context.Businesses
                .FirstOrDefault(b => b.Id == id);

            return mapper.Map<BusinessDto>(business);
        }

        public BusinessDto Create(CreateBusinessDto createBusinessDto)
        {
            var business = mapper.Map<Data.Entities.Business>(createBusinessDto);
            
            _context.Businesses.Add(business);
            _context.SaveChanges();
            
            return mapper.Map<BusinessDto>(business);
        }

        public bool Delete(Guid id)
        {
            var business = _context.Businesses
                .FirstOrDefault(b => b.Id == id);

            if (business == null)
            {
                return true;
            }

            _context.Businesses.Remove(business);
            return _context.SaveChanges() > 0;
        }
    }
}
