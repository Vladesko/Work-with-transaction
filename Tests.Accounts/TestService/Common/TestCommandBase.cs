using Application.Common.Validations.AccountValidation;
using Application.Interfaces.AccountsInterfaces;
using Application.Services;
using Persistance.Entities;
using Persistance.Repositories;
using Persistance.Repositories.AccountRepositories;


namespace Tests.Accounts.TestService.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        internal readonly AccountDbContext context = AccountsContextFactory.Create();
        internal IAccountService GetService()
        {
            var repositry = GetRepository();

            var validator = GetValidator();

            //Cache might be null, because it not use for commands
            var service = new AccountService(repositry, null, validator);

            return service;
        }

        public void Dispose()
        {
            AccountsContextFactory.Destroy(context);
        }
        private IAccountValidator GetValidator() => 
            new AccountValidator(new CreateAccountValidator(), 
                                 new UpdateAccountValidator());
        private IAccountRepository GetRepository() => 
            new AccountRepository(context, 
                                  new AccountsCommands(context),
                                  new AccountsQueries(context));
    }
}
