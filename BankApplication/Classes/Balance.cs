using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.Classes
{
    /// <summary>This class defines Balance, methods and properties</summary>
    class Balance
    {
        public decimal Balanced { get; set; }
        /// <summary>Gets the balance.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return balance of acc by id user</returns>
        public decimal GetBalance(int ID)
        {
            {
                Balanced = default;
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

                        Balanced = Convert.ToDecimal(query.Balance);
                    }
                }
                return Balanced;
            }
        }
        /// <summary>This method sets a balance of acc by id user</summary>
        /// <param name="ID">The identifier of user.</param>
        /// <param name="balance">The balance of acc.</param>
        public void SetBalance(int ID, decimal balance) 
        {
            using (var db = new SQLite())
            {
                var result = db.Account.SingleOrDefault(b => b.Id_User == ID);
                if (result != null)
                {
                    result.Balance = balance;
                    db.SaveChanges();
                }
            }
        }
    }
}
