using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Models.AccountsViewModels;
using Application.Services;
using Moq;
using Tests.Accounts.TestService.Common;

namespace Tests.Accounts.TestService.Queries
{
    public class GetAccountDetailsViewModel : TestQueryBase
    {
        private AccountService service;
        public GetAccountDetailsViewModel()
        {
            service = new AccountService(repositoryMock.Object, cacheMock.Object, validatorMock.Object);
        }
        [Fact]
        public async Task GetAccountDetails_WithValidData_Success()
        {
            //Arrange
            var model = new AccountDetailsViewModel()
            {
                AmountOfMoney = 0,
                Name = "TestName",
                Nickname = "TestNickname"
            };
            var idForGetAccount = Guid.NewGuid();

            //Act
            cacheMock.Setup(r => r.GetAccountByIdFromCahceAsync(idForGetAccount)).
                ReturnsAsync((AccountDetailsViewModel)null);

            repositoryMock.Setup(r => r.GetAccountByIdAsync(idForGetAccount)).
                ReturnsAsync(model);

            var result = await service.GetAccountByIdAsync(idForGetAccount);

            //Assert
            Assert.Equal(model, result);
        }
    }
}
