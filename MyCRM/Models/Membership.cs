using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCRM.Models
{
    public enum MembershipLevel
    {
        None,
        Basic,
        Premium,
        Elite
    }

    public class Membership
    {
        public int MembershipID { get; set; }

        [Required(ErrorMessage = "Please Select a Membership Level")]
        [Display(Name = "Membership Level")]
        public MembershipLevel MembershipLevel { get; set; }

        [Display(Name = "Effective Date")]
        public DateTime? EffectiveDate { get; private set; }

        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; private set; }
        public decimal? Price { get; set; }

        [Index]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public Membership()
        {
            DateTime _date = GetEffectiveDate();

            EffectiveDate = _date;
            ExpirationDate = _date.AddYears(1);
        }

        /// <summary>
        /// Calculate Membership Level
        /// </summary>
        /// <returns></returns>
        public void CalculateMembershipPrice()
        {
            switch (MembershipLevel)
            {
                case MembershipLevel.None:
                    Price = (decimal)0.00;
                    break;
                case MembershipLevel.Basic:
                    Price = (decimal)45.00;
                    break;
                case MembershipLevel.Premium:
                    Price = (decimal)75.00;
                    break;
                case MembershipLevel.Elite:
                    Price = (decimal)105.00;
                    break;
                default:
                    Price = null;
                    break;
            }
        }

        /// <summary>
        /// Return today's date
        /// </summary>
        /// <returns></returns>
        private DateTime GetEffectiveDate()
        {
            return DateTime.Now.Date;
        }

        /// <summary>
        /// String to Enum Parser from Stackoverflow
        /// URL: https://stackoverflow.com/questions/16100/how-should-i-convert-a-string-to-an-enum-in-c
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}