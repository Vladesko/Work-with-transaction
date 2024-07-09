using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
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



            //Act

            //Assert
        }
    }
}
