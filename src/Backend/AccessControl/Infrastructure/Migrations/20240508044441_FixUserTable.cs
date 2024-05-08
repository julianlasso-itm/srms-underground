using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "usr_name",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usr_photo",
                table: "user",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2232), null, "User role", false, "User", null },
                    { new Guid("1933240c-c76c-4c5a-9772-d3bdbde9b72c"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2226), null, "Admin role", false, "Admin", null },
                    { new Guid("22eef1fd-c4d5-4802-bf56-8d9b68beb659"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2241), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("2df4d5ba-940b-40f0-ac17-7b0217ec4417"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2271), null, "Customer role", false, "Customer", null },
                    { new Guid("39828fe2-634d-4e15-970d-892edfbf4d99"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2287), null, "Developer role", false, "Developer", null },
                    { new Guid("3f5ee3d4-b800-415f-87b5-c13484192806"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2258), null, "Contributor role", false, "Contributor", null },
                    { new Guid("40cde1ee-f690-48ce-bf5b-450976178258"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2262), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("44243581-3a22-4902-8604-37b6d39a2f42"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2275), null, "Client role", false, "Client", null },
                    { new Guid("4e032af9-f029-402a-96ea-b425b3079a2f"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2267), null, "Member role", false, "Member", null },
                    { new Guid("5a93c3a1-c1cb-4c3f-b339-4c9c3472dc2c"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2254), null, "Author role", false, "Author", null },
                    { new Guid("5dc96435-b54d-4c31-bada-9ca912819855"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2236), null, "Guest role", false, "Guest", null },
                    { new Guid("62014bb1-1cd9-44e6-8903-f8e27dd17458"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2283), null, "Tester role", false, "Tester", null },
                    { new Guid("7fa1a171-626f-4f4f-845c-583eeaaa4e66"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2245), null, "Moderator role", false, "Moderator", null },
                    { new Guid("ceafeaa6-0c28-43d4-80e1-4735f71fd75c"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2279), null, "Viewer role", false, "Viewer", null },
                    { new Guid("eb1676ef-5e69-4458-965f-d4abf5d18eb3"), new DateTime(2024, 5, 8, 4, 44, 41, 317, DateTimeKind.Utc).AddTicks(2250), null, "Editor role", false, "Editor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("1933240c-c76c-4c5a-9772-d3bdbde9b72c"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("22eef1fd-c4d5-4802-bf56-8d9b68beb659"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("2df4d5ba-940b-40f0-ac17-7b0217ec4417"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("39828fe2-634d-4e15-970d-892edfbf4d99"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("3f5ee3d4-b800-415f-87b5-c13484192806"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("40cde1ee-f690-48ce-bf5b-450976178258"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("44243581-3a22-4902-8604-37b6d39a2f42"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("4e032af9-f029-402a-96ea-b425b3079a2f"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("5a93c3a1-c1cb-4c3f-b339-4c9c3472dc2c"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("5dc96435-b54d-4c31-bada-9ca912819855"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("62014bb1-1cd9-44e6-8903-f8e27dd17458"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("7fa1a171-626f-4f4f-845c-583eeaaa4e66"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("ceafeaa6-0c28-43d4-80e1-4735f71fd75c"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("eb1676ef-5e69-4458-965f-d4abf5d18eb3"));

            migrationBuilder.DropColumn(
                name: "usr_name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "usr_photo",
                table: "user");

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
        }
    }
}
