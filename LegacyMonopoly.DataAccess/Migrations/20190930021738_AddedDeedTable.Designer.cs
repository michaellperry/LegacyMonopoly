﻿// <auto-generated />
using LegacyMonopoly.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LegacyMonopoly.DataAccess.Migrations
{
    [DbContext(typeof(MonopolyContext))]
    [Migration("20190930021738_AddedDeedTable")]
    partial class AddedDeedTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Deed", b =>
                {
                    b.Property<int>("DeedId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.Property<int>("PropertyId");

                    b.HasKey("DeedId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Deeds");
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<decimal>("Money")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1500m);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("PlayerId");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Property", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<string>("Name")
                        .HasMaxLength(40);

                    b.Property<int>("Position");

                    b.Property<decimal>("Price");

                    b.Property<int>("PropertyGroupId");

                    b.Property<decimal>("Rent");

                    b.HasKey("PropertyId");

                    b.HasIndex("PropertyGroupId");

                    b.ToTable("Properties");

                    b.HasData(
                        new { PropertyId = 1, Name = "Mediterranean Ave.", Position = 2, Price = 60m, PropertyGroupId = 1, Rent = 2m },
                        new { PropertyId = 2, Name = "Baltic Ave.", Position = 4, Price = 60m, PropertyGroupId = 1, Rent = 4m },
                        new { PropertyId = 3, Name = "Oriental Ave.", Position = 7, Price = 100m, PropertyGroupId = 2, Rent = 6m },
                        new { PropertyId = 4, Name = "Vermont Ave.", Position = 9, Price = 100m, PropertyGroupId = 2, Rent = 6m },
                        new { PropertyId = 5, Name = "Connecticut Ave.", Position = 10, Price = 120m, PropertyGroupId = 2, Rent = 8m },
                        new { PropertyId = 6, Name = "St. Charles Place", Position = 12, Price = 140m, PropertyGroupId = 3, Rent = 10m },
                        new { PropertyId = 7, Name = "States Ave.", Position = 14, Price = 140m, PropertyGroupId = 3, Rent = 10m },
                        new { PropertyId = 8, Name = "Virginia Ave.", Position = 15, Price = 160m, PropertyGroupId = 3, Rent = 12m },
                        new { PropertyId = 9, Name = "St. James Place", Position = 17, Price = 180m, PropertyGroupId = 4, Rent = 14m },
                        new { PropertyId = 10, Name = "Tennessee Ave.", Position = 19, Price = 180m, PropertyGroupId = 4, Rent = 14m },
                        new { PropertyId = 11, Name = "New York Ave.", Position = 20, Price = 200m, PropertyGroupId = 4, Rent = 16m },
                        new { PropertyId = 12, Name = "Kentucky Ave.", Position = 22, Price = 220m, PropertyGroupId = 5, Rent = 18m },
                        new { PropertyId = 13, Name = "Indiana Ave.", Position = 24, Price = 220m, PropertyGroupId = 5, Rent = 18m },
                        new { PropertyId = 14, Name = "Illinois Ave.", Position = 25, Price = 240m, PropertyGroupId = 5, Rent = 20m },
                        new { PropertyId = 15, Name = "Atlantic Ave.", Position = 27, Price = 260m, PropertyGroupId = 6, Rent = 22m },
                        new { PropertyId = 16, Name = "Ventor Ave.", Position = 28, Price = 260m, PropertyGroupId = 6, Rent = 22m },
                        new { PropertyId = 17, Name = "Marvin Gardens", Position = 30, Price = 280m, PropertyGroupId = 6, Rent = 24m },
                        new { PropertyId = 18, Name = "Pacific Ave.", Position = 32, Price = 300m, PropertyGroupId = 7, Rent = 26m },
                        new { PropertyId = 19, Name = "North Carolina Ave.", Position = 33, Price = 300m, PropertyGroupId = 7, Rent = 26m },
                        new { PropertyId = 20, Name = "Pennsylvania Ave.", Position = 35, Price = 320m, PropertyGroupId = 7, Rent = 28m },
                        new { PropertyId = 21, Name = "Park Place", Position = 38, Price = 350m, PropertyGroupId = 8, Rent = 35m },
                        new { PropertyId = 22, Name = "Boardwalk", Position = 40, Price = 400m, PropertyGroupId = 8, Rent = 50m },
                        new { PropertyId = 23, Name = "Electric Company", Position = 13, Price = 150m, PropertyGroupId = 9, Rent = 0m },
                        new { PropertyId = 24, Name = "Water Works", Position = 29, Price = 150m, PropertyGroupId = 9, Rent = 0m },
                        new { PropertyId = 25, Name = "Reading Railroad", Position = 6, Price = 200m, PropertyGroupId = 10, Rent = 25m },
                        new { PropertyId = 26, Name = "Pennsylvania Railroad", Position = 16, Price = 200m, PropertyGroupId = 10, Rent = 25m },
                        new { PropertyId = 27, Name = "B. & O. Railroad", Position = 26, Price = 200m, PropertyGroupId = 10, Rent = 25m },
                        new { PropertyId = 28, Name = "Short Line Railroad", Position = 36, Price = 200m, PropertyGroupId = 10, Rent = 25m }
                    );
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.PropertyGroup", b =>
                {
                    b.Property<int>("PropertyGroupId");

                    b.Property<string>("Color")
                        .HasMaxLength(20);

                    b.HasKey("PropertyGroupId");

                    b.ToTable("PropertyGroups");

                    b.HasData(
                        new { PropertyGroupId = 1, Color = "Purple" },
                        new { PropertyGroupId = 2, Color = "Light Green" },
                        new { PropertyGroupId = 3, Color = "Violet" },
                        new { PropertyGroupId = 4, Color = "Orange" },
                        new { PropertyGroupId = 5, Color = "Red" },
                        new { PropertyGroupId = 6, Color = "Yellow" },
                        new { PropertyGroupId = 7, Color = "Dark Green" },
                        new { PropertyGroupId = 8, Color = "Dark Blue" },
                        new { PropertyGroupId = 9, Color = "Utilities" },
                        new { PropertyGroupId = 10, Color = "Railroads" }
                    );
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Deed", b =>
                {
                    b.HasOne("ExeterMonopoly.DataAccess.Player", "Player")
                        .WithMany("Deeds")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExeterMonopoly.DataAccess.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Player", b =>
                {
                    b.HasOne("ExeterMonopoly.DataAccess.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExeterMonopoly.DataAccess.Property", b =>
                {
                    b.HasOne("ExeterMonopoly.DataAccess.PropertyGroup", "PropertyGroup")
                        .WithMany("Properties")
                        .HasForeignKey("PropertyGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
