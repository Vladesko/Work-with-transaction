using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Models.AccountsViewModels;

namespace Application.Services
{
    internal class AccountService(IAccountRepository accountRepository,
                                  ICacheRepository cache,
                                  IAccountValidator validator) : IAccountService
    {
        private readonly IAccountRepository accountRepository = accountRepository;
        private readonly ICacheRepository cache = cache;
        private readonly IAccountValidator validator = validator;

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
            await validator.ValidateAsync(model);

            var result = await accountRepository.CreateAccountAsync(model);
            return result;
        }
        public async Task RemoveAccountByIdAsync(Guid id)
        {
            await accountRepository.RemoveAccountByIdAsync(id);
        }
        public async Task UpdateNicknameAsync(UpdateAccountViewModel model)
        {
            await validator.ValidateAsync(model);

            await accountRepository.UpdateNicknameById(model);
        }
    }
}
