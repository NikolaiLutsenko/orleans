namespace Study.Orleans.Data.Models
{
    /// <summary>
    /// Specifies the frequency of payments into merchant wallets for a particular merchant payment currency
    /// </summary>
    public enum MerchantPaymentCurrencyPayoutFrequency
    {
        /// <summary>
        /// normal payout frequency, could be daily
        /// </summary>
        Normal = 1,

        /// <summary>
        /// payout as soon as possible
        /// </summary>
        AsSoonAsPossible = 2,

        /// <summary>
        /// payout every hour at HH:00:00 (0 minutes, 0 seconds)
        /// </summary>
        Hourly = 3,

        /// <summary>
        /// payout every day at 00:00:00 (midnight)
        /// </summary>
        Nightly = 4,

        /// <summary>
        /// payout every week at 00:00:00 (midnight) on Monday
        /// </summary>
        Weekly = 5
    }
}
