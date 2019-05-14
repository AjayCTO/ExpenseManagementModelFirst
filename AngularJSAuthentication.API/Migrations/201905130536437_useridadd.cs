namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Suppliers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Incomings", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "UserId");
            CreateIndex("dbo.Suppliers", "UserId");
            CreateIndex("dbo.Incomings", "CustomerID");
            AddForeignKey("dbo.Assets", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Suppliers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Incomings", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomings", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Suppliers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Assets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Incomings", new[] { "CustomerID" });
            DropIndex("dbo.Suppliers", new[] { "UserId" });
            DropIndex("dbo.Assets", new[] { "UserId" });
            DropColumn("dbo.Incomings", "CustomerID");
            DropColumn("dbo.Suppliers", "UserId");
            DropColumn("dbo.Assets", "UserId");
        }
    }
}
