using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

    public partial class Homepage : Window
    {
        private string accountNumber;
        private decimal balance;
        MainWindow mw;

        public Homepage(string accountNumber, decimal balance)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        private void Button_Withdrawal_Click(object sender, RoutedEventArgs e)
        {
            Withdraw withdrawal = new Withdraw(accountNumber, balance, mw);
            withdrawal.ShowDialog();
            this.Close();
        }

        private void Button_Deposit_Click(object sender, RoutedEventArgs e)
        {
            Deposit deposit = new Deposit(accountNumber, balance, mw);
            deposit.ShowDialog();
            this.Close();

        }

        private void Button_BalanceCheck_Click(object sender, RoutedEventArgs e)
        {
            Balance_Check balanceCheck = new Balance_Check(accountNumber, balance);
            balanceCheck.ShowDialog();
            this.Close();

        }

    }
}
