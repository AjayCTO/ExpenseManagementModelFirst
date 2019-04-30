using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class ExpenseUserModel
    {
        public Expense  Expense { get; set; }
        public string UserName { get; set; }
    }
}