using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegacyMonopoly.DataAccess
{
    public class PropertyGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyGroupId { get; set; }
        [StringLength(20)]
        public string Color { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();
    }
}