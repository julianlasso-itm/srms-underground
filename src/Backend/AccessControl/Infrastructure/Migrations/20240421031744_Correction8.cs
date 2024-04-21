using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_usr_email",
                table: "tbl_user");

            migrationBuilder.DropIndex(
                name: "IX_tbl_user_usr_user_id_usr_deleted_at",
                table: "tbl_user");

            migrationBuilder.DropIndex(
                name: "IX_tbl_role_rol_role_id_deleted_at",
                table: "tbl_role");

            migrationBuilder.RenameColumn(
                name: "usr_updated_at",
                table: "tbl_user",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "usr_deleted_at",
                table: "tbl_user",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "usr_created_at",
                table: "tbl_user",
                newName: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_usr_email_deleted_at",
                table: "tbl_user",
                columns: new[] { "usr_email", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_usr_email_usr_password",
                table: "tbl_user",
                columns: new[] { "usr_email", "usr_password" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_user_usr_email_deleted_at",
                table: "tbl_user");

            migrationBuilder.DropIndex(
                name: "IX_tbl_user_usr_email_usr_password",
                table: "tbl_user");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tbl_user",
                newName: "usr_updated_at");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "tbl_user",
                newName: "usr_deleted_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "tbl_user",
                newName: "usr_created_at");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_usr_email",
                table: "tbl_user",
                column: "usr_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_usr_user_id_usr_deleted_at",
                table: "tbl_user",
                columns: new[] { "usr_user_id", "usr_deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_role_id_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_role_id", "deleted_at" },
                unique: true);
        }
    }
}
