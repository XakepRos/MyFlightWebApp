namespace FlightWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcreated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddFlightDatas", newName: "AddFlightData");
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Test");
            RenameTable(name: "dbo.AddFlightData", newName: "AddFlightDatas");
        }
    }
}
