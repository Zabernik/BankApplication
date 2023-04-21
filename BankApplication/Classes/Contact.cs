using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Classes
{
    public class Contact
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

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
