namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberTypeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PhoneNumberTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "PhoneNumberType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "PhoneNumberType_Id");
            AddForeignKey("dbo.Customers", "PhoneNumberType_Id", "dbo.PhoneNumberTypes", "Id");
            DropColumn("dbo.Customers", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            DropForeignKey("dbo.Customers", "PhoneNumberType_Id", "dbo.PhoneNumberTypes");
            DropIndex("dbo.Customers", new[] { "PhoneNumberType_Id" });
            DropColumn("dbo.Customers", "PhoneNumberType_Id");
            DropColumn("dbo.Customers", "PhoneNumberTypeId");
        }
    }
}
