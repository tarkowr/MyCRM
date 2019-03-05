using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCRM.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Required]
        [Display(Name ="Organization?")]
        public bool Organization { get; set; }  

        public virtual ICollection<Customer> Customers { get; set; }
    }
}