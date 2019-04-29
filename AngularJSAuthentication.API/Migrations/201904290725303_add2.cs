namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Expenses", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Expenses", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Expenses", "ApplicationUser_Id");
            AddForeignKey("dbo.Expenses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
