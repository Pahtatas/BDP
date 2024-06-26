using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDP
{
    public partial class Deposit : Window
    {
        private string AccountNumber;
        private decimal balance;

        private MainWindow mainWindow;


        public Deposit(string acctNumber, decimal bal, MainWindow mainWindow)
        {
            InitializeComponent();
            AccountNumber = acctNumber;
            balance = bal;
            this.mainWindow = mainWindow;
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string number = button.Content.ToString();
                txtBox_Amount.Text += number;
            }
        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = decimal.Parse(txtBox_Amount.Text);
            balance += amount;
            mainWindow.GenerateReceipt("Withdrawal", amount, balance, AccountNumber);
            mainWindow.UpdateLog("DP", amount, balance, AccountNumber);
            MessageBox.Show("Deposit successful");
            ((MainWindow)Application.Current.MainWindow).SavethePotatoes();
            mainWindow.SavethePotatoes();
            mainWindow.accountBal[AccountNumber] = balance;
            this.Close();


        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Amount.Clear();
        }

    }
}
