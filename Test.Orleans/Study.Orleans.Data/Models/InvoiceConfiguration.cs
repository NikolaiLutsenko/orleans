using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .ToTable("Invoices");

            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id);

            builder
                .Property(i => i.MerchantId);

            builder
                .Property(i => i.MerchantClientId);

            builder
                .Property(i => i.InvoiceId)
                .HasMaxLength(127)
                .IsUnicode();

            builder
                .Property(i => i.InvoiceIdSuffix)
                .HasMaxLength(4)
                .IsUnicode();

            builder
                .Property(i => i.Created);

            builder
                .Property(i => i.Expires);

            builder
                .Property(i => i.InvoiceDate);

            builder
                .Property(i => i.DueDate);

            builder
                .Property(i => i.Confirmed);

            builder
                .Property(i => i.Completed);

            builder
                .Property(i => i.Cancelled);

            builder
                .HasOne<Buyer>(i => i.Buyer)
                .WithOne()
                .HasForeignKey<Buyer>(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(i => i.Description)
                .HasMaxLength(200)
                .IsUnicode();

            builder
                .HasMany(i => i.Items)
                .WithOne(i => i.Invoice)
                .HasForeignKey(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(i => i.CurrencyId);

            builder
                .Property(i => i.Subtotal)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.ShippingTotal)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.HandlingTotal)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.TaxTotal)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.DiscountTotal)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.Total)
                .HasColumnType("decimal(38, 0)");

            builder
                .HasOne<Shipping>(i => i.Shipping)
                .WithOne()
                .HasForeignKey<Shipping>(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(i => i.CustomData)
                .HasMaxLength(500)
                .IsUnicode();

            builder
                .Property(i => i.State)
                .HasConversion<int>();

            builder
                .Property(i => i.Flags)
                .HasConversion<uint>();

            builder
                .Property(i => i.BuyerDataCollectionMessage)
                .HasMaxLength(300)
                .IsUnicode();

            builder
                .Property(i => i.Notes)
                .HasMaxLength(500)
                .IsUnicode();

            builder
                .Property(i => i.NotesToRecipient)
                .HasMaxLength(2000)
                .IsUnicode();

            builder
                .Property(i => i.TermsAndConditions)
                .HasMaxLength(2000)
                .IsUnicode();

            builder
                .Property(i => i.MetaSourceIntegration)
                .HasMaxLength(100);

            builder
                .Property(i => i.MetaSourceHostname)
                .HasMaxLength(100);

            builder
                .OwnsOne(i => i.EmailDeliveryOptions, email =>
                {
                    email
                        .Property(i => i.To)
                        .IsUnicode()
                        .HasMaxLength(500);

                    email
                        .Property(i => i.Cc)
                        .IsUnicode()
                        .HasMaxLength(500);

                    email
                        .Property(i => i.Bcc)
                        .IsUnicode()
                        .HasMaxLength(500);
                });

            builder
                .OwnsOne(i => i.MerchantOptions, options =>
                {
                    options
                        .Property(i => i.ShowFieldsFlag)
                        .HasConversion<uint>();

                    options
                        .Property(i => i.AdditionalInfo)
                        .IsUnicode()
                        .HasMaxLength(500);
                });

            builder
                .Property(i => i.ConcurrencyToken)
                .IsConcurrencyToken();

            builder
                .HasIndex(i => i.State)
                .IsUnique(false);

            builder
                .HasIndex(i => i.MetaSourceIntegration)
                .IsUnique(false);

            builder.Property(i => i.PONumber);
        }
    }
}
