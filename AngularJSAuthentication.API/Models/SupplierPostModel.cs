using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class SupplierPostModel
    {
        public int projectID { get; set; }
        public Supplier Supplier { get; set; }

        public string UserName { get; set; }

    }
}