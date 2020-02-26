namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberIdToCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PhoneNumberType_Id", "dbo.PhoneNumberTypes");
            DropIndex("dbo.Customers", new[] { "PhoneNumberType_Id" });
            RenameColumn(table: "dbo.Customers", name: "PhoneNumberType_Id", newName: "PhoneNumberTypeId");
            AlterColumn("dbo.Customers", "PhoneNumberTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PhoneNumberTypeId");
            AddForeignKey("dbo.Customers", "PhoneNumberTypeId", "dbo.PhoneNumberTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PhoneNumberTypeId", "dbo.PhoneNumberTypes");
            DropIndex("dbo.Customers", new[] { "PhoneNumberTypeId" });
            AlterColumn("dbo.Customers", "PhoneNumberTypeId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "PhoneNumberTypeId", newName: "PhoneNumberType_Id");
            CreateIndex("dbo.Customers", "PhoneNumberType_Id");
            AddForeignKey("dbo.Customers", "PhoneNumberType_Id", "dbo.PhoneNumberTypes", "Id");
        }
    }
}
