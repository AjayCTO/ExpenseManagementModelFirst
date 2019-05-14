using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ProjectUserModel
    {
        public Project project { get; set; }
        public string userName { get; set; }
    }
}