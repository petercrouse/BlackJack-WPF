namespace BlackJack.persistence.Migrations.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Alias = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        ReferenceId = c.Guid(nullable: false),
                        DataState = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scoreboard",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlayerId = c.Long(nullable: false),
                        HighScore = c.Int(nullable: false),
                        GameType = c.String(nullable: false),
                        ReferenceId = c.Guid(nullable: false),
                        DataState = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameUser", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scoreboard", "PlayerId", "dbo.GameUser");
            DropIndex("dbo.Scoreboard", new[] { "PlayerId" });
            DropTable("dbo.Scoreboard");
            DropTable("dbo.GameUser");
        }
    }
}
