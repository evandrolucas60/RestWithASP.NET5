using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class _V1_API_Person_adding_Enabled_column_values_set_to_true : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 1L,
                column: "enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 2L,
                column: "enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 3L,
                column: "enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 4L,
                column: "enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 5L,
                column: "enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "refresh_toke_expiry_time",
                value: new DateTime(2023, 12, 1, 10, 2, 4, 241, DateTimeKind.Local).AddTicks(6959));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 1L,
                column: "enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 2L,
                column: "enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 3L,
                column: "enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 4L,
                column: "enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "id",
                keyValue: 5L,
                column: "enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "refresh_toke_expiry_time",
                value: new DateTime(2023, 12, 1, 9, 58, 36, 447, DateTimeKind.Local).AddTicks(3521));
        }
    }
}
