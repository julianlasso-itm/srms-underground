using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
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

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("015574c4-a247-49b9-9202-486ad3eb96b5"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3206), null, "Contributor role", false, "Contributor", null },
                    { new Guid("3c5a3d78-8ec2-4174-bff0-9a6e3f819da8"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3227), null, "Viewer role", false, "Viewer", null },
                    { new Guid("4059eb83-ff5f-40bf-9088-16b1bb850e32"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3185), null, "Guest role", false, "Guest", null },
                    { new Guid("4b8bd85a-993b-4914-9e32-d4afb2cd33c0"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3230), null, "Tester role", false, "Tester", null },
                    { new Guid("6ce47b78-8810-433a-a33e-dd9d8cc32715"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3193), null, "Moderator role", false, "Moderator", null },
                    { new Guid("83b03bb0-c0ff-47b0-8b6d-aaf8c563e116"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3189), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("8516fd59-6105-4bea-9a05-ff22f0e33387"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3234), null, "Developer role", false, "Developer", null },
                    { new Guid("9230e8ae-22a0-4e78-960e-d9ebcaba95a6"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3218), null, "Customer role", false, "Customer", null },
                    { new Guid("a33e1826-9660-4b45-b42d-d45a367563dd"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3214), null, "Member role", false, "Member", null },
                    { new Guid("b7a6dd5e-3458-4b21-a31b-1d0831447f65"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3175), null, "Admin role", false, "Admin", null },
                    { new Guid("c004777c-0ca3-4488-9f9e-c6065cc9d283"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3198), null, "Editor role", false, "Editor", null },
                    { new Guid("d3474e21-aa52-4c25-b60b-347b3e9ab3a0"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3202), null, "Author role", false, "Author", null },
                    { new Guid("d961ada9-ebeb-44e5-83fe-2e992903f071"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3209), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("e510b04c-ce2f-40f8-ab85-da0b5a7a214b"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3181), null, "User role", false, "User", null },
                    { new Guid("f0fe1d8c-13ec-4c31-a380-994bb3fd02c4"), new DateTime(2024, 4, 28, 5, 55, 38, 267, DateTimeKind.Utc).AddTicks(3222), null, "Client role", false, "Client", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_rol_name",
                table: "role",
                column: "rol_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
