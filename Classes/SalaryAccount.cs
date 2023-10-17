namespace NewWPFBank.Classes
{
    public class SalaryAccount : IAccount
    {
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
        public int UserAccountOwner { get; set; }

        public SalaryAccount(string accountNumber, double consumeBalance)
        {
            AccountNumber = accountNumber;
            Balance = consumeBalance;
        }
    }

}