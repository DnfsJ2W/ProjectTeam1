using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMSDAL.Models
{
    public class tblProductOrderPayment
    {
        [Key]
        public int ProductOrderPaymentId { get; set; }
        public int ProductOrderId { get; set; }
        public virtual tblProductOrder ProductOrder { get; set; }
        public int PaymentId { get; set; }
        public virtual tblPayment Payment { get; set; }
        public string CardNumber { get; set; }
        public string BankName { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpiryDate { get; set; }
        //public int UserId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }



        // public virtual tblUser User { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}