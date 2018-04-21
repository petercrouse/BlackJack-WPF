using Blackjack.models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence.Maps
{
    public abstract class GameEntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : GameEntity
    {
        public GameEntityMap(string tableName)
        {
            ToTable(tableName);
            HasKey(x => x.Id);
            Property(x => x.ReferenceId).IsRequired();
            Property(x => x.DataState).IsRequired();
            Property(x => x.CreatedDate).IsRequired();
            Property(x => x.ModifiedDate).IsOptional();
        }
    }
}
