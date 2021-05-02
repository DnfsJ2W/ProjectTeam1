using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMSAPI.Models
{
    public class tblProduct
    {
        public tblProduct()
        {
            this.ProductOrders = new List<tblProductOrder>();
            //this.ProductOrderPayments = new List<tblProductOrderPayment>();
        }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Discount { get; set; }
        public int Quantity { get; set; }
        public string StockStatus { get; set; }

        public virtual tblCategory Category { get; set; }
        public virtual ICollection<tblProductOrder> ProductOrders { get; set; }


        public virtual ICollection<tblProductOrderPayment> tblProductOrderPayment { get; set; }

    }
}