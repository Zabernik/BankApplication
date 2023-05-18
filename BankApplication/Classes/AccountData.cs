using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    /// <summary>This class defines AccountData, methods and properties</summary>
    public class AccountData
    {
        public string NumberAcc { get; set; }
        public bool Active { get; set; }
        public ClientType Type { get; set; }

        /// <summary>Gets the number acc.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return us number acc from DB by a id of user</returns>
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
        /// <summary>This method getting us info about status of register acc</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Thats return if the acc was full register in app</returns>
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
        /// <summary>Gets the type.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return us type of acc</returns>
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
