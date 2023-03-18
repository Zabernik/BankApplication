using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using BankApplication.Enums;

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
        public decimal Balance { get; set; }
        [Key]
        public string NumberAccount { get; set; }
        public decimal Debet { get; set; }
        public bool Active { get; set; }
        [ForeignKey("ClientTypes")]
        public ClientType Type { get; set; }
        public ClientTypes ClientTypes { get; set; }
    }
    public class Clients
    {
        [Key]
        public int Id_User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string NumberID { get; set; }
        public string? DateBirth { get; set; }
    }
    public class History
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        public string NumberAccountSender { get; set; }
        public string NumberAccountRecipient { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        [Key]
        public string Id_Transfer { get; set; }
        public DateTime DateTransfer { get; set; }
    }
    public class Logs
    {
        [Key]
        public int Number_Error { get; set; }
        public int IdError { get; set; }
        public DateTime DataError { get; set; }
    }
    public class Contact
    {
        [Key]
        public string Phone_Number { get; set; }
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        public string? Mail { get; set; }
        public string Adress { get; set; }
    }
    public class ClientTypes
    {
        [Key]
        public ClientType Type { get; set; }
    }
    public class BussinesAccount 
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        [ForeignKey("ClientTypes")]
        public ClientType Type { get; set; }
        public ClientTypes ClientTypes { get; set; }
        [Key]
        public string NIP { get; set; }
    }
    public class StudentAccount
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        [ForeignKey("ClientTypes")]
        public ClientType Type { get; set; }
        public ClientTypes ClientTypes { get; set; }
        public string Name_of_University { get; set; }
        public DateTime End_of_Study { get; set; }
        [Key]
        public int ID_Student { get; set; }

    }
    public class PensionerAccount
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        [ForeignKey("ClientTypes")]
        public ClientType Type { get; set; }
        public ClientTypes ClientTypes { get; set; }
        [Key]
        public string Number_of_ZUS_ID { get; set; }
    }
    public class TeenagerAccount
    {
        [ForeignKey("Clients")]
        public int Id_User { get; set; }
        public Clients Clients { get; set; }
        [ForeignKey("ClientTypes")]
        public ClientType Type { get; set; }
        public ClientTypes ClientTypes { get; set; }
        public string Name_of_Guardian { get; set; }
        [Key]
        public string ID_Teenager { get; set; }
    }
}
