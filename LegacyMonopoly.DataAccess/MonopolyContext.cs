using Microsoft.EntityFrameworkCore;
using System;

namespace LegacyMonopoly.DataAccess
{
    public class MonopolyContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PropertyGroup> PropertyGroups { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Deed> Deeds { get; set; }

        public MonopolyContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var purple = pg(1, "Purple");
            var lightGreen = pg(2, "Light Green");
            var violet = pg(3, "Violet");
            var orange = pg(4, "Orange");
            var red = pg(5, "Red");
            var yellow = pg(6, "Yellow");
            var darkGreen = pg(7, "Dark Green");
            var darkBlue = pg(8, "Dark Blue");
            var utilities = pg(9, "Utilities");
            var railroads = pg(10, "Railroads");

            modelBuilder.Entity<PropertyGroup>().HasData(
                purple,
                lightGreen,
                violet,
                orange,
                red,
                yellow,
                darkGreen,
                darkBlue,
                utilities,
                railroads
            );

            modelBuilder.Entity<Property>().HasData(
                p(1, purple, "Mediterranean Ave.", 2, 60, 2),
                p(2, purple, "Baltic Ave.", 4, 60, 4),
                p(3, lightGreen, "Oriental Ave.", 7, 100, 6),
                p(4, lightGreen, "Vermont Ave.", 9, 100, 6),
                p(5, lightGreen, "Connecticut Ave.", 10, 120, 8),
                p(6, violet, "St. Charles Place", 12, 140, 10),
                p(7, violet, "States Ave.", 14, 140, 10),
                p(8, violet, "Virginia Ave.", 15, 160, 12),
                p(9, orange, "St. James Place", 17, 180, 14),
                p(10, orange, "Tennessee Ave.", 19, 180, 14),
                p(11, orange, "New York Ave.", 20, 200, 16),
                p(12, red, "Kentucky Ave.", 22, 220, 18),
                p(13, red, "Indiana Ave.", 24, 220, 18),
                p(14, red, "Illinois Ave.", 25, 240, 20),
                p(15, yellow, "Atlantic Ave.", 27, 260, 22),
                p(16, yellow, "Ventor Ave.", 28, 260, 22),
                p(17, yellow, "Marvin Gardens", 30, 280, 24),
                p(18, darkGreen, "Pacific Ave.", 32, 300, 26),
                p(19, darkGreen, "North Carolina Ave.", 33, 300, 26),
                p(20, darkGreen, "Pennsylvania Ave.", 35, 320, 28),
                p(21, darkBlue, "Park Place", 38, 350, 35),
                p(22, darkBlue, "Boardwalk", 40, 400, 50),
                p(23, utilities, "Electric Company", 13, 150, 0),
                p(24, utilities, "Water Works", 29, 150, 0),
                p(25, railroads, "Reading Railroad", 6, 200, 25),
                p(26, railroads, "Pennsylvania Railroad", 16, 200, 25),
                p(27, railroads, "B. & O. Railroad", 26, 200, 25),
                p(28, railroads, "Short Line Railroad", 36, 200, 25)
            );

            modelBuilder.Entity<Player>()
                .Property(e => e.Money)
                .HasDefaultValue(1500m);
        }

        private static PropertyGroup pg(int id, string color)
        {
            return new PropertyGroup
            {
                PropertyGroupId = id,
                Color = color
            };
        }

        private static Property p(int id, PropertyGroup propertyGroup,
            string name, int position, decimal price, decimal rent)
        {
            return new Property
            {
                PropertyId = id,
                Name = name,
                Position = position,
                Price = price,
                Rent = rent,
                PropertyGroupId = propertyGroup.PropertyGroupId
            };
        }
    }
}
