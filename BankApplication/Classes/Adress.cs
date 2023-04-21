using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    public class Adress
    {
        public string? Adres { get; set; }
        public string GetAdress(int ID)
        {
            {
                Adres = default;
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
                        Adres = query.Adress;
                    }
                }
                return Adres;
            }
        }
    }
}
