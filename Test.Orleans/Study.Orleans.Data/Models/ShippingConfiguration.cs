using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Study.Orleans.Data.Models
{
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder
               .ToTable("ShippingDetails");

            builder
                .HasKey(i => i.InvoiceId);

            builder
                .Property(i => i.InvoiceId);

            builder
                .Property(i => i.Method)
                .HasMaxLength(127)
                .IsUnicode();

            builder
                .Property(i => i.CompanyName)
                .IsUnicode()
                .HasMaxLength(140);

            builder
                .Property(i => i.FirstName)
                .HasMaxLength(140)
                .IsUnicode();

            builder
                .Property(i => i.LastName)
                .HasMaxLength(140)
                .IsUnicode();

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
                        .WithOwner();

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
