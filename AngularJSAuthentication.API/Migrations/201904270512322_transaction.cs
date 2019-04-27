namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Short(nullable: false, identity: true),
                        ProjectID = c.Short(nullable: false),
                        AssetID = c.Short(nullable: false),
                        SupplierID = c.Short(nullable: false),
                        Supplier_SupplierID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Assets", t => t.AssetID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierID)
                .Index(t => t.ProjectID)
                .Index(t => t.AssetID)
                .Index(t => t.Supplier_SupplierID);
            
            AddColumn("dbo.Expenses", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Expenses", "UserId");
            AddForeignKey("dbo.Expenses", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Supplier_SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Transactions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "AssetID", "dbo.Assets");
            DropForeignKey("dbo.Expenses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "Supplier_SupplierID" });
            DropIndex("dbo.Transactions", new[] { "AssetID" });
            DropIndex("dbo.Transactions", new[] { "ProjectID" });
            DropIndex("dbo.Expenses", new[] { "UserId" });
            DropColumn("dbo.Expenses", "UserId");
            DropTable("dbo.Transactions");
        }
    }
}
