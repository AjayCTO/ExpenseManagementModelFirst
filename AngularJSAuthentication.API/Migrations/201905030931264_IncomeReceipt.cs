namespace AngularJSAuthentication.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incomings", "receiptPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incomings", "receiptPath");
        }
    }
}
