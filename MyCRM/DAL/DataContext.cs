using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCRM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyCRM.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}