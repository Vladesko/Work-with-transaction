using Application.Models;
using WebApiBank.Models;

namespace WebApiBank.Commons
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
    }
}
