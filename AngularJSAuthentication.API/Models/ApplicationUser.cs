using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public ApplicationUser()
        //{

        //    this.Expense = new HashSet<Expense>();
        //}


        public string Contact { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }


        //public virtual ICollection<Expense> Expense { get; set; }


    }
}