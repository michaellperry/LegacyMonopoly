using System.Collections.Generic;

namespace LegacyMonopoly.Models
{
    public class PlayerRepresentation
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string HrefDeeds { get; set; }
        public List<DeedRepresentation> Deeds { get; set; } = new List<DeedRepresentation>();
    }
}