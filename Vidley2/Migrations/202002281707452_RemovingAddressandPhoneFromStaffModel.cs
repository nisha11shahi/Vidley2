namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAddressandPhoneFromStaffModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "AddressTypeId", "dbo.AddressTypes");
            DropForeignKey("dbo.Staffs", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropIndex("dbo.Staffs", new[] { "PhoneNumberTypeId" });
            DropIndex("dbo.Staffs", new[] { "AddressTypeId" });
            DropColumn("dbo.Staffs", "PhoneNumberTypeId");
            DropColumn("dbo.Staffs", "AddressTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "AddressTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "PhoneNumberTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "AddressTypeId");
            CreateIndex("dbo.Staffs", "PhoneNumberTypeId");
            AddForeignKey("dbo.Staffs", "PhoneNumberTypeId", "dbo.PhoneNumberTypes", "Id");
            AddForeignKey("dbo.Staffs", "AddressTypeId", "dbo.AddressTypes", "Id");
        }
    }
}
