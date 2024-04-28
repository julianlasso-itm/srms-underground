using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_level",
                columns: table => new
                {
                    rol_level_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_level", x => x.rol_level_id);
                });

            migrationBuilder.InsertData(
                table: "tbl_level",
                columns: new[] { "rol_level_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("98ccd4bf-cd55-4dd2-968e-abdcefc77189"), new DateTime(2024, 4, 28, 2, 5, 16, 597, DateTimeKind.Utc).AddTicks(1658), null, "Admin level", false, "Admin", null },
                    { new Guid("cdd66bc0-11e0-4fa8-aa58-3668e9ff3c66"), new DateTime(2024, 4, 28, 2, 5, 16, 597, DateTimeKind.Utc).AddTicks(1665), null, "User level", false, "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_level_rol_name_deleted_at",
                table: "tbl_level",
                columns: new[] { "rol_name", "deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_level");
        }
    }
}
