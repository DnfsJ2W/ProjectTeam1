using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblPayment
    {
         [Key]
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
    }
}
