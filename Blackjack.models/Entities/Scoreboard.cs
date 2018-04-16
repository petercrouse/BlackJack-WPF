using System.ComponentModel.DataAnnotations;

namespace Blackjack.models.Entities
{
    public class Scoreboard : GameEntity
    {
        public virtual GameUser Player { get; set; }
        [Required]
        public long PlayerId { get; set; }
        [Required]
        public int HighScore { get; set; }
        [Required]
        public string GameType { get; set; }
    }
}
