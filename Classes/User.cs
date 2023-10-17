using System.Collections.Generic;

namespace NewWPFBank.Classes
{
    public abstract class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public double Savings { get; set; }
        public List<IAccount> Accounts { get; } = new List<IAccount>(); // Skapa en lista där users sparas i.

        public int UserAccountOwner { get; set; }

        // public bool IsAdmin { get; set; } // Undersök snart!

        public User(string username, string password, double salary, double savings)
        {
            Username = username;
            Password = password;
            Salary = salary;
            Savings = savings;

        }

        public List<IAccount> GetUserAccounts()
        {
            return Accounts; // Undersök sen

        }

    }
}
