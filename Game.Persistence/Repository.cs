using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using static Game.Models.Enumerations.EnumBag;

namespace Game.Persistence
{
    public class Repository<TEntity> : IDisposable where TEntity : GameEntity
    {
        public Repository(IDbContextFactory<GameContext> contextFactory)
        {
            _contextFactory = contextFactory;
            Context = Context ?? contextFactory.Create();
        }

        private IDbContextFactory<GameContext> _contextFactory;
        private bool _disposed;
        protected GameContext Context { get; set; }


        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.ModifiedDate = DateTimeOffset.Now;
                entity.DataState = DataState.Deleted;
            }
            else
            {
                Context.Set<TEntity>().Remove(entity);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public virtual void Edit(TEntity entity)
        {
            if(entity.DataState == DataState.Active)
            {
                entity.ModifiedDate = DateTimeOffset.Now;
            }
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Context.Set<TEntity>().Where(predicate) as IQueryable<TEntity>;
            query = includes.Aggregate(query, (current, property) => current.Include(property));
            return query.ToList();
        }

        public IEnumerable<TEntity> FindByNoTracking(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Context.Set<TEntity>().Where(predicate) as IQueryable<TEntity>;
            query = includes.Aggregate(query, (current, property) => current.Include(property)).AsNoTracking();
            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Context.Set<TEntity>() as IQueryable<TEntity>;
            query = includes.Aggregate(query, (current, property) => current.Include(property));
            return query.ToList(); //read only
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
