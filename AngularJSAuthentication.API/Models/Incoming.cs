using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Incoming
    {
        [Key]
        public short IncomingID { get; set; }
        
        public string SourceName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

        public string  receiptPath { get; set; }


        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}