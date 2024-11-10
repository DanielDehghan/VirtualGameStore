using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConestogaVirtualGameStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Relationship_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relationship_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Relationship_ID);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Wishlist_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wishlist_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Member_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Wishlist_ID);
                    table.ForeignKey(
                        name: "FK_Wishlist_Members_Member_ID",
                        column: x => x.Member_ID,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersRelationships",
                columns: table => new
                {
                    MemberRelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Relationship_ID = table.Column<int>(type: "int", nullable: false),
                    MemberAdded_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersRelationships", x => x.MemberRelationshipId);
                    table.ForeignKey(
                        name: "FK_MembersRelationships_Members_MemberAdded_ID",
                        column: x => x.MemberAdded_ID,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembersRelationships_Members_Member_ID",
                        column: x => x.Member_ID,
                        principalTable: "Members",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembersRelationships_Relationships_Relationship_ID",
                        column: x => x.Relationship_ID,
                        principalTable: "Relationships",
                        principalColumn: "Relationship_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist_Games",
                columns: table => new
                {
                    Wishlist_ID = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist_Games", x => new { x.Wishlist_ID, x.GameId });
                    table.ForeignKey(
                        name: "FK_Wishlist_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_Games_Wishlist_Wishlist_ID",
                        column: x => x.Wishlist_ID,
                        principalTable: "Wishlist",
                        principalColumn: "Wishlist_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Member_ID", "Address", "Cart_ID", "City", "Country", "Email", "FirstName", "Language_ID", "LastName", "Password", "Phone_Number", "Postal_Code", "Province", "Register_Date" },
                values: new object[,]
                {
                    { 3, "123 Maple St", null, "New York", "USA", "amelia.hawke@example.com", "Amelia", null, "Hawke", "password123", "555-1234", "10001", "NY", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3464) },
                    { 4, "456 Oak St", null, "Vancouver", "Canada", "leo.montgomery@example.com", "Leo", null, "Montgomery", "password234", "555-2345", "V6B 3A2", "BC", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3466) },
                    { 5, "789 Pine St", null, "London", "UK", "clara.fitzgerald@example.com", "Clara", null, "Fitzgerald", "password345", "555-3456", "EC1A 1BB", "England", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3469) },
                    { 6, "101 Birch St", null, "Los Angeles", "USA", "ethan.rivers@example.com", "Ethan", null, "Rivers", "password456", "555-4567", "90001", "CA", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3472) },
                    { 7, "202 Cedar St", null, "Sydney", "Australia", "sofia.langford@example.com", "Sofia", null, "Langford", "password567", "555-5678", "2000", "NSW", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3474) },
                    { 8, "303 Willow St", null, "Chicago", "USA", "jackson.mercer@example.com", "Jackson", null, "Mercer", "password678", "555-6789", "60601", "IL", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3477) },
                    { 9, "404 Elm St", null, "Montreal", "Canada", "ava.kensington@example.com", "Ava", null, "Kensington", "password789", "555-7890", "H3B 2A7", "QC", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3480) },
                    { 10, "505 Pine St", null, "Manchester", "UK", "oliver.stanton@example.com", "Oliver", null, "Stanton", "password890", "555-8901", "M1 1AE", "England", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3483) },
                    { 11, "606 Oak St", null, "Melbourne", "Australia", "isabella.drake@example.com", "Isabella", null, "Drake", "password901", "555-9012", "3000", "VIC", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3552) },
                    { 12, "707 Maple St", null, "San Francisco", "USA", "mason.carlisle@example.com", "Mason", null, "Carlisle", "password012", "555-0123", "94101", "CA", new DateTime(2024, 11, 9, 18, 12, 48, 248, DateTimeKind.Local).AddTicks(3556) }
                });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Relationship_ID", "Relationship_Type" },
                values: new object[,]
                {
                    { 1, "Friend" },
                    { 2, "Family" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembersRelationships_Member_ID",
                table: "MembersRelationships",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRelationships_MemberAdded_ID",
                table: "MembersRelationships",
                column: "MemberAdded_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersRelationships_Relationship_ID",
                table: "MembersRelationships",
                column: "Relationship_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Member_ID",
                table: "Wishlist",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Games_GameId",
                table: "Wishlist_Games",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembersRelationships");

            migrationBuilder.DropTable(
                name: "Wishlist_Games");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 1,
                column: "Register_Date",
                value: new DateTime(2024, 11, 8, 4, 36, 32, 461, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_ID",
                keyValue: 2,
                column: "Register_Date",
                value: new DateTime(2024, 11, 8, 4, 36, 32, 461, DateTimeKind.Local).AddTicks(6216));
        }
    }
}
