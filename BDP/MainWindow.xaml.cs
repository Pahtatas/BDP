using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BDP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, decimal> accountBal = new Dictionary<string, decimal>();
        private List<string> accountNumbers = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            LoadthePotatoes();
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string number = button.Content.ToString();
                txtBox_AcctNum.Text += number;
            }
        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            string potatoNumber = txtBox_AcctNum.Text;
            if (accountNumbers.Contains(potatoNumber))
            {
                Homepage homepage = new Homepage(potatoNumber, accountBal[potatoNumber]);
                homepage.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid account number");
            }
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtBox_AcctNum.Clear();
        }
        private void LoadthePotatoes()
        {
            string filePath = @"C:\Users\Acer\Downloads\Account Names.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        accountNumbers.Add(parts[0]);
                        accountBal.Add(parts[0], decimal.Parse(parts[1]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid line format: " + line);
                    }
                }
            }
        }

        public void SavethePotatoes()
        {
            string filePath = @"C:\Users\Acer\Downloads\Account Names.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var potato in accountBal)
                {
                    writer.WriteLine($"{potato.Key},{potato.Value}");
                }
            }
        }

        public void GenerateReceipt(string transactionType, decimal amount, decimal newBalance, string accountNumber)
        {
            string receipt = $"Type of Transaction: {transactionType}\n" +
                             $"Account number: {accountNumber}\n" +
                             $"Date: {DateTime.Now.ToShortDateString()}\n" +
                             $"Time: {DateTime.Now.ToShortTimeString()}\n" +
                             $"Cash In:/Cash Out: {amount:F2}\n" +
                             $"New Balance: {newBalance:F2}";
            File.WriteAllText($"receipt_{accountNumber}_{DateTime.Now.Ticks}.txt", receipt);
        }

        public void UpdateLog(string transactionType, decimal amount, decimal newBalance, string accountNumber)
        {
            string logEntry = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} {transactionType} {accountNumber} {amount:F2} {newBalance:F2}";
            File.AppendAllText($"log_{accountNumber}.txt", logEntry + Environment.NewLine);
        }
    }
}






//private void txtBox_AcctNum_TextChanged(object sender, TextChangedEventArgs e)
//{
//    if (!string.IsNullOrEmpty(txtBox_AcctNum.Text))
//    {
//        foreach (char c in txtBox_AcctNum.Text)
//        {
//            if (char.IsDigit(c))
//            {
//                txtBox_AcctNum.Text += c;
//            }
//        }
//        else { 
//        }
//    }
//}






