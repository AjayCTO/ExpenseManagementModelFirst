using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class AssetsProject
    {
        
        [Key]
        [Column(Order = 1)]
        public int assetID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int projectID { get; set; }

        public Asset Asset { get; set; }
        public Project Project { get; set; }
    }
}