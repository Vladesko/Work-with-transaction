using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.CacheInterfaces;
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

            services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionsRepository, TransactionsRepository>();
            services.AddSingleton<ICacheRepository, CacheRepository>();

            return services;
        }
    }
}
