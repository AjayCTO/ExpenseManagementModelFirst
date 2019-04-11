namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        Name = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Business = c.String(),
                        UserID = c.Short(),
                    })
                .PrimaryKey(t => t.AssetID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        Date = c.DateTime(),
                        AssetID = c.Short(),
                        CategoryID = c.Short(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        Refrence = c.String(),
                        IsApproved = c.Boolean(),
                        ReceiptPath = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Assets", t => t.AssetID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID)
                .Index(t => t.AssetID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        BillingMethod = c.String(),
                        CustomerName = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Incomings",
                c => new
                    {
                        IncomeID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        SourceName = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.IncomeID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        Name = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        Role = c.String(),
                        LastLogin = c.DateTime(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Assets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Incomings", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Expenses", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Categories", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Assets", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Expenses", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "AssetID", "dbo.Assets");
            DropIndex("dbo.Users", new[] { "ProjectID" });
            DropIndex("dbo.Incomings", new[] { "ProjectID" });
            DropIndex("dbo.Categories", new[] { "ProjectID" });
            DropIndex("dbo.Expenses", new[] { "CategoryID" });
            DropIndex("dbo.Expenses", new[] { "AssetID" });
            DropIndex("dbo.Expenses", new[] { "ProjectID" });
            DropIndex("dbo.Assets", new[] { "UserID" });
            DropIndex("dbo.Assets", new[] { "ProjectID" });
            DropTable("dbo.Users");
            DropTable("dbo.Incomings");
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
            DropTable("dbo.Expenses");
            DropTable("dbo.Assets");
        }
    }
}
