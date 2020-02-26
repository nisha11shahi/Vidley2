namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressTypeAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressTypes", "Type", c => c.String());
            DropColumn("dbo.AddressTypes", "StreetAddress");
            DropColumn("dbo.AddressTypes", "City");
            DropColumn("dbo.AddressTypes", "State");
            DropColumn("dbo.AddressTypes", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddressTypes", "ZipCode", c => c.String());
            AddColumn("dbo.AddressTypes", "State", c => c.String());
            AddColumn("dbo.AddressTypes", "City", c => c.String());
            AddColumn("dbo.AddressTypes", "StreetAddress", c => c.String());
            DropColumn("dbo.AddressTypes", "Type");
        }
    }
}
