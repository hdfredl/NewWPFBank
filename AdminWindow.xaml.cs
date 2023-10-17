using System.Windows;

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


        }


        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow accountWindow = new MainWindow();
            accountWindow.Show();
            this.Close();
        }

    }
}
