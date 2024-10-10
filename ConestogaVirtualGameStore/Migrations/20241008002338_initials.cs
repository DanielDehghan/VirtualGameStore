using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "CoverImageURL", "Description", "Genere", "Platform", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "https://image.api.playstation.com/vulcan/ap/rnd/202208/1718/NFf86jgU4AeVYgJBEoEKBpxW.jpg", "An action RPG set in a historical setting, featuring stealth and combat elements.", "Action RPG", "PlayStation 5, Xbox Series X/S, PC", 59.99m, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin's Creed Mirage" },
                    { 2, "https://cdn2.steamgriddb.com/grid/3c8907c9dc26266603441dcb03dbe620.png", "The latest installment in the Call of Duty series, offering intense first-person shooter action.", "First-Person Shooter", "PlayStation 5, Xbox Series X/S, PC", 69.99m, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call of Duty MW3" },
                    { 3, "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg", "A futuristic open-world RPG set in the dystopian Night City, filled with cybernetic enhancements and complex narratives.", "Action RPG", "PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, PC", 39.99m, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { 4, "https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/4xJ8XB3bi888QTLZYdl7Oi0s.png", "An epic sequel to the critically acclaimed God of War, featuring Norse mythology and Kratos' journey.", "Action-Adventure", "PlayStation 4, PlayStation 5", 69.99m, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of War Ragnarok" },
                    { 5, "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg", "A modern remake of the classic survival horror game, offering updated graphics and gameplay mechanics.", "Survival Horror", "PlayStation 4, PlayStation 5, Xbox Series X/S, PC", 59.99m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil 4 Remake" },
                    { 6, "https://image.api.playstation.com/vulcan/ap/rnd/202312/0117/315718bce7eed62e3cf3fb02d61b81ff1782d6b6cf850fa4.png", "A narrative-driven action-adventure game that continues the story of Ellie and Joel in a post-apocalyptic world.", "Action-Adventure", "PlayStation 4", 59.99m, new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Last of Us: Part 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
