using Application.Models.TransactionsViewModels;
using WebApiBank.Models.TransactionsDto;

namespace WebApiBank.Commons.Mapping
{
    public class TransactionsMapper
    {
        public TransactionsByNicknameViewModel MapWith(TransactionsByNicknameDto dto) =>
            new() 
            {
                Amount = dto.Amount,
                NicknameFrom = dto.NickNameFrom,
                NicknameTo = dto.NickNameTo,
            };

    }
}
