using Microsoft.EntityFrameworkCore;
using Study.Orleans.Data.Models;

namespace Study.Orleans.Data
{
    public class InvoiceDbContext: DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PooledHotWallet> PooledHotWallets { get; set; }

        public DbSet<PaymentHotWallet> PaymentHotWallets { get; set; }

        public DbSet<PooledHotWalletAssignment> PooledHotWalletAssignments { get; set; }

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new InvoiceConfiguration())
                .ApplyConfiguration(new BuyerConfiguration())
                .ApplyConfiguration(new ShippingConfiguration())
                .ApplyConfiguration(new LineItemConfiguration())
                .ApplyConfiguration(new PaymentConfiguration())
                .ApplyConfiguration(new PooledHotWalletConfiguration())
                .ApplyConfiguration(new PaymentHotWalletConfiguration())
                .ApplyConfiguration(new PooledHotWalletAssignmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
