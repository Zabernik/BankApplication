using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class User
    {
        public string UserName { get; set; }
        public string PIN { get; set; }
        public string Password { get; set; }

        [Key]
        public int Id_User { get; set; }
    }
    public class Account
    {
        [Key]
        public int Id_User { get; set;}
        public decimal Balance { get; set;}
        public string NumberAccount { get; set;}
        public decimal Debet { get; set;}
        public bool Active { get; set;}
    }
    public class Clients
    {
        [Key]
        public int Id_User {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PESEL { get; set;}
        public string NumberID { get; set; }
    }
    public class History
    {
        public int Id_User { get; set; }
        public string NumberAccountSender { get; set; }
        public string NumberAccountRecipient { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set;}
        [Key]
        public string Id_Transfer { get; set;}
        public DateOnly DateTransfer { get; set;}
    }
    public class Logs
    {
        [Key]
        public int Number_Error { get; set;}
        public int IdError { get; set;}
        public DateOnly DataError { get; set;}
    }
}
