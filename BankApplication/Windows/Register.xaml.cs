using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Media;

namespace BankApplication
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            StrenghtIndicator(PasswordBox.Password);
        }
        public Enums.PasswordStrenght ScorePass { get; set; }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            switch (CheckRequirements())
            {
                case 1:
                    Success();
                    break;
                case 2:
                    //Error id = 1; Too long Name
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za długie imię", "Error #1", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 3:
                    //Error id = 2; Too short Name
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za krótkie imię", "Error #2", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 4:
                    //Error id = 4; Too long LastName
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za długie nazwisko", "Error #4", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 5:
                    //Error id = 5; Too short LastName
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za krótkie nazwisko", "Error #4", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 6:
                    //Error id = 6; Wrong PESEL
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono błędny PESEL lub już taki został zarejestrowany", "Error #5", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 7:
                    //Error id = 7; Wrong ID Number
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono błedny numer dowodu lub już taki został zarejestrowany", "Error #6", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 8:
                    //Error id = 8; Wrong NickName
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za długi nick, użyto innych znaków niż liter lub taki nick już został zarejestrowany", "Error #7", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 9:
                    //Error id = 9; Too weak Password
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Wprowadzono za słabe hasło", "Error #8", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

        }

        private void CheckBoxPolicy_Checked(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        private void CheckBoxPolicy_UnChecked(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        public void ButtonCheck()
        {

            if (StatusAllChecked(false) == true && !String.IsNullOrEmpty(TextBoxName.Text) && !String.IsNullOrEmpty(TextBoxLastName.Text) && !String.IsNullOrEmpty(TextBoxPESEL.Text) && !String.IsNullOrEmpty(TextBoxNrID.Text) && !String.IsNullOrEmpty(TextBoxUser.Text) && !String.IsNullOrEmpty(PasswordBox.Password))
            {
                ButtonRegister.IsEnabled = true;
            }
            else
            {
                ButtonRegister.IsEnabled = false;
            }
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }
        private void CheckBoxAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckedAll(true);
        }
        private void CheckBoxAll_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckedAll(false);
        }
        public void CheckedAll(bool x)
        {
            CheckBoxPolicy.IsChecked = x;
            CheckBoxPolicy2.IsChecked = x;
            CheckBoxPolicy3.IsChecked = x;
            CheckBoxPolicy4.IsChecked = x;
        }
        public bool StatusAllChecked(bool Need)
        {
            if (Need == true && CheckBoxPolicy.IsChecked == true && CheckBoxPolicy2.IsChecked == true && CheckBoxPolicy3.IsChecked == true && CheckBoxPolicy4.IsChecked == true)
            {
                return true;
            }
            if (Need == false && CheckBoxPolicy.IsChecked == true && CheckBoxPolicy2.IsChecked == true && CheckBoxPolicy3.IsChecked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CheckRequirements()
        {
            if (TextBoxName.Text.Length > 12)
            {
                AddLog(2);
                return 2;
            }
            if (TextBoxName.Text.Length < 3)
            {
                AddLog(3);
                return 3;
            }
            if (TextBoxLastName.Text.Length > 16)
            {
                AddLog(4);
                return 4;
            }
            if (TextBoxLastName.Text.Length < 2)
            {
                AddLog(5);

                return 5;
            }
            if (TextBoxPESEL.Text.Length != 11 || TestPESELAcc(TextBoxPESEL.Text) == true)
            {
                AddLog(6);
                return 6;
            }
            if (TextBoxNrID.Text.Length != 9 || !(Regex.IsMatch(TextBoxNrID.Text, "^[a-zA-Z]{3}\\s{0,1}[0-9]{6}$")) || TestIdCard(TextBoxNrID.Text) == true)
            {
                AddLog(7);
                return 7;
            }
            if (TextBoxUser.Text.Length > 16 || !TextBoxUser.Text.All(Char.IsLetter) || TestNickName(TextBoxUser.Text) == true)
            {
                AddLog(8);
                return 8;
            }
            if (CheckStrength(PasswordBox.Password) < PasswordStrenght.Medium)
            {
                AddLog(9);
                return 9;
            }
            return 1;
        }
        private void Success()
        {
            using (SQLite conn = new SQLite())
            {
                var newClient = new Clients { FirstName = TextBoxName.Text, LastName = TextBoxLastName.Text, PESEL = TextBoxPESEL.Text, NumberID = TextBoxNrID.Text };
                conn.Add<Clients>(newClient);
                conn.SaveChanges();

                var newUser = new User { UserName = TextBoxUser.Text, Password = PasswordBox.Password, Id_User = ReadId() };
                conn.Add<User>(newUser);
                conn.SaveChanges();

                var newAccount = new Account { Balance = 0, NumberAccount = CreateNumberAcc(ReadId()), Active = false, Debet = 0, Id_User = ReadId() };
                conn.Add<Account>(newAccount);
                conn.SaveChanges();
            }

            Login log = new Login();
            log.Show();
            Close();
        }
        public static PasswordStrenght CheckStrength(string password)
        {
            Regex Level3 = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{9,}$");
            Regex Level2 = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{7,}$");
            Regex Level1 = new Regex("^(?=.*?[a-z])(?=.*?[0-9]).{1,}$");

            if (password.Length < 1)
                return PasswordStrenght.Blank;
            if (Level3.IsMatch(password))
                return PasswordStrenght.Strong;
            if (Level2.IsMatch(password))
                return PasswordStrenght.Medium;
            if (Level1.IsMatch(password))
                return PasswordStrenght.Weak;

            return PasswordStrenght.Weak;
        }

        private void TextBoxPass_TextChanged(object sender, RoutedEventArgs args)
        {
            ButtonCheck();
            StrenghtIndicator(PasswordBox.Password);
        }
        private void StrenghtIndicator(string Input)
        {
            switch (CheckStrength(Input))
            {
                case PasswordStrenght.Blank:
                    ProgressPass.Value = 0;

                    break;
                case PasswordStrenght.Weak:
                    ProgressPass.Value = 33;
                    ProgressPass.Foreground = Brushes.Red;
                    break;
                case PasswordStrenght.Medium:
                    ProgressPass.Value = 66;
                    ProgressPass.Foreground = Brushes.Orange;
                    break;
                case PasswordStrenght.Strong:
                    ProgressPass.Value = 100;
                    ProgressPass.Foreground = Brushes.Green;
                    break;
            }
            TextBoxPassStrenght.Text = Convert.ToString(CheckStrength(Input));
        }

        public void AddLog(int Id) 
        {
            using (SQLite conn = new SQLite())
            {
                var newLog = new Logs {IdError = Id, DataError = DateTime.Now};
                conn.Add<Logs>(newLog);
                conn.SaveChanges();
            }
        }
        private int ReadId()
        {
            int x = 0;
            using (SQLite ctx = new SQLite())
            {
                var query = (from c in ctx.Client
                             where c.PESEL == TextBoxPESEL.Text
                             select new
                             {
                                 c.Id_User,
                             }
                             ).FirstOrDefault();

                if (query != null)
                {
                    x = query.Id_User;
                }
            }
            return x;
        }
        private bool TestNumberAcc(string NumberTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Account.Any(acc => acc.NumberAccount == NumberTest);
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
        private bool TestPESELAcc(string PESELTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Client.Any(acc => acc.PESEL == PESELTest);
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
        private bool TestIdCard(string IdTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Client.Any(acc => acc.NumberID == IdTest);
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
        private bool TestNickName(string NickTest)
        {
            using (SQLite conn = new SQLite())
            {
                bool NumberExist = conn.Login.Any(acc => acc.UserName == NickTest);
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
        private string CreateNumberAcc(int Id)
        {
        Start:
            string Number;
            System.Random random = new System.Random(); 
            int num1 = random.Next(1000, 5000);
            int num2 = random.Next(5000, 9000);

            while (Id > 99)
            {
                Id = Id - 100;
            }
            if (Id < 10)
            {
                Number = "210" + Id + " " + num1 + " 0000 " + num2;
            }
            else
            {
                Number = "21" + Id + " " + num1 + " 0000 " + num2;
            }
            

            if (TestNumberAcc(Number) == true)
            {
                goto Start;
            }

            return Number;
        }
    }
}
