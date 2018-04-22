using System;
using static Game.Core.Enumerations.EnumBag;

namespace Game.Core.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        Guid ReferenceId { get; set; }
        DataState DataState { get; set; }
    }
}
