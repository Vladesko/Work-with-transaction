using Application.Interfaces.CacheInterfaces;
using Application.Models.AccountsViewModels;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Persistance.Repositories
{
    internal class CacheRepository(IDistributedCache cache) : ICacheRepository
    {
        private readonly IDistributedCache cache = cache;
        private const string KEYFORLISTACCOUNTS = "AllAccounts";
        public async Task<AccountDetailsViewModel> GetAccountByIdFromCahceAsync(Guid id)
        {
            string cacheData = await cache.GetStringAsync($"{id}");
            if (string.IsNullOrEmpty(cacheData))
                return null;

            var accountDetailsViewModel = JsonSerializer.Deserialize<AccountDetailsViewModel>(cacheData);
            return accountDetailsViewModel;
        }
        public async Task SetAccountDetailsViewModelAsync(Guid id, AccountDetailsViewModel model)
        {
            string jsonAccount = JsonSerializer.Serialize(model);

            await cache.SetStringAsync($"{id}", jsonAccount, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1)
            });

        }
        public async Task<List<AccountsViewModel>> GetAccountsAsync()
        {
            string cacheData = await cache.GetStringAsync(KEYFORLISTACCOUNTS);
            if (string.IsNullOrEmpty(cacheData))
                return null;

            var accounts = JsonSerializer.Deserialize<List<AccountsViewModel>>(cacheData);
            return accounts;
        }
        public async Task SetListOfAccountsToCacheAsync(List<AccountsViewModel> accounts)
        {
            string jsonAccounts = JsonSerializer.Serialize(accounts);

            await cache.SetStringAsync(KEYFORLISTACCOUNTS, jsonAccounts, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(3)
            });
        }
    }
}
