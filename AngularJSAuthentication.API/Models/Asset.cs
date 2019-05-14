using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Asset : Person
    {
        public Asset()
        {

            this.Expense = new List<Expense>();
            this.Transaction = new List<Transaction>();
            this.AssetsProject = new List<AssetsProject>();
        }

        public int AssetID { get; set; }

    
        //[ForeignKey("Project")]
        //public int ProjectID { get; set; }
        //public Project Project { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual ICollection<AssetsProject> AssetsProject { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}