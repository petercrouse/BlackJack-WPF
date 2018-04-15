using System;
using System.ComponentModel.DataAnnotations;

namespace Blackjack.models.Entities
{
    public class Scoreboard
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public GameUser GameUser { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public string Game { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
