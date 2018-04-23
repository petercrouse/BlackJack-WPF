using System;

namespace Game.Models.Entities
{
    public class GameEntity : IEntity
    {
        public GameEntity()
        {
            ReferenceId = new Guid();
            DataState = DataState.New;
            CreatedDate = DateTimeOffset.Now;
        }

        [Required]
        public long Id { get; set; }

        [Required]
        public Guid ReferenceId { get; set; }

        [Required]
        public DataState DataState { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
