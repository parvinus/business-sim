using System.Net;
using BusinessSim.Data.Models.Player;
using BusinessSim.Data.Models.Response;
using BusinessSim.Services.Player;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSim.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(IPlayerService playerService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = playerService.GetById(id);

            if (result.Id == Guid.Empty)
            {
                var response = new ResponseDto()
                {
                    IsSuccessful = false,
                    Message = $"No player found matching id {id}",
                    StatusCode = HttpStatusCode.OK
                };

                return Ok(response);
            }

            var responseDto = new ResponseDto<PlayerDto>()
            {
                Data = result,
                IsSuccessful = true,
                StatusCode = HttpStatusCode.OK
            };

            return Ok(responseDto);
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] CreatePlayerDto playerDto)
        {
            var createdPlayer = playerService.Create(playerDto);
            var responseDto = new ResponseDto<PlayerDto>
            {
                Data = createdPlayer, 
                StatusCode = HttpStatusCode.Created, 
                IsSuccessful = true
            };
            return Ok(responseDto);
        }
        
        [HttpPut]
        public IActionResult UpdatePlayer([FromBody] PlayerDto updateDto)
        {
            var updatedPlayer = playerService.Update(updateDto);
            var responseDto = new ResponseDto<PlayerDto>
            {
                Data = updatedPlayer, 
                StatusCode = HttpStatusCode.OK, 
                IsSuccessful = true
            };
            return Ok(responseDto);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var isDeleted = playerService.Delete(id);

            if (!isDeleted)
            {
                var response = new ResponseDto()
                {
                    IsSuccessful = false,
                    Message = $"Player with id {id} not found",
                    StatusCode = HttpStatusCode.NotFound
                };

                return NotFound(response);
            }

            var responseDto = new ResponseDto()
            {
                IsSuccessful = true,
                Message = $"Player with id {id} deleted successfully",
                StatusCode = HttpStatusCode.OK
            };

            return Ok(responseDto);
        }
    }
}
