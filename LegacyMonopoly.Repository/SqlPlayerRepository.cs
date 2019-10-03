using LegacyMonopoly.DataAccess;
using System;

namespace LegacyMonopoly.Repository
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private MonopolyContext context;

        public SqlPlayerRepository(MonopolyContext context)
        {
            this.context = context;
        }

        public Game GetGameById(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
