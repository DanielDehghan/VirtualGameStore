using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class MemberEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 10, 27, 17, 46, 46, 743, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 10, 27, 17, 46, 46, 743, DateTimeKind.Local).AddTicks(9202));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 10, 27, 17, 45, 50, 136, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 10, 27, 17, 45, 50, 136, DateTimeKind.Local).AddTicks(5876));
        }
    }
}
