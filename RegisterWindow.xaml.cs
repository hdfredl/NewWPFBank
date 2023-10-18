using System.Collections.Generic;
using System.Windows;
using NewWPFBank.Classes;

namespace NewWPFBank;

/// <summary>
/// Interaction logic for RegisterWindow.xaml
/// </summary>
public partial class RegisterWindow : Window
{


    public RegisterWindow(List<User> users)
    {
        InitializeComponent();


    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        string username = txtRegisterUserName.Text;
        string password = txtRegisterPassword.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Username and password are required.");
            return;
        }
        User newUser = new Client(username, password);
        // userManager.AddUser(newUser);
        MessageBox.Show("Registration successful. You can now log in.");
        UserManager.Users.Add(newUser);

        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();


    }
}
