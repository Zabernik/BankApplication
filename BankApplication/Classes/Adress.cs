using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    /// <summary>This class defines AdressData, methods and properties</summary>
    public class Adress
    {
        public string? Adres { get; set; }
        /// <summary>Gets the adress.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return adress of acc by id user</returns>
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
