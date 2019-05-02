using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class CategoryModel
    {
        public int categoryID { get; set; }
        public string name { get; set; }
        public string description { get; set; }      
        public int projectID { get; set; }
    
    }
}