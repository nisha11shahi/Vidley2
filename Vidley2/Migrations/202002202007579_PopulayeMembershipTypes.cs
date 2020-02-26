namespace Vidley2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulayeMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, Type, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 'Pay as you go', 0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, Type, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 'Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes(Id, Type, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 'Quarterly', 90, 3,20)");
            Sql("INSERT INTO MembershipTypes(Id, Type, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 'Yearly', 100,12,30)");
        }
        
        public override void Down()
        {
        }
    }
}
