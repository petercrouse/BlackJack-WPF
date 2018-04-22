using Blackjack.models.Entities;
using System.Data.Entity.Migrations;
using System.Linq;
using static Blackjack.models.Enumerations.EnumBag;

namespace BlackJack.persistence.Migrations.Configuration
{
    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<GameContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameContext context)
        {
            DummyDataSeed(context);
        }

        private void DummyDataSeed(GameContext context)
        {
            if (!context.Set<GameUser>().ToList().Any())
            {
                GameUser dummyUser = new GameUser
                {
                    Alias = "BoomStraat21",
                    Email = "pacrouse@gmail.com",
                    DataState = DataState.Active
                };
                context.Set<GameUser>().Add(dummyUser);

                context.Set<Scoreboard>().Add(new Scoreboard
                {
                    PlayerId = dummyUser.Id,
                    GameName = GameName.Blackjack,
                    HighScore = 10,
                    DataState = DataState.Active
                });

                context.SaveChanges();
            }
        }
    }
}
