using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using Domain;

namespace Application.Interfaces.AccountsInterfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountsViewModel>> GetAccountsAsync();
        Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id);
        Task<Guid> CreateAccountAsync(CreateAccountViewModel model);
        Task RemoveAccountByIdAsync(Guid id);
        Task UpdateNicknameById(UpdateAccountViewModel model);
        Task TransferByNicknameAsync(TransactionsByNicknameViewModel model);
    }
}
