using LegacyMonopoly.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegacyMonopoly.IntegrationTests
{
    public static class MemoryPlayerRepositoryExtensions
    {
        public static MonopolyContext WithGame(
            this MonopolyContext context,
            out int gameId)
        {
            var game = new Game();
            context.Games.Add(game);
            context.SaveChanges();
            gameId = game.GameId;   
            return context;
        }

        public static MonopolyContext WithGameHavingPlayers(
            this MonopolyContext context,
            out int gameId,
            params string[] playerNames)
        {
            var game = new Game
            {
                Players = playerNames
                    .Select(n => new Player { Name = n })
                    .ToList()
            };
            context.Games.Add(game);
            context.SaveChanges();
            gameId = game.GameId;
            return context;
        }
    }
}
