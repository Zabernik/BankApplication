using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
