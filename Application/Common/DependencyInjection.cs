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
            services.AddValidators();

            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<ITransactionsService, TransactiosService>();

            return services;
        }
        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateAccountViewModel>, CreateAccountValidator>();
            services.AddTransient<IValidator<UpdateAccountViewModel>, UpdateAccountValidator>();

            services.AddScoped<IAccountValidator, AccountValidator>();

            return services;
        }
    }
}
