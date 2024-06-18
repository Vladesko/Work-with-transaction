using Application.Interfaces;
using Application.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

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
            var account = await context.Accounts
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
        public async Task UpdateNicknameById(UpdateAccountViewModel model)
        {
                 var account = await context.Accounts
                .Where(a => a.Id == model.Id).
                 ExecuteUpdateAsync(a => a.SetProperty(a => a.Nickname, model.Nickname));
        }
    }
}
