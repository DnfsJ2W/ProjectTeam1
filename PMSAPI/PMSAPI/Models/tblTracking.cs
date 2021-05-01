using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSAPI.Models
{
    public class tblTracking
    {
        [Key]
        public int TrackId { get; set; }
        public int OrderId { get; set; }
        public DateTime EstimatedDate { get; set; }

        public virtual tblOrder Order { get; set; }
    }
}