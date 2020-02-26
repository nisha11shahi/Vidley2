namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStreetAddressForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "StreetAddress");
        }
    }
}
