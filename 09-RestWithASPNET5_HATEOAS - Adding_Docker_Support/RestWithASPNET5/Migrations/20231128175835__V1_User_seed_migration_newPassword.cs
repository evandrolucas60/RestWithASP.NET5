using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    /// <inheritdoc />
    public partial class _V1_User_seed_migration_newPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "password", "refresh_toke_expiry_time", "user_name" },
                values: new object[] { "24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9", new DateTime(2023, 11, 28, 14, 58, 35, 639, DateTimeKind.Local).AddTicks(3119), "evandro" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "password", "refresh_toke_expiry_time", "user_name" },
                values: new object[] { "6f403cce6bb38bd0a424f416cc7250372dd3977d6f4740cd1db4ab569400a8ac", new DateTime(2023, 11, 28, 14, 50, 18, 896, DateTimeKind.Local).AddTicks(7264), "Evandro" });
        }
    }
}
