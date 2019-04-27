namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TotalAmount");
        }
    }
}
