using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class PaymentHotWalletConfiguration : IEntityTypeConfiguration<PaymentHotWallet>
    {
        public void Configure(EntityTypeBuilder<PaymentHotWallet> builder)
        {
            builder
                .ToTable("PaymentHotWallets");

            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id);

            builder
                .Property(i => i.InvoicePaymentId);

            builder
                .Property(i => i.CurrencyId);

            builder
                .Property(i => i.CurrencyRateFromInvoiceCurrency)
                .HasColumnType("decimal(38,20)");

            builder
                .Property(i => i.Created);

            builder
                .Property(i => i.PaymentReceiveAddress)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder
                .Property(i => i.MerchantPayoutAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(i => i.MerchantPayoutWalletId)
                .HasColumnType("binary(16)");

            builder
                .Property(i => i.PaymentSubTotal)
                .HasColumnType("decimal(38,0)");

            builder
                .Property(i => i.BuyerCoinPaymentsFee)
                .HasColumnType("decimal(38,0)");

            builder
                .Property(i => i.BuyerNetworkFee)
                .HasColumnType("decimal(38,0)");

            builder
                .Property(i => i.MerchantCoinPaymentsFee)
                .HasColumnType("decimal(38,0)");

            builder
                .Property(i => i.MerchantNetworkFee)
                .HasColumnType("decimal(38,0)");

            builder
                .Property(i => i.ConcurrencyToken)
                .IsConcurrencyToken();

            // invoice should only have a single hot wallet for a particular currency

            builder
                .HasIndex("InvoicePaymentId", "CurrencyId", "ContractAddress")
                .IsUnique();

            // lookups will be performed by address when blocks are detected

            builder
                .HasIndex(i => i.PaymentReceiveAddress);    // pooled address not unique

            builder
                .Property(i => i.IsConversion)
                .HasDefaultValue(false);

            builder
                .Property(i => i.PayoutFrequency);

            builder.Property(i => i.BuyerConversionFee).HasDefaultValue(0);
            builder.Property(i => i.MerchantConversionFee).HasDefaultValue(0);

            builder.Property(i => i.SettlementModeError);
        }
    }
}
