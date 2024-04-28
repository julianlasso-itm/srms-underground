using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.rol_role_id);
                });

            migrationBuilder.InsertData(
                table: "tbl_role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("3d73c744-161a-4dc9-99c6-02011f269ac5"), new DateTime(2024, 4, 28, 5, 42, 0, 821, DateTimeKind.Utc).AddTicks(1880), null, "Admin role", false, "Admin", null },
                    { new Guid("824538cd-f415-4149-8871-88ddc779f596"), new DateTime(2024, 4, 28, 5, 42, 0, 821, DateTimeKind.Utc).AddTicks(1887), null, "User role", false, "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_name_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_name", "deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_role");
        }
    }
}
