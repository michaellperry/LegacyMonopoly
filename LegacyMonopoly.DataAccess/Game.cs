using System.Collections.Generic;

namespace LegacyMonopoly.DataAccess
{
    public class Game
    {
        public int GameId { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}