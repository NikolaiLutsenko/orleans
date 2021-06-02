using System;

namespace Study.Orleans.Data.Models
{
    public class Buyer
    {
        /// <summary>
        /// the invoice this buyer belongs to
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// the company name of the buyer
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// the buyer's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the buyer's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the buyer's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the buyer's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the buyer's address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// value indicating whether any data has been set on the object
        /// </summary>
        public bool HasData => CompanyName != null || FirstName != null || LastName != null || Email != null ||
                               PhoneNumber != null || (Address != null && Address.HasData);
    }
}
