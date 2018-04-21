using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.models.Entities;

namespace BlackJack.persistence.Maps
{
    public class ScoreboardMap : GameEntityMap<Scoreboard>
    {
        public ScoreboardMap() : base("Scoreboard")
        {
            Property(x => x.HighScore).IsRequired();
            Property(x => x.GameType).IsRequired();
            HasRequired(x => x.Player);
        }
    }
}
