using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class PooledHotWalletConfiguration : IEntityTypeConfiguration<PooledHotWallet>
    {
        public void Configure(EntityTypeBuilder<PooledHotWallet> builder)
        {
            builder
                .ToTable("PooledHotWallets");

            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id);

            builder
                .Property(i => i.CurrencyId);

            builder
                .Property(i => i.Created);

            builder
                .Property(i => i.DepositAddress)
                .HasMaxLength(200);

            builder
                .Property(i => i.State)
                .HasConversion<int>();

            builder
                .Property(i => i.ConcurrencyToken)
                .IsConcurrencyToken()
                .HasColumnType("tinytext")
                .IsUnicode(false);

            builder
                .HasIndex(i => i.DepositAddress);
        }
    }
}
