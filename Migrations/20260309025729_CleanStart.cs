using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThePleasantOcc.Migrations
{
    /// <inheritdoc />
    public partial class CleanStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBeds = table.Column<int>(type: "int", nullable: false),
                    OccupiedBeds = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "OccupiedBeds", "Price", "Residence", "RoomNumber", "RoomType", "Size", "TotalBeds" },
                values: new object[,]
                {
                    { 1, 1, 0, 3500m, "single", "101", "Single", "20m²", 1 },
                    { 2, 1, 0, 3500m, "single", "102", "Single", "20m²", 1 },
                    { 3, 1, 0, 3500m, "single", "103", "Single", "20m²", 1 },
                    { 4, 1, 0, 3500m, "single", "104", "Single", "20m²", 1 },
                    { 5, 2, 0, 3500m, "single", "201", "Single", "20m²", 1 },
                    { 6, 2, 0, 3500m, "single", "202", "Single", "20m²", 1 },
                    { 7, 2, 0, 3500m, "single", "203", "Single", "20m²", 1 },
                    { 8, 2, 0, 3500m, "single", "204", "Single", "20m²", 1 },
                    { 9, 1, 0, 2800m, "double", "101", "Double", "28m²", 2 },
                    { 10, 1, 0, 2800m, "double", "102", "Double", "28m²", 2 },
                    { 11, 1, 0, 2800m, "double", "103", "Double", "28m²", 2 },
                    { 12, 1, 0, 2800m, "double", "104", "Double", "28m²", 2 },
                    { 13, 1, 0, 2200m, "triple", "101", "Triple", "35m²", 3 },
                    { 14, 1, 0, 2200m, "triple", "102", "Triple", "35m²", 3 },
                    { 15, 1, 0, 2200m, "triple", "103", "Triple", "35m²", 3 },
                    { 16, 1, 0, 2200m, "triple", "104", "Triple", "35m²", 3 },
                    { 17, 1, 0, 3500m, "mix", "101", "Single", "20m²", 1 },
                    { 18, 1, 0, 2800m, "mix", "102", "Double", "28m²", 2 },
                    { 19, 1, 0, 2200m, "mix", "103", "Triple", "35m²", 3 },
                    { 20, 1, 0, 3500m, "mix", "104", "Single", "20m²", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
