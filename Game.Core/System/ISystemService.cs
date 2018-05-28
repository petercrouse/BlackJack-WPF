using Game.Core.Services.GameUserService;
using Game.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.System
{
    public interface ISystemService
    {
        ILogger Logger { get; }
        IGameUserService GameUserService { get; }
    }
}
