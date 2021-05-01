using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblUser
    {
        public tblUser()
        {
            this.Orders = new List<tblOrder>();
            this.ProductOrderPayments = new List<tblProductOrderPayment>();
        }
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string StreetAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<tblOrder> Orders { get; set; }
        public virtual ICollection<tblProductOrderPayment> ProductOrderPayments { get; set; }


    }
}