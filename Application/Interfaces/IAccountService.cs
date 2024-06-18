using Application.Models;
using Domain;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountsViewModel>> GetAccountsAsync();
        Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id);
        Task<Guid> CreateAccountAsync(CreateAccountViewModel model);
        Task RemoveAccountByIdAsync(Guid id);
        Task UpdateNicknameAsync(UpdateAccountViewModel model);
    }
}
