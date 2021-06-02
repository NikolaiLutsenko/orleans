using System;

namespace Study.Orleans.Data.Models
{
    /// <summary>
    /// Indicates merchant profile fields that can be shown or hidden on an invoice
    /// </summary>
    [Flags]
    public enum MerchantFields
    {
        ShowNone = 0,
        ShowAddress = 0x01,
        ShowEmail = 0x02,
        ShowPhone = 0x04,
        ShowRegistrationNumber = 0x08
    }
}
