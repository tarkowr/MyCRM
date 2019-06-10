using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCRM.Models
{
    public class Customer
    {
        public int ID { get; set; } 

        [Index]
        [Required]
        public int AccountID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+[.][a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Invalid Phone Number. Enter in Format: (XXX)-XXX-XXXX")]
        public string Phone { get; set; }

        public virtual Account Account { get; set; }
    }
}