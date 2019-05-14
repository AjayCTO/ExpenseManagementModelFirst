namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Suppliers", new[] { "ProjectID" });
            CreateTable(
                "dbo.SupplierProjects",
                c => new
                    {
                        supplierID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.supplierID, t.projectID })
                .ForeignKey("dbo.Projects", t => t.projectID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.supplierID, cascadeDelete: true)
                .Index(t => t.supplierID)
                .Index(t => t.projectID);
            
            DropColumn("dbo.Suppliers", "ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "ProjectID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SupplierProjects", "supplierID", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierProjects", "projectID", "dbo.Projects");
            DropIndex("dbo.SupplierProjects", new[] { "projectID" });
            DropIndex("dbo.SupplierProjects", new[] { "supplierID" });
            DropTable("dbo.SupplierProjects");
            CreateIndex("dbo.Suppliers", "ProjectID");
            AddForeignKey("dbo.Suppliers", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
        }
    }
}
