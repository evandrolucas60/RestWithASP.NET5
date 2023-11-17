using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "person");
        }
    }
}
