using System;

namespace Study.Orleans.Data.Models
{
    [Flags]
    public enum InvoicePaymentSettlementModeError
    {
        Unknown = 0,
        NegativeRate = 1,
        PayoutAddressIsNull = 2,
        PaymentSubTotalIsLessThanMerchantTotalFee = 4,
        TotalBuyerWillPayIsNegativeOrZero = 8,
        TotalBuyerWillPayIsLessThanBuyerNetworkFee = 16,
        TotalMerchantFeeRatioIsMoreThanMaximumRatioSetting = 32,
        PayoutAmountIsLessThanDust = 64,
        CurrencyIsNotActive = 128,
        AmountIsBelowOfConversionLimit = 256,
        AmountIsAboveOfConversionLimit = 512,
        UserLimitIsReached = 1024,
        NotEnoughToActivateRippleAddress = 2048,
        ConversionPairDoesNotExist = 4096,
        AddressIsNotValid = 8_192,
        DoesNotHaveCompletedKyc = 16_384,
        UnstoppableDomainNotFound = 32_768,
        UnstoppableDomainNotFoundForCurrency = 65_536
    }
}
