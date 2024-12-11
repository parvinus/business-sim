using System.Net;
using BusinessSim.Data.Models.Business;
using BusinessSim.Data.Models.Response;
using BusinessSim.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSim.Server.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController(IBusinessService businessService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var businesses = businessService.GetAll();
            var responseDto = new ResponseDto<List<BusinessDto>>
            {
                Data = businesses,
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
            return Ok(responseDto);
        }
        
        [HttpGet("[action]/{playerId}")]
        public IActionResult GetByPlayer(Guid playerId)
        {
            var businesses = businessService.GetByPlayer(playerId);
            var responseDto = new ResponseDto<List<BusinessDto>>
            {
                Data = businesses,
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = businesses.Any()
            };
            return Ok(responseDto);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var business = businessService.GetById(id);
            var responseDto = new ResponseDto<BusinessDto>
            {
                Data = business,
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = business.Id != Guid.Empty
            };
            return Ok(responseDto);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateBusinessDto createBusinessDto)
        {
            var business = businessService.Create(createBusinessDto);
            var responseDto = new ResponseDto<BusinessDto>
            {
                Data = business,
                StatusCode = HttpStatusCode.Created,
                IsSuccessful = business.Id != Guid.Empty
            };
            return Ok(responseDto);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = businessService.Delete(id);
            var responseDto = new ResponseDto
            {
                Data = result,
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = result
            };
            return Ok(responseDto);
        }
    }   
}
