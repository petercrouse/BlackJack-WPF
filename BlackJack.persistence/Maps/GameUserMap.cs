namespace Game.Persistence.Maps
{
    public class GameUserMap : GameEntityMap<GameUser>
    {
        public GameUserMap(): base("GameUser")
        {
            Property(x => x.Alias).IsRequired();
            Property(x => x.Email).IsRequired();
        }
    }
}
