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
            StrenghtIndicator(TextBoxPass.Text);
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
                    MessageBox.Show("");
                    break;
                case 3:
                    //Error id = 2; Too short Name
                    MessageBox.Show("");
                    break;
                case 4:
                    //Error id = 4; Too long LastName
                    MessageBox.Show("");
                    break;
                case 5:
                    //Error id = 5; Too short LastName
                    MessageBox.Show("");
                    break;
                case 6:
                    //Error id = 6; Wrong PESEL
                    MessageBox.Show("");
                    break;
                case 7:
                    //Error id = 7; Wrong ID Number
                    MessageBox.Show("Error 7");
                    break;
                case 8:
                    //Error id = 8; Wrong NickName
                    MessageBox.Show("Error 8");
                    break;
                case 9:
                    //Error id = 9; Too weak Password
                    MessageBox.Show("Error 9");
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

            if (StatusAllChecked(false) == true && !String.IsNullOrEmpty(TextBoxName.Text) && !String.IsNullOrEmpty(TextBoxLastName.Text) && !String.IsNullOrEmpty(TextBoxPESEL.Text) && !String.IsNullOrEmpty(TextBoxNrID.Text) && !String.IsNullOrEmpty(TextBoxUser.Text) && !String.IsNullOrEmpty(TextBoxPass.Text))
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
                AddLog(2, DateTime.Now);
                return 2;
            }
            if (TextBoxName.Text.Length < 3)
            {
                AddLog(3, DateTime.Now);
                return 3;
            }
            if (TextBoxLastName.Text.Length > 16)
            {
                AddLog(4, DateTime.Now);
                return 4;
            }
            if (TextBoxLastName.Text.Length < 2)
            {
                AddLog(5, DateTime.Now);

                return 5;
            }
            if (TextBoxPESEL.Text.Length != 11)
            {
                AddLog(6, DateTime.Now);
                return 6;
            }
            if (TextBoxNrID.Text.Length != 9 || !(Regex.IsMatch(TextBoxNrID.Text.Substring(0, 3), "^[a-zA-Z ]*$")))
            {
                AddLog(7, DateTime.Now);
                return 7;
            }
            if (TextBoxUser.Text.Length > 16 || !TextBoxUser.Text.All(Char.IsLetter))
            {
                AddLog(8, DateTime.Now);
                return 8;
            }
            if (CheckStrength(TextBoxPass.Text) < PasswordStrenght.Medium)
            {
                AddLog(9, DateTime.Now);
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
                var newUser = new User { UserName = TextBoxUser.Text, Password = TextBoxPass.Text};
                conn.Add<User>(newUser);
                conn.SaveChanges();
                var newAccount = new Account {Balance = 0, NumberAccount = "1000", Active = false, Debet = 0 };
                conn.Add<Account>(newAccount);
                conn.SaveChanges();
            }
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

        private void TextBoxPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
            StrenghtIndicator(TextBoxPass.Text);
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

        private void AddLog(int Id, DateTime date) 
        {
            using (SQLite conn = new SQLite())
            {
                var newLog = new Logs {IdError = Id, DataError = date};
                conn.Add<Logs>(newLog);
                conn.SaveChanges();
            }
        }
    }
}
