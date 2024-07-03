using Application.Models.AccountsViewModels;

namespace Persistance.Common.Interfaces
{
    internal interface ICommandAccountsRepository
    {
        Task<Guid> CreateAsync(CreateAccountViewModel model);
        Task UpdateAsync(UpdateAccountViewModel model);
        Task DeleteAsync(Guid id);
    }
}
