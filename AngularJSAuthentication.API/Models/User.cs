using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            this.Asset = new HashSet<Asset>();
        }

        public short UserID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
    }
}