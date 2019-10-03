using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LegacyMonopoly.DataAccess;

namespace LegacyMonopoly.Repository
{
    public class MemoryPlayerRepository : IPlayerRepository
    {
        private List<Game> games = new List<Game>();

        public void AddGame(Game game)
        {
            games.Add(game);
        }

        public Game GetGameById(int gameId)
        {
            return games
                .Where(g => g.GameId == gameId)
                .SingleOrDefault();
        }
    }
}
