using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblProductOrder
    {
        public tblProductOrder()
        {
            //this.ProductOrderPayment = new List<tblProductOrderPayment>();
        }
        [Key]
        public int ProductOrderId { get; set; }
        public int OrderId { get; set; }
        public virtual tblOrder Order { get; set; }
        public int ProductId { get; set; }
        public virtual tblProduct Product { get; set; }



        public virtual ICollection<tblProductOrderPayment> ProductOrderPayment { get; set; }
    }
}