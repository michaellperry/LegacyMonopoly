using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyMonopoly.DataAccess
{
    public class GameRepository
    {
        private MonopolyContext context;

        public GameRepository(MonopolyContext context)
        {
            this.context = context;
        }

        public List<Game> LoadAllGames()
        {
            return context.Games.ToList();
        }
    }
}