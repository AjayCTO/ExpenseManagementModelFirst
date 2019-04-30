using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Category
    {
        public Category()
        {

            this.Expense = new List<Expense>();
        }

        public int CategoryID { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }


        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }

    }
}