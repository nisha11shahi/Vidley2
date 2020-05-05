namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerPhoneNumberAndCustomerAddressToModelpart2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.CustomerPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PhoneNumberTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        PhoneExtension = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.PhoneNumberTypes", t => t.PhoneNumberTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.PhoneNumberTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPhoneNumbers", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropForeignKey("dbo.CustomerPhoneNumbers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerAddresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.CustomerPhoneNumbers", new[] { "PhoneNumberTypeId" });
            DropIndex("dbo.CustomerPhoneNumbers", new[] { "CustomerId" });
            DropIndex("dbo.CustomerAddresses", new[] { "AddressTypeId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CustomerId" });
            DropTable("dbo.CustomerPhoneNumbers");
            DropTable("dbo.CustomerAddresses");
        }
    }
}
