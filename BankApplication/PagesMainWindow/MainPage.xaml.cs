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

namespace BankApplication.PagesMainWindow
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadText();
        }
        public void LoadText()
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            LabelNumberAcc.Content = x.NumberAcc;
            TextBoxBalance.Text = x.Balance.ToString() +  " PLN";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingleTransfer singleTransfer = new SingleTransfer();
            this.Content = singleTransfer;
        }
    }
}
