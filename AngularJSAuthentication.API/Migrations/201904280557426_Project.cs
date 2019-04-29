namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BillingMethod = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CustomerID)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Assets", "ProjectID", c => c.Int(nullable: false));
            AddColumn("dbo.Manufacturers", "ProjectID", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "ProjectID");
            CreateIndex("dbo.Manufacturers", "ProjectID");
            CreateIndex("dbo.Suppliers", "ProjectID");
            AddForeignKey("dbo.Manufacturers", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Assets", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Suppliers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Manufacturers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Suppliers", new[] { "ProjectID" });
            DropIndex("dbo.Manufacturers", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropIndex("dbo.Projects", new[] { "CustomerID" });
            DropIndex("dbo.Assets", new[] { "ProjectID" });
            DropColumn("dbo.Suppliers", "ProjectID");
            DropColumn("dbo.Manufacturers", "ProjectID");
            DropColumn("dbo.Assets", "ProjectID");
            DropTable("dbo.Projects");
        }
    }
}
