using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using BankApplication.Enums;
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
            LoadDataDB(TestAdmin(),TestType());
        }
        private void LoadDataDB(bool AdminExist, bool TypesExist)
        {
            if (TypesExist == false)
            {
                using (SQLite conn = new SQLite())
                {
                    var newType1 = new ClientTypes { Type = ClientType.Standard };
                    conn.Add<ClientTypes>(newType1);
                    conn.SaveChanges();
                    var newType2 = new ClientTypes { Type = ClientType.Bussines };
                    conn.Add<ClientTypes>(newType2);
                    conn.SaveChanges();
                    var newType3 = new ClientTypes { Type = ClientType.Student };
                    conn.Add<ClientTypes>(newType3);
                    conn.SaveChanges();
                    var newType4 = new ClientTypes { Type = ClientType.Teenager };
                    conn.Add<ClientTypes>(newType4);
                    conn.SaveChanges();
                    var newType5 = new ClientTypes { Type = ClientType.Pensioner };
                    conn.Add<ClientTypes>(newType5);
                    conn.SaveChanges();
                }
            }
            if (AdminExist == false)
            {
                using (SQLite conn = new SQLite())
                {
                    Clients newClient = new Clients { FirstName = "admin", LastName = "admin", PESEL = "00000000000", NumberID = "000000000", Id_User = 1 };
                    conn.Add<Clients>(newClient);
                    conn.SaveChanges();
                }
                using (SQLite conn = new SQLite())
                {
                    User newUser = new User { UserName = "admin", Password = "admin", PIN = "0000", Id_User = 1 };
                    conn.Add<User>(newUser);
                    conn.SaveChanges();
                }
                using (SQLite conn = new SQLite())
                {
                    Account newAccount = new Account { Balance = 0, NumberAccount = "0000 0000 0000 0000", Active = true, Debet = 0, Id_User = 1, Type = ClientType.Bussines };
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
        private bool TestType()
        {
            using (SQLite conn = new SQLite())
            {
                bool TypesExist = conn.ClientTypes.Any(acc => acc.Type == ClientType.Student || acc.Type == ClientType.Bussines || acc.Type == ClientType.Student || acc.Type == ClientType.Teenager || acc.Type == ClientType.Pensioner);
                if (TypesExist)
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
