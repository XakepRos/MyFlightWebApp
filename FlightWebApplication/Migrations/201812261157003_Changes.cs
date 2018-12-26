namespace FlightWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddFlightDatas", "DestinationName", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddFlightDatas", "DestinationName", c => c.String(maxLength: 60));
        }
    }
}
