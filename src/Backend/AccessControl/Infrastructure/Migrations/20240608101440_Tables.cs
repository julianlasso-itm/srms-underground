using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessControl.Infrastructure.Migrations
{
  /// <inheritdoc />
  public partial class Tables : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "role",
        columns: table => new
        {
          rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
          rol_name = table.Column<string>(
            type: "character varying(100)",
            maxLength: 100,
            nullable: false
          ),
          rol_description = table.Column<string>(
            type: "character varying(1024)",
            maxLength: 1024,
            nullable: true
          ),
          rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
          created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
          updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
          deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_role", x => x.rol_role_id);
        }
      );

      migrationBuilder.CreateTable(
        name: "user",
        columns: table => new
        {
          usr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
          usr_name = table.Column<string>(
            type: "character varying(100)",
            maxLength: 100,
            nullable: false
          ),
          usr_email = table.Column<string>(
            type: "character varying(500)",
            maxLength: 500,
            nullable: false
          ),
          usr_password = table.Column<string>(
            type: "character varying(128)",
            maxLength: 128,
            nullable: false
          ),
          usr_photo = table.Column<string>(
            type: "character varying(500)",
            maxLength: 500,
            nullable: false
          ),
          usr_city_id = table.Column<Guid>(type: "uuid", nullable: false),
          usr_disabled = table.Column<bool>(type: "boolean", nullable: false),
          created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
          updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
          deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_user", x => x.usr_user_id);
        }
      );

      migrationBuilder.CreateTable(
        name: "user_per_role",
        columns: table => new
        {
          upr_id = table.Column<Guid>(type: "uuid", nullable: false),
          upr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
          upr_role_id = table.Column<Guid>(type: "uuid", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_user_per_role", x => x.upr_id);
          table.ForeignKey(
            name: "FK_user_per_role_role_upr_role_id",
            column: x => x.upr_role_id,
            principalTable: "role",
            principalColumn: "rol_role_id",
            onDelete: ReferentialAction.Restrict
          );
          table.ForeignKey(
            name: "FK_user_per_role_user_upr_user_id",
            column: x => x.upr_user_id,
            principalTable: "user",
            principalColumn: "usr_user_id",
            onDelete: ReferentialAction.Restrict
          );
        }
      );

      migrationBuilder.InsertData(
        table: "role",
        columns: new[]
        {
          "rol_role_id",
          "created_at",
          "deleted_at",
          "rol_description",
          "rol_disabled",
          "rol_name",
          "updated_at"
        },
        values: new object[,]
        {
          {
            new Guid("0974ff08-e056-4039-8423-3fd6577433d3"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9726),
            null,
            "Author role",
            false,
            "Author",
            null
          },
          {
            new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9701),
            null,
            "User role",
            false,
            "User",
            null
          },
          {
            new Guid("1466d240-a5e1-490c-a363-472ec60bd051"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9743),
            null,
            "Customer role",
            false,
            "Customer",
            null
          },
          {
            new Guid("2af57491-3169-4beb-84bd-4ff4a31d26d5"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9730),
            null,
            "Contributor role",
            false,
            "Contributor",
            null
          },
          {
            new Guid("374a5b53-8951-4492-bf72-a1ddeba33ae6"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9739),
            null,
            "Member role",
            false,
            "Member",
            null
          },
          {
            new Guid("5246fd6d-82bb-4612-9cca-92b71170886f"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9706),
            null,
            "Guest role",
            false,
            "Guest",
            null
          },
          {
            new Guid("561007f0-1d7b-4fcf-afa8-373c8e70fe5b"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9711),
            null,
            "SuperAdmin role",
            false,
            "SuperAdmin",
            null
          },
          {
            new Guid("5722b0bf-93d4-481f-a6a5-2b2aecbc4046"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9734),
            null,
            "Subscriber role",
            false,
            "Subscriber",
            null
          },
          {
            new Guid("667cb970-f4a1-4c3a-b199-1a3dfe6b6f2c"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9760),
            null,
            "Developer role",
            false,
            "Developer",
            null
          },
          {
            new Guid("6a49683c-d303-489e-ae1d-cabb3be79090"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9715),
            null,
            "Moderator role",
            false,
            "Moderator",
            null
          },
          {
            new Guid("7bf5213a-7473-4cdf-a38d-c315447814bf"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9756),
            null,
            "Tester role",
            false,
            "Tester",
            null
          },
          {
            new Guid("b99f06e2-a616-45b1-ac78-bb635a3133a5"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9752),
            null,
            "Viewer role",
            false,
            "Viewer",
            null
          },
          {
            new Guid("c63d9a0b-b023-4d9d-ad04-e4359f425b78"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9721),
            null,
            "Editor role",
            false,
            "Editor",
            null
          },
          {
            new Guid("dce27d6c-a019-4ba6-b7fa-9b3296dfec1b"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9675),
            null,
            "Admin role",
            false,
            "Admin",
            null
          },
          {
            new Guid("ea0f5af6-2d6b-4c92-a105-c9118fe2d25a"),
            new DateTime(2024, 6, 8, 10, 14, 40, 781, DateTimeKind.Utc).AddTicks(9748),
            null,
            "Client role",
            false,
            "Client",
            null
          }
        }
      );

      migrationBuilder.CreateIndex(
        name: "IX_role_rol_name_deleted_at",
        table: "role",
        columns: new[] { "rol_name", "deleted_at" },
        unique: true
      );

      migrationBuilder.CreateIndex(
        name: "IX_user_usr_email_deleted_at",
        table: "user",
        columns: new[] { "usr_email", "deleted_at" },
        unique: true
      );

      migrationBuilder.CreateIndex(
        name: "IX_user_usr_email_usr_password",
        table: "user",
        columns: new[] { "usr_email", "usr_password" }
      );

      migrationBuilder.CreateIndex(
        name: "IX_user_per_role_upr_role_id",
        table: "user_per_role",
        column: "upr_role_id"
      );

      migrationBuilder.CreateIndex(
        name: "IX_user_per_role_upr_user_id_upr_role_id",
        table: "user_per_role",
        columns: new[] { "upr_user_id", "upr_role_id" },
        unique: true
      );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "user_per_role");

      migrationBuilder.DropTable(name: "role");

      migrationBuilder.DropTable(name: "user");
    }
  }
}
