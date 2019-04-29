using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Project
    {
        public Project()
        {
            this.Asset = new HashSet<Asset>();
            this.Supplier = new HashSet<Supplier>();
            this.Manufacturer = new HashSet<Manufacturer>();
            this.Category = new HashSet<Category>();
            this.Incoming = new HashSet<Incoming>();
            this.Expense = new HashSet<Expense>();
            this.Transaction = new HashSet<Transaction>();
        }


        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string BillingMethod { get; set; }
        public decimal TotalCost { get; set; }


        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
        public virtual ICollection<Manufacturer> Manufacturer { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Incoming> Incoming { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }



    }
}