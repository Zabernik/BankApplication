using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
            if(CheckRequirments() is true) 
            {
                Succes();
            }
            
        }
        public void Succes()
        {
            Transfer transfer = new Transfer();
            HistoryTransfer historyTransfer = new HistoryTransfer();

            transfer.TransferMoneyFrom(TextBoxAmount.Text);
            transfer.TransferMoneyTo(TextBoxAmount.Text, TextBoxNumberRecipient.Text);
            historyTransfer.UploadHistoryTransfer(TextBoxNumberRecipient.Text,Convert.ToDouble(TextBoxAmount.Text),TextBoxTitle.Text,TextBoxName.Text);
            this.Close();
        }

        private void TextBoxNumberRecipient_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Regex accTest1 = new Regex("^\\d{1,4}$"); //1234
            Regex accTest2 = new Regex("^\\d{1,16}$"); //1234123412341234
            if (accTest2.Match(TextBoxNumberRecipient.Text).Success && TextBoxNumberRecipient.Text.Length == 16)
            {
                TextBoxNumberRecipient.Text = string.Join(" ", Enumerable.Range(0, TextBoxNumberRecipient.Text.Length / 4).Select(i => TextBoxNumberRecipient.Text.Substring(i * 4, 4)));
            }
        }
        public bool CheckRequirments()
        {
            Regex accNumberValidation = new Regex("^\\d{4}[ ]{1}\\d{4}[ ]{1}\\d{4}[ ]{1}\\d{4}$");
            if (!accNumberValidation.Match(TextBoxNumberRecipient.Text).Success)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Numer Bankowy musi mieć 16 cyfr oddzielonych co 4 spacją", "Error #101", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Regex nameValidation = new Regex("^[a-zA-Z]{1,20}[ ]{0,1}[a-zA-Z]{0,20}$");
            if (!nameValidation.Match(TextBoxName.Text).Success)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Błędna nazwa użytkownika, nie może być tutaj polskich znaków", "Error #102", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Regex titleValidation = new Regex("^[a-zA-Z 0-9-,.]{1,35}$");
            if (!titleValidation.Match(TextBoxTitle.Text).Success)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Błędny tytuł przelewu bankowego, nie może być tutaj polskich znaków", "Error #103", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Regex amountValidation = new Regex("^[0-9]{1,8}[,]{0,1}[0-9]{0,2}$");
            if (!amountValidation.Match(TextBoxAmount.Text).Success)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Błędna kwota przelewu, dozwolone w użytku tylko ',' ", "Error #103", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            try
            {
                if (Convert.ToDouble(TextBoxAmount.Text) == 0)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Błędna kwota przelewu", "Error #104", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch
            {
                return false;
            }
                return true;
            
        }
    }
}

