using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSDAL.Models.Viewmodel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        // public int UserId { get; set; }

        // public virtual tblUser User { get; set; }

        public string UserName { get; set; }


        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime EstimatedDate { get; set; }
    }
}