using Game.Models.Entities;
using System;
using System.Data.Entity.Infrastructure;
using static Game.Models.Enumerations.EnumBag;

namespace Game.Persistence.Repositories
{
    public class GameUserRepository : Repository<GameUser>, IRepository<GameUser>
    {
        public GameUserRepository(IDbContextFactory<GameContext> contextFactory): base(contextFactory)
        {

        }
        public void Add(GameUser entity)
        {
            if (entity.DataState == DataState.New)
            {
                entity.CreatedDate = DateTimeOffset.Now;
                entity.DataState = DataState.Active;
                Context.Set<GameUser>().Add(entity);
            }
        }
    }
}
