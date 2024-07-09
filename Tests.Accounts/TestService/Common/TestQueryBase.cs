using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Services;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Accounts.TestService.Common
{
    public abstract class TestQueryBase
    {
        protected readonly Mock<IAccountRepository> repositoryMock = new Mock<IAccountRepository>();
        protected readonly Mock<ICacheRepository> cacheMock = new Mock<ICacheRepository>();
        internal readonly Mock<IAccountValidator> validatorMock = new Mock<IAccountValidator>();

    }
}
