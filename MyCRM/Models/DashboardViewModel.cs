using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCRM.Models
{
    public class DashboardViewModel
    {
        [Display(Name = "Customer")]
        public List<Customer> Customers { get; set; }

        [Display(Name = "Account")]
        public List<Account> Accounts { get; set; }

        [Display(Name = "Membership Level")]
        public List<Membership> Memberships { get; set; }   

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DashboardViewModel()
        {
            Customers = new List<Customer>();
            Accounts = new List<Account>();
            Memberships = new List<Membership>();
        }

        /// <summary>
        /// Constructor with DB Data
        /// </summary>
        /// <param name="_customers"></param>
        /// <param name="_accounts"></param>
        /// <param name="_memberships"></param>
        public DashboardViewModel(List<Customer> _customers, List<Account> _accounts, List<Membership> _memberships)
        {
            Customers = _customers;
            Accounts = _accounts;
            Memberships = _memberships;
        }

        public Account GetCustomerAccount(Customer customer)
        {
            return Accounts.FirstOrDefault(a => a.Customers.Contains(customer));
        }

        public List<Membership> GetCustomerMemberships(Customer customer)
        {
            return Memberships.Where(m => m.CustomerID == customer.ID).ToList();
        }
    }
}