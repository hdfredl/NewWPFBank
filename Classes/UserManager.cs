using System.Collections.Generic;

namespace NewWPFBank.Classes
{
    public static class UserManager // "Databas" 
    {
        public static List<User> Users { get; set; } = new();
        public static List<User> users = new List<User>(); // Skapa en lista för users, så man kan "logga in"
                                                           //public double client1 { get; set; } = 5000;
        public static List<IAccount> allAccounts = new List<IAccount>();

        static UserManager()
        {

            users.Add(new Admin("admin", "adminspassword", 500, 2000)); // Skapar 3 tillfälliga konton i UserManager så man kan logga på något sätt.
            users.Add(new Client("user1", "user1password")); // Hämtat data från Client. 
            users.Add(new Client("user2", "user2password"));


        }

        public static User AuthenticateUser(string username, string password) // Ser om användaren skriver in rätt användarnamn och lösenord.
        {
            foreach (User user in users) // Ändrat denna, se om det funkar
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static void AddUser(User user) // Metod som adderar en user till List<User> som kan användas på andra ställen. 
        {
            users.Add(user);
        }

        public static List<IAccount> AllAccounts()
        {
            return allAccounts;
        }

    }
}
