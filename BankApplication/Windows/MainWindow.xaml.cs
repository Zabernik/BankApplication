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
            //BlockNav();
        }
        public void Active()
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            if (x.Active == false)
            {
                sidebar.SelectedIndex = 6;
            }
            if (x.Active == true)
            {
                sidebar.SelectedIndex = 0;
            }
        }
        public void BlockNav() //problem z blokowaniem menu podczas rejestracji danych
        {
              if (sidebar.SelectedIndex == 6)
              {
              NavHome.IsEnabled = false;
              NavCurrency.IsEnabled = false;
              NavHistory.IsEnabled = false;
              NavCards.IsEnabled = false;
              NavProfile.IsEnabled = false;
              NavTransfer.IsEnabled = false;
              NavExit.IsEnabled = false;
              }
              else
              {
              NavHome.IsEnabled = true;
              NavCurrency.IsEnabled = true;
              NavHistory.IsEnabled = true;
              NavCards.IsEnabled = true;
              NavProfile.IsEnabled = true;
              NavTransfer.IsEnabled = true;
              NavExit.IsEnabled = true;
              }
        }        
    }
}
