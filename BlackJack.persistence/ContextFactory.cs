using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence
{
    public class ContextFactory : IDbContextFactory<GameContext>
    {
        public GameContext Create()
        {
            return new GameContext();
        }
    }
}
