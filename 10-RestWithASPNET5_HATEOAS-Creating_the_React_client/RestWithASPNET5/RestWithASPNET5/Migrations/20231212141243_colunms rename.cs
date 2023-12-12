using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class colunmsrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "books",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "books",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "books",
                newName: "launch_date");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "refresh_toke_expiry_time",
                value: new DateTime(2023, 12, 12, 11, 12, 42, 558, DateTimeKind.Local).AddTicks(1318));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "books",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "launch_date",
                table: "books",
                newName: "Date");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "refresh_toke_expiry_time",
                value: new DateTime(2023, 12, 1, 10, 2, 4, 241, DateTimeKind.Local).AddTicks(6959));
        }
    }
}
