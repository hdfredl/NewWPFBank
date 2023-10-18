using System.Collections.Generic;
using System.Windows;
using NewWPFBank.Classes;

namespace NewWPFBank
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {


        public AdminWindow() // Flyttar alla variabler /objekt hit till AdminWindow så man kan se dom.
        {
            InitializeComponent();

            // Lista
            List<IAccount> accounts = new();
            // Foreach varje user
            foreach (User user in UserManager.Users) // Loopa genom statisk lista
            {
                foreach (IAccount account in user.Accounts)
                {
                    accounts.Add(account);


                }

            }
            lstAllAccounts.ItemsSource = accounts;
            // Foreaach varje account




            // Displaya dom i lstAllAccounts





        }


        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow accountWindow = new MainWindow();
            accountWindow.Show();
            this.Close();
        }

    }
}
