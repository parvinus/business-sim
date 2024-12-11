using BusinessSim.Data.Models.Business;

namespace BusinessSim.Services.Business
{
    public interface IBusinessService
    {
        List<BusinessDto> GetAll();
        List<BusinessDto> GetByPlayer(Guid playerId);
        BusinessDto GetById(Guid id);
        BusinessDto Create(CreateBusinessDto createBusinessDto);
        bool Delete(Guid id);
    }
}
