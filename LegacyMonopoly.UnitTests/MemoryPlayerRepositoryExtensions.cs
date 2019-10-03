using LegacyMonopoly.DataAccess;
using LegacyMonopoly.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegacyMonopoly.UnitTests
{
    public static class MemoryPlayerRepositoryExtensions
    {
        public static MemoryPlayerRepository WithGame(
            this MemoryPlayerRepository repository,
            int gameId)
        {
            repository.AddGame(new Game { GameId = gameId });
            return repository;
        }

        public static MemoryPlayerRepository WithGameHavingPlayers(
            this MemoryPlayerRepository repository,
            int gameId,
            params string[] playerNames)
        {
            repository.AddGame(new Game
            {
                GameId = gameId,
                Players = playerNames
                    .Select(n => new Player { Name = n })
                    .ToList()
            });
            return repository;
        }
    }
}
