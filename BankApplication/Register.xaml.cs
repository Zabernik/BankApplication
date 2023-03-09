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

            if (StatusNeedChecked() == true && !String.IsNullOrEmpty(TextBoxName.Text) && !String.IsNullOrEmpty(TextBoxLastName.Text) && !String.IsNullOrEmpty(TextBoxPESEL.Text) && !String.IsNullOrEmpty(TextBoxNrID.Text) && !String.IsNullOrEmpty(TextBoxUser.Text) && !String.IsNullOrEmpty(TextBoxPass.Text))
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
            if (Need == false && CheckBoxPolicy.IsChecked == true && CheckBoxPolicy2.IsChecked == true && CheckBoxPolicy3.IsChecked == true && CheckBoxPolicy4.IsChecked == true)
            {
                return true;
            }
            if (Need == true && CheckBoxPolicy.IsChecked == true && CheckBoxPolicy2.IsChecked == true && CheckBoxPolicy3.IsChecked == true && CheckBoxPolicy4.IsChecked == true)
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
