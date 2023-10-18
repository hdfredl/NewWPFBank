using System;

namespace NewWPFBank.Classes
{
    public class SalaryAccount : IAccount
    {
        public double Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserAccountOwner { get; set; }

        public SalaryAccount(double consumeBalance)
        {
            AccountNumber = Guid.NewGuid().GetHashCode();
            Balance = consumeBalance;
        }



    }

}