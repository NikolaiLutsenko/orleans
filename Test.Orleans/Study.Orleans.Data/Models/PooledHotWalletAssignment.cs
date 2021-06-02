using System;

namespace Study.Orleans.Data.Models
{
    /// <summary>
    /// Represents the assigned of a pooled hot wallet to a particular invoice payment
    /// </summary>
    public class PooledHotWalletAssignment
    {
        /// <summary>
        /// the id of the pooled hot wallet assigned to the <see cref="Models.Payment"/>
        /// </summary>
        public Guid InvoicePooledHotWalletId { get; set; }

        /// <summary>
        /// the id of the <see cref="PaymentHotWallet"/> to which the <see cref="Models.PooledHotWallet"/> is assigned
        /// </summary>
        public Guid InvoicePaymentHotWalletId { get; set; }

        /// <summary>
        /// the timestamp from which the pooled hot wallet is assigned to an invoice payment
        /// </summary>
        public DateTimeOffset AssignedFrom { get; set; }

        /// <summary>
        /// the timestamp to which the pooled hot wallet is assigned to an invoice payment
        /// </summary>
        public DateTimeOffset AssignedUntil { get; set; }

        /// <summary>
        /// Is assignment completed
        /// </summary>
        public bool IsCompleted { get; set; }

        public DateTimeOffset? CompletedDate { get; set; }

        /// <summary>
        /// A random value that must change whenever the entity is persisted to the store
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
