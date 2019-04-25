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
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Incoming> Incoming { get; set; }      
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }

}