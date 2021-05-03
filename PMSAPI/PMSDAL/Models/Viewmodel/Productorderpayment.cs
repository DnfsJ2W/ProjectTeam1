using PMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSDAL.Models.Viewmodel
{
    public class Productorderpayment
    {
        public int ProductOrderPaymentId { get; set; }
        public int ProductOrderId { get; set; }
        public virtual tblProductOrder ProductOrder { get; set; }
        public int PaymentId { get; set; }
        public virtual tblPayment Payment { get; set; }
        public string CardNumber { get; set; }
        public string BankName { get; set; }
        public string NameOnCard { get; set; }
        public DateTime ExpiryDate { get; set; }
       
        public string UserId { get; set; }

    }
}