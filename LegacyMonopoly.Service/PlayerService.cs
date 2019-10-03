using LegacyMonopoly.DataAccess;
using System;
using System.Linq;

namespace LegacyMonopoly.Service
{
    public class PlayerService
    {
        private readonly MonopolyContext context;

        public PlayerService(MonopolyContext context)
        {
            this.context = context;
        }

        public PlayerCollection LoadPlayers(int gameId)
        {
            var game = context.Games
                .Where(g => g.GameId == gameId)
                .SingleOrDefault();
            if (game == null)
            {
                return null;
            }
            else
            {
                return new PlayerCollection();
            }
        }
    }
}
