using System;

namespace Study.Orleans.Data.Models
{
    [Flags]
    public enum InvoiceFlags
    {
        None = 0,

        /// <summary>
        /// prompt the buyer for their name and email address
        /// </summary>
        RequireBuyerNameAndEmail = 1,

        /// <summary>
        /// sends a payment completed e-mail notification to the merchant
        /// </summary>
        SendPaymentCompleteEmailNotification = 2,

        /// <summary>
        /// Is pos.
        /// </summary>
        IsPos = 4
    }
}
