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
using BankApplication.Classes;

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
            HistoryWidgetLoad();
        }
        public void LoadText()
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            LabelNumberAcc.Content = x.NumberAcc;
            TextBoxBalance.Text = x.Balance.ToString() + " PLN";
        }
        public void HistoryWidgetLoad()
        {
            Client y = new Client();
            y = y.LoadData(Client.IdUser);
            HistoryTransfer historyTransfer = new HistoryTransfer();
            var x = historyTransfer.GetHistory(y.NumberAcc);
            TextBoxHistory1.Text = x.Item1;
            TextBoxHistory2.Text = x.Item2;
            TextBoxHistory3.Text = x.Item3;

            TextBoxHistory1.Foreground = Brushes.LightGreen;
            TextBoxHistory2.Foreground = Brushes.LightGreen;
            TextBoxHistory3.Foreground = Brushes.LightGreen;
            if (x.Item4 is false) 
            {
                TextBoxHistory1.Foreground = Brushes.IndianRed;
                TextBoxHistory1.Text = "-" + x.Item1;
            }
            if(x.Item5 is false) 
            {
                TextBoxHistory2.Foreground = Brushes.IndianRed;
                TextBoxHistory2.Text = "-" + x.Item2;
            }
            if (x.Item6 is false)
            {
                TextBoxHistory3.Foreground = Brushes.IndianRed;
                TextBoxHistory3.Text = "-" + x.Item3;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingleTransfer singleTransfer = new SingleTransfer();
            singleTransfer.ShowDialog();
        }       
    }
}
