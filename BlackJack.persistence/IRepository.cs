using Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Game.Persistence
{
    public interface IRepository<TEntity> where TEntity : GameEntity
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity, bool softDelete = true);
        void Save();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> FindByNoTracking(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
    }
}
