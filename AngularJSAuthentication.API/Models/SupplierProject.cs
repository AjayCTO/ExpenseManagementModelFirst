using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class SupplierProject
    {
        [Key]
        [Column(Order=1)]
        public int supplierID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int projectID { get; set; }

        public Supplier Supplier { get; set; }
        public Project Project { get; set; }

    }
}