using Game.Core.Entities;

namespace Game.Persistence.Maps
{
    public class ScoreboardMap : GameEntityMap<Scoreboard>
    {
        public ScoreboardMap() : base("Scoreboard")
        {
            Property(x => x.HighScore).IsRequired();
            Property(x => x.GameName).IsRequired();
            HasRequired(x => x.Player);
        }
    }
}
