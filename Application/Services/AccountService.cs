using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using Domain;

namespace Application.Services
{
    internal class AccountService(IAccountRepository accountRepository,
                                  ICacheRepository cache) : IAccountService
    {
        private readonly IAccountRepository accountRepository = accountRepository;
        private readonly ICacheRepository cache = cache;
        public async Task<List<AccountsViewModel>> GetAccountsAsync()
        {
            var accounts = await cache.GetAccountsAsync();
            if (accounts != null)
                return accounts;

            accounts = await accountRepository.GetAccountsAsync();

            await cache.SetListOfAccountsToCacheAsync(accounts);

            return accounts;
        }
        public async Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id)
        {
            var accountFromCache = await cache.GetAccountByIdFromCahceAsync(id);
            if(accountFromCache != null) 
                return accountFromCache;

            var account = await accountRepository.GetAccountByIdAsync(id);

            await cache.SetAccountDetailsViewModelAsync(id, account);
            return account;
        }
        public async Task<Guid> CreateAccountAsync(CreateAccountViewModel model)
        {
            var result = await accountRepository.CreateAccountAsync(model);
            return result;
        }
        public async Task RemoveAccountByIdAsync(Guid id)
        {
            await accountRepository.RemoveAccountByIdAsync(id);
        }
        public async Task UpdateNicknameAsync(UpdateAccountViewModel model)
        {
            await accountRepository.UpdateNicknameById(model);
        }
        public async Task TransferMoneyByNicknameAsync(TransactionsByNicknameViewModel model)
        {
            await accountRepository.TransferByNicknameAsync(model);
        }
    }
}
