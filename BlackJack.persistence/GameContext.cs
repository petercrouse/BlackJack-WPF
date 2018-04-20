using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blackjack.models.Entities;

namespace BlackJack.persistence
{
    public class GameContext : DbContext, IDbContext
    {
        public GameContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GameContext>());
            Database.SetInitializer<GameContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : GameEntity
        {
            return base.Entry(entity);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : GameEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
