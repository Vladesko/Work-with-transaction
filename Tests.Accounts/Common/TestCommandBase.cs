using Application.Common.Validations.AccountValidation;
using Application.Services;
using Persistance.Entities;
using Persistance.Repositories;


namespace Tests.Accounts.Common
{
    internal abstract class TestCommandBase : IDisposable
    {
        protected readonly AccountDbContext context = AccountsContextFactory.Create();
        public AccountService GetService()
        {
            var repositry = new AccountRepository(context);

            var validator = new AccountValidator(new CreateAccountValidator(), new UpdateAccountValidator());

            //Cache might be null, because it not use for commands
            var service = new AccountService(repositry, null, validator);

            return service;
        }
        public void Dispose()
        {
            AccountsContextFactory.Destroy(context);
        }
    }
}
