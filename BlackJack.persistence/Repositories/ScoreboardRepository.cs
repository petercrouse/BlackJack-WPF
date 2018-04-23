using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using static Game.Core.Enumerations.EnumBag;

namespace Game.Persistence.Repositories
{
    public class ScoreboardRepository : Repository<Scoreboard>, IRepository<Scoreboard>
    {
        public ScoreboardRepository(IDbContextFactory<GameContext> contextFactory): base(contextFactory)
        {

        }
        public void Add(Scoreboard entity)
        {
            if (entity.DataState == DataState.New)
            {
                entity.DataState = DataState.Active;
                entity.ModifiedDate = DateTimeOffset.Now;
                Context.Set<Scoreboard>().Add(entity);
            }
        }

        private GameUser ResolveGameUser(long playerId)
        {
            return Context.Set<GameUser>().First(u => u.Id == playerId);
        }
    }
}
