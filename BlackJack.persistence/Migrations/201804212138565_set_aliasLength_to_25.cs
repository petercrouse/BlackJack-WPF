namespace Game.Persistence.Migrations.Configuration
{
    using System.Data.Entity.Migrations;

    public partial class set_aliasLength_to_25 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameUser", "Alias", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameUser", "Alias", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
