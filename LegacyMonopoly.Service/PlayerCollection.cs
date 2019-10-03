using LegacyMonopoly.DataAccess;
using System.Collections.Generic;

namespace LegacyMonopoly.Service
{
    public class PlayerCollection
    {
        public IEnumerable<PlayerRepresentation> Players { get; }
            = new List<PlayerRepresentation>();
    }
}