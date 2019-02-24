using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCRM.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        public bool Organization { get; set; }  

        public virtual ICollection<Customer> Customers { get; set; }
    }
}