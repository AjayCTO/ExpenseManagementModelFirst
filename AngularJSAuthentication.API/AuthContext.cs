using AngularJSAuthentication.API.Entities;
using AngularJSAuthentication.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Incoming> Incomings { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        //    public System.Data.Entity.DbSet<AngularJSAuthentication.API.Models.Expense> Expenses { get; set; }

        //    public System.Data.Entity.DbSet<AngularJSAuthentication.API.Models.ApplicationUser> IdentityUsers { get; set; }
        

    }
}