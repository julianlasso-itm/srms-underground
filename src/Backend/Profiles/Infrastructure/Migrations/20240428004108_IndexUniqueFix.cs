using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IndexUniqueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_skill_skl_skill_id_skl_name_deleted_at",
                table: "tbl_skill");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_ProfessionalId_Email_deleted_at",
                table: "Professionals");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_skill_skl_name_deleted_at",
                table: "tbl_skill",
                columns: new[] { "skl_name", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_Email_deleted_at",
                table: "Professionals",
                columns: new[] { "Email", "deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_skill_skl_name_deleted_at",
                table: "tbl_skill");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_Email_deleted_at",
                table: "Professionals");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_skill_skl_skill_id_skl_name_deleted_at",
                table: "tbl_skill",
                columns: new[] { "skl_skill_id", "skl_name", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ProfessionalId_Email_deleted_at",
                table: "Professionals",
                columns: new[] { "ProfessionalId", "Email", "deleted_at" },
                unique: true);
        }
    }
}
