using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblOrder
    {
        public tblOrder()
        {
            this.ProductOrders = new List<tblProductOrder>();
            this.Trackings = new List<tblTracking>();
        }

        [Key]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }

        public virtual tblUser User { get; set; }
        public virtual ICollection<tblProductOrder> ProductOrders { get; set; }
        public virtual ICollection<tblTracking> Trackings { get; set; }
    }
}