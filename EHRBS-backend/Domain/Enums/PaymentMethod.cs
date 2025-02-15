namespace EHRBS_backend.Domain.Enums
{
    public enum PaymentMethod
    {
        //Undecided

        Cash = 1,
        CreditCard = 2,
        DebitCard = 3,
        Insurance = 4,
        BankTransfer = 5,
        MobilePayment = 6, // (e.g., Apple Pay, Google Pay)
        OnlinePayment = 7, // (e.g., PayPal, Stripe)
        Other = 99 // (For any other custom method)
    }
}
