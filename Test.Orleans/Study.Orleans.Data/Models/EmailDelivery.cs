namespace Study.Orleans.Data.Models
{
    /// <summary>
    /// Encapsulates the email delivery options of invoices
    /// </summary>
    public class EmailDelivery
    {
        /// <summary>
        /// the To field of an invoice email
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// the Cc field of an invoice email
        /// </summary>
        public string Cc { get; set; }

        /// <summary>
        /// the Bcc field of an invoice email
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        /// Used to determine whether email delivery is used. Will have non null values if email delivery is to be used (empty strings allowed for drafts)
        /// </summary>
        public bool HasNonNullData => To != null || Cc != null || Bcc != null;

        public EmailDelivery Clone(EmailDelivery original, string customerToBill)
        {
            return new EmailDelivery
            {
                To = customerToBill,
                Cc = original.Cc,
                Bcc = original.Bcc
            };
        }
    }
}
