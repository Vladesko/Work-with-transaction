using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBank.Commons;
using WebApiBank.Models;

namespace WebApiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService accountService = accountService;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await accountService.GetAccountsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(Guid id)
        {
            var result = await accountService.GetAccountByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var result = await accountService.CreateAccountAsync(new AccountMapper().MapWith(dto));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await accountService.RemoveAccountByIdAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountDto dto)
        {
            await accountService.UpdateNicknameAsync(new AccountMapper().MapWith(dto));
            return NoContent();
        }
    }
}
