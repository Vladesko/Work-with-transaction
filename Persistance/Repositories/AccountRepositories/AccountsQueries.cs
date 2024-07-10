using Application.Models.AccountsViewModels;
using Dapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Persistance.Common.Exceptions;
using Persistance.Common.Interfaces;
using Persistance.Entities;
using System.Data;

namespace Persistance.Repositories.AccountRepositories
{
    internal class AccountsQueries(AccountDbContext context) : IQueryAccountsRepository
    {
        private readonly AccountDbContext context = context;
        public async Task<AccountDetailsViewModel> GetAccountByIdAsync(Guid id)
        {
            using (var connection = new NpgsqlConnection(context.Database.GetConnectionString()))
            {
                var accounts = await connection.QueryAsync<Account>($"SELECT * FROM public.\"Accounts\"\r\nWHERE \"Id\"='{id}'") 
                    ?? throw new AccountNotFoundException("Account not found");

                var account = accounts.First();

                var model = new AccountDetailsViewModel() 
                { 
                    AmountOfMoney = account.AmountOfMoney,
                    Name = account.Name,
                    Nickname = account.Nickname,
                };
                return model;
            };
        }

        public async Task<IEnumerable<AccountsViewModel>> GetAccountsAsync()
        {
            using (var connection = new NpgsqlConnection(context.Database.GetConnectionString()))
            {
                var accounts = await connection.QueryAsync<Account>("SELECT * FROM public.\"Accounts\"");
                var models = accounts.Select(a => new AccountsViewModel()
                                                { 
                                                    Nickname = a.Nickname
                                                }).
                                      ToArray();
                return models;
            }
        }
    }
}
