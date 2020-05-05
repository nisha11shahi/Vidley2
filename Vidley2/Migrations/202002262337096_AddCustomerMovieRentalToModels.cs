namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerMovieRentalToModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMovieRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Checkin = c.DateTime(nullable: false),
                        Checkout = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerMovieRentals", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CustomerMovieRentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerMovieRentals", new[] { "MovieId" });
            DropIndex("dbo.CustomerMovieRentals", new[] { "CustomerId" });
            DropTable("dbo.CustomerMovieRentals");
        }
    }
}
