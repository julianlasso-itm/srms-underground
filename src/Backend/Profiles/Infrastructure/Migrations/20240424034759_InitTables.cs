using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_country",
                columns: table => new
                {
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ctr_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_country", x => x.ctr_country_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_province",
                columns: table => new
                {
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prv_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_province", x => x.prv_province_id);
                    table.ForeignKey(
                        name: "FK_tbl_province_tbl_country_ctr_country_id",
                        column: x => x.ctr_country_id,
                        principalTable: "tbl_country",
                        principalColumn: "ctr_country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_city",
                columns: table => new
                {
                    cty_city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cty_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cty_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_city", x => x.cty_city_id);
                    table.ForeignKey(
                        name: "FK_tbl_city_tbl_province_prv_province_id",
                        column: x => x.prv_province_id,
                        principalTable: "tbl_province",
                        principalColumn: "prv_province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_city_prv_province_id",
                table: "tbl_city",
                column: "prv_province_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_province_ctr_country_id",
                table: "tbl_province",
                column: "ctr_country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_city");

            migrationBuilder.DropTable(
                name: "tbl_province");

            migrationBuilder.DropTable(
                name: "tbl_country");
        }
    }
}
