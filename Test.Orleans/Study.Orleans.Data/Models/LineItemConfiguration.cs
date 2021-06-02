using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder
                .ToTable("LineItems");

            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id);

            builder
                .Property(i => i.InvoiceId);

            builder
                .Property(i => i.CustomId)
                .HasMaxLength(127)
                .IsUnicode();

            builder
                .Property(i => i.SKU)
                .HasMaxLength(127)
                .IsUnicode();

            builder
                .Property(i => i.Name)
                .HasMaxLength(127)
                .IsUnicode();

            builder
                .Property(i => i.Description)
                .HasMaxLength(1000)
                .IsUnicode();

            builder
                .Property(i => i.Quantity);

            builder
                .Property(i => i.Amount)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.OriginalAmount)
                .HasColumnType("decimal(38, 0)");

            builder
                .Property(i => i.Tax)
                .HasColumnType("decimal(38, 0)");

            builder
                .HasIndex(i => i.InvoiceId);

            builder
                .HasIndex(i => i.SKU);

            builder
                .Property(i => i.Type)
                .HasDefaultValue(LineItemType.Quantity);
        }
    }
}
