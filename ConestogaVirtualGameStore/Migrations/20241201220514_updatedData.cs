using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class updatedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Review_ID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_Game_ID",
                table: "Reviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "Game_ID", "Member_ID" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 16, 15, 39, 774, DateTimeKind.Local).AddTicks(513));
        }
    }
}
