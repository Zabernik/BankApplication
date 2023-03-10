using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string? PIN { get; set; }
        public string Password { get; set; }

        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
    }
    public class Account
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        public decimal Balance { get; set;}
        [Key]
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
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set;}
        public string NumberAccountSender { get; set; }
        public string NumberAccountRecipient { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set;}
        [Key]
        public string Id_Transfer { get; set;}
        public DateTime DateTransfer { get; set;}
    }
    public class Logs
    {
        [Key]
        public int Number_Error { get; set;}
        public int IdError { get; set;}
        public DateTime DataError { get; set;}
    }
}
