using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 10, 12, 22, 49, 36, 487, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 10, 12, 22, 49, 36, 490, DateTimeKind.Local).AddTicks(8174));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 10, 12, 22, 41, 37, 360, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 10, 12, 22, 41, 37, 363, DateTimeKind.Local).AddTicks(8051));
        }
    }
}
