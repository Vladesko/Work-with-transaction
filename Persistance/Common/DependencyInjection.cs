using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.TransactionInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Entities;
using Persistance.Repositories;

namespace Persistance.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, 
            IConfiguration configuration)
        {

            services.AddDbContext<AccountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionsRepository, TransactionsRepository>();

            return services;
        }
    }
}
