using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rol_updated_at",
                table: "tbl_role",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "rol_deleted_at",
                table: "tbl_role",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "rol_created_at",
                table: "tbl_role",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_role_rol_role_id_rol_deleted_at",
                table: "tbl_role",
                newName: "IX_tbl_role_rol_role_id_deleted_at");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_role_rol_name_rol_deleted_at",
                table: "tbl_role",
                newName: "IX_tbl_role_rol_name_deleted_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tbl_role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tbl_role",
                newName: "rol_updated_at");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "tbl_role",
                newName: "rol_deleted_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "tbl_role",
                newName: "rol_created_at");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_role_rol_role_id_deleted_at",
                table: "tbl_role",
                newName: "IX_tbl_role_rol_role_id_rol_deleted_at");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_role_rol_name_deleted_at",
                table: "tbl_role",
                newName: "IX_tbl_role_rol_name_rol_deleted_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rol_created_at",
                table: "tbl_role",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
