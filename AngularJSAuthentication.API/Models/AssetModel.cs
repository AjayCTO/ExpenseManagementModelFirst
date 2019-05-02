using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class AssetModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public int assetID { get; set; }      
        public int projectID { get; set; }
        public decimal totalExpesne { get; set; }
      
    }
}