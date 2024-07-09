using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Accounts.TestService.Common
{
    public static class AccountsContextFactory
    {
        public static Guid IdForFirstAccount = Guid.Parse("CE52A6E8-99E3-4B00-B9DE-0E08E6F74C14");
        public static Guid IdForSecondAccount = Guid.Parse("F5931909-B88E-4A7D-896C-81ECC6FBDE95");

        public static string NameForFirstAccount = "Name First";
        public static string NameForSecondAccount = "Name Second";

        public static string NicknameForFirstAccount = "Nickname first";
        public static string NicknameForSecondAccount = "Nickname second";

        public static decimal MoneyOfFirstAccount = 5m;
        public static decimal MoneyOfSecondAccount = 0;

        internal static AccountDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AccountDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).
                Options;

            var context = new AccountDbContext(options);

            context.Database.EnsureCreated();

            AddTestsAccounts(context);

            return context;
        }
        private static void AddTestsAccounts(AccountDbContext context)
        {
            //Add **Test** Accounts
            context.Accounts.AddRange(
            new Account()
            {
                Id = IdForFirstAccount,
                Name = NameForFirstAccount,
                Nickname = NameForFirstAccount,
                AmountOfMoney = MoneyOfFirstAccount,
            },
            new Account()
            {
                Id = IdForSecondAccount,
                Name = NameForSecondAccount,
                Nickname = NicknameForSecondAccount,
                AmountOfMoney = MoneyOfSecondAccount
            });
            context.SaveChanges();
        }
        internal static void Destroy(AccountDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
