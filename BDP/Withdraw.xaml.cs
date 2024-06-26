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
    public partial class Withdraw : Window
    {
        public string AccountNumber;
        private decimal balance;

        private MainWindow mainWindow;

        public Withdraw(string acctNumber, decimal bal, MainWindow mainWindow)
        {
            InitializeComponent();
            AccountNumber = acctNumber;
            balance = bal;
            this.mainWindow = mainWindow;

        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = decimal.Parse(txtBox_Amount.Text);
            if (amount <= balance)
            {
                balance -= amount;
                mainWindow.GenerateReceipt("Withdrawal", amount, balance, AccountNumber);
                mainWindow.UpdateLog("WD", amount, balance, AccountNumber);
                MessageBox.Show("Withdrawal successful");
                mainWindow.SavethePotatoes();
                mainWindow.accountBal[AccountNumber] = balance;
                this.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance");
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Amount.Clear();
        }
        private void Type(object sender, RoutedEventArgs e)
        {
            Button b = new Button();
            b = (Button)sender;
            txtBox_Amount.Text += b.Content;
        }
    }
}
