namespace FlightWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datatypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddFlightDatas", "FlightPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AddFlightDatas", "DiscountPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddFlightDatas", "DiscountPercentage", c => c.Int(nullable: false));
            AlterColumn("dbo.AddFlightDatas", "FlightPrice", c => c.Int(nullable: false));
        }
    }
}
