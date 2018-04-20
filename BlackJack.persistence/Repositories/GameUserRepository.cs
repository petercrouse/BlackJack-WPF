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
    public class GameUserRepository : Repository<GameUser>, IRepository<GameUser>
    {
        public GameUserRepository(IDbContextFactory<GameContext> contextFactory): base(contextFactory)
        {

        }
        public void Add(GameUser entity)
        {
            if (entity.DataState == EnumBag.DataState.New)
            {
                entity.ModifiedDate = DateTimeOffset.Now;
                entity.DataState = EnumBag.DataState.Active;
                Context.Set<GameUser>().Add(entity);
            }
        }
    }
}
