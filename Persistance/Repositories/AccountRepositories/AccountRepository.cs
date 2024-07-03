using Application.Interfaces.AccountsInterfaces;
using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Common.Interfaces;
using Persistance.Entities;
using Persistance.Repositories.AccountRepositories;
using System.Data.SqlClient;

namespace Persistance.Repositories
{
    internal class AccountRepository(AccountDbContext context,
                                     ICommandAccountsRepository commandsRepository,
                                     IQueryAccountsRepository queryRepository) : IAccountRepository
    {
        private readonly AccountDbContext context = context;
        private readonly ICommandAccountsRepository commandsRepository = commandsRepository;
        private readonly IQueryAccountsRepository queryRepository = queryRepository;
        public async Task<IEnumerable<AccountsViewModel>> GetAccountsAsync()
        {
            return await queryRepository.GetAccountsAsync();
        }
        public async Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id)
        {
            var account = await context.Accounts.
                AsNoTracking().
                Where(a => a.Id == id).
                FirstOrDefaultAsync();

            return new AccountDetailsViewModel()
            {
                AmountOfMoney = account.AmountOfMoney,
                Name = account.Name,
                Nickname = account.Nickname,
            };
        }
        public async Task<Guid> CreateAccountAsync(CreateAccountViewModel model)
        {
            return await commandsRepository.CreateAsync(model);
        }
        public async Task RemoveAccountByIdAsync(Guid id)
        {
            await commandsRepository.DeleteAsync(id);
        }
        public async Task UpdateNicknameById(UpdateAccountViewModel model)
        {
             await commandsRepository.UpdateAsync(model);
        }
    }
}
