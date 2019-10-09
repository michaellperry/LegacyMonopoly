using LegacyMonopoly.DataAccess;
using Microsoft.EntityFrameworkCore;
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
                .Include(g => g.Players)
                .Where(g => g.GameId == gameId)
                .SingleOrDefault();
            if (game == null)
            {
                return null;
            }
            else
            {
                return new PlayerCollection
                {
                    Players = game.Players.Select(p => new PlayerRepresentation
                    {
                        Name = p.Name
                    }).ToList()
                };
            }
        }
    }
}
