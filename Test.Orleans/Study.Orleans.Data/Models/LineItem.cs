using System;

namespace Study.Orleans.Data.Models
{
    public class LineItem
    {
        /// <summary>
        /// the unique id of the line item (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// the id of the invoice to which this item belongs
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// the invoice to which this item belongs
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// the API caller provided external ID for the item.  Appears on the Merchant dashboard and reports only.
        /// </summary>
        public string CustomId { get; set; }

        /// <summary>
        /// the stock keeping unit (SKU) of the item
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// the name or title of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the detailed description of the item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the quantity of the item.  Must be greater than 0 and less than 999,999,999‬
        /// </summary>
        public int Quantity { get; set; }

        public LineItemType Type { get; set; }

        /// <summary>
        /// the subtotal price of the item
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// the original total price of the item if <see cref="Amount"/> represents a discounted price
        /// </summary>
        public decimal? OriginalAmount { get; set; }

        /// <summary>
        /// the total taxes charged on this item
        /// </summary>
        public decimal? Tax { get; set; }

        public LineItem Clone(LineItem original, Guid invoiceId)
        {
            return new LineItem
            {
                Id = Guid.NewGuid(),
                InvoiceId = invoiceId,
                Amount = original.Amount,
                CustomId = original.CustomId,
                Description = original.Description,
                Name = original.Name,
                OriginalAmount = original.OriginalAmount,
                Quantity = original.Quantity,
                SKU = original.SKU,
                Tax = original.Tax,
                Type = original.Type
            };
        }
    }
}
