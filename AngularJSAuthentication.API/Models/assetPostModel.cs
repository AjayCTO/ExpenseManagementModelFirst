using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class assetPostModel
    {
        public int projectID { get; set; }
        public Asset Asset { get; set; }
        public string UserName { get; set; }
    }
}