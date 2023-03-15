using BankApplication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Client
    {
        public string FullName { get; set; }
        public ClientType Type { get; set; }
        public int IdUser { get; set; }
        public string NumberAcc { get; set; }
        public bool Active { get; set; }
        public decimal Balance { get; set; }
        public string PESEL { get; set; }
        public string NumberID { get; set; }

        public Client(bool active, string name, ClientType clientType, int idUser, string nrAcc, decimal balance, string PESEL, string numberID) 
        { 
            Active = active;
            FullName = name;
            Type = clientType;
            IdUser = idUser;
            NumberAcc = nrAcc;
            Balance = balance;
            this.PESEL = PESEL;
            NumberID = numberID;
        }
    }
}
