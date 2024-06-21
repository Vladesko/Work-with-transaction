using Application.Models.AccountsViewModels;
using Application.Models.TransactionsViewModels;
using WebApiBank.Models.AccountsDto;
using WebApiBank.Models.TransactionsDto;

namespace WebApiBank.Commons.Mapping
{
    public class AccountMapper
    {
        public CreateAccountViewModel MapWith(CreateAccountDto dto) =>
          new()
          {
              Name = dto.Name,
              Nickname = dto.Nickname,
          };

        public UpdateAccountViewModel MapWith(UpdateAccountDto dto) =>
            new()
            {
                Id = dto.Id,
                Nickname = dto.Nickname
            };

        public TransactionsByNicknameViewModel MapWith(TransactionsByNicknameDto dto) =>
            new()
            {
                Amount = dto.Amount,
                NicknameFrom = dto.NickNameFrom,
                NicknameTo = dto.NickNameTo,
            };
    }
}
