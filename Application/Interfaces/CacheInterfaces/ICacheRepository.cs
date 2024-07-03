using Application.Models.AccountsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CacheInterfaces
{
    public interface ICacheRepository
    {
        Task<IEnumerable<AccountsViewModel>> GetAccountsAsync();
        Task SetListOfAccountsToCacheAsync(IEnumerable<AccountsViewModel> accounts);
        Task<AccountDetailsViewModel> GetAccountByIdFromCahceAsync(Guid id);
        Task SetAccountDetailsViewModelAsync(Guid id, AccountDetailsViewModel model);
    }
}
