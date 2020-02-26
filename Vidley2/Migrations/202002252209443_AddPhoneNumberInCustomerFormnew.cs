namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberInCustomerFormnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            DropColumn("dbo.Customers", "PhoneNumberTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PhoneNumberTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Customers", "PhoneNumber");
        }
    }
}
