using System;
using System.Collections.Generic;

namespace Study.Orleans.Data.Models
{
    public class Invoice
    {
        /// <summary>
        /// the unique id of the invoice (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// the id of the merchant this invoice belongs to
        /// </summary>
        public Guid MerchantId { get; set; }

        /// <summary>
        /// options to show/hide merchant information on an invoice, or include additional merchant information specific to an invoice
        /// </summary>
        public MerchantOptions MerchantOptions { get; set; }

        /// <summary>
        /// the id of the client this invoice was created by
        /// </summary>
        /// <remarks>
        /// if this invoice was created internally there may not be a client id attached
        /// </remarks>
        public Guid? MerchantClientId { get; set; }

        /// <summary>
        /// the optional API caller provided external invoice number.  Appears in screens shown to the Buyer and emails sent.
        /// Note: Can have duplicates if invoice is emailed to multiple customers
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// the optional numeric suffix for the <see cref="InvoiceId"/>. Used for when invoice is emailed to multiple customers
        /// </summary>
        public string InvoiceIdSuffix { get; set; }

        /// <summary>
        /// the timestamp when the invoice entity was created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// the explicit expiry date of the invoice, for checkout and POS invoices, after this time they can no longer be paid
        /// </summary>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// the custom user specified date and time of the invoice (when it becomes active),
        /// if not set then same as <see cref="Created"/>
        /// </summary>
        public DateTimeOffset? InvoiceDate { get; set; }

        /// <summary>
        /// the timestamp of when the invoice is due
        /// </summary>
        public DateTimeOffset? DueDate { get; set; }

        /// <summary>
        /// the timestamp when the invoice was confirmed (paid)
        /// </summary>
        public DateTimeOffset? Confirmed { get; set; }

        /// <summary>
        /// the timestamp when the invoice was completed (paid out to the merchant and CoinPayments fees)
        /// </summary>
        public DateTimeOffset? Completed { get; set; }

        /// <summary>
        /// the timestamp when the invoice was manually cancelled. Applicable for payment invoices only
        /// </summary>
        public DateTimeOffset? Cancelled { get; set; }

        /// <summary>
        /// the buyer information of the invoice
        /// </summary>
        public Buyer Buyer { get; set; }

        /// <summary>
        /// the purchase description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the id of the currency the invoice is charged in
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// the subtotal amount of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal? Subtotal { get; set; }

        /// <summary>
        /// the shipping cost of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal? ShippingTotal { get; set; }

        /// <summary>
        /// the handling cost of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal? HandlingTotal { get; set; }

        /// <summary>
        /// the total taxes of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal? TaxTotal { get; set; }

        /// <summary>
        /// the total discounts of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal? DiscountTotal { get; set; }

        /// <summary>
        /// the total amount of the invoice in the invoice currencies smallest units (e.g. Satoshis for Bitcoin, Wei for Ethereum)
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// the shipping method and address, if applicable
        /// </summary>
        public Shipping Shipping { get; set; }

        /// <summary>
        /// any custom data the caller wishes to attach to the invoice which will be sent back in notifications
        /// </summary>
        public string CustomData { get; set; }

        /// <summary>
        /// the optional array of items and/or services that a buyer intends to purchase from the merchant
        /// </summary>
        public ICollection<LineItem> Items { get; set; }

        /// <summary>
        /// the state of the invoice
        /// </summary>
        public InvoiceState State { get; set; }

        /// <summary>
        /// additional flags (e.g. prompt the buyer for their name and email)
        /// </summary>
        public InvoiceFlags Flags { get; set; }

        /// <summary>
        /// the message to display when collecting buyer user data
        /// </summary>
        public string BuyerDataCollectionMessage { get; set; }

        /// <summary>
        /// notes for the merchant only, these are not visible to the buyers
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// any additional information to share with the buyer about the transaction
        /// </summary>
        public string NotesToRecipient { get; set; }

        /// <summary>
        /// any terms and conditions, e.g. a cancellation policy
        /// </summary>
        public string TermsAndConditions { get; set; }

        /// <summary>
        /// the integration from which the invoice was created
        /// </summary>
        public string MetaSourceIntegration { get; set; }

        /// <summary>
        /// the hostname on which the invoice was created
        /// </summary>
        public string MetaSourceHostname { get; set; }

        /// <summary>
        /// the email delivery options for the current invoice
        /// </summary>
        public EmailDelivery EmailDeliveryOptions { get; set; }

        /// <summary>
        /// random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// place order number
        /// </summary>
        public string PONumber { get; set; }
    }
}
