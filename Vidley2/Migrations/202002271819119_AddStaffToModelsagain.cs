namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffToModelsagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(),
                        PhoneNumberTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        StreetAddress = c.String(),
                        AddressTypeId = c.Int(nullable: false),
                        EmergencyContactName = c.String(),
                        EmergencyContactAddress = c.String(),
                        EmergencyContactPhone = c.String(),
                        EmergencyContactRelationship = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumberTypes", t => t.PhoneNumberTypeId, cascadeDelete: true)
                .Index(t => t.PhoneNumberTypeId)
                .Index(t => t.AddressTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropForeignKey("dbo.Staffs", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.Staffs", new[] { "AddressTypeId" });
            DropIndex("dbo.Staffs", new[] { "PhoneNumberTypeId" });
            DropTable("dbo.Staffs");
        }
    }
}
