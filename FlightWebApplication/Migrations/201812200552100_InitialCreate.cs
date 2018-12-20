namespace FlightWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddFlightDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlightNumber = c.Int(nullable: false),
                        DestinationName = c.String(maxLength: 60),
                        FlightDistance = c.Int(nullable: false),
                        FlightPrice = c.Int(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddFlightDatas");
        }
    }
}
