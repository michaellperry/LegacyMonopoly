using Microsoft.EntityFrameworkCore.Migrations;

namespace LegacyMonopoly.DataAccess.Migrations
{
    public partial class AddedPropertyGroupsAndProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyGroups",
                columns: table => new
                {
                    PropertyGroupId = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyGroups", x => x.PropertyGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Rent = table.Column<decimal>(nullable: false),
                    PropertyGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyGroups_PropertyGroupId",
                        column: x => x.PropertyGroupId,
                        principalTable: "PropertyGroups",
                        principalColumn: "PropertyGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PropertyGroups",
                columns: new[] { "PropertyGroupId", "Color" },
                values: new object[,]
                {
                    { 1, "Purple" },
                    { 2, "Light Green" },
                    { 3, "Violet" },
                    { 4, "Orange" },
                    { 5, "Red" },
                    { 6, "Yellow" },
                    { 7, "Dark Green" },
                    { 8, "Dark Blue" },
                    { 9, "Utilities" },
                    { 10, "Railroads" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "Name", "Position", "Price", "PropertyGroupId", "Rent" },
                values: new object[,]
                {
                    { 1, "Mediterranean Ave.", 2, 60m, 1, 2m },
                    { 26, "Pennsylvania Railroad", 16, 200m, 10, 25m },
                    { 25, "Reading Railroad", 6, 200m, 10, 25m },
                    { 24, "Water Works", 29, 150m, 9, 0m },
                    { 23, "Electric Company", 13, 150m, 9, 0m },
                    { 22, "Boardwalk", 40, 400m, 8, 50m },
                    { 21, "Park Place", 38, 350m, 8, 35m },
                    { 20, "Pennsylvania Ave.", 35, 320m, 7, 28m },
                    { 19, "North Carolina Ave.", 33, 300m, 7, 26m },
                    { 18, "Pacific Ave.", 32, 300m, 7, 26m },
                    { 17, "Marvin Gardens", 30, 280m, 6, 24m },
                    { 16, "Ventor Ave.", 28, 260m, 6, 22m },
                    { 15, "Atlantic Ave.", 27, 260m, 6, 22m },
                    { 14, "Illinois Ave.", 25, 240m, 5, 20m },
                    { 13, "Indiana Ave.", 24, 220m, 5, 18m },
                    { 12, "Kentucky Ave.", 22, 220m, 5, 18m },
                    { 11, "New York Ave.", 20, 200m, 4, 16m },
                    { 10, "Tennessee Ave.", 19, 180m, 4, 14m },
                    { 9, "St. James Place", 17, 180m, 4, 14m },
                    { 8, "Virginia Ave.", 15, 160m, 3, 12m },
                    { 7, "States Ave.", 14, 140m, 3, 10m },
                    { 6, "St. Charles Place", 12, 140m, 3, 10m },
                    { 5, "Connecticut Ave.", 10, 120m, 2, 8m },
                    { 4, "Vermont Ave.", 9, 100m, 2, 6m },
                    { 3, "Oriental Ave.", 7, 100m, 2, 6m },
                    { 2, "Baltic Ave.", 4, 60m, 1, 4m },
                    { 27, "B. & O. Railroad", 26, 200m, 10, 25m },
                    { 28, "Short Line Railroad", 36, 200m, 10, 25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyGroupId",
                table: "Properties",
                column: "PropertyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyGroups");
        }
    }
}
