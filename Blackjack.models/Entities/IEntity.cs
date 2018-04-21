using System;
using static Blackjack.models.Enumerations.EnumBag;

namespace Blackjack.models.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        Guid ReferenceId { get; set; }
        DataState DataState { get; set; }
    }
}
