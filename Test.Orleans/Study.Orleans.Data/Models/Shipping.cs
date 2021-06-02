using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Orleans.Data.Models
{
    public class Shipping
    {
        /// <summary>
        /// the invoice this shipping information belongs to
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// the shipping method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// the company name of the party to ship the items to
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// the first name of the party to ship the items to
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the last name of the party to ship the items to
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the email of the party to ship the items to
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the phone number of the party to ship the items to
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the address of the party to ship the items to
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// value indicating whether any data has been set on the object
        /// </summary>
        public bool HasData => Method != null || CompanyName != null || FirstName != null || LastName != null
                               || Email != null || PhoneNumber != null || (Address != null && Address.HasData);
    }
}
