using Microsoft.EntityFrameworkCore;
using Tests.Accounts.TestService.Common;

namespace Tests.Accounts.TestService.Commands
{
    public class DeleteAccount : TestCommandBase
    {
        [Fact]
        public async Task RemoveAccount_Success()
        {
            //Arrange
            var id = AccountsContextFactory.IdForSecondAccount;
            var service = GetService();

            //Act
            await service.RemoveAccountByIdAsync(id);

            //Assert
            Assert.Null(context.Accounts.FirstOrDefault(a => a.Id == id));
        }
    }
}
