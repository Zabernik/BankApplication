using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace BankApplication
{
    public class SQLite : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Bankdb.db");
        }

        public DbSet<History> History { get; set;}
        public DbSet<Clients> Client  { get; set;}
        public DbSet<Account> Account { get; set; }
        public DbSet<User> Login{ get; set;}
        public DbSet<Logs> Logs { get; set;}
    }
}
