using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ProjectModel
    {
        public int projectID { get; set; }
        public string name { get; set; }
        public string billingMethod { get; set; }
        public decimal toalCost { get; set; }
    }
}