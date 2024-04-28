using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionalsEmailUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Professionals_Name",
                table: "Professionals");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_Email",
                table: "Professionals",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Professionals_Email",
                table: "Professionals");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_Name",
                table: "Professionals",
                column: "Name",
                unique: true);
        }
    }
}
