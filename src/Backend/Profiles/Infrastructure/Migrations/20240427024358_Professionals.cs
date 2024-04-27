using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Professionals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalId",
                table: "tbl_skill",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professionals",
                columns: table => new
                {
                    ProfessionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professionals", x => x.ProfessionalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_skill_ProfessionalId",
                table: "tbl_skill",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_Name",
                table: "Professionals",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_skill_Professionals_ProfessionalId",
                table: "tbl_skill",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_skill_Professionals_ProfessionalId",
                table: "tbl_skill");

            migrationBuilder.DropTable(
                name: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_tbl_skill_ProfessionalId",
                table: "tbl_skill");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "tbl_skill");
        }
    }
}
