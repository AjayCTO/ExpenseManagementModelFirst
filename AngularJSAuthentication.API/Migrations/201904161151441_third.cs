namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Projects", new[] { "AppUser_Id" });
            DropColumn("dbo.Projects", "UserId");
            RenameColumn(table: "dbo.Projects", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Projects", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "UserId");
            DropColumn("dbo.Projects", "AppUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "AppUser_Id", c => c.String(maxLength: 128));
            DropIndex("dbo.Projects", new[] { "UserId" });
            AlterColumn("dbo.Projects", "UserId", c => c.Short());
            RenameColumn(table: "dbo.Projects", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Projects", "UserId", c => c.Short());
            CreateIndex("dbo.Projects", "AppUser_Id");
            CreateIndex("dbo.Projects", "ApplicationUser_Id");
            AddForeignKey("dbo.Projects", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
