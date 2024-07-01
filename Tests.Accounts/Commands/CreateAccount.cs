using Application.Models.AccountsViewModels;
using Microsoft.EntityFrameworkCore;
using Tests.Accounts.Common;

namespace Tests.Accounts.Commands
{
    public class CreateAccount : TestCommandBase
    {
        [Fact]
        public async Task CreateAccount_Success()
        {
            //Arrange
            var service = GetService();
            var model = new CreateAccountViewModel()
            {
                Name = "Test",
                Nickname = "Test",
            }; 

            //Act
            var result = await service.CreateAccountAsync(model);

            //Assert
            Assert.NotNull(await context.Accounts.FirstOrDefaultAsync(a => a.Id == result));
        }
    }
}
