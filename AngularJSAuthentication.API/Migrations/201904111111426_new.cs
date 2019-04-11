namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ProjectID", c => c.Short());
            AddColumn("dbo.AspNetUsers", "Contact", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Assets", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "ProjectID");
            AddForeignKey("dbo.Assets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "ProjectID", "dbo.Projects", "ProjectID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Assets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "ProjectID" });
            DropIndex("dbo.Assets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "LastLogin");
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Contact");
            DropColumn("dbo.AspNetUsers", "ProjectID");
            DropColumn("dbo.Assets", "ApplicationUser_Id");
        }
    }
}
