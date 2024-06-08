using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "level",
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
                    table.PrimaryKey("PK_level", x => x.rol_level_id);
                });

            migrationBuilder.InsertData(
                table: "level",
                columns: new[] { "rol_level_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("018de1d9-0878-44bf-b501-7205e4f0dd99"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1975), null, null, false, "DevOps", null },
                    { new Guid("01dfef2e-e845-4df0-9d0f-e54345f105b7"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1977), null, null, false, "QA", null },
                    { new Guid("34c611ee-9b16-495e-8d80-ee86f3db2419"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1983), null, null, false, "DataScience", null },
                    { new Guid("66a57db7-6ba5-45cb-886f-8012b0efa63d"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1981), null, null, false, "UX/UI", null },
                    { new Guid("a8586256-6348-4a2b-8903-05bac522f34b"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1990), null, null, false, "Project", null },
                    { new Guid("bde87b01-bba2-4c67-aea8-b811729f423d"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1962), null, null, false, "Frontend", null },
                    { new Guid("c6b7431b-4d1c-4a16-b345-48bcdffd4c73"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1964), null, null, false, "Fullstack", null },
                    { new Guid("c6b8d32e-e333-4107-93e4-1b44299cb60b"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1995), null, null, false, "Other", null },
                    { new Guid("d0839f4f-6351-4dac-adb1-fbbcd25f414b"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1956), null, null, false, "Backend", null },
                    { new Guid("d573949b-d77e-4872-91e1-2041e7c796f7"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1985), null, null, false, "Cybersecurity", null },
                    { new Guid("d61b04d4-4ad4-40b3-9bf7-604e3926c323"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1987), null, null, false, "Product", null },
                    { new Guid("e305b62b-fbb4-42d4-b6ca-0dbae64aa674"), new DateTime(2024, 6, 8, 7, 32, 1, 892, DateTimeKind.Utc).AddTicks(1992), null, null, false, "Management", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_level_rol_name",
                table: "level",
                column: "rol_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "level");
        }
    }
}
