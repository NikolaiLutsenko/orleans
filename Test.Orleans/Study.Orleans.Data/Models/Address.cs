namespace Study.Orleans.Data.Models
{
    public class Address
    {
        /// <summary>
        /// the first line of the address. For example, number or street.
        /// </summary>
        /// <example>123 Fake street</example>
        public string Address1 { get; set; }

        /// <summary>
        /// the second line of the address. For example, suite or apartment number.
        /// </summary>
        /// <example>Apartment 42</example>
        public string Address2 { get; set; }

        /// <summary>
        /// the third line of the address, if needed. For example, a street complement for Brazil, direction text 
        /// such as 'next to Walmart', or a landmark in an Indian address.
        /// </summary>
        public string Address3 { get; set; }

        /// <summary>
        /// the highest level sub-division in a country, which is usually a province, state, or ISO-3166-2 subdivision.
        ///
        /// Format for postal delivery. For example, `CA` instead of `California`
        /// 
        ///  - UK: county
        ///  - US: state
        ///  - Canada: province
        ///  - Japan: prefecture
        ///  - Switzerland: kanton
        /// </summary>
        /// <example>BC</example>
        public string ProvinceOrState { get; set; }

        /// <summary>
        /// the city, town or village
        /// </summary>
        /// <example>Vancouver</example>
        public string City { get; set; }

        /// <summary>
        /// the neighborhood, suburb or district.
        ///   - Brazil: Suburb, bairoo, or neighborhood
        ///   - India: Sub-locality or district, Street name information is not always available but a sub-locality
        ///            or district can be a very small area
        /// </summary>
        public string SuburbOrDistrict { get; set; }

        /// <summary>
        /// the two-character IS0-3166-1 country code
        /// </summary>
        /// <example>CA</example>
        public string CountryCode { get; set; }

        /// <summary>
        /// the postal code, which is the zip code or equivalent.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// value indicating whether any data has been set on the object
        /// </summary>
        public bool HasData =>
            Address1 != null || Address2 != null || Address3 != null || ProvinceOrState != null ||
            City != null || SuburbOrDistrict != null || CountryCode != null || PostalCode != null;
    }
}
