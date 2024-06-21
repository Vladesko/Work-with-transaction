using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.TransactionInterfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<ITransactionsService, TransactiosService>();

            return services;
        }
    }
}
