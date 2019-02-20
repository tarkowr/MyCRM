using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCRM.Models
{
    public class Customer
    {
        public int ID { get; set; } 
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Account Account { get; set; }
    }
}