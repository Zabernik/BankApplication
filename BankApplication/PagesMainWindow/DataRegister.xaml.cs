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
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using BankApplication.Classes;

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
                DateUniversity.Visibility = Visibility.Hidden;
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
                DateUniversity.Visibility = Visibility.Hidden;
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
                DateUniversity.Visibility = Visibility.Visible;
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
                DateUniversity.Visibility = Visibility.Hidden;
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
            MessageBoxResult dialogResult = MessageBox.Show("Czy chcesz zaakceptować wprowadzone dane i je zapisać? ","",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialogResult == MessageBoxResult.Yes)
            {
                UpdateData();
                this.NavigationService.Navigate(new Uri("PagesMainWindow/MainPage.xaml", UriKind.Relative));
            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }
        }
        private bool CheckReqirements()
        {
            Register reg = new Register();
            Regex PINValidation = new Regex("^\\d{4}$");
            if (!PINValidation.Match(TextBoxPIN.Text).Success) 
            {
                MessageBox.Show(Convert.ToString(ComboBox_Type.SelectedIndex));
                reg.AddLog(10);
                SystemSounds.Beep.Play();
                MessageBox.Show("PIN musi mieć 4 cyfry", "Error #10", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Regex PhoneValidation = new Regex("^[+]{0,1}\\d{0,3}[ -]{0,1}\\d{1,9}[ -]{0,1}\\d{1,3}[ -]{0,1}\\d{1,3}$");
            if (!PhoneValidation.Match(TextBoxPhoneNumber.Text).Success || TestNumberAcc(TextBoxPhoneNumber.Text) == true)
            {
                reg.AddLog(11);
                SystemSounds.Beep.Play();
                MessageBox.Show("Numer telefonu powinien mieć 9 cyfr", "Error #11", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            var trimmedEmail = TextBoxMail.Text.Trim();
            if (trimmedEmail.EndsWith(".") || TextBoxMail.Text is null || TestMailAcc(TextBoxMail.Text))
            {
                reg.AddLog(12);
                SystemSounds.Beep.Play();
                MessageBox.Show("Wprowadzono nie poprawny mail", "Error #12", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(TextBoxMail.Text);
                //return addr.Address == trimmedEmail; <---source mail adress
                //MessageBox.Show(Convert.ToString(addr.Address == trimmedEmail));
            }
            catch
            {
                reg.AddLog(12);
                SystemSounds.Beep.Play();
                MessageBox.Show("Wprowadzono nie poprawny mail", "Error #12", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DateBirth.SelectedDate == DateTime.Now || DateBirth.SelectedDate > DateTime.Now.AddYears(-18) || DateBirth.SelectedDate is null)
            {
                reg.AddLog(13);
                SystemSounds.Beep.Play();

                MessageBox.Show("Żeby zarejestrować się w naszym Banku z innym kontem niż dla młodych trzeba mieć ukończone 18 lat.", "Error #13", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            Regex postCodeValidation = new Regex(@"^[a-zA-Z ńłźżóćŃŁŹŻÓĆ-]+\s\d{2}[-]\d{3}$");
            if (!postCodeValidation.Match(TextBoxAdress1.Text).Success)
            {
                reg.AddLog(14);
                SystemSounds.Beep.Play();
                MessageBox.Show("Adres powinien zawierać 'Miasto' oraz Kod Pocztowy 'XX-XXX' ", "Error #14", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Regex adressValidation = new Regex("^[a-zA-Zł ńźżóćŁŃŹŻÓĆ-]+\\s\\d{1,4}[A-Z]{0,2}[ -]{0,1}\\d{0,5}$");
            if (!adressValidation.Match(TextBoxAdress2.Text).Success)
            {
                reg.AddLog(15);
                SystemSounds.Beep.Play();
                MessageBox.Show("Adres powinien zawierać 'Ulice' 'Nr.Domu' i ewentualnie 'Nr.Mieszkania' np. 'Utrata 2 33' lub 'Łanowicze Małe 9' ", "Error #15", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (ComboBox_Type.SelectedValue is null)
            {
                reg.AddLog(16);
                SystemSounds.Beep.Play();
                MessageBox.Show("Musisz wybrać typ konta który chciałbyś użytkować", "Error #16", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (ComboBox_Type.SelectedIndex == 1)
            {
                Regex NIPValidation = new Regex("^\\d{10}$");
                if (!NIPValidation.Match(TextBoxNIP.Text).Success || TestNIPAcc(TextBoxNIP.Text))
                {
                    reg.AddLog(16);
                    SystemSounds.Beep.Play();
                    MessageBox.Show("NIP powinien zawierać 10 cyfr", "Error #16", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (ComboBox_Type.SelectedIndex == 2)
            {
                Regex UniversityValidation = new Regex("^[a-zA-Z ńłźżóćŁŹŃŻÓĆ]{1,}$");
                if (!UniversityValidation.Match(TextBoxNameUniversity.Text).Success)
                {
                    reg.AddLog(17);
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Nie poprawna nazwa uczelni", "Error #17", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (DateUniversity.SelectedDate < DateTime.Now.AddYears(-1) || DateUniversity.SelectedDate is null)
                {
                    reg.AddLog(18);
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Żeby skorzystać z oferty Konta Studenckiego, musimy aktywować konto min. rok przed teoretycznym ukończeniem studiów", "Error #18", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (ComboBox_Type.SelectedIndex == 3)
            {
                Regex ZUSValidation = new Regex("^\\d{10}$");
                if (!ZUSValidation.Match(TextBoxZUS.Text).Success || TestZUSAcc(TextBoxZUS.Text))
                {
                    reg.AddLog(19);
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Numer ubezpieczenia powinien zawierać 10 cyfr", "Error #19", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }
        private void UpdateData()
        {
            int ID = Client.IdUser;
            using (SQLite conn = new SQLite())
            {
                UploadData();
                var result = conn.Login.SingleOrDefault(b => b.Id_User == ID);
                if (result != null)
                {
                    result.PIN = TextBoxPIN.Text;
                    conn.SaveChanges();
                }
                var result2 = conn.Client.SingleOrDefault(b => b.Id_User == ID);
                if (result2 != null)
                {
                    result2.DateBirth = DateBirth.SelectedDate.ToString();
                    conn.SaveChanges();
                }
                var result3 = conn.Account.SingleOrDefault(b => b.Id_User == ID);
                if (result3 != null)
                {
                    result3.Type = (Enums.ClientType)ComboBox_Type.SelectedIndex;
                    conn.SaveChanges();
                    result3.Active = true;
                }
                var newContact = new Contact { Phone_Number = TextBoxPhoneNumber.Text, Mail = TextBoxMail.Text, Adress = TextBoxAdress1.Text + " " + TextBoxAdress2.Text, Id_User = ID };
                conn.Add<Contact>(newContact);
                conn.SaveChanges();
            }
        }
        private void UploadData()
        {
            int ID = Client.IdUser;
            using (SQLite conn = new SQLite())
            {
                MessageBox.Show("Funkcja otwarta przed wpisaniu" + Convert.ToString(ComboBox_Type.SelectedValue));
                if (ComboBox_Type.SelectedIndex == 1)
                {
                    var newBussines = new BussinesAccount { NIP = TextBoxNIP.Text, Type = Enums.ClientType.Bussines, Id_User = ID };
                    conn.Add<BussinesAccount>(newBussines);
                    conn.SaveChanges();
                }
                if (ComboBox_Type.SelectedIndex == 3)
                {
                    var newPensioner = new PensionerAccount { Number_of_ZUS_ID = TextBoxZUS.Text, Type = Enums.ClientType.Pensioner, Id_User = ID };
                    conn.Add<PensionerAccount>(newPensioner);
                    conn.SaveChanges();
                }
                if (ComboBox_Type.SelectedIndex == 2)
                {
                    var newStudent = new StudentAccount { Name_of_University = TextBoxNameUniversity.Text, End_of_Study = (DateTime)DateUniversity.SelectedDate, Type = Enums.ClientType.Student, Id_User = ID };
                    conn.Add<StudentAccount>(newStudent);
                    conn.SaveChanges();
                }
            }
        }
        private bool TestNumberAcc(string NumberTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Contact.Any(acc => acc.Phone_Number == NumberTest);
                if (NumberExist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool TestMailAcc(string MailTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Contact.Any(acc => acc.Mail == MailTest);
                if (NumberExist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool TestNIPAcc(string NIPTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.bussinesAccounts.Any(acc => acc.NIP == NIPTest);
                if (NumberExist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool TestZUSAcc(string ZUSTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.pensionerAccounts.Any(acc => acc.Number_of_ZUS_ID == ZUSTest);
                if (NumberExist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
