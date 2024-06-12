using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //Configure Id
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            //Configure Name
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            //Configure Nickname
            builder.Property(x => x.Nickname).HasMaxLength(30).IsRequired();

            //Configure Amount of money
            builder.Property(x => x.AmountOfMoney).IsRequired();
        }
    }
}
