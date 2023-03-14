using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BankApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade databaseFacade = new DatabaseFacade(new SQLite());
            databaseFacade.EnsureCreated();
            LoadAdmin(TestAdmin());
        }
        private void LoadAdmin(bool AdminExist)
        {
            if (AdminExist == false)
            {
                using (SQLite conn = new SQLite())
                {
                    var newClient = new Clients { FirstName = "admin", LastName = "admin", PESEL = "00000000000", NumberID = "000000000", Id_User = 1 };
                    conn.Add<Clients>(newClient);
                    conn.SaveChanges();
                }
                using (SQLite conn = new SQLite())
                {
                    var newUser = new User { UserName = "admin", Password = "admin", PIN = "0000", Id_User = 1 };
                    conn.Add<User>(newUser);
                    conn.SaveChanges();
                }
                using (SQLite conn = new SQLite())
                {
                    var newAccount = new Account { Balance = 0, NumberAccount = "0000 0000 0000 0000", Active = true, Debet = 0, Id_User = 1 };
                    conn.Add<Account>(newAccount);
                    conn.SaveChanges();
                }
            }
        }
        private bool TestAdmin()
        {
            using (SQLite conn = new SQLite())
            {
                bool AdminExist = conn.Client.Any(acc => acc.FirstName == "admin" && acc.LastName == "admin");
                if (AdminExist)
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
}
