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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace BankApplication.PagesMainWindow
{
    /// <summary>
    /// Logika interakcji dla klasy DataRegister.xaml
    /// </summary>
    public partial class DataRegister : Page
    {
        public DataRegister()
        {
            InitializeComponent();
        }

        private void ComboBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeRegister(Convert.ToString(ComboBox_Type.SelectedValue));
        }
        private void TypeRegister(string type) 
        { 
            if (type == "System.Windows.Controls.ComboBoxItem: Bussines")
            {
                TextBoxNIP.Visibility = Visibility.Visible;
                LabelNIP.Visibility = Visibility.Visible;

                TextBoxNameUniversity.Visibility = Visibility.Hidden;
                LabelNameUniversity.Visibility = Visibility.Hidden;
                TextBoxNameUniversity2.Visibility = Visibility.Hidden;
                LabelNameUniversity2.Visibility = Visibility.Hidden;

                TextBoxZUS.Visibility = Visibility.Hidden;
                LabelZUS.Visibility = Visibility.Hidden;
            }
            if (type == "System.Windows.Controls.ComboBoxItem: Standard")
            {
                TextBoxNIP.Visibility = Visibility.Hidden;
                LabelNIP.Visibility = Visibility.Hidden;

                TextBoxNameUniversity.Visibility = Visibility.Hidden;
                LabelNameUniversity.Visibility = Visibility.Hidden;
                TextBoxNameUniversity2.Visibility = Visibility.Hidden;
                LabelNameUniversity2.Visibility = Visibility.Hidden;

                TextBoxZUS.Visibility = Visibility.Hidden;
                LabelZUS.Visibility = Visibility.Hidden;
            }
            if (type == "System.Windows.Controls.ComboBoxItem: Student")
            {
                TextBoxNIP.Visibility = Visibility.Hidden;
                LabelNIP.Visibility = Visibility.Hidden;

                TextBoxNameUniversity.Visibility = Visibility.Visible;
                LabelNameUniversity.Visibility = Visibility.Visible;
                TextBoxNameUniversity2.Visibility = Visibility.Visible;
                LabelNameUniversity2.Visibility = Visibility.Visible;

                TextBoxZUS.Visibility = Visibility.Hidden;
                LabelZUS.Visibility = Visibility.Hidden;
            }
            if (type == "System.Windows.Controls.ComboBoxItem: Pensioner")
            {
                TextBoxNIP.Visibility = Visibility.Hidden;
                LabelNIP.Visibility = Visibility.Hidden;

                TextBoxNameUniversity.Visibility = Visibility.Hidden;
                LabelNameUniversity.Visibility = Visibility.Hidden;
                TextBoxNameUniversity2.Visibility = Visibility.Hidden;
                LabelNameUniversity2.Visibility = Visibility.Hidden;

                TextBoxZUS.Visibility = Visibility.Visible;
                LabelZUS.Visibility = Visibility.Visible;
            }
        }
        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReqirements() == true)
            {
                Succes();
            }
        }
        private void Succes()
        {
            this.NavigationService.Navigate(new Uri("PagesMainWindow/MainPage.xaml", UriKind.Relative));
        }
        private bool CheckReqirements()
        {
            var trimmedEmail = TextBoxMail.Text.Trim();
            Register reg = new Register();
            if(TextBoxPIN.Text.Length != 4 || TextBoxPIN.Text.All(Char.IsLetter)) 
            {
                reg.AddLog(10);
                SystemSounds.Beep.Play();
                MessageBox.Show("PIN musi mieć 4 cyfry", "Error #10", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (TextBoxPhoneNumber.Text.Length != 9)
            {
                reg.AddLog(11);
                SystemSounds.Beep.Play();
                MessageBox.Show("Numer telefonu powinien mieć 9 cyfr", "Error #11", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (TextBoxPhoneNumber.Text.Length != 9)
            {
                reg.AddLog(11);
                SystemSounds.Beep.Play();
                MessageBox.Show("Numer telefonu powinien mieć 9 cyfr", "Error #11", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(TextBoxMail.Text);
                //return addr.Address == trimmedEmail; <---source mail adress
                MessageBox.Show(Convert.ToString(addr.Address == trimmedEmail));
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
