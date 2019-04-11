using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Project
    {
        public Project()
        {
            this.Asset = new HashSet<Asset>();
            this.Category = new HashSet<Category>();
            this.Expense = new HashSet<Expense>();
            this.Incoming = new HashSet<Incoming>();
            this.User = new HashSet<User>();
        }

        public short ProjectID { get; set; }
        public string Name { get; set; }
        public string BillingMethod { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> TotalCost { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Incoming> Incoming { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}