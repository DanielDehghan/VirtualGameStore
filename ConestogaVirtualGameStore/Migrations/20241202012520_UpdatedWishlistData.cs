using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedWishlistData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "CartGames",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                columns: new[] { "PreferredCategory", "Register_Date" },
                values: new object[] { "Action", new DateTime(2024, 12, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 20, 25, 19, 639, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "Wishlist_ID", "Member_ID", "Wishlist_Name" },
                values: new object[,]
                {
                    { 1, 1, "Wishlist 1" },
                    { 2, 1, "Wishlist 2" },
                    { 3, 2, "Wishlist 3" },
                    { 4, 3, "Wishlist 4" },
                    { 5, 3, "Wishlist 5" },
                    { 6, 4, "Wishlist 6" },
                    { 7, 5, "Wishlist 7" },
                    { 8, 6, "Wishlist 8" },
                    { 9, 7, "Wishlist 9" },
                    { 10, 8, "Wishlist 10" },
                    { 11, 9, "Wishlist 11" },
                    { 12, 10, "Wishlist 12" },
                    { 13, 11, "Wishlist 13" },
                    { 14, 12, "Wishlist 14" },
                    { 15, 13, "Wishlist 15" },
                    { 16, 13, "Wishlist 16" }
                });

            migrationBuilder.InsertData(
                table: "Wishlist_Games",
                columns: new[] { "GameId", "Wishlist_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 4 },
                    { 10, 4 },
                    { 11, 5 },
                    { 12, 5 },
                    { 13, 5 },
                    { 14, 6 },
                    { 15, 6 },
                    { 16, 7 },
                    { 17, 7 },
                    { 18, 7 },
                    { 19, 8 },
                    { 20, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 3, 10 },
                    { 4, 10 },
                    { 5, 11 },
                    { 6, 11 },
                    { 7, 12 },
                    { 8, 12 },
                    { 9, 13 },
                    { 10, 13 },
                    { 11, 14 },
                    { 12, 14 },
                    { 13, 15 },
                    { 14, 16 },
                    { 15, 16 },
                    { 16, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 19, 8 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 11, 14 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 12, 14 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 14, 16 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 15, 16 });

            migrationBuilder.DeleteData(
                table: "Wishlist_Games",
                keyColumns: new[] { "GameId", "Wishlist_ID" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Wishlist",
                keyColumn: "Wishlist_ID",
                keyValue: 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "CartGames",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                columns: new[] { "PreferredCategory", "Register_Date" },
                values: new object[] { "Shooter", new DateTime(2024, 12, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(1985) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 19, 50, 9, 14, DateTimeKind.Local).AddTicks(2065));
        }
    }
}
