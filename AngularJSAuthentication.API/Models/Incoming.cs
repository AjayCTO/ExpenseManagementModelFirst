using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Incoming
    {
        [Key]
        public short IncomeID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string SourceName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Date { get; set; }

        public virtual Project Project { get; set; }
    }
}