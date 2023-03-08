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

        private void CheckBoxPolicy2_Checked(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        private void CheckBoxPolicy2_UnChecked(object sender, RoutedEventArgs e) 
        { 
            ButtonCheck();
        }
        private void CheckBoxPolicy_UnChecked(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        public void ButtonCheck()
        {

            if (CheckBoxPolicy.IsChecked == true && CheckBoxPolicy2.IsChecked == true && !String.IsNullOrEmpty(TextBoxName.Text) && !String.IsNullOrEmpty(TextBoxLastName.Text) && !String.IsNullOrEmpty(TextBoxPESEL.Text) && !String.IsNullOrEmpty(TextBoxNrID.Text) && !String.IsNullOrEmpty(TextBoxUser.Text) && !String.IsNullOrEmpty(TextBoxPass.Text))
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

        private void TextBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void TextBoxPESEL_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void TextBoxNrID_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void TextBoxUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void TextBoxPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }
    }
}
