using System;
using System.Collections.Generic;
using System.Text;
using LegacyMonopoly.DataAccess;

namespace LegacyMonopoly.Repository
{
    public interface IPlayerRepository
    {
        Game GetGameById(int gameId);
    }
}
