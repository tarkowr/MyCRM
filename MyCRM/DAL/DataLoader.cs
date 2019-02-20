using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCRM.Models;
using System.Data.Entity;

namespace MyCRM.DAL
{
    public class DataLoader : DropCreateDatabaseIfModelChanges<DataContext> //TODO: Change back to CreateDrop DB on Model Change
    {
        protected override void Seed(DataContext context)
        {
            var accounts = new List<Account>
            {
                new Account {AccountName="Tarkowski Account", Organization=false},
                new Account {AccountName="Hagerty Insurance", Organization=true},
                new Account {AccountName="Oleson's Grocery Stores", Organization=true},
                new Account {AccountName="Smith Family", Organization=false},
                new Account {AccountName="Tewers Crew", Organization=false},
                new Account {AccountName="The Hammond Group", Organization=false},
                new Account {AccountName="Walgreens, Inc.", Organization=true},
                new Account {AccountName="Munson Hospital", Organization=true}
            };

            accounts.ForEach(a => context.Accounts.Add(a));
            SaveChanges(context);
            
            var customers = new List<Customer>
            {
                new Customer {Name="Rich Tarkowski", Email="rich@gmail.com", Phone="231-555-7821", AccountID=1},
                new Customer {Name="Alyssa Tarkowski", Email="tarkowa@mygta.us", Phone="231-888-5664", AccountID=1},
                new Customer {Name="McKeel Hagerty", Email="mhagerty@hagerty.com", Phone="231-999-1265", AccountID=2},
                new Customer {Name="Josh Adams", Email="jadams117@hagerty.com", Phone="231-313-5566", AccountID=2},
                new Customer {Name="Jim Powers", Email="powersj@oleson.org", Phone="231-888-1221", AccountID=3},
                new Customer {Name="Emily Tewers", Email="etewers@gmail.com", Phone="231-899-9901", AccountID=5},
                new Customer {Name="Daniel Tewers", Email="dtewers@gmail.com", Phone="231-444-8931", AccountID=5},
                new Customer {Name="Dan Westover", Email="dwestover@walgreens.com", Phone="231-444-3387", AccountID=7}
            };

            customers.ForEach(c => context.Customers.Add(c));
            SaveChanges(context);

            var memberships = new List<Membership>
            {
                new Membership { MembershipLevel=MembershipLevel.Premium, CustomerID=1, Price=75 },
                new Membership { MembershipLevel=MembershipLevel.Basic, CustomerID=2, Price=45},
                new Membership { MembershipLevel=MembershipLevel.Elite, CustomerID=3, Price=105 },
                new Membership { MembershipLevel=MembershipLevel.Elite, CustomerID=4, Price=105 },
                new Membership { MembershipLevel=MembershipLevel.None, CustomerID=5, Price=0 },
                new Membership { MembershipLevel=MembershipLevel.Basic, CustomerID=6, Price=45 },
                new Membership { MembershipLevel=MembershipLevel.Premium, CustomerID=7, Price=75 },
                new Membership { MembershipLevel=MembershipLevel.Premium, CustomerID=8, Price=75 }
            };

            memberships.ForEach(m => context.Memberships.Add(m));
            SaveChanges(context);
        }

        private void SaveChanges(DataContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}