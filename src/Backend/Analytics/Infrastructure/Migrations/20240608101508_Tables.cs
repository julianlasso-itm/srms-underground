using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
  /// <inheritdoc />
  public partial class Tables : Migration
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
                    { new Guid("10518b06-1c9a-4318-bec3-20b689f6bc07"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6494), null, null, false, "Fullstack", null },
                    { new Guid("158dab97-0b37-4b2e-909f-e801cbfe38ab"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6519), null, null, false, "Product", null },
                    { new Guid("20d03185-6852-4e04-b474-33cbb57c5d30"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6511), null, null, false, "DataScience", null },
                    { new Guid("232ca6c8-e24d-4872-bad3-7e88d5cdd7f0"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6527), null, null, false, "Management", null },
                    { new Guid("322c1b97-4284-4f69-8602-e394f0696ae3"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6490), null, null, false, "Frontend", null },
                    { new Guid("4b378c3b-3823-45e1-a934-50475db28cd3"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6498), null, null, false, "DevOps", null },
                    { new Guid("50aaafd2-4bee-4453-8913-0336d29306f8"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6515), null, null, false, "Cybersecurity", null },
                    { new Guid("8075a7cb-c688-4c57-b205-0fda99f33c3f"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6478), null, null, false, "Backend", null },
                    { new Guid("a0a0ce05-e9ec-47d5-ad94-a6bb2de97f7f"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6501), null, null, false, "QA", null },
                    { new Guid("a663fff2-a93a-4f08-95c4-1fd113b29043"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6523), null, null, false, "Project", null },
                    { new Guid("d139f1cf-259e-4658-9dce-a7dcf2e34197"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6507), null, null, false, "UX/UI", null },
                    { new Guid("d7ffddf0-1fa6-49ca-b110-131f274471cb"), new DateTime(2024, 6, 8, 10, 15, 8, 359, DateTimeKind.Utc).AddTicks(6530), null, null, false, "Other", null }
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
