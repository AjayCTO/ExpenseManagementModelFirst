using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Supplier : Person
    {
        public Supplier()
        {

            this.Expense = new HashSet<Expense>();
        }

        public int SupplierID { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }

    }
}