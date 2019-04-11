using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Category
    {
        public Category()
        {
            this.Expense = new HashSet<Expense>();
        }

        public short CategoryID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
    }
}