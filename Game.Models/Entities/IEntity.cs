using System;
using static Game.Models.Enumerations.EnumBag;

namespace Game.Models.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        Guid ReferenceId { get; set; }
        DataState DataState { get; set; }
    }
}
