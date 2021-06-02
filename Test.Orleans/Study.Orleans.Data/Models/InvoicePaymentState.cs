namespace Study.Orleans.Data.Models
{
    public enum InvoicePaymentState
    {
        /// <summary>
        /// active but no payments have been detected
        /// </summary>
        Created = 1,

        /// <summary>
        /// payments detected in the mem-pool
        /// </summary>
        Detected = 2,

        /// <summary>
        /// partially or completely paid but the payments have not yet been confirmed
        /// </summary>
        Pending = 3,

        /// <summary>
        /// payments have been confirmed and enough funds were received to cover the invoice amount
        /// </summary>
        Confirmed = 4,

        /// <summary>
        /// payments have been scheduled for payout to the merchant
        /// </summary>
        ScheduledForPayout = 5,

        /// <summary>
        /// payments have been paid-out to the merchants wallets and any over-payments have claim refunds sent
        /// </summary>
        Completed = 6,

        /// <summary>
        /// payment manually cancelled
        /// </summary>
        Cancelled = 10,

        /// <summary>
        /// payment timed out, was not paid within the time limit and can no longer receive payments
        /// </summary>
        TimedOut = 11,

        /// <summary>
        /// any refunds have been sent
        /// </summary>
        Refunded = 16
    }
}
