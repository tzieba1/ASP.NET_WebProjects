using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace movie_tracker_mvc.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSeen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 1, new DateTime(2020, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama", 9, "Good Will Hunting" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 2, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy", 6, "Austin Powers: Goldmember" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateSeen", "Genre", "Rating", "Title" },
                values: new object[] { 3, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action", 8, "Aquaman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
