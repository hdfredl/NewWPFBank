using System;

namespace NewWPFBank.Classes
{
    public class Client : User
    {
        public Client(string username, string password) : base(username, password, 0, 0)
        {
            var random = new Random();
            int startBalance = random.Next(0, 1001); // Skapar en int som håller mellan 0-1000 . 


            var savingsAccount = new SavingsAccount(startBalance); // Skapar ett konto nr, random. 
            Accounts.Add(savingsAccount); // skapar ett konto till SavingsAccount


            var salaryAccount = new SalaryAccount(0); // Skapar ett konto nr, random. 
            Accounts.Add(salaryAccount); // Skapar ett kontot till SalaryAccount

            // 2 variabler har lagts till i User - IAccount
        }
    }
}
