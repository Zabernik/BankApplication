using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    public class AccountData
    {
        public string NumberAcc { get; set; }
        public bool Active { get; set; }
        public ClientType Type { get; set; }

        public string GetNumberAcc(int ID)
        {
            {
                NumberAcc = default;
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
                        NumberAcc = query.NumberAccount;
                    }
                }
                return NumberAcc;
            }
        }
        public bool GetActive(int ID)
        {
            {
                Active = default;
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
                        Active = query.Active;
                    }
                }
                return Active;
            }
        }
        public ClientType GetType(int ID)
        {
            {
                Type = default;
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
                        Type = query.Type;
                    }
                }
                return Type;
            }
        }
    }
}
