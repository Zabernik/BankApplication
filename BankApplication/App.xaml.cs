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
            //var ID = new Clients { Id_User = 1 };
            //using (SQLite conn = new SQLite())
            //{
            //    var newClient = new Clients { FirstName = "Wiktor", LastName = "TEST", PESEL = "01234567890", NumberID = "TEST56789", Id_User = 1 };
            //    conn.Add<Clients>(newClient);
            //    conn.SaveChanges();
            //}
            //using (SQLite conn = new SQLite())
            //{
            //    var newUser = new User { UserName = "admin", Password = "admin", PIN = "0000", Id_User = ID };
            //    conn.Add<User>(newUser);
            //    conn.SaveChanges();
            //}
            //using (SQLite conn = new SQLite())
            //{
            //    var newAccount = new Account { Balance = 0, NumberAccount = "1000 1000 1000 1000", Active = true, Debet = 0, Id_User = ID };
            //    conn.Add<Account>(newAccount);
            //    conn.SaveChanges();
            //}
        }
    }
}
