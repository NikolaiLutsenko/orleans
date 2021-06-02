using System;

namespace Study.Orleans.Data.Models
{
    public class PooledHotWallet
    {
        /// <summary>
        /// the unique id of the pooled invoice hot wallet (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// the id of the currency for the hot wallet to receive
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// the timestamp when the hot wallet was created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// the wallets receive address where buyer payments are received
        /// </summary>
        public string DepositAddress { get; set; }

        /// <summary>
        /// the state of the pooled hot wallet
        /// </summary>
        public InvoicePooledHotWalletState State { get; set; }

        /// <summary>
        /// A random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
    }
}
