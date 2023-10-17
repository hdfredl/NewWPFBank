using System.Windows;
using System.Windows.Controls;
using NewWPFBank.Classes;

namespace NewWPFBank;

/// <summary>
/// Interaction logic for AccountsWindow.xaml
/// </summary>
public partial class AccountsWindow : Window
{
    User user;

    public AccountsWindow(User user) // Undersök sen? 
    {
        InitializeComponent();
        this.user = user;

        foreach (IAccount accounts in user.Accounts)
        {
            if (accounts.GetType() == typeof(SalaryAccount))
            {
                txtSalaryMoney.Text = accounts.Balance.ToString();
            }
            else if (accounts.GetType() == typeof(SavingsAccount))
            {
                txtSavedMoney.Text = accounts.Balance.ToString();
            }
            else
            {
                MessageBox.Show("...");
            }
        }

        UpdateUI();

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
                            break; // Exit the loop after a successful transfer
                        }
                        else
                        {
                            MessageBox.Show("Not enough balance in the savings account to make the transfer.");
                            break; // Exit the loop if there's not enough balance
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

    }
    private void UpdateUI()
    {
        // Rensa tidigare visade konton
        lstSavedMoney.Items.Clear();
        lstSalaryMoney.Items.Clear();

        // Visa endast användarens egna konton
        foreach (IAccount account in user.Accounts)
        {
            if (account is SavingsAccount)
            {
                lstSavedMoney.Items.Add(new ListViewItem { Content = $"Savings Account: {account.Balance} SEK" });

            }
            else if (account is SalaryAccount)
            {
                lstSalaryMoney.Items.Add(new ListViewItem { Content = $"Salary Account: {account.Balance} SEK" });

            }

        }

    }
    // txtSalaryMoney.Text = salaryAccount.Balance.ToString();

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



