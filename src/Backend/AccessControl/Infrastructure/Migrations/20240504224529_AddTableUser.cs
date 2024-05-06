using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_role_rol_name",
                table: "role");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("015574c4-a247-49b9-9202-486ad3eb96b5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("3c5a3d78-8ec2-4174-bff0-9a6e3f819da8"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("4059eb83-ff5f-40bf-9088-16b1bb850e32"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("4b8bd85a-993b-4914-9e32-d4afb2cd33c0"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("6ce47b78-8810-433a-a33e-dd9d8cc32715"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("83b03bb0-c0ff-47b0-8b6d-aaf8c563e116"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("8516fd59-6105-4bea-9a05-ff22f0e33387"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9230e8ae-22a0-4e78-960e-d9ebcaba95a6"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("a33e1826-9660-4b45-b42d-d45a367563dd"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("b7a6dd5e-3458-4b21-a31b-1d0831447f65"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("c004777c-0ca3-4488-9f9e-c6065cc9d283"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("d3474e21-aa52-4c25-b60b-347b3e9ab3a0"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("d961ada9-ebeb-44e5-83fe-2e992903f071"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("e510b04c-ce2f-40f8-ab85-da0b5a7a214b"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("f0fe1d8c-13ec-4c31-a380-994bb3fd02c4"));

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    usr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usr_email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    usr_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
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
                    { new Guid("25fb8a38-9b31-4190-a223-355fb733285d"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9143), null, "Guest role", false, "Guest", null },
                    { new Guid("2dfb50a9-2d2d-43af-8300-e795a0edce02"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9168), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("423aa66d-6585-47a1-b8fe-cd28f51dbca3"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9151), null, "Moderator role", false, "Moderator", null },
                    { new Guid("550c7a0a-a93a-4841-88be-6eedc652b8e4"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9173), null, "Member role", false, "Member", null },
                    { new Guid("6f0c0b78-b48e-458d-be72-c941685ade15"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9185), null, "Viewer role", false, "Viewer", null },
                    { new Guid("7b049f15-50ab-42df-a7fa-b4a45bf82cbe"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9164), null, "Contributor role", false, "Contributor", null },
                    { new Guid("804d52b3-a852-4a24-bc66-a12403b316e9"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9132), null, "Admin role", false, "Admin", null },
                    { new Guid("9787f5bf-1b7f-418e-b0a9-47ad6a3b151c"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9147), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("9c559ac2-9422-4710-914f-9f15868ee08f"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9156), null, "Editor role", false, "Editor", null },
                    { new Guid("a92770ae-70bd-47ec-a0cd-e4c82843ac43"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9189), null, "Tester role", false, "Tester", null },
                    { new Guid("b935989c-bbb6-405b-b8a4-4a680e5bedfe"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9181), null, "Client role", false, "Client", null },
                    { new Guid("c4d1bef7-4f6b-47c0-a7c2-52a74b5d0178"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9138), null, "User role", false, "User", null },
                    { new Guid("cfbbc7ae-dcad-4bb2-be4a-d5bee48660e9"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9160), null, "Author role", false, "Author", null },
                    { new Guid("e1a9e7a9-5378-4d7b-9877-8b4c25dee471"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9193), null, "Developer role", false, "Developer", null },
                    { new Guid("f533c846-9f20-45cb-abab-3d809a05cdb8"), new DateTime(2024, 5, 4, 22, 45, 29, 408, DateTimeKind.Utc).AddTicks(9177), null, "Customer role", false, "Customer", null }
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
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_role_rol_name_deleted_at",
                table: "role");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("25fb8a38-9b31-4190-a223-355fb733285d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("2dfb50a9-2d2d-43af-8300-e795a0edce02"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("423aa66d-6585-47a1-b8fe-cd28f51dbca3"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("550c7a0a-a93a-4841-88be-6eedc652b8e4"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("6f0c0b78-b48e-458d-be72-c941685ade15"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("7b049f15-50ab-42df-a7fa-b4a45bf82cbe"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("804d52b3-a852-4a24-bc66-a12403b316e9"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9787f5bf-1b7f-418e-b0a9-47ad6a3b151c"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9c559ac2-9422-4710-914f-9f15868ee08f"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("a92770ae-70bd-47ec-a0cd-e4c82843ac43"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("b935989c-bbb6-405b-b8a4-4a680e5bedfe"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("c4d1bef7-4f6b-47c0-a7c2-52a74b5d0178"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("cfbbc7ae-dcad-4bb2-be4a-d5bee48660e9"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("e1a9e7a9-5378-4d7b-9877-8b4c25dee471"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("f533c846-9f20-45cb-abab-3d809a05cdb8"));

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
    }
}
