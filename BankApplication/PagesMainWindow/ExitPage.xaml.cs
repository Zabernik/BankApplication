using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Logika interakcji dla klasy ExitPage.xaml
    /// </summary>
    public partial class ExitPage : Page
    {
        public ExitPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Shutdown button
        {
            Application.Current.Shutdown();
        }

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)//LogOut button
        {
            Login log = new Login();
            CloseAllWindows();
            log.Show();
        }
        public void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Hide();
        }
    }
}
