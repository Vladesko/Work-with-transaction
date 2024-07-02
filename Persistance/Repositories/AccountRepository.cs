using Application.Interfaces.AccountsInterfaces;
using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using System.Data.SqlClient;

namespace Persistance.Repositories
{
    internal class AccountRepository(AccountDbContext context) : IAccountRepository
    {
        private readonly AccountDbContext context = context;
        public async Task<List<AccountsViewModel>> GetAccountsAsync()
        {
            var accounts = await context.Accounts.
                Select(a => new AccountsViewModel { Nickname = a.Nickname }).
                AsNoTracking().
                ToListAsync();

            return accounts;
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
            var account = new Account() 
            {
                AmountOfMoney = 0,
                Nickname = model.Nickname,
                Name = model.Name,
                Id = Guid.NewGuid()
            };
            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return account.Id;
        }
        public async Task RemoveAccountByIdAsync(Guid id)
        {
            var command = from a in context.Accounts
                          where a.Id == id
                          select a;

            context.Accounts.Remove(command.First());
            await context.SaveChangesAsync();
        }
        public async Task UpdateNicknameById(UpdateAccountViewModel model)
        {
             var command = from a in context.Accounts
                           where a.Id == model.Id
                           select a;

            foreach (var account in command)
            {
                account.Nickname = model.Nickname;
                break;
            }
            await context.SaveChangesAsync();
        }
    }
}
