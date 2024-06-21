using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.TransactionsViewModels
{
    public class TransactionsByNicknameViewModel
    {
        public string NicknameFrom { get; set; } = string.Empty;
        public string NicknameTo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
