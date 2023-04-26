using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.Classes
{
    class Balance
    {
        public double Balanced { get; set; }
        public double GetBalance(int ID)
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

                        Balanced = Convert.ToDouble(query.Balance);
                    }
                }
                return Balanced;
            }
        }
        public void SetBalance(int ID, double balance) 
        {
            using (var db = new SQLite())
            {
                var result = db.Account.SingleOrDefault(b => b.Id_User == ID);
                if (result != null)
                {
                    MessageBox.Show(balance.ToString());
                    result.Balance = balance;
                    db.SaveChanges();
                }
            }
        }
    }
}
