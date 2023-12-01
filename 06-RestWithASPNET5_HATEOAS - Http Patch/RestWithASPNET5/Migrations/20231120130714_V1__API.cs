using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class V1__API : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Date", "Price", "Title" },
                values: new object[,]
                {
                    { 1L, "Stephen King", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.799999999999997, "IT" },
                    { 2L, "Stephen Hawking", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.89, "A Brief time history" },
                    { 3L, "Connan Arthur Doyle", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.72999999999999, "Sherlock Holme - The Baskerville Dog" },
                    { 4L, "Edgar Alan Poe", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.340000000000003, "The Crow" },
                    { 5L, "Agatha Christie", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.560000000000002, "A Haunting in Vinice" },
                    { 6L, "Agatha Christie", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.620000000000005, "A Haunting in Vinice" },
                    { 7L, "JJ Tolkien", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.32, "The Hobbit" },
                    { 8L, "Tom Clancy's", new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.759999999999998, "Spliter Cell" }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "address", "first_name", "gender", "last_name" },
                values: new object[,]
                {
                    { 1L, "Recife", "Evandro", "Male", "Lucas" },
                    { 2L, "Jaboatão", "Jamerson", "Male", "Lucas" },
                    { 3L, "Petrolina", "Danielly", "Femele", "Oliveira" },
                    { 4L, "Juazeiro", "Lucinea", "Femele", "Lucas" },
                    { 5L, "Recife", "Bruno", "male", "Lucas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
