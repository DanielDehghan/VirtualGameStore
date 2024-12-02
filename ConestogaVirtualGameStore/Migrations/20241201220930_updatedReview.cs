using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class updatedReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Games_Game_ID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_Game_ID",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 17, 9, 30, 240, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Games_GameId",
                table: "Reviews",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Games_GameId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 17, 5, 13, 923, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Game_ID",
                table: "Reviews",
                column: "Game_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Games_Game_ID",
                table: "Reviews",
                column: "Game_ID",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
