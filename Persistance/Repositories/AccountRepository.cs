using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Repositories
{
    internal class AccountRepository(AccountDbContext context) : IAccountRepository
    {
        private readonly AccountDbContext context = context;
        public async Task<List<Account>> GetAccountsAsync()
        {
            var account = await context.Accounts.ToListAsync();
            return account;
        }
    }
}
