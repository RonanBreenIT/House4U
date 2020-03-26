using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace House4U.Models
{
    public enum LeaseType
    {
        Managed, FullyDelagated
    }
    public class Property
    {
        public int ID { get; set; }

        public string Address { get; set; }
        public int NoBedrooms { get; set; }
        public LeaseType LType { get; set; }

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if ((value != null) && (value.Contains("@")))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Email cannot be blank");
                }
            }
        }

        private DateTime expiryDate;
        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }
            set
            {
                if (value != null)
                {
                    this.expiryDate = value;
                }
                else
                {
                    throw new ArgumentException("Date cannot be blank");
                }
            }
        }
    }
}