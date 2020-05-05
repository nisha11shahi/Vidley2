namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerSignatureToCustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerSignature", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerSignature");
        }
    }
}
