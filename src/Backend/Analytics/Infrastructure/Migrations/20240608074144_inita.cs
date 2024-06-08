using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("018de1d9-0878-44bf-b501-7205e4f0dd99"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("01dfef2e-e845-4df0-9d0f-e54345f105b7"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("34c611ee-9b16-495e-8d80-ee86f3db2419"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("66a57db7-6ba5-45cb-886f-8012b0efa63d"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("a8586256-6348-4a2b-8903-05bac522f34b"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("bde87b01-bba2-4c67-aea8-b811729f423d"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("c6b7431b-4d1c-4a16-b345-48bcdffd4c73"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("c6b8d32e-e333-4107-93e4-1b44299cb60b"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("d0839f4f-6351-4dac-adb1-fbbcd25f414b"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("d573949b-d77e-4872-91e1-2041e7c796f7"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("d61b04d4-4ad4-40b3-9bf7-604e3926c323"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("e305b62b-fbb4-42d4-b6ca-0dbae64aa674"));

            migrationBuilder.InsertData(
                table: "level",
                columns: new[] { "rol_level_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0008ff53-9070-4e0f-a512-2cf5567d16db"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5206), null, null, false, "Cybersecurity", null },
                    { new Guid("2200279d-7d10-4f03-85c2-87e2d23d990b"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5210), null, null, false, "Project", null },
                    { new Guid("521ed0db-f80f-4b79-9f80-d2c78b2c0a53"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5212), null, null, false, "Management", null },
                    { new Guid("5d1414f4-3699-4143-b9b8-13801e6118d6"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5191), null, null, false, "QA", null },
                    { new Guid("6bed3a66-867f-4880-8cf1-9deb3cfa913d"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5154), null, null, false, "DevOps", null },
                    { new Guid("a0612b52-bb9c-4ea6-be02-2b8965339a08"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5144), null, null, false, "Backend", null },
                    { new Guid("a0c52685-662a-4722-adea-0fb65f2cbf64"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5152), null, null, false, "Fullstack", null },
                    { new Guid("a3f6bbfe-6db8-42fe-8013-01b90d484cef"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5196), null, null, false, "UX/UI", null },
                    { new Guid("ae7b127e-4074-4e90-8f70-d0a036fa4134"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5150), null, null, false, "Frontend", null },
                    { new Guid("c88c745d-0dbb-4c1f-9060-d59c880d05c6"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5208), null, null, false, "Product", null },
                    { new Guid("dcea93f0-f262-4148-8d8c-94de0cadeb2b"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5197), null, null, false, "DataScience", null },
                    { new Guid("de00513e-1d7d-47d6-943f-56511636d4c4"), new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5214), null, null, false, "Other", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("0008ff53-9070-4e0f-a512-2cf5567d16db"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("2200279d-7d10-4f03-85c2-87e2d23d990b"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("521ed0db-f80f-4b79-9f80-d2c78b2c0a53"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("5d1414f4-3699-4143-b9b8-13801e6118d6"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("6bed3a66-867f-4880-8cf1-9deb3cfa913d"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("a0612b52-bb9c-4ea6-be02-2b8965339a08"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("a0c52685-662a-4722-adea-0fb65f2cbf64"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("a3f6bbfe-6db8-42fe-8013-01b90d484cef"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("ae7b127e-4074-4e90-8f70-d0a036fa4134"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("c88c745d-0dbb-4c1f-9060-d59c880d05c6"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("dcea93f0-f262-4148-8d8c-94de0cadeb2b"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("de00513e-1d7d-47d6-943f-56511636d4c4"));

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
        }
    }
}
