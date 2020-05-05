namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffAddressandStaffPhoneNumberToModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerAddresses", "Staff_Id", "dbo.Staffs");
            DropForeignKey("dbo.CustomerPhoneNumbers", "Staff_Id", "dbo.Staffs");
            DropIndex("dbo.CustomerAddresses", new[] { "Staff_Id" });
            DropIndex("dbo.CustomerPhoneNumbers", new[] { "Staff_Id" });
            CreateTable(
                "dbo.StaffAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.StaffPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        PhoneNumberTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        PhoneExtension = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneNumberTypes", t => t.PhoneNumberTypeId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.PhoneNumberTypeId);
            
            DropColumn("dbo.CustomerAddresses", "Staff_Id");
            DropColumn("dbo.CustomerPhoneNumbers", "Staff_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerPhoneNumbers", "Staff_Id", c => c.Int());
            AddColumn("dbo.CustomerAddresses", "Staff_Id", c => c.Int());
            DropForeignKey("dbo.StaffPhoneNumbers", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.StaffPhoneNumbers", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropForeignKey("dbo.StaffAddresses", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.StaffAddresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.StaffPhoneNumbers", new[] { "PhoneNumberTypeId" });
            DropIndex("dbo.StaffPhoneNumbers", new[] { "StaffId" });
            DropIndex("dbo.StaffAddresses", new[] { "AddressTypeId" });
            DropIndex("dbo.StaffAddresses", new[] { "StaffId" });
            DropTable("dbo.StaffPhoneNumbers");
            DropTable("dbo.StaffAddresses");
            CreateIndex("dbo.CustomerPhoneNumbers", "Staff_Id");
            CreateIndex("dbo.CustomerAddresses", "Staff_Id");
            AddForeignKey("dbo.CustomerPhoneNumbers", "Staff_Id", "dbo.Staffs", "Id");
            AddForeignKey("dbo.CustomerAddresses", "Staff_Id", "dbo.Staffs", "Id");
        }
    }
}
