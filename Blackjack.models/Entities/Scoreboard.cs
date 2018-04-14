using System;

namespace Blackjack.models.Entities
{
    public class Scoreboard
    {
        public string Alias { get; set; }
        public int Score { get; set; }
        public string Game { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
