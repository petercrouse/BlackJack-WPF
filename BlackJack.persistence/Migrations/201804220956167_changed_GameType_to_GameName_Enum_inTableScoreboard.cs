namespace BlackJack.persistence.Migrations.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_GameType_to_GameName_Enum_inTableScoreboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scoreboard", "GameName", c => c.Int(nullable: false));
            DropColumn("dbo.Scoreboard", "GameType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scoreboard", "GameType", c => c.String(nullable: false));
            DropColumn("dbo.Scoreboard", "GameName");
        }
    }
}
