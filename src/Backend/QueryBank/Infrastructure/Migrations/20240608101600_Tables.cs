using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueryBank.Infrastructure.Migrations
{
  /// <inheritdoc />
  public partial class Tables : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "skill",
        columns: table => new
        {
          skl_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
          skl_sub_skill_id = table.Column<Guid>(type: "uuid", nullable: true),
          skl_name = table.Column<string>(
            type: "character varying(20)",
            maxLength: 20,
            nullable: false
          ),
          skl_disabled = table.Column<bool>(type: "boolean", nullable: false),
          created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
          updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
          deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_skill", x => x.skl_skill_id);
          table.ForeignKey(
            name: "FK_skill_skill_skl_sub_skill_id",
            column: x => x.skl_sub_skill_id,
            principalTable: "skill",
            principalColumn: "skl_skill_id",
            onDelete: ReferentialAction.Restrict
          );
        }
      );

      migrationBuilder.CreateIndex(
        name: "IX_skill_skl_sub_skill_id_skl_name",
        table: "skill",
        columns: new[] { "skl_sub_skill_id", "skl_name" },
        unique: true
      );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "skill");
    }
  }
}
