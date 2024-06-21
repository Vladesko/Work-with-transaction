using Application.Interfaces.AccountsInterfaces;
using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using Domain;

namespace Application.Services
{
    internal class AccountService(IAccountRepository accountRepository) : IAccountService
    {
        private readonly IAccountRepository accountRepository = accountRepository;
        public async Task<List<AccountsViewModel>> GetAccountsAsync()
        {
            var accounts = await accountRepository.GetAccountsAsync();
            return accounts;
        }
        public async Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id)
        {
            var account = await accountRepository.GetAccountByIdAsync(id);
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
