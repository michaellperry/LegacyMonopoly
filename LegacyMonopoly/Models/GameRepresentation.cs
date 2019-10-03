using System.Collections.Generic;

namespace LegacyMonopoly.Models
{
    public class GameRepresentation
    {
        public List<PlayerRepresentation> Players { get; set; } = new List<PlayerRepresentation>();
    }
}