using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Asset = new HashSet<Asset>();
        }     
        public Nullable<short> ProjectID { get; set; }       
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }       
        public virtual Project Project { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }

    }
}