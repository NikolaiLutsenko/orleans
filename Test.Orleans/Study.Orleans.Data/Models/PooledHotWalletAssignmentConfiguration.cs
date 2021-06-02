using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class PooledHotWalletAssignmentConfiguration : IEntityTypeConfiguration<PooledHotWalletAssignment>
    {
        public void Configure(EntityTypeBuilder<PooledHotWalletAssignment> builder)
        {
            builder
                .ToTable("PooledHotWalletAssignments");

            builder
                .HasKey(i => new { i.InvoicePooledHotWalletId, i.InvoicePaymentHotWalletId });

            builder
                .Property(i => i.InvoicePooledHotWalletId);

            builder
                .Property(i => i.InvoicePaymentHotWalletId);

            builder
                .Property(i => i.AssignedFrom);

            builder
                .Property(i => i.AssignedUntil);

            // only a single pooled wallet can ever be assigned to a payment hot wallet

            builder
                .HasIndex(i => i.InvoicePaymentHotWalletId)
                .IsUnique();

            builder
                .Property(i => i.IsCompleted);

            builder
                .Property(i => i.CompletedDate);

            builder.Property(b => b.Timestamp).IsRowVersion();
        }
    }
}
