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
        public int Id_User { get; set; }
        public string NumberAccountSender { get; set; }
        public string NumberAccountRecipient { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; }
        public int Id_Transfer { get; set; }
        public DateTime DateTransfer { get; set; }
        public string NameRecipient { get; set; }

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

            

            double start = balance.GetBalance(Client.IdUser);
            double end = start - Convert.ToDouble(difference);

            MessageBox.Show(end.ToString());

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
                    MessageBox.Show(idRecipient.ToString() + " IDRecipient");
                    double start = balance.GetBalance(idRecipient);
                    double end = start + Convert.ToDouble(difference);

                    MessageBox.Show(end.ToString() + " end IdRecipient");

                    balance.SetBalance(idRecipient, end);
                }
                else
                {
                    //Do nothing for now
                }

            }
        }
    }
}
