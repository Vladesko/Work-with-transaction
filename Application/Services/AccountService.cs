using Application.Interfaces;
using Domain;

namespace Application.Services
{
    internal class AccountService(IAccountRepository accountRepository) : IAccountService
    {
        private readonly IAccountRepository accountRepository = accountRepository;
        public Task<List<Account>> GetAccountsAsync()
        {
            var accounts = accountRepository.GetAccountsAsync();
            return accounts;
        }
    }
}
