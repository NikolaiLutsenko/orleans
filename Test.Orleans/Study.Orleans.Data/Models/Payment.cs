using System;

namespace Study.Orleans.Data.Models
{
    public class Payment
    {
        /// <summary>
        /// the unique id of the invoice (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// the id of the invoice this payment attempt belongs to
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// the timestamp when the payment attempt was created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// the timestamp when the payment attempt expires, payments can't be made within this attempt past this time
        /// </summary>
        public DateTimeOffset Expires { get; set; }

        /// <summary>
        /// the timestamp of when the payment was manually cancelled (invoice cancelled)
        /// </summary>
        public DateTimeOffset? Cancelled { get; set; }

        /// <summary>
        /// the timestamp of when the first payments were detected
        /// </summary>
        public DateTimeOffset? Detected { get; set; }

        /// <summary>
        /// the timestamp of when the full payment amount was detected
        /// </summary>
        public DateTimeOffset? Pending { get; set; }

        /// <summary>
        /// the timestamp of when the payment was fully paid and confirmed
        /// </summary>
        public DateTimeOffset? Confirmed { get; set; }

        /// <summary>
        /// the timestamp of when the payment was completed, paid out and overage refund claims sent
        /// </summary>
        public DateTimeOffset? Completed { get; set; }

        /// <summary>
        /// the timestamp of when the payment was scheduled for payout
        /// </summary>
        public DateTimeOffset? ScheduledForPayout { get; set; }

        /// <summary>
        /// the state of the invoice payment
        /// </summary>
        public InvoicePaymentState State { get; set; }

        /// <summary>
        /// the timestamp of when the payment was refunded
        /// </summary>
        public DateTimeOffset? Refunded { get; set; }

        /// <summary>
        /// the e-mail address to send refund instructions to, in case of payment failures
        /// </summary>
        public string RefundEmail { get; set; }

        /// <summary>
        /// random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();
    }
}
