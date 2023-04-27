using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApplication.Classes
{
    public class Transfer
    {
        public Transfer()
        {

        }
        public void TransferFromTo(string accSender, string accRecipient)
        {

        }
        public string GetName(string name)
        {
            return name;
        }
        public void TransferMoneyFrom(string difference)
        {
            Balance balance = new Balance();

            decimal start = balance.GetBalance(Client.IdUser);
            decimal end = start - Convert.ToDecimal(difference);

            balance.SetBalance(Client.IdUser, end);
        }
        public void TransferMoneyTo(string difference, string accRecipient)
        {
            Balance balance = new Balance();
            Client client = new Client();

            using (SQLite conn = new SQLite())
            {
                bool accRecipientExist = conn.Account.Any(accNumber => accNumber.NumberAccount == accRecipient);

                if (accRecipientExist is true)
                {
                    int idRecipient = client.ReadIdByAccNumber(accRecipient);
                    decimal start = balance.GetBalance(idRecipient);
                    decimal end = start + Convert.ToDecimal(difference);
                    balance.SetBalance(idRecipient, end);
                }
                else
                {
                    //Do nothing for now
                }

            }
        }
        public bool SendToMySelf(string accRecipient, string accSender)
        {
            if (accRecipient == accSender)
            {
                return true;
            }
            return false;
        }
    }
}
