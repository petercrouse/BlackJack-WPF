using Blackjack.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence
{
    public interface IRepository<TEntity> where TEntity : GameEntity
    {
        void Add(TEntity);
        void Edit(Guid referenceId);
        TEntity Get(Guid referenceId);

    }
}
