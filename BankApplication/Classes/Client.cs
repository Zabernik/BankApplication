using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.Classes
{
    public sealed class Client
    {
        public string FullName { get; }
        public ClientType Type { get; }
        public static int IdUser { get; set; }
        public string NumberAcc { get; }
        public bool Active { get; }
        public decimal Balance { get; }
        public string PESEL { get; }
        public string NumberID { get; }
        public string PhoneNumber { get; }
        public string Mail { get; }
        public string Adress { get; }

        public Client(bool active, string name, ClientType clientType, int idUser, string nrAcc, decimal balance, string PESEL, string numberID, string mail, string phoneNumber, string adress)
        {
            Active = active;
            FullName = name;
            Type = clientType;
            IdUser = idUser;
            NumberAcc = nrAcc;
            Balance = balance;
            this.PESEL = PESEL;
            NumberID = numberID;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
        public Client()
        {

        }

        public Client LoadData(int ID)
        {
            var bal = new Balance();
            var adr = new Adress();
            var con = new Contact();
            var acc = new AccountData();

            bool active = acc.GetActive(ID);
            string name = GetName(ID);
            string numberAcc = acc.GetNumberAcc(ID);
            string PESEL = GetPESEL(ID);
            string numberId = GetNumberID(ID);
            decimal balance = bal.GetBalance(ID);
            ClientType type = acc.GetType(ID);
            string mail = con.GetMail(ID);
            string adress = adr.GetAdress(ID);
            string phoneNumber = con.GetPhone(ID);


            Client x = new Client(active, name, type, ID, numberAcc, balance, PESEL, numberId, phoneNumber, mail, adress);
            return x;
        }

        public string GetName(int ID)
        {
            string x = default;
            using (SQLite ctx = new SQLite())
            {
                var query1 = (from c in ctx.Client
                              where c.Id_User == ID
                              select new
                              {
                                  c.FirstName,
                                  c.LastName,
                              }
                             ).FirstOrDefault();

                if (query1 != null)
                {
                    x = query1.FirstName + " " + query1.LastName;
                }
            }
            return x;
        }
        public string GetPESEL(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Client
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.PESEL,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.PESEL;
                    }
                }
                return x;
            }
        }
        public string GetNumberID(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Client
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.NumberID,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.NumberID;
                    }
                }
                return x;
            }
        }
        public void GetInfo(int ID)
        {
            var context = new SQLite();
            var Info = context.Client
                       .Where(s => s.Id_User == ID)
                       .ToList();
            MessageBox.Show(Convert.ToString(Info));
        }//?
        public int ReadIdByUserName(string userName)
        {
            int x = 0;
            using (SQLite ctx = new SQLite())
            {
                var query = (from c in ctx.Login
                             where c.UserName == userName
                             select new
                             {
                                 c.Id_User,
                             }
                             ).FirstOrDefault();

                if (query != null)
                {
                    x = query.Id_User;
                }
            }
            return x;
        }
        public int ReadIdByAccNumber(string accNumber)
        {
            int x = 0;
            using (SQLite ctx = new SQLite())
            {                
                var query = (from c in ctx.Account
                             where c.NumberAccount == accNumber
                             select new
                             {
                                 c.Id_User,
                             }
                             ).FirstOrDefault();

                if (query != null)
                {
                    x = query.Id_User;
                }
            }
            return x;
        }
    }
}
