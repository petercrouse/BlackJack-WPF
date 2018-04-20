using Blackjack.models.Entities;
using Blackjack.models.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence.Repositories
{
    public class ScoreboardRepository : Repository<Scoreboard>, IRepository<Scoreboard>
    {
        public ScoreboardRepository(IDbContextFactory<GameContext> contextFactory): base(contextFactory)
        {

        }
        public void Add(Scoreboard entity)
        {
            if (entity.DataState == EnumBag.DataState.New)
            {
                entity.DataState = EnumBag.DataState.Active;
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
