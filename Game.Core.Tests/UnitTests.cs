using System;
using Game.Models.Entities;
using Game.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Core.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestInitialize]
        public void Initialize(IRepository<GameUser> userRepository, IRepository<Scoreboard> scoreboardRepository)
        {
            IRepository<GameUser> _userRepository = userRepository;
            IRepository<Scoreboard> _scoreboardRepository = scoreboardRepository;
        }

        [TestMethod]
        public void CreateUser_Success()
        {

        }
    }
}
