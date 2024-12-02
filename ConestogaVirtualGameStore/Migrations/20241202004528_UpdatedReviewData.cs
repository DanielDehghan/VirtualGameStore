using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReviewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3,
                column: "Register_Date",
                value: new DateTime(2024, 12, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4,
                column: "Register_Date",
                value: new DateTime(2023, 12, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5,
                column: "Register_Date",
                value: new DateTime(2024, 11, 16, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6,
                column: "Register_Date",
                value: new DateTime(2024, 3, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7,
                column: "Register_Date",
                value: new DateTime(2024, 8, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8,
                column: "Register_Date",
                value: new DateTime(2022, 12, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9,
                column: "Register_Date",
                value: new DateTime(2024, 7, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10,
                column: "Register_Date",
                value: new DateTime(2024, 10, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11,
                column: "Register_Date",
                value: new DateTime(2024, 2, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12,
                column: "Register_Date",
                value: new DateTime(2024, 5, 1, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 13,
                column: "Register_Date",
                value: new DateTime(2024, 11, 6, 19, 45, 27, 436, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Review_ID", "GameId", "Game_ID", "Member_ID", "ReviewDescription", "ReviewRating", "ReviewTitle", "Status" },
                values: new object[,]
                {
                    { 1, null, 1, 1, "One of the best games I have ever played! would recommend!", "5", "This game is great!", null },
                    { 2, null, 2, 2, "I liked the previous games more", "2", "Its alright", null },
                    { 3, null, 3, 2, "I hope the next game is as good as this one!", "4", "Very good!!", null },
                    { 4, null, 4, 3, "They put a lot of effort into this game, this is a must buy", "5", "Great game!", null },
                    { 5, null, 5, 4, "Please add the previous games on this site", "1", "Not my favourite", null },
                    { 6, null, 6, 2, "I liked the previous games more", "2", "Its alright", null },
                    { 7, null, 7, 5, "Please add the previous games on this site", "1", "Not my favourite", null },
                    { 8, null, 8, 6, "I hope the next game is as good as this one!", "4", "Very good!!", null },
                    { 9, null, 9, 7, "They put a lot of effort into this game, this is a must buy", "5", "Great game!", null },
                    { 10, null, 10, 1, "One of the best games I have ever played! would recommend!", "5", "This game is great!", null },
                    { 11, null, 11, 8, "Please add the previous games on this site", "1", "Not my favourite", null },
                    { 12, null, 12, 8, "I hope the next game is as good as this one!", "4", "Very good!!", null },
                    { 13, null, 13, 9, "They put a lot of effort into this game, this is a must buy", "5", "Great game!", null },
                    { 14, null, 14, 10, "I hope the next game is as good as this one!", "4", "Very good!!", null },
                    { 15, null, 15, 11, "Please add the previous games on this site", "1", "Not my favourite", null },
                    { 16, null, 16, 1, "One of the best games I have ever played! would recommend!", "5", "This game is great!", null },
                    { 17, null, 17, 8, "They put a lot of effort into this game, this is a must buy", "5", "Great game!", null },
                    { 18, null, 18, 5, "Please add the previous games on this site", "1", "Not my favourite", null },
                    { 19, null, 19, 2, "I liked the previous games more", "2", "Its alright", null },
                    { 20, null, 20, 6, "I hope the next game is as good as this one!", "4", "Very good!!", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Review_ID",
                keyValue: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
