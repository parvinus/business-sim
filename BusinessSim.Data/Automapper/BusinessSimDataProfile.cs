using AutoMapper;
using BusinessSim.Data.Entities;
using BusinessSim.Data.Models.Player;

namespace BusinessSim.Data.Automapper
{
    public class BusinessSimDataProfile : Profile
    {
        public BusinessSimDataProfile()
        {
            // Add mapping configurations here
            CreateMap<Player, CreatePlayerDto>()
                .ReverseMap();
            CreateMap<Player, PlayerDto>()
                .ReverseMap();
            
            
        }
    }
}
