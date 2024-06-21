using Application.Models.TransactionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.TransactionInterfaces
{
    public interface ITransactionsRepository
    {
        Task TransactionByNickname(TransactionsByNicknameViewModel model);
    }
}
