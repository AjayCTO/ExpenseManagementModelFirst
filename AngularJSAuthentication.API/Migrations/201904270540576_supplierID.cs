namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "SupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "SupplierID");
            AddForeignKey("dbo.Expenses", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Expenses", new[] { "SupplierID" });
            DropColumn("dbo.Expenses", "SupplierID");
        }
    }
}
