using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "password", "refresh_token", "refresh_toke_expiry_time" },
                values: new object[] { "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", "", new DateTime(2023, 11, 30, 15, 37, 11, 17, DateTimeKind.Local).AddTicks(8418) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "password", "refresh_token", "refresh_toke_expiry_time" },
                values: new object[] { "24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9", "h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=", new DateTime(2023, 11, 28, 14, 58, 35, 639, DateTimeKind.Local).AddTicks(3119) });
        }
    }
}
