using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BankApplication.Classes;
using BankApplication.PagesMainWindow;
using Transfer = BankApplication.Classes.Transfer;

namespace BankApplication
{
    /// <summary>
    /// Logika interakcji dla klasy SingleTransfer.xaml
    /// </summary>
    public partial class SingleTransfer : Window
    {
        public SingleTransfer()
        {
            InitializeComponent();
        }

        
        HistoryTransfer historyTransfer = new HistoryTransfer();

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            Succes();
        }
        public void Succes()
        {
            Transfer transfer = new Transfer();
            transfer.TransferMoneyFrom(TextBoxAmount.Text);
            transfer.TransferMoneyTo(TextBoxAmount.Text, TextBoxNumberRecipient.Text);
            this.Close();
        }

        private void TextBoxNumberRecipient_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex accTest1 = new Regex("^\\d{1,4}[ ]{1}\\d{1,4}[ ]{1}\\d{1,4}[ ]{1}\\d{1,4}$"); //1234 1234 1234 1234
            Regex accTest2 = new Regex("^\\d{1,16}$"); //1234123412341234
            Regex accTest3 = new Regex("^^\\d{1,4}\\d{1,4}[ ]{1}\\d{1,4}[ ]{1}\\d{1,4}$"); //12341234 1234 1234
            Regex accTest4 = new Regex("^\\d{1,4}\\d{1,4}\\d{1,4}[ ]{1}\\d{1,4}$"); //123412341234 1234
            Regex accTest5 = new Regex("^\\d{1,4}[ ]{1}\\d{1,4}\\d{1,4}\\d{1,4}$"); //1234 123412341234 
            Regex accTest6 = new Regex("^\\d{1,4}\\d{1,4}[ ]{1}\\d{1,4}\\d{1,4}$"); //12341234 12341234
            if (accTest2.Match(TextBoxNumberRecipient.Text).Success && TextBoxNumberRecipient.Text.Length == 16)
            {
                TextBoxNumberRecipient.Text = string.Join(" ", Enumerable.Range(0, TextBoxNumberRecipient.Text.Length / 4).Select(i => TextBoxNumberRecipient.Text.Substring(i * 4, 4)));
            }
        }
    }
}
