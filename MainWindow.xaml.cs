using System.Collections.Generic;
using System.Windows;
using NewWPFBank.Classes;

namespace NewWPFBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> Users;
        public MainWindow()
        {
            InitializeComponent();


        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtPassword.Password.ToString();
            /* UserManager userManager = new UserManager();*/ // hämtar tillfälliga konton från UserManager som man kan logga in med. Öppnar en ny ruta.. 
            User user = UserManager.AuthenticateUser(username, password);

            if (user != null)
            {
                MessageBox.Show("Login successful.");

                AccountsWindow accounts = new AccountsWindow(user); // öppnar AccountsWindow. CHECK. Och skickar med username o password.
                accounts.Show();
                this.Close();
            }


        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(Users); // Öppnar Register Window. CHECK.
            registerWindow.Show();
            this.Close();
        }

        private void AdminLogIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
