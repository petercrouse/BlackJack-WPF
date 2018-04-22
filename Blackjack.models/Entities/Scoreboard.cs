using System.ComponentModel.DataAnnotations;
using static Game.Core.Enumerations.EnumBag;

namespace Game.Core.Entities
{
    public class Scoreboard : GameEntity
    {
        public virtual GameUser Player { get; set; }
        [Required]
        public long PlayerId { get; set; }
        [Required]
        public int HighScore { get; set; }
        [Required]
        public GameName GameName { get; set; }
    }
}
