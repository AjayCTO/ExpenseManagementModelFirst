using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Transaction
    {
        public short TransactionID { get; set; }
        public short ProjectID { get; set; }
        public short AssetID { get; set; }
        public short SupplierID { get; set; }

        public virtual Project Project { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}