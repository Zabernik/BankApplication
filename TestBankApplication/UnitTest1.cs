using BankApplication;
using BankApplication.Classes;
using System.Windows;
using TestBankApplication;

namespace TestBankApplication
{
    [TestClass]
    public class BankTests
    {

        [TestMethod]
        public void CheckTransferMethodToVerifyNumberAccIsTheSame()
        {
            Transfer transfer = new Transfer();

            string accRecipient = "1000 0000 0001";

            string accSender = "0001 0000 1000";

            bool result = transfer.SendToMySelf(accRecipient,accSender);

            Assert.IsFalse(result);
        }

    }
}