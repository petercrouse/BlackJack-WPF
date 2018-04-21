﻿using Blackjack.models.Entities;
using Blackjack.models.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.persistence.Migrations.Configuration
{
    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<GameContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameContext context)
        {
            DummyDataSeed(context);
        }

        private void DummyDataSeed(GameContext context)
        {
            if (!context.Set<GameUser>().ToList().Any())
            {
                GameUser dummyUser = new GameUser
                {
                    Alias = "BoomStraat21",
                    Email = "pacrouse@gmail.com",
                    DataState = EnumBag.DataState.Active
                };
                context.Set<GameUser>().Add(dummyUser);

                context.Set<Scoreboard>().Add(new Scoreboard
                {
                    PlayerId = dummyUser.Id,
                    GameType = "Blackjack",
                    HighScore = 10,
                    DataState = EnumBag.DataState.Active
                });

                context.SaveChanges();
            }
        }
    }
}
