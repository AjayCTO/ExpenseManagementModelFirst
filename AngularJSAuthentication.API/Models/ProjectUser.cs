using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ProjectUser
    {
        public Project Project { get; set; }
        public string  UserName { get; set; }
    }
}