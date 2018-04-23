using System.Data.Entity.ModelConfiguration;

namespace Game.Persistence.Maps
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
