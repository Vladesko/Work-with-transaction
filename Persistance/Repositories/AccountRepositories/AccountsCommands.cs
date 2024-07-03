using Application.Models.AccountsViewModels;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Common.Exceptions;
using Persistance.Common.Interfaces;
using Persistance.Entities;

namespace Persistance.Repositories.AccountRepositories
{
    internal class AccountsCommands(AccountDbContext context) : ICommandAccountsRepository
    {
        private readonly AccountDbContext context = context;
        public async Task<Guid> CreateAsync(CreateAccountViewModel model)
        {
            var account = new Account()
            {
                AmountOfMoney = 0,
                Nickname = model.Nickname,
                Name = model.Name,
                Id = Guid.NewGuid()
            };

            await context.AddAsync(account);
            await context.SaveChangesAsync();

            return account.Id;
        }

        public async Task UpdateAsync(UpdateAccountViewModel model)
        {
            var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == model.Id) ??
                throw new AccountNotFoundException($"Account with this id:{model.Id} is not found");

            account.Nickname = model.Nickname;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == id) ??
                throw new AccountNotFoundException($"Account with this id:{id} is not found");

            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
        }
    }
}
