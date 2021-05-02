using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblCategory
    {
        public tblCategory()
        {
            this.Products = new List<tblProduct>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public virtual ICollection<tblProduct> Products { get; set; }



    }
}