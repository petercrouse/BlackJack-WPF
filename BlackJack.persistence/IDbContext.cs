using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Game.Core.Entities;

namespace Game.Persistence
{
    public interface IDbContext
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : GameEntity;
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : GameEntity;
    }
}
