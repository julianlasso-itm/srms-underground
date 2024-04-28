using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Level : Migration
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
                    { new Guid("00f2acaf-a65c-4681-9b0b-6c6dab9e7391"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9441), null, null, false, "Management", null },
                    { new Guid("084d2830-bc7a-4661-898f-b6fdb637d4a4"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9416), null, null, false, "QA", null },
                    { new Guid("10059232-c12b-41e3-a496-01c3f1515d1c"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9445), null, null, false, "Other", null },
                    { new Guid("3c19c0ce-5309-4343-b732-a34feacd7fdb"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9408), null, null, false, "Fullstack", null },
                    { new Guid("5321c1c8-50f1-44ba-9b9c-4d4be3492675"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9425), null, null, false, "DataScience", null },
                    { new Guid("6857f7b0-0cb8-4f2d-b022-4dee55ce61db"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9397), null, null, false, "Backend", null },
                    { new Guid("6a680d88-c0a7-43f5-8b5c-2d9872501156"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9412), null, null, false, "DevOps", null },
                    { new Guid("75715d56-0026-4894-af50-13d71e051914"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9429), null, null, false, "Cybersecurity", null },
                    { new Guid("84d04e2a-8fbb-4524-8cff-edd1712b3e1e"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9433), null, null, false, "Product", null },
                    { new Guid("ad9e8525-55e4-468e-a433-2897d98977d7"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9404), null, null, false, "Frontend", null },
                    { new Guid("b67bd192-d78e-455f-a78d-a26829f6473a"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9437), null, null, false, "Project", null },
                    { new Guid("b6cabb2b-a19d-4d15-9bb8-1fc6a4b26901"), new DateTime(2024, 4, 28, 6, 57, 55, 307, DateTimeKind.Utc).AddTicks(9421), null, null, false, "UX/UI", null }
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
