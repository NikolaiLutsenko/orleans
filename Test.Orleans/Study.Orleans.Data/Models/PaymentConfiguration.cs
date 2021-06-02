using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .ToTable("Payments");

            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id);

            builder
                .Property(i => i.InvoiceId);

            builder
                .Property(i => i.Created);

            builder
                .Property(i => i.Expires);

            builder
                .Property(i => i.Cancelled);

            builder
                .Property(i => i.Detected);

            builder
                .Property(i => i.Pending);

            builder
                .Property(i => i.Confirmed);

            builder
                .Property(i => i.Completed);

            builder
                .Property(i => i.State)
                .HasConversion<int>();

            builder
                .Property(i => i.RefundEmail)
                .IsUnicode()
                .HasMaxLength(254);

            builder
                .Property(i => i.ConcurrencyToken)
                .IsConcurrencyToken();

            //builder
            //    .HasMany(i => i.Payouts)
            //    .WithOne(i => i.InvoicePayment)
            //    .HasForeignKey(i => i.InvoicePaymentId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //
            //builder
            //    .HasMany(i => i.Refunds)
            //    .WithOne(i => i.InvoicePayment)
            //    .HasForeignKey(i => i.InvoicePaymentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(i => i.ScheduledForPayout);

            builder
                .Property(i => i.Refunded);
        }
    }
}
