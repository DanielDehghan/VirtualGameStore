using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class AddEventRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 11, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 11, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 11, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 11, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 12, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 2, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 7, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 11, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 6, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 9, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 1, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 4, 27, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 2, 14, 52, 58, 39, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.CreateIndex(
                name: "IX_MembersEvents_Event_ID",
                table: "MembersEvents",
                column: "Event_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersEvents_Member_ID",
                table: "MembersEvents",
                column: "Member_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersEvents_Events_Event_ID",
                table: "MembersEvents",
                column: "Event_ID",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersEvents_Members_Member_ID",
                table: "MembersEvents",
                column: "Member_ID",
                principalTable: "Members",
                principalColumn: "Member_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersEvents_Events_Event_ID",
                table: "MembersEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersEvents_Members_Member_ID",
                table: "MembersEvents");

            migrationBuilder.DropIndex(
                name: "IX_MembersEvents_Event_ID",
                table: "MembersEvents");

            migrationBuilder.DropIndex(
                name: "IX_MembersEvents_Member_ID",
                table: "MembersEvents");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 11, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 11, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 11, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 11, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 10, 27, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 2, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 7, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 11, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 6, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 9, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 1, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 4, 11, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 10, 17, 18, 4, 26, 947, DateTimeKind.Local).AddTicks(6562));
        }
    }
}
