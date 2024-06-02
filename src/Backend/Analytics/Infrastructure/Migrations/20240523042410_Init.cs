using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("00f2acaf-a65c-4681-9b0b-6c6dab9e7391"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("084d2830-bc7a-4661-898f-b6fdb637d4a4"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("10059232-c12b-41e3-a496-01c3f1515d1c"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("3c19c0ce-5309-4343-b732-a34feacd7fdb"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("5321c1c8-50f1-44ba-9b9c-4d4be3492675"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("6857f7b0-0cb8-4f2d-b022-4dee55ce61db"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("6a680d88-c0a7-43f5-8b5c-2d9872501156"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("75715d56-0026-4894-af50-13d71e051914"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("84d04e2a-8fbb-4524-8cff-edd1712b3e1e"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("ad9e8525-55e4-468e-a433-2897d98977d7"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("b67bd192-d78e-455f-a78d-a26829f6473a"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("b6cabb2b-a19d-4d15-9bb8-1fc6a4b26901"));

            migrationBuilder.InsertData(
                table: "level",
                columns: new[] { "rol_level_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0cf40f54-d68b-4072-bef1-1d30a619991e"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3634), null, null, false, "QA", null },
                    { new Guid("202cfa47-189e-482d-9a63-6cad414687ef"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3639), null, null, false, "UX/UI", null },
                    { new Guid("2625b027-05bf-4cef-b1cf-99cae799aa31"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3650), null, null, false, "Product", null },
                    { new Guid("5b935487-4ef9-4641-9ff1-92785f80d578"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3655), null, null, false, "Project", null },
                    { new Guid("61cdcbbc-645a-42cf-8ec5-c32841febe32"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3630), null, null, false, "DevOps", null },
                    { new Guid("75b5cd1c-f198-46a9-a02b-6500384d4d7a"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3647), null, null, false, "Cybersecurity", null },
                    { new Guid("81572849-4fd1-4220-842c-a9cb0dcb62de"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3622), null, null, false, "Frontend", null },
                    { new Guid("8af5f1a9-e7d2-4368-bc10-4768661f7263"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3626), null, null, false, "Fullstack", null },
                    { new Guid("91a14b3b-0d12-4b8d-b3f0-beee70c7c9dd"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3662), null, null, false, "Other", null },
                    { new Guid("95e3b072-05b5-4f49-9352-8d1f334095e6"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3643), null, null, false, "DataScience", null },
                    { new Guid("b88ecaad-991f-4d42-84e7-c07832369328"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3659), null, null, false, "Management", null },
                    { new Guid("db7c06e7-ec3c-40fa-b521-3776f6826084"), new DateTime(2024, 5, 23, 4, 24, 10, 780, DateTimeKind.Utc).AddTicks(3614), null, null, false, "Backend", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("0cf40f54-d68b-4072-bef1-1d30a619991e"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("202cfa47-189e-482d-9a63-6cad414687ef"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("2625b027-05bf-4cef-b1cf-99cae799aa31"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("5b935487-4ef9-4641-9ff1-92785f80d578"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("61cdcbbc-645a-42cf-8ec5-c32841febe32"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("75b5cd1c-f198-46a9-a02b-6500384d4d7a"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("81572849-4fd1-4220-842c-a9cb0dcb62de"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("8af5f1a9-e7d2-4368-bc10-4768661f7263"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("91a14b3b-0d12-4b8d-b3f0-beee70c7c9dd"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("95e3b072-05b5-4f49-9352-8d1f334095e6"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("b88ecaad-991f-4d42-84e7-c07832369328"));

            migrationBuilder.DeleteData(
                table: "level",
                keyColumn: "rol_level_id",
                keyValue: new Guid("db7c06e7-ec3c-40fa-b521-3776f6826084"));

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
        }
    }
}
