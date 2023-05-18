using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    /// <summary>This class defines Contact Data, methods and properties</summary>
    public class Contact
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

        /// <summary>Gets the mail.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return mail by id user</returns>
        public string GetMail(int ID)
        {
            {
                Mail = default;
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
                        Mail = query.Mail;
                    }
                }
                return Mail;
            }
        }
        /// <summary>Gets the phone.</summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>This method return phone number by id user</returns>
        public string GetPhone(int ID)
        {
            {
                PhoneNumber = default;
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
                        PhoneNumber = query.Phone_Number;
                    }
                }
                return PhoneNumber;
            }
        }
    }
}
