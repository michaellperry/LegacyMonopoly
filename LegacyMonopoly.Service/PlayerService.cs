using LegacyMonopoly.DataAccess;
using LegacyMonopoly.Repository;
using System;

namespace LegacyMonopoly.Service
{
    public class PlayerService
    {
        private readonly IPlayerRepository repository;

        public PlayerService(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public PlayerCollection LoadPlayers(int gameId)
        {
            var game = repository.GetGameById(gameId);
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
