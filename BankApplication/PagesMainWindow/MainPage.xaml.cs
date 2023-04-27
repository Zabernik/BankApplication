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
            var x = GetHistory(Client.IdUser);
            TextBoxHistory1.Text = x.Item1;
            TextBoxHistory2.Text = x.Item2;
            TextBoxHistory3.Text = x.Item3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingleTransfer singleTransfer = new SingleTransfer();
            singleTransfer.ShowDialog();
        }
        public (string, string, string, int) GetHistory(int ID)
        {
            {
                string x = default;
                string y = default;
                string z = default;
                int i = 0;

                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.History
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Amount,
                                     c.Title,
                                     c.NumberAccountRecipient,
                                     c.Id_Transfer
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        string title = query.Title;
                        string amount = query.Amount.ToString();
                        for (int j = 30; j > title.Length;)
                        {
                            title = title + " ";
                        }
                        for (int j = 8; j > amount.Length;)
                        {
                            amount = amount + " ";
                        }
                        x = query.Amount + " PLN     " + title + "  " + query.NumberAccountRecipient;
                        i = query.Id_Transfer;
                    }
                }
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.History
                                 where c.Id_User == ID && c.Id_Transfer > i
                                       
                                 select new
                                 {
                                     c.Amount,
                                     c.Title,
                                     c.NumberAccountRecipient,
                                     c.Id_Transfer
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        string title = query.Title;
                        string amount = query.Amount.ToString();
                        for (int j = 30; j > title.Length;)
                        {
                            title = title + " ";
                        }
                        for (int j = 8; j > amount.Length;)
                        {
                            amount = amount + " ";
                        }
                        y = query.Amount + " PLN     " + title + "  " + query.NumberAccountRecipient;
                        i = query.Id_Transfer;
                    }
                }
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.History
                                 where c.Id_User == ID && c.Id_Transfer > i

                                 select new
                                 {
                                     c.Amount,
                                     c.Title,
                                     c.NumberAccountRecipient,
                                     c.Id_Transfer
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        string title = query.Title;
                        string amount = query.Amount.ToString();
                        for (int j = 30; j > title.Length;)
                        {
                            title = title + " ";
                        }
                        for (int j = 8; j > amount.Length;)
                        {
                            amount = amount + " ";
                        }
                        z = query.Amount + " PLN     " + title + "  " + query.NumberAccountRecipient;
                        i = query.Id_Transfer;
                    }
                }
                return (x, y, z, i);
            }

        }
    }
}
