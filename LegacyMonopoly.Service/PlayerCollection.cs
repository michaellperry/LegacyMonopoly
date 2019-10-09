using LegacyMonopoly.DataAccess;
using System.Collections.Generic;

namespace LegacyMonopoly.Service
{
    public class PlayerCollection
    {
        public List<PlayerRepresentation> Players { get; set; }
            = new List<PlayerRepresentation>();
    }
}