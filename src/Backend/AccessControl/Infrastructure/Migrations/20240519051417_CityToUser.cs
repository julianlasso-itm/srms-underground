using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CityToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "usr_city_id",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("26e7cee5-590e-40df-9e66-f6c3d68e5745"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1350), null, "Tester role", false, "Tester", null },
                    { new Guid("28d873cc-5a6d-44f8-b6d3-ea6afd262966"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1317), null, "Editor role", false, "Editor", null },
                    { new Guid("332dfdba-ba90-4898-9424-571030b20619"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1339), null, "Customer role", false, "Customer", null },
                    { new Guid("41bac60b-a853-4a6e-b57c-1e85359fcbf8"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1335), null, "Member role", false, "Member", null },
                    { new Guid("4442aea1-1c40-4ce7-a33e-7a63853db6cf"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1308), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("52564de7-43ae-4664-9188-73b1a0992f19"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1289), null, "Admin role", false, "Admin", null },
                    { new Guid("5602ac76-01b7-4a3b-a2c3-6d6d3ec393b5"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1299), null, "User role", false, "User", null },
                    { new Guid("62ba4193-6de8-4d86-a7f8-30ac047ccc89"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1303), null, "Guest role", false, "Guest", null },
                    { new Guid("6ec56bb4-a0ba-47e1-a426-7281e67cdf3e"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1326), null, "Contributor role", false, "Contributor", null },
                    { new Guid("72775eea-49c2-48c1-a38a-a8bb39e7a434"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1343), null, "Client role", false, "Client", null },
                    { new Guid("75df4221-201f-4a44-8d05-6f5b5e891c5f"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1354), null, "Developer role", false, "Developer", null },
                    { new Guid("c4bcaeb3-7233-4e1f-aeab-ffb64cb2917e"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1312), null, "Moderator role", false, "Moderator", null },
                    { new Guid("cfc551fd-9914-4c0c-b3d5-1aa230cf631a"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1321), null, "Author role", false, "Author", null },
                    { new Guid("d7916bee-573a-490b-bf9a-e2d091160261"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1330), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("e622769c-4bf4-4a6a-b7a4-7637e8a408aa"), new DateTime(2024, 5, 19, 5, 14, 17, 88, DateTimeKind.Utc).AddTicks(1347), null, "Viewer role", false, "Viewer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("26e7cee5-590e-40df-9e66-f6c3d68e5745"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("28d873cc-5a6d-44f8-b6d3-ea6afd262966"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("332dfdba-ba90-4898-9424-571030b20619"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("41bac60b-a853-4a6e-b57c-1e85359fcbf8"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("4442aea1-1c40-4ce7-a33e-7a63853db6cf"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("52564de7-43ae-4664-9188-73b1a0992f19"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("5602ac76-01b7-4a3b-a2c3-6d6d3ec393b5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("62ba4193-6de8-4d86-a7f8-30ac047ccc89"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("6ec56bb4-a0ba-47e1-a426-7281e67cdf3e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("72775eea-49c2-48c1-a38a-a8bb39e7a434"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("75df4221-201f-4a44-8d05-6f5b5e891c5f"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("c4bcaeb3-7233-4e1f-aeab-ffb64cb2917e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("cfc551fd-9914-4c0c-b3d5-1aa230cf631a"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("d7916bee-573a-490b-bf9a-e2d091160261"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("e622769c-4bf4-4a6a-b7a4-7637e8a408aa"));

            migrationBuilder.DropColumn(
                name: "usr_city_id",
                table: "user");

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
    }
}
