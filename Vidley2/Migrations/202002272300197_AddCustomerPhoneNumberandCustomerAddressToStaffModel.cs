namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerPhoneNumberandCustomerAddressToStaffModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddresses", "Staff_Id", c => c.Int());
            AddColumn("dbo.CustomerPhoneNumbers", "Staff_Id", c => c.Int());
            CreateIndex("dbo.CustomerAddresses", "Staff_Id");
            CreateIndex("dbo.CustomerPhoneNumbers", "Staff_Id");
            AddForeignKey("dbo.CustomerAddresses", "Staff_Id", "dbo.Staffs", "Id");
            AddForeignKey("dbo.CustomerPhoneNumbers", "Staff_Id", "dbo.Staffs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPhoneNumbers", "Staff_Id", "dbo.Staffs");
            DropForeignKey("dbo.CustomerAddresses", "Staff_Id", "dbo.Staffs");
            DropIndex("dbo.CustomerPhoneNumbers", new[] { "Staff_Id" });
            DropIndex("dbo.CustomerAddresses", new[] { "Staff_Id" });
            DropColumn("dbo.CustomerPhoneNumbers", "Staff_Id");
            DropColumn("dbo.CustomerAddresses", "Staff_Id");
        }
    }
}
