namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assetProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetsProjects",
                c => new
                    {
                        assetID = c.Int(nullable: false),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.assetID, t.projectID })
                .ForeignKey("dbo.Assets", t => t.assetID, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.projectID, cascadeDelete: false)
                .Index(t => t.assetID)
                .Index(t => t.projectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetsProjects", "projectID", "dbo.Projects");
            DropForeignKey("dbo.AssetsProjects", "assetID", "dbo.Assets");
            DropIndex("dbo.AssetsProjects", new[] { "projectID" });
            DropIndex("dbo.AssetsProjects", new[] { "assetID" });
            DropTable("dbo.AssetsProjects");
        }
    }
}
