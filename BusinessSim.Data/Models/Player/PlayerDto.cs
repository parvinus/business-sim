using BusinessSim.Data.Entities;
using BusinessSim.Data.Models.Business;

namespace BusinessSim.Data.Models.Player
{
    public class PlayerDto : CreatePlayerDto
    {
        public Guid Id { get; set; }

        public IList<BusinessDto> Businesses { get; set; } = new List<BusinessDto>();
    }
}
