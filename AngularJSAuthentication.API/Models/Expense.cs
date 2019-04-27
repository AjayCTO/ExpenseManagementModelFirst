using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Expense
    {
        public short ExpenseID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<short> AssetID { get; set; }
        public Nullable<short> CategoryID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Description { get; set; }
        public string Refrence { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ReceiptPath { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public virtual Project Project { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Category Category { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}