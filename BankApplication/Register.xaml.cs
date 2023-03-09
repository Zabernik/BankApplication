using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }

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
                    //Error id = 8; 
                    MessageBox.Show("");
                    break;
                case 9:
                    //Error id = 9;
                    MessageBox.Show("");
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
                return 2;
            }
            if (TextBoxName.Text.Length < 3)
            {
                return 3;
            }
            if (TextBoxLastName.Text.Length > 16)
            {
                return 4;
            }
            if (TextBoxLastName.Text.Length < 2)
            {
                return 5;
            }
            if (TextBoxPESEL.Text.Length != 11)
            {
                return 6;
            }
            //if (TextBoxNrID.Text.Length != 9 || !(System.Text.RegularExpressions.Regex.IsMatch(TextBoxNrID.Text.Substring(0, 3), "^[a-zA-Z ]*$")) || (System.Text.RegularExpressions.Regex.IsMatch(TextBoxNrID.Text.Substring(4), "^[a-zA-Z ]*$")))
            //{
            //    return 7;
            //}



            return 1;
        }
        private void Success()
        {

        }
    }
}
