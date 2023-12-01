using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class _V1_User_seed_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "full_name", "password", "refresh_token", "refresh_toke_expiry_time", "user_name" },
                values: new object[] { 1L, "Evandro Lucas da Silva", "fc8252c8dc55839967c58b9ad755a59b61b67c13227ddae4bd3f78a38bf394f7", "h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=", new DateTime(2023, 11, 28, 14, 29, 50, 249, DateTimeKind.Local).AddTicks(1920), "Evandro" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
