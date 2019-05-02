using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ExpenseModel
    {
        public int expenseID { get; set; }
        public int projectID { get; set; }
        public int assetID { get; set; }
        public int categoryID { get; set; }
        public int supplierID { get; set; }
        public string projectName { get; set; }
        public string assetName { get; set; }
        public string categoryName { get; set; }
        public string supplierName { get; set; }
        public decimal totalAmount { get; set; }
        public string description { get; set; }
        public string refrence { get; set; }
        public Nullable<bool> isApproved { get; set; }
        public string receiptPath { get; set; }

    }
}