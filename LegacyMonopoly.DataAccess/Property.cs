using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegacyMonopoly.DataAccess
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyId { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        public int Position { get; set; }
        public decimal Price { get; set; }
        public decimal Rent { get; set; }

        public PropertyGroup PropertyGroup { get; set; }
        public int PropertyGroupId { get; set; }
    }
}