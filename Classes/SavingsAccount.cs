using System;

namespace NewWPFBank.Classes
{
    public class SavingsAccount : IAccount
    {
        public double Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserAccountOwner { get; set; }

        public SavingsAccount(double initialBalance)
        {
            AccountNumber = Guid.NewGuid().GetHashCode();
            Balance = initialBalance;
        }
    }

}
