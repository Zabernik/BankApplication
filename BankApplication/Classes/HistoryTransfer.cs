using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace BankApplication.Classes
{
    public class HistoryTransfer
    {
        public int Id_User { get; }
        public string NumberAccountSender { get; }
        public string NumberAccountRecipient { get; }
        public decimal Amount { get; }
        public string Title { get; }
        public int Id_Transfer { get; }
        public DateTime DateTransfer { get; }
        public string NameRecipient { get; }

        public HistoryTransfer(int idUser, string accSender, string accRecipient, decimal amount, string title, int idTransfer, DateTime dateTransfer, string nameRecipient)
        {
            Transfer tr = new Transfer();
            Id_User = idUser;
            NumberAccountSender = accSender;
            NumberAccountRecipient = accRecipient;
            Amount = amount;
            Title = title;
            Id_Transfer = idTransfer;
            DateTransfer = dateTransfer;
            NameRecipient = nameRecipient;
        }
        public HistoryTransfer()
        {

        }

        public void UploadHistoryTransfer(string accRecipient, decimal amount, string title, string nameRecipient)
        {
            Client x = new Client();
            x = x.LoadData(Client.IdUser);
            using (SQLite conn = new SQLite())
            {
                var newRecord = new History { Id_User = Client.IdUser, NumberAccountSender = x.NumberAcc, NumberAccountRecipient = accRecipient, Amount = amount, Title = title, DateTransfer = DateTime.Now, NameRecipient = nameRecipient };
                conn.Add<History>(newRecord);
                conn.SaveChanges();
            }
        }
        public (string, string, string, bool, bool, bool) GetHistory(string NumberAcc)
        {
            {
                Client client = new Client();
                client = client.LoadData(Client.IdUser);

                string x = default;
                string y = default;
                string z = default;
                int i = 0;
                bool color1 = false;
                bool color2 = false;
                bool color3 = false;

                string newLine = Environment.NewLine;

                using (SQLite ctx = new SQLite())
                {
                    var query = (from c in ctx.History
                                 where c.NumberAccountSender == NumberAcc || c.NumberAccountRecipient == NumberAcc
                                 orderby c.Id_Transfer
                                 select new
                                 {
                                     c.Amount,
                                     c.Title,
                                     c.NumberAccountRecipient,
                                     c.Id_Transfer
                                 }
                                 ).LastOrDefault();
                    
                    if (query != null)
                    {
                        if (query.NumberAccountRecipient == client.NumberAcc)
                        {
                            color1 = true;
                        }
                        x = query.Amount + " PLN " +newLine+ query.Title;
                        i = query.Id_Transfer;
                    }

                    query = (from c in ctx.History
                             where (c.NumberAccountSender == NumberAcc || c.NumberAccountRecipient == NumberAcc) && c.Id_Transfer < i
                             orderby c.Id_Transfer
                             select new
                             {
                                 c.Amount,
                                 c.Title,
                                 c.NumberAccountRecipient,
                                 c.Id_Transfer
                             }
                                 ).LastOrDefault();

                    if (query != null)
                    {
                        if (query.NumberAccountRecipient == client.NumberAcc)
                        {
                            color2 = true;
                        }
                        y = query.Amount + " PLN" +newLine+ query.Title;
                        i = query.Id_Transfer;
                    }
                    query = (from c in ctx.History
                             where (c.NumberAccountSender == NumberAcc || c.NumberAccountRecipient == NumberAcc) && c.Id_Transfer < i
                             orderby c.Id_Transfer
                             select new
                             {
                                 c.Amount,
                                 c.Title,
                                 c.NumberAccountRecipient,
                                 c.Id_Transfer
                             }
                                 ).LastOrDefault();

                    if (query != null)
                    {
                        if (query.NumberAccountRecipient == client.NumberAcc)
                        {
                            color3 = true;
                        }
                        z = query.Amount + " PLN" +newLine+ query.Title;
                        i = query.Id_Transfer;
                    }
                }
                return (x, y, z, color1, color2, color3);
            }
        }
    }
}
