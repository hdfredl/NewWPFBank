using System.Collections.Generic;

namespace NewWPFBank.Classes
{
    public static class UserManager // "Databas" 
    {
        public static List<User> Users { get; set; } = new() { new Admin("admin", "password", 0, 0) };
        //public static List<User> users = new List<User>(); // Skapa en lista för users, så man kan "logga in"
        //public double client1 { get; set; } = 5000;
        public static List<IAccount> allAccounts = new List<IAccount>();
        public static User? CurrentSignedInUser { get; set; }
        static UserManager()
        {

            ; // Skapar 3 tillfälliga konton i UserManager så man kan logga på något sätt.
            Users.Add(new Client("user1", "user1password")); // Hämtat data från Client. 
            Users.Add(new Client("user2", "user2password"));


        }

        //public static bool SignInUIser(string username, string password)
        //{
        //    foreach (var user in Users)
        //    {
        //        if (user.Username == username && user.Password == password)
        //        {
        //            CurrentSignedInUser = user;

        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static User AuthenticateUser(string username, string password) // Ser om användaren skriver in rätt användarnamn och lösenord.
        {
            foreach (User user in Users) // Ändrat denna, se om det funkar
            {
                if (user.Username == username && user.Password == password)
                {
                    CurrentSignedInUser = user;
                    return user;
                }
            }

            return null;
        }

        public static void AddUser(User user) // Metod som adderar en user till List<User> som kan användas på andra ställen. 
        {
            Users.Add(user);
        }

        public static List<IAccount> AllAccounts()
        {
            return allAccounts;
        }

    }
}
