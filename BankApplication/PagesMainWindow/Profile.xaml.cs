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

namespace BankApplication.PagesMainWindow
{
    /// <summary>
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            LoadText();
        }
        /// <summary>Loads data from logged in user and fill all textboxes with them.</summary>
        public void LoadText()
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            TextBlockName.Text = x.FullName;
            TextBlockNrID.Text = x.NumberID;
            TextBlockPESEL.Text = x.PESEL;
            TextBlockMail.Text = x.Mail;
            TextBlockAdress.Text = x.Adress;
            TextBlockMail.Text = x.Mail;
            TextBlockPhone.Text = x.PhoneNumber;
        }
    }
}
