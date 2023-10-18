using System.Windows;
using NewWPFBank.Classes;

namespace NewWPFBank;

/// <summary>
/// Interaction logic for AccountsWindow.xaml
/// </summary>
public partial class AccountsWindow : Window
{
    User user;

    public AccountsWindow(User user) // Hämtar info från Mainwindow.
    {
        InitializeComponent();

        this.user = user;


        if (UserManager.CurrentSignedInUser?.GetType() == typeof(Admin))
        {
            btnAdminView.Visibility = Visibility.Visible;
        }

        foreach (IAccount accounts in user.Accounts)
        {
            if (accounts.GetType() == typeof(SalaryAccount))
            {
                txtSalaryMoney.Text = accounts.Balance.ToString();
                txtAccountNumber.Text = accounts.AccountNumber.ToString();
            }
            else if (accounts.GetType() == typeof(SavingsAccount))
            {
                txtSavedMoney.Text = accounts.Balance.ToString();
                txtSavingsNumber.Text = accounts.AccountNumber.ToString();
            }
            else
            {
                MessageBox.Show("...");
            }
        }

    }


    private void btnTransfer_Click(object sender, RoutedEventArgs e)
    {
        int transfer;
        if (int.TryParse(txtTransferMoney.Text, out transfer))
        {
            if (transfer > 0)
            {
                bool transferSuccessful = false;

                foreach (IAccount account in user.Accounts)
                {
                    if (account.GetType() == typeof(SavingsAccount))
                    {
                        var savingsAccount = (SavingsAccount)account;

                        if (savingsAccount.Balance >= transfer)
                        {
                            transferSuccessful = true;
                            savingsAccount.Balance -= transfer;
                            txtSavedMoney.Text = savingsAccount.Balance.ToString();
                            break; // Breakar loop om det går att överföra pengar
                        }
                        else
                        {
                            MessageBox.Show("Not enough balance in the savings account to make the transfer.");
                            break; // breakar om det inte finns pengar i kontot.
                        }
                    }
                }
                if (transferSuccessful)
                {
                    foreach (IAccount account in user.Accounts)
                    {
                        if (account.GetType() == typeof(SalaryAccount))
                        {
                            var salaryAccount = (SalaryAccount)account;
                            salaryAccount.Balance += transfer;
                            txtSalaryMoney.Text = salaryAccount.Balance.ToString();
                            // Adderar pengar till salarykontot.
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid transfer amount. Please enter a positive amount.");
            }
        }
        else
        {
            MessageBox.Show("Invalid amount. Please enter a valid number.");
        }
    }









    //private void UpdateUI()
    //{
    //    // Rensa tidigare visade konton
    //    lstSavedMoney.Items.Clear();
    //    lstSalaryMoney.Items.Clear();

    //    // Visa endast användarens egna konton
    //    foreach (IAccount account in user.Accounts)
    //    {
    //        if (account is SavingsAccount)
    //        {
    //            lstSavedMoney.Items.Add(new ListViewItem { Content = $"Savings Account: {account.Balance} SEK" });

    //        }
    //        else if (account is SalaryAccount)
    //        {
    //            lstSalaryMoney.Items.Add(new ListViewItem { Content = $"Salary Account: {account.Balance} SEK" });

    //        }
    //    }












    private void LogOut_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Close();
        mainWindow.Show();
    }

    private void AdminView_Click(object sender, RoutedEventArgs e)
    {
        AdminWindow adminWindow = new AdminWindow();
        adminWindow.Show();
        this.Close();
    }
}




//int transfer = int.Parse(txtTransferMoney.Text);
//foreach (IAccount accounts in user.Accounts)
//{

//    if (accounts.GetType() == typeof(SavingsAccount))
//    {
//        accounts.Balance -= transfer;
//        txtSavedMoney.Text = accounts.Balance.ToString();

//    }
//    else if (accounts.GetType() == typeof(SalaryAccount))
//    {
//        accounts.Balance += transfer;
//        txtSalaryMoney.Text = accounts.Balance.ToString();
//    }
//    else { MessageBox.Show("..."); }

//}