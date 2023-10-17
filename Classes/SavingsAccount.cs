namespace NewWPFBank.Classes
{
    public class SavingsAccount : IAccount
    {
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
        public int UserAccountOwner { get; set; }

        public SavingsAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
    }

}
