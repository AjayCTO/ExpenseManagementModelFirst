namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(),
                        AssetID = c.Short(),
                        SupplierID = c.Int(),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        ExpenseID = c.Int(),
                        Asset_AssetID = c.Int(),
                        Expense_ExpenseID = c.Short(),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Assets", t => t.Asset_AssetID)
                .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .Index(t => t.SupplierID)
                .Index(t => t.Asset_AssetID)
                .Index(t => t.Expense_ExpenseID)
                .Index(t => t.Project_ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Transactions", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "Expense_ExpenseID", "dbo.Expenses");
            DropForeignKey("dbo.Transactions", "Asset_AssetID", "dbo.Assets");
            DropIndex("dbo.Transactions", new[] { "Project_ProjectID" });
            DropIndex("dbo.Transactions", new[] { "Expense_ExpenseID" });
            DropIndex("dbo.Transactions", new[] { "Asset_AssetID" });
            DropIndex("dbo.Transactions", new[] { "SupplierID" });
            DropTable("dbo.Transactions");
        }
    }
}
