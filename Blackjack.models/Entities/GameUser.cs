using System.ComponentModel.DataAnnotations;

namespace Game.Core.Entities

{
    public class GameUser : GameEntity
    {
        [Required]
        [MaxLength(25)]
        public string Alias { get; set; }

        public string Email { get; set; }
    }
}
