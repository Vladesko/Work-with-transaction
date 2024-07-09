using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Models.AccountsViewModels;
using Application.Services;
using Moq;
using Tests.Accounts.TestService.Common;

namespace Tests.Accounts.TestService.Queries
{
    public class GetListAccounts : TestQueryBase
    {
        private AccountService service;
        public GetListAccounts()
        {
            service = new AccountService(repositoryMock.Object, cacheMock.Object, validatorMock.Object);
        }
        [Fact]
        public async Task GetListOfAccount_WithValidData_Success()
        {
            //Arrange
            var accounts = GetAccounts();

            //Act
            cacheMock.Setup(r => r.GetAccountsAsync()).
                ReturnsAsync((IEnumerable<AccountsViewModel>)null);

            repositoryMock.Setup(r => r.GetAccountsAsync()).
                ReturnsAsync(accounts);

            var result = await service.GetAccountsAsync();

            //Assert
            Assert.Equal(accounts, result);
        }
    }
}
