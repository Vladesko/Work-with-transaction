using Application.Common.Validations.AccountValidation;
using Application.Interfaces.AccountsInterfaces;
using Application.Interfaces.TransactionInterfaces;
using Application.Models.AccountsViewModels;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentValidation();

            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<ITransactionsService, TransactiosService>();

            return services;
        }
        private static IServiceCollection AddFluentValidation(this IServiceCollection services) 
        {
            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            services.AddScoped<IValidator<CreateAccountViewModel>, CreateAccountValidator>();
            services.AddScoped<IValidator<UpdateAccountViewModel>, UpdateAccountValidator>();

            services.AddScoped<IAccountValidator, AccountValidator>();
            
            return services;
        }
    }
}
