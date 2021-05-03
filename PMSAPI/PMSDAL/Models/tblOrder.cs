using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMSDAL.Models
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
        // public int UserId { get; set; }

        // public virtual tblUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<tblProductOrder> ProductOrders { get; set; }
        public virtual ICollection<tblTracking> Trackings { get; set; }
    }
}