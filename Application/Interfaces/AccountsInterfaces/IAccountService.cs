using Application.Models.AccountsViewModels;
using Domain;

namespace Application.Interfaces.AccountsInterfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountsViewModel>> GetAccountsAsync();
        Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id);
        Task<Guid> CreateAccountAsync(CreateAccountViewModel model);
        Task RemoveAccountByIdAsync(Guid id);
        Task UpdateNicknameAsync(UpdateAccountViewModel model);
    }
}
