using Blackjack.models.Entities;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace BlackJack.persistence
{
    public interface IDbContext
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : GameEntity;
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : GameEntity;
    }
}
