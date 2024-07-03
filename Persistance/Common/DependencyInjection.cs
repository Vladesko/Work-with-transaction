using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
using Application.Interfaces.TransactionInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Common.Interfaces;
using Persistance.Entities;
using Persistance.Repositories;
using Persistance.Repositories.AccountRepositories;

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

            services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });

            //Accounts
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommandAccountsRepository, AccountsCommands>();
            services.AddScoped<IQueryAccountsRepository, AccountsQueries>();

            //Transaction
            services.AddTransient<ITransactionsRepository, TransactionsRepository>();

            //Cache
            services.AddSingleton<ICacheRepository, CacheRepository>();

            return services;
        }
    }
}
