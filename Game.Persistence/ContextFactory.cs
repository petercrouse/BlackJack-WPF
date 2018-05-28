using System.Data.Entity.Infrastructure;

namespace Game.Persistence
{
    public class ContextFactory : IDbContextFactory<GameContext>
    {
        public GameContext Create()
        {
            return new GameContext();
        }
    }
}
