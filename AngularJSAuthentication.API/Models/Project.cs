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
            this.Asset = new List<Asset>();
            this.Supplier = new List<Supplier>();
            this.Manufacturer = new List<Manufacturer>();
            this.Category = new List<Category>();
            this.Incoming = new List<Incoming>();
            this.Expense = new List<Expense>();
            this.Transaction = new List<Transaction>();
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