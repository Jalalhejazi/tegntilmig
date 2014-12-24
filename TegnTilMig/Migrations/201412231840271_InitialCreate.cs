namespace TegnTilMig.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drawings",
                c => new
                    {
                        DrawingID = c.Int(nullable: false, identity: true),
                        DrawingString = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DrawingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drawings");
        }
    }
}
