using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
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
                    table.PrimaryKey("PK_role", x => x.rol_role_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    usr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usr_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usr_email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    usr_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    usr_photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    usr_city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usr_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.usr_user_id);
                });

            migrationBuilder.CreateTable(
                name: "user_per_role",
                columns: table => new
                {
                    upr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    upr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    upr_role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_per_role", x => x.upr_id);
                    table.ForeignKey(
                        name: "FK_user_per_role_role_upr_role_id",
                        column: x => x.upr_role_id,
                        principalTable: "role",
                        principalColumn: "rol_role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_per_role_user_upr_user_id",
                        column: x => x.upr_user_id,
                        principalTable: "user",
                        principalColumn: "usr_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("08c605e8-d107-4060-8d24-67ba37ee54f1"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7622), null, "Author role", false, "Author", null },
                    { new Guid("10e85027-cd98-45e2-95bf-6945037f94ea"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7822), null, "Tester role", false, "Tester", null },
                    { new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7552), null, "User role", false, "User", null },
                    { new Guid("177b2108-513d-40b2-9275-416c1ffc4c22"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7599), null, "Moderator role", false, "Moderator", null },
                    { new Guid("1bb2b059-cd40-4142-af8e-87277cb58a87"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7814), null, "Viewer role", false, "Viewer", null },
                    { new Guid("3ccf777f-8cd7-4349-81de-ae8304cd8d50"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7806), null, "Client role", false, "Client", null },
                    { new Guid("7b48f05d-0506-4ec8-b619-657781887d58"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7629), null, "Contributor role", false, "Contributor", null },
                    { new Guid("7bc67ff8-6144-4a1b-99f7-e7ef38d5d5a0"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7482), null, "Admin role", false, "Admin", null },
                    { new Guid("82dc7223-51c3-416f-b50f-3db9653f81cf"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7592), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("97f63c8c-d5fa-4350-a27b-0d4d694dc865"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7662), null, "Customer role", false, "Customer", null },
                    { new Guid("dce9c1b7-7bb6-4947-9c6f-51cb9213a7fe"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7829), null, "Developer role", false, "Developer", null },
                    { new Guid("ebcb515b-885e-4a32-ad7d-bbbda68153e8"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7585), null, "Guest role", false, "Guest", null },
                    { new Guid("edf03f2c-f9a7-4206-aad7-602ddeda68b9"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7636), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("ef1d308c-9d9c-47ad-b7ef-3b190d1407d1"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7615), null, "Editor role", false, "Editor", null },
                    { new Guid("ef5fdad0-9acb-48c7-8ed8-96c3dbcc1132"), new DateTime(2024, 6, 7, 19, 49, 6, 505, DateTimeKind.Utc).AddTicks(7647), null, "Member role", false, "Member", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_rol_name_deleted_at",
                table: "role",
                columns: new[] { "rol_name", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_usr_email_deleted_at",
                table: "user",
                columns: new[] { "usr_email", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_usr_email_usr_password",
                table: "user",
                columns: new[] { "usr_email", "usr_password" });

            migrationBuilder.CreateIndex(
                name: "IX_user_per_role_upr_role_id",
                table: "user_per_role",
                column: "upr_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_per_role_upr_user_id_upr_role_id",
                table: "user_per_role",
                columns: new[] { "upr_user_id", "upr_role_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_per_role");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
