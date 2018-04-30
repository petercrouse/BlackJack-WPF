using Game.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.System
{
    public class SystemService : ISystemService
    {
        public SystemService(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; private set; }
    }
}
