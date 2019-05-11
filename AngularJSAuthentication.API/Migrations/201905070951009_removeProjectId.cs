namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProjectId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Assets", new[] { "ProjectID" });
            DropColumn("dbo.Assets", "ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "ProjectID");
            AddForeignKey("dbo.Assets", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
        }
    }
}
