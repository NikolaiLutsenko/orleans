using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder
                .ToTable("Buyers");

            builder
                .HasKey(i => i.InvoiceId);

            builder
                .Property(i => i.InvoiceId);

            builder
                .Property(i => i.CompanyName)
                .IsUnicode()
                .HasMaxLength(140);

            builder
                .Property(i => i.FirstName)
                .IsUnicode()
                .HasMaxLength(140);

            builder
                .Property(i => i.LastName)
                .IsUnicode()
                .HasMaxLength(140);

            builder
                .Property(i => i.Email)
                .IsUnicode()
                .HasMaxLength(254);

            builder
                .Property(i => i.PhoneNumber)
                .IsUnicode()        // so that it can be part of the unicode index
                .HasMaxLength(25);

            builder
                .OwnsOne(i => i.Address, address =>
                {
                    address
                        .Property(i => i.Address1)
                        .HasMaxLength(300)
                        .IsUnicode();

                    address
                        .Property(i => i.Address2)
                        .HasMaxLength(300)
                        .IsUnicode();

                    address
                        .Property(i => i.Address3)
                        .HasMaxLength(300)
                        .IsUnicode();

                    address
                        .Property(i => i.ProvinceOrState)
                        .HasMaxLength(300)
                        .IsUnicode();

                    address
                        .Property(i => i.City)
                        .HasMaxLength(120)
                        .IsUnicode();

                    address
                        .Property(i => i.SuburbOrDistrict)
                        .HasMaxLength(100)
                        .IsUnicode();

                    address
                        .Property(i => i.CountryCode)
                        .HasMaxLength(2)
                        .IsUnicode();

                    address
                        .Property(i => i.PostalCode)
                        .HasMaxLength(60)
                        .IsUnicode();
                });

            builder
                .Property(i => i.ConcurrencyToken)
                .IsConcurrencyToken()
                .HasColumnType("tinytext")
                .IsUnicode(false);
        }
    }
}
