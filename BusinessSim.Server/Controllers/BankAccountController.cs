using System.Net;
using BusinessSim.Data.Enumerations;
using BusinessSim.Data.Models.BankAccount;
using BusinessSim.Data.Models.Response;
using BusinessSim.Services.BankAccount;
using Microsoft.AspNetCore.Mvc;

namespace BusinessSim.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController(IBankAccountService bankAccountService) : ControllerBase
    {
        [HttpGet("[action]/{playerId}")]
        public IActionResult GetByPlayerId(Guid playerId)
        {
            var responseDto = new ResponseDto<List<BankAccountDto>>
            {
                StatusCode = HttpStatusCode.OK, 
                IsSuccessful = true
            };

            if (playerId.Equals(Guid.Empty))
            {
                responseDto.StatusCode = HttpStatusCode.BadRequest;
                responseDto.Errors = ["PlayerId cannot be empty"];
                
                return BadRequest(responseDto);
            }
            
            var bankAccounts = bankAccountService.GetByParentId(playerId, AccountType.Player);

            if (bankAccounts.Any())
            {
                responseDto.Data = bankAccounts;
            } 
            else
            {
                responseDto.Message = "No results were found";
            }
            
            return Ok(responseDto);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById(Guid id)
        {
            var bankAccount = bankAccountService.GetById(id);

            if (bankAccount == null)
            {
                var response = new ResponseDto
                {
                    StatusCode = HttpStatusCode.NotFound, Message = "Bank account not found."
                };

                return NotFound(response);
            }

            var responseDto = new ResponseDto<BankAccountDto>
            {
                Data = bankAccount, StatusCode = HttpStatusCode.OK, IsSuccessful = true
            };

            return Ok(responseDto);
        }

        [HttpPut("{id}/[action]")]
        public IActionResult UpdateBalance(Guid id, [FromBody] decimal newBalance)
        {
            var updatedAccount = bankAccountService.UpdateBalance(id, newBalance);

            var responseDto = new ResponseDto<BankAccountDto>
            {
                Data = updatedAccount, StatusCode = HttpStatusCode.OK, IsSuccessful = true
            };

            return Ok(responseDto);
        }
        
        [HttpPost]
        public IActionResult CreateBankAccount([FromBody] CreateBankAccountDto bankAccountDto)
        {
            var createdAccount = bankAccountService.Create(bankAccountDto);

            var responseDto = new ResponseDto<BankAccountDto>
            {
                Data = createdAccount, StatusCode = HttpStatusCode.Created, IsSuccessful = true
            };

            return Ok(responseDto);
        }
        
        [HttpPut]
        public IActionResult UpdateBankAccount([FromBody] BankAccountDto updateDto)
        {
            var updatedAccount = bankAccountService.Update(updateDto);

            var responseDto = new ResponseDto<BankAccountDto>
            {
                Data = updatedAccount, 
                StatusCode = HttpStatusCode.OK, 
                IsSuccessful = true
            };

            return Ok(responseDto);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteBankAccount(Guid id)
        {
            var isDeleted = bankAccountService.Delete(id);
            
            var responseDto = new ResponseDto
            {
                StatusCode = HttpStatusCode.NoContent
            };

            if (isDeleted)
            {
                responseDto.IsSuccessful = true;
                return Ok(responseDto);
            }
            
            responseDto.IsSuccessful = false;
            responseDto.Message = "Bank account not found to delete.";

            return NotFound(responseDto);
        }
    }
}
