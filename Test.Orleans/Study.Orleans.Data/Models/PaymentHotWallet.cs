using System;

namespace Study.Orleans.Data.Models
{
    public class PaymentHotWallet
    {
        /// <summary>
        /// the unique id of the hot wallet (PK)
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// the id of the invoice to which this hot wallet belongs
        /// </summary>
        public Guid InvoicePaymentId { get; set; }

        /// <summary>
        /// the id of the currency for the hot wallet to receive
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// the currency conversion rate to convert into <see cref="Currency"/> from the invoice's currency
        /// </summary>
        public decimal CurrencyRateFromInvoiceCurrency { get; set; }

        /// <summary>
        /// the timestamp when the hot wallet was created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// the wallets receive address where buyer payments are received
        /// </summary>
        public string PaymentReceiveAddress { get; set; }

        /// <summary>
        /// the merchants payment output address at the time the hot wallet was created
        /// </summary>
        /// <remarks>
        /// the latest payout addresses will be looked up at the time of pay out and this one will be used as a backup
        /// if for example the merchant disables a payment currency while payments are in progress
        /// </remarks>
        public string MerchantPayoutAddress { get; set; }

        /// <summary>
        /// the id of the merchant payout wallet
        /// </summary>
        public Guid? MerchantPayoutWalletId { get; set; }

        /// <summary>
        /// the currency id of the wallet having id equal to <see cref="MerchantPayoutWalletId"/>
        /// </summary>
        public int MerchantPayoutWalletCurrencyId { get; set; }

        /// <summary>
        /// the subtotal of the payment, the original payment amount without any fees, in the smallest units of the
        /// payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal PaymentSubTotal { get; set; }

        /// <summary>
        /// the CoinPayments service fee, charged to the buyer, in the smallest units of the
        /// payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal BuyerCoinPaymentsFee { get; set; }

        /// <summary>
        /// the currency network fee, charged to the buyer, in the smallest units of the
        /// payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal BuyerNetworkFee { get; set; }

        /// <summary>
        /// the markup or discount applied to the payment amount by the merchant
        /// </summary>
        public decimal MerchantMarkupOrDiscount { get; set; }

        /// <summary>
        /// the CoinPayments service fee, charged to the merchant, in the smallest units of the
        /// payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal MerchantCoinPaymentsFee { get; set; }

        /// <summary>
        /// the currency network fee, charged to the merchant, in the smallest units of the
        /// payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal MerchantNetworkFee { get; set; }

        /// <summary>
        /// the expected total amount to be received from the buyer
        /// </summary>
        public decimal TotalBuyerWillPay => PaymentSubTotal + BuyerCoinPaymentsFee + BuyerNetworkFee + MerchantMarkupOrDiscount;

        /// <summary>
        /// the expected payout to the merchant if <see cref="TotalBuyerWillPay"/> is received in this wallet, in the
        /// smallest units of the payment <see cref="Currency"/> (e.g. Satoshis for Bitcoin)
        /// </summary>
        public decimal TotalMerchantWillReceive => PaymentSubTotal + MerchantMarkupOrDiscount - MerchantCoinPaymentsFee - MerchantNetworkFee - MerchantConversionFee;

        /// <summary>
        /// the sum of the CoinPayments service fees charged to the buyer and merchant
        /// </summary>
        public decimal TotalCoinPaymentsServiceFees => BuyerCoinPaymentsFee + MerchantCoinPaymentsFee;

        /// <summary>
        /// the sum of the network fees charged to the buyer and merchant
        /// </summary>
        public decimal TotalNetworkFees => BuyerNetworkFee + MerchantNetworkFee + MerchantConversionFee;

        /// <summary>
        /// A random value that must change whenever the entity is persisted to the store
        /// </summary>
        public string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Smart contract address.
        /// </summary>
        public string ContractAddress { get; set; }

        /// <summary>
        /// Payout contract address.
        /// </summary>
        public string MerchantPayoutContractAddress { get; set; }

        /// <summary>
        /// Marks payment as conversion. We need this flag as PayoutAddress, PayoutCurrencyId, PayoutContractAddress could be rewritten
        /// </summary>
        public bool IsConversion { get; set; }

        public decimal BuyerConversionFee { get; set; }

        public decimal MerchantConversionFee { get; set; }

        public InvoicePaymentSettlementModeError? SettlementModeError { get; set; }

        public string SettlementModeErrorMessage { get; set; }

        public MerchantPaymentCurrencyPayoutFrequency? PayoutFrequency { get; set; }
    }
}
