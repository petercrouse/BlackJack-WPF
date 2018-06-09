using System;
using System.ComponentModel.DataAnnotations;
using static Game.Models.Enumerations.EnumBag;

namespace Game.Models.Entities
{
    public class GameEntity : IEntity
    {
        public GameEntity()
        {
            ReferenceId = Guid.NewGuid();
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
