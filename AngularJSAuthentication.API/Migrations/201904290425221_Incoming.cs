namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incoming : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Incomings",
                c => new
                    {
                        IncomingID = c.Short(nullable: false, identity: true),
                        SourceName = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomingID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            AlterColumn("dbo.Suppliers", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Suppliers", "AmountPaid", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomings", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Categories", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Incomings", new[] { "ProjectID" });
            DropIndex("dbo.Categories", new[] { "ProjectID" });
            AlterColumn("dbo.Suppliers", "AmountPaid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Suppliers", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.Incomings");
            DropTable("dbo.Categories");
        }
    }
}
