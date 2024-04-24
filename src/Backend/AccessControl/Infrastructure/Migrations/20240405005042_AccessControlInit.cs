using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccessControlInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    rol_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rol_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rol_deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.rol_role_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    usr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usr_email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    usr_password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    usr_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    usr_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usr_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usr_deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.usr_user_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_per_role",
                columns: table => new
                {
                    upr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    upr_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    upr_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    upr_deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_per_role", x => new { x.upr_user_id, x.upr_role_id });
                    table.ForeignKey(
                        name: "FK_tbl_user_per_role_tbl_role_upr_role_id",
                        column: x => x.upr_role_id,
                        principalTable: "tbl_role",
                        principalColumn: "rol_role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_user_per_role_tbl_user_upr_user_id",
                        column: x => x.upr_user_id,
                        principalTable: "tbl_user",
                        principalColumn: "usr_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_name",
                table: "tbl_role",
                column: "rol_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_role_id_rol_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_role_id", "rol_deleted_at" },
                unique: true);

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
                name: "IX_tbl_user_per_role_upr_role_id",
                table: "tbl_user_per_role",
                column: "upr_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_per_role_upr_user_id_upr_role_id_upr_deleted_at",
                table: "tbl_user_per_role",
                columns: new[] { "upr_user_id", "upr_role_id", "upr_deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_user_per_role");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
