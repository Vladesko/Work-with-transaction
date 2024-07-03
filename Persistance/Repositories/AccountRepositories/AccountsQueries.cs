using Application.Models.AccountsViewModels;
using Microsoft.EntityFrameworkCore;
using Persistance.Common.Exceptions;
using Persistance.Common.Interfaces;
using Persistance.Entities;

namespace Persistance.Repositories.AccountRepositories
{
    internal class AccountsQueries(AccountDbContext context) : IQueryAccountsRepository
    {
        private readonly AccountDbContext context = context;
        public async Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id)
        {
            return await context.Accounts.
                Select(a => new AccountDetailsViewModel
                { 
                    AmountOfMoney = a.AmountOfMoney,
                    Name = a.Name,
                    Nickname = a.Nickname,
                }).
                AsNoTracking().
                FirstOrDefaultAsync() ??
                throw new AccountNotFoundException($"Account with this id:{id} is not found");
        }

        public async Task<IEnumerable<AccountsViewModel>> GetAccountsAsync()
        {
            return await context.Accounts.
                Select(a => new AccountsViewModel { Nickname = a.Nickname }).
                AsNoTracking().
                ToArrayAsync();
        }
    }
}
