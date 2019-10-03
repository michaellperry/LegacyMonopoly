using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegacyMonopoly.Models
{
    public class DeedRepresentation
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Rent { get; set; }
        public int Position { get; set; }
    }
}
