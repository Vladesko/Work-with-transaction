using Application.Interfaces.TransactionInterfaces;
using Application.Models.TransactionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class TransactiosService(ITransactionsRepository transactionsRepository) : ITransactionsService
    {
        private readonly ITransactionsRepository transactionsRepository = transactionsRepository;
        public async Task TransferMoneyByNicknameAsync(TransactionsByNicknameViewModel model)
        {
            await transactionsRepository.TransactionByNickname(model);
        }
    }
}
