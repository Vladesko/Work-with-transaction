using Application.Interfaces.TransactionInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBank.Models.TransactionsDto;
using WebApiBank.Commons.Mapping;

namespace WebApiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(ITransactionsService transactionsService) : ControllerBase
    {
        private readonly ITransactionsService transactionsService = transactionsService;

        [HttpPost]
        public async Task<IActionResult> TransactionByNickname([FromBody] TransactionsByNicknameDto dto)
        {
            await transactionsService.TransferMoneyByNicknameAsync(new TransactionsMapper().MapWith(dto));
            return Ok();
        }
    }
}
