using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMSDAL.Models
{
    public class tblTracking
    {
        [Key]
        public int TrackId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public DateTime EstimatedDate { get; set; }

        public virtual tblOrder Order { get; set; }
    }
}