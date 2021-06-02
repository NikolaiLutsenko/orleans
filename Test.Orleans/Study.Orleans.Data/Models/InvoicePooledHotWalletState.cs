namespace Study.Orleans.Data.Models
{
    public enum InvoicePooledHotWalletState
    {
        /// <summary>
        /// creation of the wallet is in progress
        /// </summary>
        Creating = 0,

        /// <summary>
        /// available for assignment to an invoice
        /// </summary>
        Available = 10,

        /// <summary>
        /// currently assigned to an invoice
        /// </summary>
        Assigned = 20
    }
}
