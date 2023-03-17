using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication
{
    class Client
    {
        public string FullName { get; set; }
        public ClientType Type { get; set; }
        public static int IdUser { get; set; }
        public string NumberAcc { get; set; }
        public bool Active { get; set; }
        public decimal Balance { get; set; }
        public string PESEL { get; set; }
        public string NumberID { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }

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
        public void GetInfo(int ID)
        {
                var context = new SQLite();
                var Info = context.Client
                           .Where(s => s.Id_User == ID)
                           .ToList();
            MessageBox.Show(Convert.ToString(Info));
        }

        public Client LoadData(int ID)
        {
            bool active = GetActive(ID);
            string name = GetName(ID);
            string numberAcc = GetNumberAcc(ID);
            string PESEL = GetPESEL(ID);
            string numberId = GetNumberID(ID);
            decimal balance = GetBalance(ID);
            ClientType type = GetType(ID);

            string mail = GetMail(ID);
            string adress = GetAdress(ID);
            string phoneNumber = GetPhone(ID);


            Client x = new Client(active, name, type, ID, numberAcc, balance, PESEL, numberId, phoneNumber, mail, adress);
            //Client y = new Client(phoneNumber, mail, adress);
            return x;
            //switch (mode)
            //{
            //    case 1:
            //        return x;
            //    default:
            //        return y;
            //}
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
        public bool GetActive(int ID) 
        {
            {
                bool x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Account
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Active,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Active;
                    }
                }
                return x;
            }
        }
        public string GetNumberAcc(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Account
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.NumberAccount,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.NumberAccount;
                    }
                }
                return x;
            }
        }
        public string GetMail(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Contact
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Mail,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Mail;
                    }
                }
                return x;
            }
        }
        public string GetPhone(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Contact
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Phone_Number,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Phone_Number;
                    }
                }
                return x;
            }
        }
        public string GetAdress(int ID)
        {
            {
                string x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Contact
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Adress,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Adress ;
                    }
                }
                return x;
            }
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
        public decimal GetBalance(int ID)
        {
            {
                decimal x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Account
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Balance,
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Balance;
                    }
                }
                return x;
            }
        }
        public ClientType GetType(int ID)
        {
            {
                ClientType x = default;
                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.Account
                                 where c.Id_User == ID
                                 select new
                                 {
                                     c.Type
                                 }
                                 ).FirstOrDefault();

                    if (query != null)
                    {
                        x = query.Type;
                    }
                }
                return x;
            }
        }
    }
}
