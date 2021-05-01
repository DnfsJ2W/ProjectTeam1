using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblProductOrderPayment
    {
        [Key]
        public int ProductOrderPaymentId { get; set; }
        public int ProductOrderId { get; set; }
        public int ProductId { get; set; }
        public string CardNumber { get; set; }
        public string BankName { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UserId { get; set; }

        public virtual tblProductOrder ProductOrder { get; set; }
        public virtual tblProduct Product { get; set; }
        public virtual tblUser User { get; set; }
    }
}