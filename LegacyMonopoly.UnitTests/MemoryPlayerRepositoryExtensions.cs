using LegacyMonopoly.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegacyMonopoly.UnitTests
{
    public static class MemoryPlayerRepositoryExtensions
    {
        public static MonopolyContext WithGame(
            this MonopolyContext context,
            int gameId)
        {
            context.Games.Add(new Game { GameId = gameId });
            context.SaveChanges();
            return context;
        }

        public static MonopolyContext WithGameHavingPlayers(
            this MonopolyContext context,
            int gameId,
            params string[] playerNames)
        {
            context.Games.Add(new Game
            {
                GameId = gameId,
                Players = playerNames
                    .Select(n => new Player { Name = n })
                    .ToList()
            });
            context.SaveChanges();
            return context;
        }
    }
}
