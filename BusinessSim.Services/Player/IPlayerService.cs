using BusinessSim.Data.Models.Player;

namespace BusinessSim.Services.Player
{
    public interface IPlayerService
    {
        List<PlayerDto> GetAll();
        PlayerDto GetById(Guid id);
        
        PlayerDto Create(CreatePlayerDto player);
        PlayerDto Update(PlayerDto player);
        
        bool Delete(Guid id);
    }
}
