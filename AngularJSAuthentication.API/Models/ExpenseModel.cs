using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ExpenseModel
    {
        public int expenseID { get; set; }
        public string projectName { get; set; }
        public string assetName { get; set; }
        public string categoryName { get; set; }
        public decimal TotalAmount { get; set; }

        public string description { get; set; }

    }
}