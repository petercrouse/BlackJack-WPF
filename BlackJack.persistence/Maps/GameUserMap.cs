using Blackjack.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence.Maps
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
