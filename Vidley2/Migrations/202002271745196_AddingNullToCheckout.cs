namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNullToCheckout : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerMovieRentals", "Checkout", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerMovieRentals", "Checkout", c => c.DateTime(nullable: false));
        }
    }
}
