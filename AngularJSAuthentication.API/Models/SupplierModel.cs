using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class SupplierModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public int supplierID { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
        public Nullable<decimal> amountPaid { get; set; }
        public int projectID { get; set; }    
      
    }
}