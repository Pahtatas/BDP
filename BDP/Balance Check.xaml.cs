using System;
using System.IO;
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
    public partial class Balance_Check : Window
    {
        private string accountNumber;
        private decimal balance;

        public Balance_Check(string accountNumber, decimal balance)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.balance = balance;
            Balance.Content = $"Balance: {balance}";
        }

        private void Button_BalanceCheck_Click(object sender, RoutedEventArgs e)
        {
            GenerateBalanceCheckReceipt();
            this.Close();
        }

        private void GenerateBalanceCheckReceipt()
        {
            string receipt = $"Account Number: {accountNumber}\n" +
                             $"-----Date-----Type of Transaction-----Withdrawal-----Deposit-----Balance-----\n" +
                             $"{DateTime.Now.ToShortDateString()} BC 0 0 {balance:F2}";
            string receiptFileName = $"balance_check_{accountNumber}_{DateTime.Now.Ticks}.txt";

            try
            {
                File.WriteAllText(receiptFileName, receipt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing receipt file: {ex.Message}");
            }
        }
    }
}
