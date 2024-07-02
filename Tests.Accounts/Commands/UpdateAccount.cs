using Application.Models.AccountsViewModels;
using Microsoft.EntityFrameworkCore;
using Tests.Accounts.Common;

namespace Tests.Accounts.Commands
{
    public class UpdateAccount : TestCommandBase
    {
        private const string NICKNAME_FOR_UPDATE = "NicknameIsUpdate";
        [Fact]
        public async Task UpdateAccount_Success()
        {
            //Arange
            var model = new UpdateAccountViewModel()
            {
                Id = AccountsContextFactory.IdForSecondAccount,
                Nickname = NICKNAME_FOR_UPDATE
            };
            var service = GetService();

            //Act
            await service.UpdateNicknameAsync(model);

            //Assert
            Assert.NotNull(context.Accounts.FirstOrDefaultAsync(
                a => a.Id == AccountsContextFactory.IdForFirstAccount && 
                a.Nickname == NICKNAME_FOR_UPDATE));
        }
    }
}
