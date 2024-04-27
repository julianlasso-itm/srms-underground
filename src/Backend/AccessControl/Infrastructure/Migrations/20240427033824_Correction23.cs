using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("7981d92c-ced8-448f-b545-7fda62b414b8"), new DateTime(2024, 4, 27, 3, 38, 24, 754, DateTimeKind.Utc).AddTicks(2441), null, "Admin role", false, "Admin", null },
                    { new Guid("e1c3192a-0268-4f5c-9baf-0f8c46bb6dd7"), new DateTime(2024, 4, 27, 3, 38, 24, 754, DateTimeKind.Utc).AddTicks(2447), null, "User role", false, "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("7981d92c-ced8-448f-b545-7fda62b414b8"));

            migrationBuilder.DeleteData(
                table: "tbl_role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("e1c3192a-0268-4f5c-9baf-0f8c46bb6dd7"));
        }
    }
}
