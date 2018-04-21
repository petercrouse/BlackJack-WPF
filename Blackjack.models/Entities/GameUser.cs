using System.ComponentModel.DataAnnotations;

namespace Blackjack.models.Entities

{
    public class GameUser : GameEntity
    {
        [Required]
        [MaxLength(25)]
        public string Alias { get; set; }

        public string Email { get; set; }
    }
}
