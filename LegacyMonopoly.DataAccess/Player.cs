using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegacyMonopoly.DataAccess
{
    public class Player
    {
        public int PlayerId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public decimal Money { get; set; }

        public Game Game { get; set; }
        public int GameId { get; set; }

        public List<Deed> Deeds { get; set; } = new List<Deed>();
    }
}