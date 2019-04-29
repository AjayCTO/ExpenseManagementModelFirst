using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Transaction
    {
        public short TransactionID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public Nullable<short> AssetID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<int> ExpenseID { get; set; }

        public virtual Project Project { get; set; }
        public virtual Asset Asset { get; set; } 
        public virtual Supplier Supplier { get; set; }
        public virtual Expense Expense { get; set; }
    }
}