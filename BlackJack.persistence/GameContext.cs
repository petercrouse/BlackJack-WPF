using Game.Core.Entities;
using Game.Persistence.Maps;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Game.Persistence
{
    public class GameContext : DbContext, IDbContext
    {
        public GameContext() : base("name=gamedb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GameContext>());
            Database.SetInitializer<GameContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
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
            modelBuilder.Configurations.Add(new GameUserMap());
            modelBuilder.Configurations.Add(new ScoreboardMap());
        }
    }
}
