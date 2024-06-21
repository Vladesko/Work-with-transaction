using Application.Interfaces.TransactionInterfaces;
using Application.Models.TransactionsViewModels;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    internal class TransactionsRepository(AccountDbContext context) : ITransactionsRepository
    {
        private readonly AccountDbContext context = context;
        public async Task TransactionByNickname(TransactionsByNicknameViewModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var AccounfFrom = await context.Accounts.
                        FirstOrDefaultAsync(a => a.Nickname == model.NicknameFrom);

                    var AccounfTo = await context.Accounts.
                        FirstOrDefaultAsync(a => a.Nickname == model.NicknameTo);

                    if (AccounfFrom.AmountOfMoney < model.Amount)
                        throw new Exception();

                    AccounfFrom.AmountOfMoney -= model.Amount;
                    AccounfTo.AmountOfMoney += model.Amount;

                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
