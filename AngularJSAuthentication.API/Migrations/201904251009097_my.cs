namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        CategoryID = c.Short(nullable: false),
                        ProjectID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ManufacturerID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Short(nullable: false),
                        ProjectID = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Suppliers", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Manufacturers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Manufacturers", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Suppliers", new[] { "ProjectID" });
            DropIndex("dbo.Suppliers", new[] { "CategoryID" });
            DropIndex("dbo.Manufacturers", new[] { "ProjectID" });
            DropIndex("dbo.Manufacturers", new[] { "CategoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Manufacturers");
        }
    }
}
