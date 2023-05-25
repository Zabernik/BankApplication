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
using BankApplication.Enums;
using BankApplication.PagesMainWindow;
using Microsoft.EntityFrameworkCore;

namespace BankApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Active();
        }
        private void sidebar_SelectionChanged(object sander, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            navframe.Navigate(selected.NavLink);
        }
        public void Active()
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            if (x.Active == false)
            {
                BlockedSideBar(false);
                sidebar.SelectedIndex = 6;
            }
            if (x.Active == true)
            {
                BlockedSideBar(true);
                sidebar.SelectedIndex = 0;
            }
        }
        public void BlockedSideBar(bool isEnable)
        {
            NavCards.IsEnabled = isEnable;
            NavCurrency.IsEnabled = isEnable;
            NavHistory.IsEnabled = isEnable;
            NavHome.IsEnabled = isEnable;
            NavProfile.IsEnabled = isEnable;  
            NavTransfer.IsEnabled = isEnable;
        }
    }
}
