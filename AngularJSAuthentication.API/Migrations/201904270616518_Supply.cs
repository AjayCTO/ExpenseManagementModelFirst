namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supply : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "AssetID", "dbo.Assets");
            DropForeignKey("dbo.Transactions", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Transactions", new[] { "ProjectID" });
            DropIndex("dbo.Transactions", new[] { "AssetID" });
            DropIndex("dbo.Transactions", new[] { "Supplier_SupplierID" });
            DropColumn("dbo.Transactions", "SupplierID");
            RenameColumn(table: "dbo.Transactions", name: "Supplier_SupplierID", newName: "SupplierID");
            AlterColumn("dbo.Transactions", "ProjectID", c => c.Short());
            AlterColumn("dbo.Transactions", "AssetID", c => c.Short());
            AlterColumn("dbo.Transactions", "SupplierID", c => c.Int());
            AlterColumn("dbo.Transactions", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Transactions", "ProjectID");
            CreateIndex("dbo.Transactions", "AssetID");
            CreateIndex("dbo.Transactions", "SupplierID");
            AddForeignKey("dbo.Transactions", "AssetID", "dbo.Assets", "AssetID");
            AddForeignKey("dbo.Transactions", "ProjectID", "dbo.Projects", "ProjectID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "AssetID", "dbo.Assets");
            DropIndex("dbo.Transactions", new[] { "SupplierID" });
            DropIndex("dbo.Transactions", new[] { "AssetID" });
            DropIndex("dbo.Transactions", new[] { "ProjectID" });
            AlterColumn("dbo.Transactions", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "SupplierID", c => c.Short(nullable: false));
            AlterColumn("dbo.Transactions", "AssetID", c => c.Short(nullable: false));
            AlterColumn("dbo.Transactions", "ProjectID", c => c.Short(nullable: false));
            RenameColumn(table: "dbo.Transactions", name: "SupplierID", newName: "Supplier_SupplierID");
            AddColumn("dbo.Transactions", "SupplierID", c => c.Short(nullable: false));
            CreateIndex("dbo.Transactions", "Supplier_SupplierID");
            CreateIndex("dbo.Transactions", "AssetID");
            CreateIndex("dbo.Transactions", "ProjectID");
            AddForeignKey("dbo.Transactions", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "AssetID", "dbo.Assets", "AssetID", cascadeDelete: true);
        }
    }
}
