using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_per_role_upr_user_id_upr_role_id_upr_deleted_at",
                table: "tbl_user_per_role");

            migrationBuilder.DropIndex(
                name: "IX_tbl_role_rol_name",
                table: "tbl_role");

            migrationBuilder.DropColumn(
                name: "upr_created_at",
                table: "tbl_user_per_role");

            migrationBuilder.DropColumn(
                name: "upr_deleted_at",
                table: "tbl_user_per_role");

            migrationBuilder.AddColumn<Guid>(
                name: "upr_id",
                table: "tbl_user_per_role",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_per_role_upr_user_id_upr_role_id",
                table: "tbl_user_per_role",
                columns: new[] { "upr_user_id", "upr_role_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_name_rol_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_name", "rol_deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_per_role_upr_user_id_upr_role_id",
                table: "tbl_user_per_role");

            migrationBuilder.DropIndex(
                name: "IX_tbl_role_rol_name_rol_deleted_at",
                table: "tbl_role");

            migrationBuilder.DropColumn(
                name: "upr_id",
                table: "tbl_user_per_role");

            migrationBuilder.AddColumn<DateTime>(
                name: "upr_created_at",
                table: "tbl_user_per_role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "upr_deleted_at",
                table: "tbl_user_per_role",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_per_role_upr_user_id_upr_role_id_upr_deleted_at",
                table: "tbl_user_per_role",
                columns: new[] { "upr_user_id", "upr_role_id", "upr_deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_name",
                table: "tbl_role",
                column: "rol_name",
                unique: true);
        }
    }
}
