namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userideee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ProjectID", "dbo.Projects");
            DropIndex("dbo.AspNetUsers", new[] { "ProjectID" });
            AddColumn("dbo.Projects", "UserId", c => c.Short());
            AddColumn("dbo.Projects", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "ApplicationUser_Id");
            CreateIndex("dbo.Projects", "AppUser_Id");
            AddForeignKey("dbo.Projects", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "AppUser_Id" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Projects", "AppUser_Id");
            DropColumn("dbo.Projects", "ApplicationUser_Id");
            DropColumn("dbo.Projects", "UserId");
            CreateIndex("dbo.AspNetUsers", "ProjectID");
            AddForeignKey("dbo.AspNetUsers", "ProjectID", "dbo.Projects", "ProjectID");
        }
    }
}
