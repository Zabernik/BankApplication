using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.Classes
{
    public class HistoryTransfer
    {
        public int Id_User { get; }
        public string NumberAccountSender { get;  }
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
        public void GetHistory(int ID)
        {

        }
    }
}
