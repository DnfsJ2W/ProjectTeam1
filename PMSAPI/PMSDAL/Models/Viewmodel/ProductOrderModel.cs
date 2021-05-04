using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSDAL.Models.Viewmodel
{
    public class ProductOrderModel
    {
        public int ProductOrderId { get; set; }
        //public int OrderId { get; set; }
       
        public int ProductId { get; set; }

        //public int Quantity { get; set; }
        //public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

       
        public string StockStatus { get; set; }
    }
}