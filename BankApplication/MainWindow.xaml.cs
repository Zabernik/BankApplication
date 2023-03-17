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
                sidebar.SelectedIndex = 6;
            }
            if (x.Active == true)
            {
                sidebar.SelectedIndex = 0;
            }
        }
    }
}
