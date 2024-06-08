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
                    { new Guid("097d0797-b3ba-4672-ad26-5685244ca4a3"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3860), null, "Author role", false, "Author", null },
                    { new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3846), null, "User role", false, "User", null },
                    { new Guid("474fdb3d-f817-4299-a687-3dafa81f107e"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3858), null, "Editor role", false, "Editor", null },
                    { new Guid("5789a37a-0be9-4ccf-960a-83bf73ec2a12"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3851), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("940c829a-a560-4013-ad8c-ecee553cd5f0"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3891), null, "Developer role", false, "Developer", null },
                    { new Guid("96aa59d2-5055-4832-ab6c-77f53f8705a5"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3876), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("98ce4a72-867d-4f30-b2d8-6ae7e86487eb"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3849), null, "Guest role", false, "Guest", null },
                    { new Guid("9b6b4ebd-03a0-4d5a-99df-02118a0c8ac4"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3853), null, "Moderator role", false, "Moderator", null },
                    { new Guid("a667d7fd-a528-4d8e-a119-50791deb5ce5"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3884), null, "Client role", false, "Client", null },
                    { new Guid("ab6c9842-5517-488c-9e27-b19563c814a9"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3886), null, "Viewer role", false, "Viewer", null },
                    { new Guid("b22f31c5-54fa-433a-8c87-530eaad0374d"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3882), null, "Customer role", false, "Customer", null },
                    { new Guid("b71a5d7f-b1bc-46d6-9ab0-3ae224e154f1"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3821), null, "Admin role", false, "Admin", null },
                    { new Guid("b87e9821-5f92-421d-a032-32db1eb92294"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3874), null, "Contributor role", false, "Contributor", null },
                    { new Guid("bff78836-e9dc-474e-aec5-ba7b60e26165"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3880), null, "Member role", false, "Member", null },
                    { new Guid("d3be8aea-9f7a-4d52-9e0b-9311e3af0e5f"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3889), null, "Tester role", false, "Tester", null }
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
