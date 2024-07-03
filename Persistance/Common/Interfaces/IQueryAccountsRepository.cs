using Application.Models.AccountsViewModels;

namespace Persistance.Common.Interfaces
{
    internal interface IQueryAccountsRepository
    {
        Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id);
        Task<IEnumerable<AccountsViewModel>> GetAccountsAsync();
    }
}
