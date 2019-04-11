using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Asset
    {
        public Asset()
        {
            this.Expense = new HashSet<Expense>();
        }

        public short AssetID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Business { get; set; }
        public Nullable<short> UserID { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
    }
}