using AutoMapper;
using BusinessSim.Data.Contexts;
using BusinessSim.Data.Models.Player;
using Microsoft.Extensions.Configuration;

namespace BusinessSim.Services.Player
{
    public class PlayerService(IConfiguration configuration, IMapper mapper) : IPlayerService
    {
        private readonly BusinessSimDbContext _context = new(configuration);

        public List<PlayerDto> GetAll()
        {
            var players = _context.Players.ToList();
            var playerDtoList = mapper.Map<List<PlayerDto>>(players);

            return playerDtoList;
        }

        public PlayerDto GetById(Guid id)
        {
            var player = _context.Players
                .FirstOrDefault(x => x.Id == id);
            
            return mapper.Map<PlayerDto>(player);
        }

        public PlayerDto Create(CreatePlayerDto player)
        {
            var playerEntity = mapper.Map<Data.Entities.Player>(player);
            
            _context.Players.Add(playerEntity);
            _context.SaveChanges();
            
            return mapper.Map<PlayerDto>(playerEntity);
        }

        public PlayerDto Update(PlayerDto player)
        {
            var playerEntity = _context.Players
                .FirstOrDefault(p => p.Id == player.Id);

            if (playerEntity == null)
            {
                throw new InvalidOperationException($"Player was not found.  Id value provided was {player.Id}");
            }

            mapper.Map(player, playerEntity);
            
            _context.Players.Update(playerEntity);
            _context.SaveChanges();

            return mapper.Map<PlayerDto>(playerEntity);
        }

        public bool Delete(Guid id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return false;
            }

            _context.Players.Remove(player);
            return _context.SaveChanges() > 0;
        }
    }
}
