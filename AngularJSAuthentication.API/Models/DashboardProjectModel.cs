using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class DashboardProjectModel
    {
        public string  projectName { get; set; }
        public decimal totalExpense { get; set; }
        public decimal totalIncoming { get; set; }
        public decimal totalCost { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}