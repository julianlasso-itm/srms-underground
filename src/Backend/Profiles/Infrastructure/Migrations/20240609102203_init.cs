using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
  /// <inheritdoc />
  public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ctr_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.ctr_country_id);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    rol_level_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.rol_level_id);
                });

            migrationBuilder.CreateTable(
                name: "podium",
                columns: table => new
                {
                    pdm_podium_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pdm_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pdm_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pdm_photo = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podium", x => x.pdm_podium_id);
                });

            migrationBuilder.CreateTable(
                name: "professional",
                columns: table => new
                {
                    prf_professional_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prf_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prf_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prf_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional", x => x.prf_professional_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.rol_role_id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    skl_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    skl_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    skl_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.skl_skill_id);
                });

            migrationBuilder.CreateTable(
                name: "squad",
                columns: table => new
                {
                    sqd_squad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sqd_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    sqd_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_squad", x => x.sqd_squad_id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prv_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.prv_province_id);
                    table.ForeignKey(
                        name: "FK_province_country_ctr_country_id",
                        column: x => x.ctr_country_id,
                        principalTable: "country",
                        principalColumn: "ctr_country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_per_skill",
                columns: table => new
                {
                    rps_role_per_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ski_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_per_skill", x => x.rps_role_per_skill_id);
                    table.ForeignKey(
                        name: "FK_role_per_skill_role_rol_role_id",
                        column: x => x.rol_role_id,
                        principalTable: "role",
                        principalColumn: "rol_role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_per_skill_skill_ski_skill_id",
                        column: x => x.ski_skill_id,
                        principalTable: "skill",
                        principalColumn: "skl_skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subskill",
                columns: table => new
                {
                    sbskl_subskill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    skl_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sbskl_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    sbskl_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subskill", x => x.sbskl_subskill_id);
                    table.ForeignKey(
                        name: "FK_subskill_skill_skl_skill_id",
                        column: x => x.skl_skill_id,
                        principalTable: "skill",
                        principalColumn: "skl_skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment",
                columns: table => new
                {
                    asm_assessment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prf_professional_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sqd_squad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment", x => x.asm_assessment_id);
                    table.ForeignKey(
                        name: "FK_assessment_professional_prf_professional_id",
                        column: x => x.prf_professional_id,
                        principalTable: "professional",
                        principalColumn: "prf_professional_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_role_rol_role_id",
                        column: x => x.rol_role_id,
                        principalTable: "role",
                        principalColumn: "rol_role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assessment_squad_sqd_squad_id",
                        column: x => x.sqd_squad_id,
                        principalTable: "squad",
                        principalColumn: "sqd_squad_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    cty_city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cty_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cty_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.cty_city_id);
                    table.ForeignKey(
                        name: "FK_city_province_prv_province_id",
                        column: x => x.prv_province_id,
                        principalTable: "province",
                        principalColumn: "prv_province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    res_result_id = table.Column<Guid>(type: "uuid", nullable: false),
                    asm_assessment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sub_sub_skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    res_result = table.Column<int>(type: "integer", nullable: false),
                    res_comment = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    res_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.res_result_id);
                    table.ForeignKey(
                        name: "FK_result_assessment_asm_assessment_id",
                        column: x => x.asm_assessment_id,
                        principalTable: "assessment",
                        principalColumn: "asm_assessment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_result_subskill_sub_sub_skill_id",
                        column: x => x.sub_sub_skill_id,
                        principalTable: "subskill",
                        principalColumn: "sbskl_subskill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "ctr_country_id", "ctr_disabled", "ctr_name" },
                values: new object[,]
                {
                    { new Guid("05ae4c4f-884f-4f16-876d-29c77c02aec2"), false, "Guatemala" },
                    { new Guid("43637808-a646-4695-9f11-c50bcbbba783"), false, "Bolivia" },
                    { new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Ecuador" },
                    { new Guid("56e42230-b919-4ce7-a086-4762d354fdff"), false, "Brasil" },
                    { new Guid("5b92c594-85a2-49ff-82e2-8d5c581d9b82"), false, "Paraguay" },
                    { new Guid("5f125678-14f2-47b6-94f9-e674855dc2d5"), false, "México" },
                    { new Guid("68dd5632-683e-4c20-adc4-28c3c7261e7f"), false, "Uruguay" },
                    { new Guid("6bfd1e0b-861f-4d96-8ebb-15917b2e3d66"), false, "El Salvador" },
                    { new Guid("716abc65-ba43-4a94-b3fd-da61c8c087f8"), false, "Chile" },
                    { new Guid("73307cf4-19ef-4a7f-869f-8e1eedc4a4d9"), false, "Belize" },
                    { new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Colombia" },
                    { new Guid("9abe8300-7cd2-42c9-975a-183d3eed5f86"), false, "Costa Rica" },
                    { new Guid("a68b4b12-ff96-4b6f-9194-955838fba590"), false, "Nicaragua" },
                    { new Guid("b4c03892-7bc3-4589-ae6d-fc6a92bc742c"), false, "Honduras" },
                    { new Guid("b5436229-7d15-4447-87d5-1352f9d1f4a0"), false, "Perú" },
                    { new Guid("d8e0fed4-ed4d-4d54-a4fc-3af6ac044f4c"), false, "Argentina" },
                    { new Guid("eb46028f-d49e-42de-ab18-27d31baad740"), false, "Venezuela" },
                    { new Guid("eefc63da-97f2-4c7f-9afb-eca0ac7db5b4"), false, "Panamá" }
                });

            migrationBuilder.InsertData(
                table: "podium",
                columns: new[] { "pdm_podium_id", "created_at", "deleted_at", "pdm_email", "pdm_name", "pdm_photo", "updated_at" },
                values: new object[,]
                {
                    { new Guid("04665c18-8d5c-41a5-ae2e-e747344ad435"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4935), null, "diegogomez@gmail.com", "Diego Gómez", "https://orderszulu2024.blob.core.windows.net/users/SRMS-aa8a6ecf-b17a-46a1-b821-43a0f39072c6.webp", null },
                    { new Guid("14179f49-d3fa-434e-9c48-38026ce09f5d"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4932), null, "aliciaruis@gmail.com", "Alicia Ruiz", "https://orderszulu2024.blob.core.windows.net/users/SRMS-6bb83a6f-f149-4be2-9d4d-aa48f2cd019e.webp", null },
                    { new Guid("9558228d-52ce-4974-9d93-066b33e8f48b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4925), null, "juan.perez@gmail.com", "Juan Perez", "https://orderszulu2024.blob.core.windows.net/users/SRMS-47a38449-7ffe-4e80-8067-b1684b02aaaf.webp", null }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("06e5ade4-f56a-41a1-9e2e-8e3be58a05f6"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4861), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("1b976c1a-8cf4-4495-92b8-28d3d5b16d1e"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4881), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("2db3abf0-c696-4754-bb1a-3b594a02c398"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4867), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("3ead8c4e-ffac-45c9-8ec9-3746153baf43"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4889), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("6b3e6411-710c-406c-96cf-bac02e9131d7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4878), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("926efa6c-2528-4ac5-80bf-66fed23f1801"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4864), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("9e3bfe67-d893-4667-8878-542316b253dd"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4855), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("ac88643c-3477-4792-a745-e3e9f025f547"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4883), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("b9bafe09-d19d-48b3-993f-9c47823386ac"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4858), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("c9111dcf-1389-4909-9c7b-f5df4841bda7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4886), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("ccc730fe-22c8-4256-8180-edbcd9964613"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4870), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("efd86546-1a51-4c74-8bd4-7b55b805600b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4892), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("f6ee2e25-ba7e-4ddb-98b9-66bcc51f0ed7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4853), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("f8e0469a-4c85-4509-9486-5c05caba64bd"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4848), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("fbe4f80e-b511-40e5-b8d2-52701812b116"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4874), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4491), null, null, false, "Full Stack Developer (C#, Angular)", null },
                    { new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4499), null, null, false, "Back-end Developer (Java, Python)", null },
                    { new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4501), null, null, false, "Front-end Developer (React, Angular)", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4552), null, false, "CSS", null },
                    { new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4560), null, false, "NodeJS", null },
                    { new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4550), null, false, "HTML", null },
                    { new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4548), null, false, "JavaScript", null },
                    { new Guid("51373385-dce2-458c-a06b-9b20625b7702"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4545), null, false, "Java", null },
                    { new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4555), null, false, "NoSQL - MongoDB", null },
                    { new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4541), null, false, "C#", null },
                    { new Guid("76a48392-0e58-496a-ae78-562df47896b7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4554), null, false, "SQL", null },
                    { new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4558), null, false, "React", null },
                    { new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4546), null, false, "Python", null },
                    { new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4561), null, false, "Spring Boot", null },
                    { new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4556), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("03bce8c7-d1a8-4370-88a4-221e4e74c602"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Caquetá" },
                    { new Guid("0791b244-f4c9-4fd5-8f0b-cdca7bb9fd96"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "El Oro" },
                    { new Guid("0b3daf29-b797-4580-bae0-89e2e6f9b2d4"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Arauca" },
                    { new Guid("0eef580a-18d0-4f68-97f5-577347259e04"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "San Andrés y Providencia" },
                    { new Guid("182bc6a2-c998-4dea-9501-7b4c5410d11e"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Galápagos" },
                    { new Guid("1d2d9c2d-ad81-4c5b-bb25-b4894f639d3e"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Chocó" },
                    { new Guid("2555368b-2bed-497a-9d39-de0b2d621b5c"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Putumayo" },
                    { new Guid("2a2e55a4-6102-4377-9756-56f3e7cfe914"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Chimborazo" },
                    { new Guid("2de4068d-f3f3-4a32-a8af-15f7db593336"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Meta" },
                    { new Guid("2e3c3d55-7126-4e4b-b1da-37ef43042097"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Risaralda" },
                    { new Guid("39d7e3b2-532f-465a-8399-59cd0851525d"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Magdalena" },
                    { new Guid("3e906885-199a-41cb-8bf9-defd3ac8959f"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Bolívar" },
                    { new Guid("43f0d6dd-7165-482b-8623-96d5faf786f8"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Guainía" },
                    { new Guid("4e4a0e82-d9cb-41c4-97ec-b3dbff2b9ecd"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Manabí" },
                    { new Guid("55650eca-f117-49a8-81b9-3e3374ed932d"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Vichada" },
                    { new Guid("5eedf221-9f45-4e3e-bee6-6a39de486d6e"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Cundinamarca" },
                    { new Guid("6fb47d2a-4ebb-4564-8460-24ed7e554d11"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Cañar" },
                    { new Guid("70e5475c-f25a-40e0-9be9-66efde3ddbe6"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Guaviare" },
                    { new Guid("78358b70-1aef-44c5-96cd-0e79934f3916"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Sucre" },
                    { new Guid("7b70cc68-946c-4de9-96b2-60fb6036bcfe"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Morona Santiago" },
                    { new Guid("8052ba3b-7f84-4211-9f82-8a265b3107e3"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Carchi" },
                    { new Guid("8147119b-1352-48a8-9b09-3fce0ebace48"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Santander" },
                    { new Guid("8641389a-414d-4d7d-a079-7d1b8678d6c5"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Caldas" },
                    { new Guid("8cc19da5-3d93-467a-98c7-0b10fc5aaa70"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Nariño" },
                    { new Guid("91084510-ec37-488a-8211-11b476281cd9"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Loja" },
                    { new Guid("923475d3-4181-4805-b138-ff7a490571c5"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Valle del Cauca" },
                    { new Guid("93b5c37f-f67f-488c-a774-f4e700247804"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Cesar" },
                    { new Guid("97e531f2-2bec-4510-9a67-f627f06031d2"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Quindío" },
                    { new Guid("9935d4ad-2a53-43c1-b07a-e196d26e3f33"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Vaupés" },
                    { new Guid("9cf68ed3-bb0b-452c-b648-feaf0b4015af"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Boyacá" },
                    { new Guid("9e0dea2e-5986-4dfb-877e-610dd1e6fcf7"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Cotopaxi" },
                    { new Guid("aa790fd1-fcc5-48a4-9b14-f0933ad83d81"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Huila" },
                    { new Guid("abe502e4-f781-49b7-9d01-cfb20f9b7fd5"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Esmeraldas" },
                    { new Guid("b18eb095-e7f8-4dab-810c-9cf2752944a9"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "La Guajira" },
                    { new Guid("b36e0cad-b27b-44b1-97be-9cf60bedae31"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Guayas" },
                    { new Guid("b91c0588-e0ce-4b63-8028-0372cbcec47e"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Amazonas" },
                    { new Guid("bda82a45-2b6b-41bd-bc7f-fe76f7e5348b"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Córdoba" },
                    { new Guid("be86bfe4-0b19-4be2-8562-f0d518ebef3f"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Azuay" },
                    { new Guid("c1bea784-e3c3-4852-9609-3f72221e10a9"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Cauca" },
                    { new Guid("c2f563f5-cb01-4636-8047-54536b46a28a"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Imbabura" },
                    { new Guid("c5f2a44a-d4a5-4eda-b0ce-1bf2bcd21a9f"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Tolima" },
                    { new Guid("cba13514-176f-4818-9645-23ba20067870"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Casanare" },
                    { new Guid("da2a3715-bb1a-47fd-aadf-a1a3906a7ccd"), new Guid("56da76e7-9ddc-4402-b3d0-7ef08d94af7f"), false, "Napo" },
                    { new Guid("e00ddf8a-9d46-4bcb-842f-55f1b9f5657a"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Bolívar" },
                    { new Guid("e964f09e-f0f7-4865-833d-70e9043bc6db"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Norte de Santander" },
                    { new Guid("ec9be16f-8cd3-484c-8ac5-03feee3f9c4e"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Atlántico" },
                    { new Guid("f54256eb-248a-4edb-ac61-f6525b5d53b4"), new Guid("99d8884f-1712-49e0-9b48-115ff0d61929"), false, "Antioquia" }
                });

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("2107fbc0-2106-482a-9f24-bd26dc4d561f"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4761), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("245148f7-bbb8-4ff7-b385-e294dd23f5c5"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4772), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("27d909b8-fe1e-4704-acc7-2c6817239e1d"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4777), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("349d8901-276f-47ab-a434-bf58dc4c79f8"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4799), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("3d075b42-d677-4883-a3cd-db11338d3325"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4798), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("4e32cb0d-0c88-4284-abb5-5d0c938d4629"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4789), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("6767e893-68fb-4c9e-a4ae-6419acbeaa57"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4781), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("6d7b7d78-dea5-4f85-8949-39974644ce9b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4774), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("8d3e3477-3129-427f-9b78-0b800a970cc8"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4791), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("908d65eb-d30c-4152-91a2-53c8549b9eb0"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4796), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("d8c012e9-15e5-4a87-bb30-620ca596bdc8"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4779), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("ebe86da4-4fe7-4d33-91ae-7444cd29abee"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4794), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("ed16c312-c95e-407c-8dd5-aa3675751752"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4768), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("f39a758f-d82e-4a4a-85ba-ad8dda6ccf36"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4783), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("f9b4eb27-f60c-4990-8169-a77e57f30f7e"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4787), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("fe69756f-3698-43c5-ae21-f9f80bd2dd63"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4770), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null }
                });

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("083b5323-9bc2-47f1-8513-1c0a6fc809d7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4611), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("1752713c-dcfa-46c1-b6ef-6926d2b00286"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4638), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("21709f3f-28bc-4d14-9e36-84fbe4a9ea55"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4640), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("429bc551-4d6a-400c-a05a-c3d59ec2b0ee"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4599), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("4572fbaf-626f-4f85-903b-56a894092ed2"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4623), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("58a9a9ce-9464-4521-84e5-b94f0c036597"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4614), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("5c31e975-beba-42e5-b839-59c96aa3ac15"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4626), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("70497f42-4ecf-4fa9-a9ec-769ac31f476b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4665), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("72fa905e-e3be-4a0b-87f2-bf39875f5fc1"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4656), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("75b75257-2cfb-4c04-ab20-0e0ea738ac15"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4642), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("7ac96831-3ad9-4e21-a7af-ee859886b12b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4647), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("7f57d816-009f-4b51-a7a7-70f43e6c476d"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4631), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("80c7c1f2-f73e-4933-8020-abccefc91a9b"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4621), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("86acbbcc-99f2-4363-a9d6-93cd115b8935"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4616), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("a741a8d8-ce8d-43ed-ad40-080fc3e0883a"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4652), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("a9e4ba7d-b991-4f92-ba26-6809920bbb71"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4633), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("bcf85596-db92-4a93-a199-d70e6f2881e3"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4644), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("bfdb2335-0a77-4940-8f7d-fb9d5c619864"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4663), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("c286c7b1-e0f7-4258-813f-97295e832e78"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4659), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("e06431cb-0b48-4f22-9975-d7f75a0aea5d"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4619), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("ea1bfed8-d277-4ceb-a3f4-881d37bb4aa7"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4636), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("eca37333-434e-43a5-b28a-21edd339bd62"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4609), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("f1dae6ae-1ff1-4e9c-9315-3caefe0185bf"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4661), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("fbaa1161-aeed-4678-be47-a9c56fdab549"), new DateTime(2024, 6, 9, 10, 22, 2, 806, DateTimeKind.Utc).AddTicks(4654), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("020b6766-0761-4d8a-8151-d935f2fe2fab"), false, "Bogotá", new Guid("5eedf221-9f45-4e3e-bee6-6a39de486d6e") },
                    { new Guid("06be99fc-126a-4015-9d8b-2815d73ca8c5"), false, "Villavicencio", new Guid("2de4068d-f3f3-4a32-a8af-15f7db593336") },
                    { new Guid("06cbb0c8-57fc-4817-9ce7-b92d0b70548b"), false, "Latacunga", new Guid("9e0dea2e-5986-4dfb-877e-610dd1e6fcf7") },
                    { new Guid("06df9a90-b139-4485-a36b-c422da728ad3"), false, "Manta", new Guid("4e4a0e82-d9cb-41c4-97ec-b3dbff2b9ecd") },
                    { new Guid("0a08cc16-8311-4b38-8847-903811144078"), false, "Yopal", new Guid("cba13514-176f-4818-9645-23ba20067870") },
                    { new Guid("0b0f437a-9321-4522-a05d-5252302cb558"), false, "Armenia", new Guid("97e531f2-2bec-4510-9a67-f627f06031d2") },
                    { new Guid("0b6ecd17-2f75-4b0c-ad94-50dcc771d57c"), false, "Salcedo", new Guid("9e0dea2e-5986-4dfb-877e-610dd1e6fcf7") },
                    { new Guid("0c627fee-ed44-4a22-92cd-f41a26cea359"), false, "Acacias", new Guid("2de4068d-f3f3-4a32-a8af-15f7db593336") },
                    { new Guid("11dce674-4235-4985-ad87-8b2ed2a49fbc"), false, "Ibagué", new Guid("c5f2a44a-d4a5-4eda-b0ce-1bf2bcd21a9f") },
                    { new Guid("185192d8-68f2-4947-94a3-6722d2ab338a"), false, "Mocoa", new Guid("2555368b-2bed-497a-9d39-de0b2d621b5c") },
                    { new Guid("1965e29a-bcf1-4800-81e6-4db2468ce267"), false, "Garzón", new Guid("aa790fd1-fcc5-48a4-9b14-f0933ad83d81") },
                    { new Guid("1b5b2a1d-6b6f-45fe-b109-48850692dbd7"), false, "Aguazul", new Guid("cba13514-176f-4818-9645-23ba20067870") },
                    { new Guid("1f03e1ee-c026-4c7d-89d9-15ffffed792e"), false, "Memarí", new Guid("43f0d6dd-7165-482b-8623-96d5faf786f8") },
                    { new Guid("2030d3dc-b531-493e-a95b-43587e7e1998"), false, "Cartagena de Indias", new Guid("e00ddf8a-9d46-4bcb-842f-55f1b9f5657a") },
                    { new Guid("2171edef-2d1f-4cc4-8914-16197ae444d2"), false, "Aguachica", new Guid("93b5c37f-f67f-488c-a774-f4e700247804") },
                    { new Guid("29014b54-1c28-4b9a-8740-6aa4993301f9"), false, "Puerto Carreño", new Guid("55650eca-f117-49a8-81b9-3e3374ed932d") },
                    { new Guid("2ba24967-da63-40fc-b3f4-44d4e8f91315"), false, "Sincelejo", new Guid("78358b70-1aef-44c5-96cd-0e79934f3916") },
                    { new Guid("2bd59948-a354-45df-ba1d-6949c62d0aa1"), false, "Esmeraldas", new Guid("abe502e4-f781-49b7-9d01-cfb20f9b7fd5") },
                    { new Guid("30145264-ce97-46f8-a845-7e67afdb8324"), false, "Leticia", new Guid("b91c0588-e0ce-4b63-8028-0372cbcec47e") },
                    { new Guid("312227f3-0def-4a6c-8296-2adf3417c2ad"), false, "Machala", new Guid("0791b244-f4c9-4fd5-8f0b-cdca7bb9fd96") },
                    { new Guid("365b80bb-0857-4a38-8219-c2a30cfcd37d"), false, "Manizales", new Guid("8641389a-414d-4d7d-a079-7d1b8678d6c5") },
                    { new Guid("38eb0ed3-cc71-4a71-8da5-09d8d3ce95a7"), false, "Cartagena del Chairá", new Guid("e00ddf8a-9d46-4bcb-842f-55f1b9f5657a") },
                    { new Guid("39fb5805-37bf-4ce6-9820-d1b95bec0fe1"), false, "Cúcuta", new Guid("e964f09e-f0f7-4865-833d-70e9043bc6db") },
                    { new Guid("3a41993f-4d77-43f8-847e-a394aaa10b66"), false, "Sogamoso", new Guid("9cf68ed3-bb0b-452c-b648-feaf0b4015af") },
                    { new Guid("3add2f6a-a728-4e07-bd22-fd19bd80ed98"), false, "Apartadó", new Guid("f54256eb-248a-4edb-ac61-f6525b5d53b4") },
                    { new Guid("3d420837-6096-4ae2-9a97-04634558ac23"), false, "Durán", new Guid("b36e0cad-b27b-44b1-97be-9cf60bedae31") },
                    { new Guid("3eb3e2bb-2f75-4af2-a701-c9782a6add65"), false, "San Cristóbal", new Guid("182bc6a2-c998-4dea-9501-7b4c5410d11e") },
                    { new Guid("40421e6a-bb7c-4648-bfac-f8e9d7ac0395"), false, "Montería", new Guid("bda82a45-2b6b-41bd-bc7f-fe76f7e5348b") },
                    { new Guid("41835e3f-98ef-4d6e-8dae-2898adb4014b"), false, "Cartagena del Chairá", new Guid("03bce8c7-d1a8-4370-88a4-221e4e74c602") },
                    { new Guid("42ef868d-6cdb-4615-8f97-8f54ce234afd"), false, "El Tambo", new Guid("6fb47d2a-4ebb-4564-8460-24ed7e554d11") },
                    { new Guid("43314df5-3863-4891-b54b-beb8146d9af6"), false, "Cereté", new Guid("bda82a45-2b6b-41bd-bc7f-fe76f7e5348b") },
                    { new Guid("44e5268f-5674-46c8-aa2c-d60e6166a127"), false, "Dosquebradas", new Guid("2e3c3d55-7126-4e4b-b1da-37ef43042097") },
                    { new Guid("474fbdb5-0543-4c60-8412-fe10de60b9d2"), false, "Yavaraté", new Guid("9935d4ad-2a53-43c1-b07a-e196d26e3f33") },
                    { new Guid("4dc14ae9-6442-4558-95c7-a4a162ea6ca9"), false, "Piedecuesta", new Guid("8147119b-1352-48a8-9b09-3fce0ebace48") },
                    { new Guid("50086c3c-0db6-4f23-b476-08d32f993d53"), false, "Fortul", new Guid("0b3daf29-b797-4580-bae0-89e2e6f9b2d4") },
                    { new Guid("504f88ba-2282-4f42-95ff-4918df39a478"), false, "Armero Guayabal", new Guid("c5f2a44a-d4a5-4eda-b0ce-1bf2bcd21a9f") },
                    { new Guid("510c665c-02b6-461c-8851-5b4efe88451f"), false, "Pamplona", new Guid("e964f09e-f0f7-4865-833d-70e9043bc6db") },
                    { new Guid("52b256ce-c496-4bc8-901b-b6cea4105fb8"), false, "Macas", new Guid("7b70cc68-946c-4de9-96b2-60fb6036bcfe") },
                    { new Guid("57fcfe0d-bac2-41d2-bad1-3bdbcadad466"), false, "Riohacha", new Guid("b18eb095-e7f8-4dab-810c-9cf2752944a9") },
                    { new Guid("59f320ef-b144-490b-b2e4-f0ada694c974"), false, "Florencia", new Guid("03bce8c7-d1a8-4370-88a4-221e4e74c602") },
                    { new Guid("5a8d0d97-5f2a-4f67-84f6-9e189b3fdf11"), false, "Tena", new Guid("da2a3715-bb1a-47fd-aadf-a1a3906a7ccd") },
                    { new Guid("61419ecb-e572-4374-8b5b-6a7dc26781c4"), false, "Valledupar", new Guid("93b5c37f-f67f-488c-a774-f4e700247804") },
                    { new Guid("62cda9ba-ca62-4d69-99ac-bbb564b59cf8"), false, "Palmira", new Guid("923475d3-4181-4805-b138-ff7a490571c5") },
                    { new Guid("68426aa4-909f-41f8-a358-5c4e8141bd80"), false, "Pitalito", new Guid("aa790fd1-fcc5-48a4-9b14-f0933ad83d81") },
                    { new Guid("6a733449-29b2-4dfd-a5d2-02316134c14d"), false, "Puerto Inírida", new Guid("43f0d6dd-7165-482b-8623-96d5faf786f8") },
                    { new Guid("6ac2df23-33ce-4d5d-a755-af0d69484abd"), false, "Zipaquirá", new Guid("5eedf221-9f45-4e3e-bee6-6a39de486d6e") },
                    { new Guid("6bc7025a-bad3-447b-815b-7301141a578d"), false, "Tulcán", new Guid("8052ba3b-7f84-4211-9f82-8a265b3107e3") },
                    { new Guid("6d6b8415-45ca-4b19-b7be-fb2f626bfeaa"), false, "Guayaquil", new Guid("b36e0cad-b27b-44b1-97be-9cf60bedae31") },
                    { new Guid("719bf923-68b2-49cb-94a9-9ff86129c3ac"), false, "Pereira", new Guid("2e3c3d55-7126-4e4b-b1da-37ef43042097") },
                    { new Guid("71a7ebfc-cdf4-4b31-ad87-20604bbaa959"), false, "Providencia", new Guid("0eef580a-18d0-4f68-97f5-577347259e04") },
                    { new Guid("76974b48-cfe7-4751-a5af-77077498f07c"), false, "Santa Catalina", new Guid("0eef580a-18d0-4f68-97f5-577347259e04") },
                    { new Guid("79faab44-fbd0-4e63-ba8d-e09a079f0650"), false, "Riobamba", new Guid("2a2e55a4-6102-4377-9756-56f3e7cfe914") },
                    { new Guid("8124128f-7f56-4e2f-9695-7c04168f281f"), false, "Magangué", new Guid("e00ddf8a-9d46-4bcb-842f-55f1b9f5657a") },
                    { new Guid("81778799-c342-4a70-9754-4fb68595e41a"), false, "Calarcá", new Guid("97e531f2-2bec-4510-9a67-f627f06031d2") },
                    { new Guid("81d8e41e-d925-4bea-8a59-c5c338a98cb2"), false, "Aracataca", new Guid("39d7e3b2-532f-465a-8399-59cd0851525d") },
                    { new Guid("83e1df72-7945-4acd-8d55-62bbbb2b957a"), false, "Granada", new Guid("2de4068d-f3f3-4a32-a8af-15f7db593336") },
                    { new Guid("8736035f-5fe7-48d0-8d4b-cc9238206940"), false, "Ibarra", new Guid("c2f563f5-cb01-4636-8047-54536b46a28a") },
                    { new Guid("8ab18a28-854b-4c92-ab76-5501df4fc3dd"), false, "Turbo", new Guid("f54256eb-248a-4edb-ac61-f6525b5d53b4") },
                    { new Guid("8b15590e-7554-42c2-822b-cf30a57a9d1c"), false, "Archidona", new Guid("da2a3715-bb1a-47fd-aadf-a1a3906a7ccd") },
                    { new Guid("8e9144e4-6608-48b7-bb64-a85e29a8ce45"), false, "Inírida", new Guid("43f0d6dd-7165-482b-8623-96d5faf786f8") },
                    { new Guid("8f13ffaa-a9ba-491c-b15b-0d271c5b796b"), false, "La Tebaida", new Guid("97e531f2-2bec-4510-9a67-f627f06031d2") },
                    { new Guid("956c726a-e5e4-470a-a362-cf3b8fcbe799"), false, "Santa Helena", new Guid("55650eca-f117-49a8-81b9-3e3374ed932d") },
                    { new Guid("99033ac0-6b04-4099-a95a-e2c3e1f73867"), false, "Istmina", new Guid("1d2d9c2d-ad81-4c5b-bb25-b4894f639d3e") },
                    { new Guid("9a479d73-5ed6-4e9e-85e3-bd22a9b72ec8"), false, "Santa Marta", new Guid("39d7e3b2-532f-465a-8399-59cd0851525d") },
                    { new Guid("9c86c0a3-2c0a-4807-980b-8ce9701d67c7"), false, "Quibdó", new Guid("1d2d9c2d-ad81-4c5b-bb25-b4894f639d3e") },
                    { new Guid("9cc638bc-53b5-44bb-a272-af2ae78f7730"), false, "Tunja", new Guid("9cf68ed3-bb0b-452c-b648-feaf0b4015af") },
                    { new Guid("9df0da52-b185-403c-a68a-1bb411c762dc"), false, "Popayán", new Guid("c1bea784-e3c3-4852-9609-3f72221e10a9") },
                    { new Guid("9df55c6f-da42-4539-9fc4-e38249e2f051"), false, "Puerto Asís", new Guid("2555368b-2bed-497a-9d39-de0b2d621b5c") },
                    { new Guid("9e27e221-8234-4ad3-9d22-26cdc57caa83"), false, "Buenaventura", new Guid("923475d3-4181-4805-b138-ff7a490571c5") },
                    { new Guid("9ef0a3cf-a693-43f4-b7e9-6824f7f64b23"), false, "Calamar", new Guid("70e5475c-f25a-40e0-9be9-66efde3ddbe6") },
                    { new Guid("9f206c2d-0856-460d-9414-21ef0582bb97"), false, "Puerto Baquerizo Moreno", new Guid("182bc6a2-c998-4dea-9501-7b4c5410d11e") },
                    { new Guid("a30acaba-6608-42b3-8b04-5c5a441da2f2"), false, "Girón", new Guid("be86bfe4-0b19-4be2-8562-f0d518ebef3f") },
                    { new Guid("a57484ae-d91c-447c-859e-0f013244cbf9"), false, "Arauca", new Guid("0b3daf29-b797-4580-bae0-89e2e6f9b2d4") },
                    { new Guid("a758aae8-51ed-4268-84e2-2c6e315e05a3"), false, "Morelia", new Guid("03bce8c7-d1a8-4370-88a4-221e4e74c602") },
                    { new Guid("a8f0fb79-a4a9-4892-bc68-c7a898c4f990"), false, "La Paz", new Guid("93b5c37f-f67f-488c-a774-f4e700247804") },
                    { new Guid("aa5cf8fe-9f8e-445c-a990-c9e143065b92"), false, "El Guabo", new Guid("8052ba3b-7f84-4211-9f82-8a265b3107e3") },
                    { new Guid("af3fd55d-000e-4329-9fcd-b42de837e0bb"), false, "San Juan de Pasto", new Guid("8cc19da5-3d93-467a-98c7-0b10fc5aaa70") },
                    { new Guid("b2f6a099-5d9a-42d5-b99f-a1117fd9fa98"), false, "Ciénaga", new Guid("39d7e3b2-532f-465a-8399-59cd0851525d") },
                    { new Guid("b3c2499d-311e-4756-bfdb-ae4d9917ab86"), false, "Tumaco", new Guid("8cc19da5-3d93-467a-98c7-0b10fc5aaa70") },
                    { new Guid("b41088c7-b618-47c7-9858-ba41fa73e395"), false, "Uribia", new Guid("b18eb095-e7f8-4dab-810c-9cf2752944a9") },
                    { new Guid("b736f384-ac39-451e-a193-0d58053c010b"), false, "Chinchiná", new Guid("8641389a-414d-4d7d-a079-7d1b8678d6c5") },
                    { new Guid("b946c326-dedb-4a08-bc2a-59b648865976"), false, "Bucaramanga", new Guid("8147119b-1352-48a8-9b09-3fce0ebace48") },
                    { new Guid("b9d24a09-4246-449a-8112-6e7a4562ad4b"), false, "Soledad", new Guid("ec9be16f-8cd3-484c-8ac5-03feee3f9c4e") },
                    { new Guid("bb2de4f6-f877-47a4-b7a1-15b1eac502e3"), false, "Neiva", new Guid("aa790fd1-fcc5-48a4-9b14-f0933ad83d81") },
                    { new Guid("bccf5dc3-a810-4f88-9adb-bd35fa74d7d8"), false, "Silvia", new Guid("c1bea784-e3c3-4852-9609-3f72221e10a9") },
                    { new Guid("bde494a8-2e66-4c33-af6e-508862d402cf"), false, "Santa Rosa", new Guid("0791b244-f4c9-4fd5-8f0b-cdca7bb9fd96") },
                    { new Guid("c1e038e2-cf1c-45d7-b19a-33bed9266783"), false, "Tauramena", new Guid("cba13514-176f-4818-9645-23ba20067870") },
                    { new Guid("c23017f1-05c5-44bf-b410-84e58792ad01"), false, "Puerto Colombia", new Guid("ec9be16f-8cd3-484c-8ac5-03feee3f9c4e") },
                    { new Guid("c3179771-6738-431a-aac6-7f0629446ce9"), false, "Orito", new Guid("2555368b-2bed-497a-9d39-de0b2d621b5c") },
                    { new Guid("c3c77775-81e6-43b8-9482-8724966e705d"), false, "Ipiales", new Guid("8cc19da5-3d93-467a-98c7-0b10fc5aaa70") },
                    { new Guid("c4f36dc7-8a54-41a5-ad31-a4885f290d06"), false, "Portoviejo", new Guid("4e4a0e82-d9cb-41c4-97ec-b3dbff2b9ecd") },
                    { new Guid("c5b1cac8-9d71-48a8-b1fc-9f3e6dcb40a5"), false, "Azogues", new Guid("6fb47d2a-4ebb-4564-8460-24ed7e554d11") },
                    { new Guid("c6c9dee6-091e-4119-bc37-8db6f2762557"), false, "Chone", new Guid("4e4a0e82-d9cb-41c4-97ec-b3dbff2b9ecd") },
                    { new Guid("c74d56e7-5947-4f6a-a6d3-f4e98a01976b"), false, "Medellín", new Guid("f54256eb-248a-4edb-ac61-f6525b5d53b4") },
                    { new Guid("c797d931-fdc6-42b2-ac0b-286dc3e06084"), false, "Corozal", new Guid("78358b70-1aef-44c5-96cd-0e79934f3916") },
                    { new Guid("c86e9109-5eea-4b17-8b98-cc4e3cd5ae34"), false, "Novita", new Guid("1d2d9c2d-ad81-4c5b-bb25-b4894f639d3e") },
                    { new Guid("caf476a5-536c-4ac2-959c-9edb10cc3670"), false, "Saraguro", new Guid("91084510-ec37-488a-8211-11b476281cd9") },
                    { new Guid("cba26309-cbdb-4597-8a54-ecc2d8ab56db"), false, "Cuenca", new Guid("be86bfe4-0b19-4be2-8562-f0d518ebef3f") },
                    { new Guid("cc9be702-c2ba-4747-9c46-4492de693551"), false, "Loja", new Guid("91084510-ec37-488a-8211-11b476281cd9") },
                    { new Guid("cd0f798f-9308-47ed-b3fb-24ec699519c7"), false, "Duitama", new Guid("9cf68ed3-bb0b-452c-b648-feaf0b4015af") },
                    { new Guid("cd70723c-4c30-4b95-be0f-4e501697f850"), false, "Ocaña", new Guid("e964f09e-f0f7-4865-833d-70e9043bc6db") },
                    { new Guid("cf75ca01-54bf-499b-9c47-9f2fae354e98"), false, "San Miguel de Bolívar", new Guid("3e906885-199a-41cb-8bf9-defd3ac8959f") },
                    { new Guid("d157bd2b-ed31-4b48-a2ee-022210074eb7"), false, "Mitú", new Guid("9935d4ad-2a53-43c1-b07a-e196d26e3f33") },
                    { new Guid("d432e51e-b9fe-4267-a65f-dfa32aace6ec"), false, "Saravena", new Guid("0b3daf29-b797-4580-bae0-89e2e6f9b2d4") },
                    { new Guid("d64a429d-9297-4a10-8b32-ea1e34b54247"), false, "Alausí", new Guid("2a2e55a4-6102-4377-9756-56f3e7cfe914") },
                    { new Guid("d862669b-117d-448e-815b-e6e85179bb54"), false, "Guaranda", new Guid("3e906885-199a-41cb-8bf9-defd3ac8959f") },
                    { new Guid("da1efb33-b884-4b42-923d-44c2ba37b0a9"), false, "Atacames", new Guid("abe502e4-f781-49b7-9d01-cfb20f9b7fd5") },
                    { new Guid("e3547897-7d73-4dac-9311-cecd5c41c558"), false, "Honda", new Guid("c5f2a44a-d4a5-4eda-b0ce-1bf2bcd21a9f") },
                    { new Guid("e6cc36d8-1482-40b1-8c5e-ab5f582591b4"), false, "Pereira", new Guid("8641389a-414d-4d7d-a079-7d1b8678d6c5") },
                    { new Guid("ebbebfa9-2287-49f3-8a7d-d3a88b684ced"), false, "San Andrés", new Guid("0eef580a-18d0-4f68-97f5-577347259e04") },
                    { new Guid("ec1628b5-3153-4a5b-a082-8384a95563e1"), false, "Santander de Quilichao", new Guid("c1bea784-e3c3-4852-9609-3f72221e10a9") },
                    { new Guid("ecde49c6-c26d-4bd6-91c8-6e123f38c193"), false, "Maicao", new Guid("b18eb095-e7f8-4dab-810c-9cf2752944a9") },
                    { new Guid("ee435dff-4a61-4ded-9bc5-b380ae016ac1"), false, "Santa Rosalía", new Guid("9935d4ad-2a53-43c1-b07a-e196d26e3f33") },
                    { new Guid("f0ce5572-00cb-4f5f-be88-5efa00a95f57"), false, "Cali", new Guid("923475d3-4181-4805-b138-ff7a490571c5") },
                    { new Guid("f247974f-5a63-4e7d-ae84-9916179371a5"), false, "Gualaquiza", new Guid("7b70cc68-946c-4de9-96b2-60fb6036bcfe") },
                    { new Guid("f3e86308-d63c-4a4e-b639-ac0375006975"), false, "La Primavera", new Guid("55650eca-f117-49a8-81b9-3e3374ed932d") },
                    { new Guid("f40c821f-9aef-4014-b82c-8bf9b2e8a8f6"), false, "Santa Rosa de Cabal", new Guid("2e3c3d55-7126-4e4b-b1da-37ef43042097") },
                    { new Guid("f40f24b9-e366-4975-a0e0-271eec7adcd5"), false, "Montería", new Guid("78358b70-1aef-44c5-96cd-0e79934f3916") },
                    { new Guid("f5423ce8-83f3-4e3f-be5a-e442975be792"), false, "El Retén", new Guid("70e5475c-f25a-40e0-9be9-66efde3ddbe6") },
                    { new Guid("f6a4d762-9a02-469f-82bf-4f4cc15d5c0e"), false, "Soacha", new Guid("5eedf221-9f45-4e3e-bee6-6a39de486d6e") },
                    { new Guid("f720768e-1f43-483a-bf52-6f6fccfcae4d"), false, "Otavalo", new Guid("c2f563f5-cb01-4636-8047-54536b46a28a") },
                    { new Guid("f8621a78-d2d9-47ef-ac33-63190e011dc7"), false, "San José del Guaviare", new Guid("70e5475c-f25a-40e0-9be9-66efde3ddbe6") },
                    { new Guid("f96f149d-bf3e-496f-8ecd-a2fbfdbc1ca4"), false, "Lorica", new Guid("bda82a45-2b6b-41bd-bc7f-fe76f7e5348b") },
                    { new Guid("fc36afe2-89ac-467a-998f-279d590ea1bc"), false, "Barranquilla", new Guid("ec9be16f-8cd3-484c-8ac5-03feee3f9c4e") },
                    { new Guid("ff92ebf9-ce85-4234-9847-a58096b15edd"), false, "Barrancabermeja", new Guid("8147119b-1352-48a8-9b09-3fce0ebace48") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessment_prf_professional_id",
                table: "assessment",
                column: "prf_professional_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_rol_role_id",
                table: "assessment",
                column: "rol_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_sqd_squad_id",
                table: "assessment",
                column: "sqd_squad_id");

            migrationBuilder.CreateIndex(
                name: "IX_city_cty_name_prv_province_id",
                table: "city",
                columns: new[] { "cty_name", "prv_province_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_prv_province_id",
                table: "city",
                column: "prv_province_id");

            migrationBuilder.CreateIndex(
                name: "IX_country_ctr_name",
                table: "country",
                column: "ctr_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_level_rol_name",
                table: "level",
                column: "rol_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_professional_prf_email",
                table: "professional",
                column: "prf_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_province_ctr_country_id",
                table: "province",
                column: "ctr_country_id");

            migrationBuilder.CreateIndex(
                name: "IX_province_prv_name_ctr_country_id",
                table: "province",
                columns: new[] { "prv_name", "ctr_country_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_result_asm_assessment_id",
                table: "result",
                column: "asm_assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_result_sub_sub_skill_id",
                table: "result",
                column: "sub_sub_skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_rol_name",
                table: "role",
                column: "rol_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_per_skill_rol_role_id",
                table: "role_per_skill",
                column: "rol_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_per_skill_ski_skill_id",
                table: "role_per_skill",
                column: "ski_skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_skill_skl_name",
                table: "skill",
                column: "skl_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_squad_sqd_name",
                table: "squad",
                column: "sqd_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subskill_sbskl_name_skl_skill_id",
                table: "subskill",
                columns: new[] { "sbskl_name", "skl_skill_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subskill_skl_skill_id",
                table: "subskill",
                column: "skl_skill_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "podium");

            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.DropTable(
                name: "role_per_skill");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "assessment");

            migrationBuilder.DropTable(
                name: "subskill");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "professional");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "squad");

            migrationBuilder.DropTable(
                name: "skill");
        }
    }
}
