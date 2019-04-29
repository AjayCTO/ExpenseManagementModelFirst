namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expesne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Short(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        Refrence = c.String(),
                        IsApproved = c.Boolean(),
                        ReceiptPath = c.String(),
                        ProjectID = c.Int(),
                        AssetID = c.Int(),
                        CategoryID = c.Int(),
                        UserId = c.String(maxLength: 128),
                        SupplierID = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Assets", t => t.AssetID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .Index(t => t.ProjectID)
                .Index(t => t.AssetID)
                .Index(t => t.CategoryID)
                .Index(t => t.UserId)
                .Index(t => t.SupplierID)
                .Index(t => t.ApplicationUser_Id);
            
            AlterColumn("dbo.Incomings", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Expenses", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Expenses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenses", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenses", "AssetID", "dbo.Assets");
            DropIndex("dbo.Expenses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Expenses", new[] { "SupplierID" });
            DropIndex("dbo.Expenses", new[] { "UserId" });
            DropIndex("dbo.Expenses", new[] { "CategoryID" });
            DropIndex("dbo.Expenses", new[] { "AssetID" });
            DropIndex("dbo.Expenses", new[] { "ProjectID" });
            AlterColumn("dbo.Incomings", "Date", c => c.DateTime(nullable: false));
            DropTable("dbo.Expenses");
        }
    }
}
