using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSDAL.Models
{
    public class tblPayment
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public virtual ICollection<tblProductOrderPayment> ProductOrderPayments { get; set; } = new List<tblProductOrderPayment>();
    }
}
