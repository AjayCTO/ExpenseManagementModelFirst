﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Expense
    {
        public short ExpenseID { get; set; }
        
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Description { get; set; }
        public string Refrence { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ReceiptPath { get; set; }


       
        public Nullable<int> ProjectID { get; set; }

         [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

     
        public Nullable<int> AssetID { get; set; }

           [ForeignKey("AssetID")]
        public virtual Asset Asset { get; set; }

        [ForeignKey("Category")]
        public Nullable<int> CategoryID { get; set; }

          [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Supplier")]
        public Nullable<int> SupplierID { get; set; }
     
        public virtual Supplier Supplier { get; set; }
        
    }
}