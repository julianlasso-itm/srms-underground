using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("097d0797-b3ba-4672-ad26-5685244ca4a3"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("474fdb3d-f817-4299-a687-3dafa81f107e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("5789a37a-0be9-4ccf-960a-83bf73ec2a12"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("940c829a-a560-4013-ad8c-ecee553cd5f0"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("96aa59d2-5055-4832-ab6c-77f53f8705a5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("98ce4a72-867d-4f30-b2d8-6ae7e86487eb"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9b6b4ebd-03a0-4d5a-99df-02118a0c8ac4"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("a667d7fd-a528-4d8e-a119-50791deb5ce5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("ab6c9842-5517-488c-9e27-b19563c814a9"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("b22f31c5-54fa-433a-8c87-530eaad0374d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("b71a5d7f-b1bc-46d6-9ab0-3ae224e154f1"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("b87e9821-5f92-421d-a032-32db1eb92294"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("bff78836-e9dc-474e-aec5-ba7b60e26165"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("d3be8aea-9f7a-4d52-9e0b-9311e3af0e5f"));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0e5c4cc5-1478-4742-a440-82b4703b27f6"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7268), null, "SuperAdmin role", false, "SuperAdmin", null },
                    { new Guid("1a19359e-c935-48b4-ae8b-362336a9abd5"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7348), null, "Developer role", false, "Developer", null },
                    { new Guid("3311a781-bbee-4922-bce5-4d73b4072bfd"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7289), null, "Contributor role", false, "Contributor", null },
                    { new Guid("3d6b420d-83d8-4260-8953-ba1034eb3731"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7291), null, "Subscriber role", false, "Subscriber", null },
                    { new Guid("3e994edc-a2dd-436b-85dd-17c3f16896a5"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7276), null, "Editor role", false, "Editor", null },
                    { new Guid("76aa8403-1a0c-4a33-88f1-89b8afe7a5dc"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7270), null, "Moderator role", false, "Moderator", null },
                    { new Guid("7ed3ebaf-d36e-4f28-a576-3a295ed8d694"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7346), null, "Tester role", false, "Tester", null },
                    { new Guid("84547c42-983d-49df-aa46-227f592be6ec"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7278), null, "Author role", false, "Author", null },
                    { new Guid("8c3e752b-2362-453c-9d92-22d71f31c78e"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7344), null, "Viewer role", false, "Viewer", null },
                    { new Guid("980f5928-35f7-482b-acf1-0ec081c055c9"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7342), null, "Client role", false, "Client", null },
                    { new Guid("be479847-3e9b-43c5-8674-6b4c908f008b"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7233), null, "Admin role", false, "Admin", null },
                    { new Guid("befbf8c0-12b7-4be6-8d9f-206cb28ea342"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7266), null, "Guest role", false, "Guest", null },
                    { new Guid("c038ad4d-1381-41f7-a869-d09ecdb32cc8"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7294), null, "Member role", false, "Member", null },
                    { new Guid("d72a2c4e-6bbb-465b-a909-a79e7d65b402"), new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7296), null, "Customer role", false, "Customer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("0e5c4cc5-1478-4742-a440-82b4703b27f6"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("1a19359e-c935-48b4-ae8b-362336a9abd5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("3311a781-bbee-4922-bce5-4d73b4072bfd"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("3d6b420d-83d8-4260-8953-ba1034eb3731"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("3e994edc-a2dd-436b-85dd-17c3f16896a5"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("76aa8403-1a0c-4a33-88f1-89b8afe7a5dc"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("7ed3ebaf-d36e-4f28-a576-3a295ed8d694"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("84547c42-983d-49df-aa46-227f592be6ec"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("8c3e752b-2362-453c-9d92-22d71f31c78e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("980f5928-35f7-482b-acf1-0ec081c055c9"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("be479847-3e9b-43c5-8674-6b4c908f008b"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("befbf8c0-12b7-4be6-8d9f-206cb28ea342"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("c038ad4d-1381-41f7-a869-d09ecdb32cc8"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("d72a2c4e-6bbb-465b-a909-a79e7d65b402"));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("097d0797-b3ba-4672-ad26-5685244ca4a3"), new DateTime(2024, 6, 8, 7, 31, 19, 709, DateTimeKind.Utc).AddTicks(3860), null, "Author role", false, "Author", null },
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
        }
    }
}
