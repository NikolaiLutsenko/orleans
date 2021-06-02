namespace Study.Orleans.Data.Models
{
    /// <summary>
    /// Options to show/hide merchant information on an invoice, or include additional merchant information specific to an invoice
    /// </summary>
    public class MerchantOptions
    {
        /// <summary>
        /// for merchant profile fields that can be shown/hidden on an invoice, if field is present in the flag it should be shown on the invoice.
        /// If no flags provided then default is to show email only.
        /// </summary>
        public MerchantFields ShowFieldsFlag { get; set; } = MerchantFields.ShowEmail;

        /// <summary>
        /// miscellaneous information to be displayed on the invoice, such as business hours or other info specific to the invoice
        /// </summary>
        public string AdditionalInfo { get; set; }

        public MerchantOptions Clone(MerchantOptions original)
        {
            return new MerchantOptions
            {
                ShowFieldsFlag = original.ShowFieldsFlag,
                AdditionalInfo = original.AdditionalInfo
            };
        }
    }
}
