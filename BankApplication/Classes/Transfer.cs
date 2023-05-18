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
        /// <summary>This method deducted difference from balance acc sending transfer.</summary>
        /// <param name="difference">Amount of transfer</param>
        public void TransferMoneyFrom(string difference)
        {
            Balance balance = new Balance();

            decimal start = balance.GetBalance(Client.IdUser);
            decimal end = start - Convert.ToDecimal(difference);

            balance.SetBalance(Client.IdUser, end);
        }
        /// <summary>This method add difference to balance acc receiving in that db by number of acc.</summary>
        /// <param name="difference">The difference.</param>
        /// <param name="accRecipient">The acc recipient.</param>
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
        /// <summary>Method to test whether user sending transfer to himself.</summary>
        /// <param name="accRecipient">The acc recipient.</param>
        /// <param name="accSender">The acc sender.</param>
        /// <returns>This method return true if user try to send transfer to himself</returns>
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
