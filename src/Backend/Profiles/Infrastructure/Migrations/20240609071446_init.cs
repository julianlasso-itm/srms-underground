using System;
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
                    { new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Ecuador" },
                    { new Guid("1b222e27-2abb-41e2-a0c2-109453e453b3"), false, "Nicaragua" },
                    { new Guid("23edad9d-810a-42b7-85fd-bbcfaf984095"), false, "Honduras" },
                    { new Guid("2f41fdff-f7ae-4a87-b405-23415a085877"), false, "Argentina" },
                    { new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Colombia" },
                    { new Guid("635bf22b-b0de-4734-934e-d4c5c7fb7df9"), false, "Belize" },
                    { new Guid("697deec7-ed15-4f28-b1f2-03ef9ff2f0a9"), false, "Uruguay" },
                    { new Guid("7a38753f-4788-4412-8c5e-c07fab28aaea"), false, "Perú" },
                    { new Guid("7ec15702-c5aa-40fc-a626-29b1b16e9325"), false, "El Salvador" },
                    { new Guid("9046cd48-048a-463f-ba0c-4f5f73b662d8"), false, "Chile" },
                    { new Guid("93c72574-a4b3-43d5-afac-f84712a53f3e"), false, "Bolivia" },
                    { new Guid("b33fcfb8-bc25-4f88-bf34-e421e421ae6c"), false, "Guatemala" },
                    { new Guid("b80e7d82-2f1f-4242-b066-226b8c9cc6e4"), false, "Brasil" },
                    { new Guid("b9ad7577-776e-453d-9ae4-3ea07f498b0b"), false, "Panamá" },
                    { new Guid("cb1e93d5-6326-4bf7-8ec6-adfc7d09eaf4"), false, "Costa Rica" },
                    { new Guid("e40f4002-14e3-40b3-b79d-b19fbabdd221"), false, "México" },
                    { new Guid("eedf1f0e-b50c-49c9-aa68-e3f8991bdb72"), false, "Paraguay" },
                    { new Guid("f19849b5-76bf-4de6-8c6e-9a21c0f551d2"), false, "Venezuela" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("00782989-ad22-492c-a095-e07133a1bd89"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(162), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("1d86a093-fb61-4e04-a3ef-ed75d91e6a16"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(186), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("39cb1153-dd8e-4790-88c3-041a54a61fd0"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(170), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("44eb64f0-af0f-4d0b-8284-e84cbbaaa6f7"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(166), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("7bccc1a2-fe10-44d3-9565-6a2a125a5003"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(197), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("8744b74e-e563-4b58-bb8d-542060ec3c39"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(172), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("90c1034d-ebfb-461a-a0b9-d29c96b6343d"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(177), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("94b81d94-aaae-4808-a527-d0696bd1aa15"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(195), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("a26b416c-d687-4bc2-881a-b93b911525f5"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(183), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("a8bfde4e-e687-4dab-9ac1-baaac2b4c471"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(175), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("a9672a69-0410-4ce7-93fe-e7361b323192"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(168), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("ab7c06c7-a913-4a34-9398-2d5615dc7bc0"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(189), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("c507272d-fd58-4ab1-af33-de621d270ca6"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(181), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("d4544c2e-9edc-4c6f-ba52-d127cdb6e69e"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(191), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("dd8885dd-2ef6-47bc-9b97-54954d1e83fa"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(193), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9821), null, null, false, "Full Stack Developer (C#, Angular)", null },
                    { new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9825), null, null, false, "Back-end Developer (Java, Python)", null },
                    { new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9827), null, null, false, "Front-end Developer (React, Angular)", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9873), null, false, "CSS", null },
                    { new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9913), null, false, "NodeJS", null },
                    { new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9872), null, false, "HTML", null },
                    { new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9870), null, false, "JavaScript", null },
                    { new Guid("51373385-dce2-458c-a06b-9b20625b7702"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9868), null, false, "Java", null },
                    { new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9909), null, false, "NoSQL - MongoDB", null },
                    { new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9864), null, false, "C#", null },
                    { new Guid("76a48392-0e58-496a-ae78-562df47896b7"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9874), null, false, "SQL", null },
                    { new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9912), null, false, "React", null },
                    { new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9869), null, false, "Python", null },
                    { new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9914), null, false, "Spring Boot", null },
                    { new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9910), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("02336e62-bcca-407a-9a37-bdc5ba9f54f4"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Córdoba" },
                    { new Guid("05c10bed-5f0c-4b0f-a17d-c1b775fea34f"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Imbabura" },
                    { new Guid("05d4771c-63db-4201-9826-a8264cffdb0b"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Bolívar" },
                    { new Guid("09fe2dfa-a01e-4fa7-8eed-81d955e08973"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Cauca" },
                    { new Guid("0cd76e95-172d-4162-af61-63158c0d7a1b"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Arauca" },
                    { new Guid("13065840-a869-47cd-8017-1e8da089a2fe"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Galápagos" },
                    { new Guid("1b721ce8-cfb0-4c2e-a85f-0d7c2265a918"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "San Andrés y Providencia" },
                    { new Guid("1f5aba30-14ed-454d-9a5b-1c340de467e6"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Nariño" },
                    { new Guid("2a59ca25-19dc-4cc2-bae8-385b95d2db7c"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Esmeraldas" },
                    { new Guid("2c5afd75-2b8e-4934-abb6-bb9a1cc348ae"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Caquetá" },
                    { new Guid("2e849b12-8413-4c0d-8370-9a1e5c4ed3fa"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Atlántico" },
                    { new Guid("479d6baa-c304-42ef-87cc-d31256c94a48"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Azuay" },
                    { new Guid("49c5cdb0-0d76-4a4e-8c04-be02c2f27b9c"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Napo" },
                    { new Guid("55b9f4ef-53bd-4c36-8e92-53ca189b619d"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Chimborazo" },
                    { new Guid("563ef041-4c49-439b-b9c4-b05d726965e7"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Tolima" },
                    { new Guid("58146754-4d74-4de2-825b-dcd15b6f606d"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Guaviare" },
                    { new Guid("5d26b7c3-0367-4f9e-9317-e74c2897c3de"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Cesar" },
                    { new Guid("5f500f5e-4fb6-4aa6-aab4-78dedf2807a7"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Chocó" },
                    { new Guid("692caebb-1f5a-4305-84aa-9fa476d4b828"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Vaupés" },
                    { new Guid("74696ce9-00d5-493a-bbe6-f7030496b9d1"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Guainía" },
                    { new Guid("75cae8ed-6ad0-4fbb-a9e0-abf9fcf33fa9"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Casanare" },
                    { new Guid("852530ae-50ff-43c9-8195-4563b8e25f05"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Cotopaxi" },
                    { new Guid("85f1567d-d712-42e2-bfb9-44629566e1ee"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Bolívar" },
                    { new Guid("8635b7d0-f807-4bc6-80e8-fe7a68c297d3"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Huila" },
                    { new Guid("864e29e5-c424-48e5-9e00-6d6e31747732"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Morona Santiago" },
                    { new Guid("878a2ee1-fca1-4bbc-90d8-57deb9abd81b"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Manabí" },
                    { new Guid("8978a6ec-7ee6-4fac-abb8-6776b80b1aba"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Guayas" },
                    { new Guid("8b0c8333-1dee-4c64-8749-a3b5b09e2339"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Sucre" },
                    { new Guid("a1de1136-5598-4cf8-9437-48c2a434e19a"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Norte de Santander" },
                    { new Guid("a2a5017d-6a72-431c-a829-84b9cab7f6b4"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Cundinamarca" },
                    { new Guid("a607a2f1-1506-43db-9979-a4259d2b6088"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Valle del Cauca" },
                    { new Guid("a9ae4df4-417a-4ed3-8e90-6a982000c334"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Quindío" },
                    { new Guid("a9c69a58-a635-43a4-a823-128b94f03ab7"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Risaralda" },
                    { new Guid("bb66eae0-6494-414e-b791-b3e9ff9115e9"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Antioquia" },
                    { new Guid("c0398a0a-7a42-4657-9a21-c55475ddfd8f"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Meta" },
                    { new Guid("c0bc2457-b549-4bad-a6ec-3b6f93ceb692"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "La Guajira" },
                    { new Guid("c2f92343-1d7e-4d25-ab29-aed63297c03c"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Santander" },
                    { new Guid("c95ecd23-027b-4471-8d87-3e00cdc2d643"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Vichada" },
                    { new Guid("cff2c94b-6b92-483e-90b6-341ecddc5dd5"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Loja" },
                    { new Guid("d46812b4-0837-495c-9919-cfdf29c3ba2a"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Caldas" },
                    { new Guid("e55ecd4b-e404-411a-a532-55c750a265bb"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "El Oro" },
                    { new Guid("e8584e9b-1dd5-40c6-a3fe-14fe98be098b"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Magdalena" },
                    { new Guid("eb2efcda-41fc-4bc5-9fb3-c96fd4f61d5c"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Carchi" },
                    { new Guid("ecf6d972-38d5-4866-859d-215119c5cf1a"), new Guid("06257294-f18e-439f-87c5-0d4b3805b66b"), false, "Cañar" },
                    { new Guid("f0ef3eb5-1785-4321-be25-3aeed9d74933"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Amazonas" },
                    { new Guid("f661afe4-7b2c-4d9f-847f-d85dad5b6ec9"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Boyacá" },
                    { new Guid("f7e1dd9d-cdbc-440c-b40e-7c67ea4ccf60"), new Guid("493213c2-70bd-47f5-bdd4-fb072398618e"), false, "Putumayo" }
                });

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("000fa9ee-518c-48d0-8506-d64f061fc8e2"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(121), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("002a21cc-213a-4ca9-ad98-173083d65fa7"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(69), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("0ae3b411-e58f-4912-b12e-69510040b830"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(119), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("18f78efd-3e32-4769-a843-19980565e56c"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(122), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("2e965006-28e2-4e0e-9781-9bbd16ffdd8b"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(63), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("323606ef-e136-45ca-90ad-9a438507e93d"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(71), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("333dde46-0dfc-40cd-9aa8-c45abccc996f"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(118), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("3c0f59e6-f19d-404b-bd5c-1f0e5def9c62"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(81), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("3f813127-26c4-4393-9cbe-0e5a125c9bc2"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(114), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("40a65473-0763-486d-9799-310462b94e8b"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(57), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("4cb6bd82-4313-4c55-a511-37771c53b4bc"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(76), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("59f42e74-9250-4f23-b1c6-0e34b9e7962a"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(65), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("6bd0e6f6-2b29-4c24-b778-0e8257ad9501"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(116), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("782c718f-60d0-4cd8-96e0-89d3265648e0"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(62), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("d417af9b-969e-4eeb-a585-630b98a07f8c"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(72), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("e52751b7-ff21-4541-8ce6-bbc5c5f31a3f"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(67), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null }
                });

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("067947a0-e9c2-4670-99ee-5607d7f22ad6"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(6), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("08accd31-c3f6-4d99-bf61-f53f9a2baa52"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9987), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("0a23178f-b9d8-4c53-88a5-4627b196e9d8"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9990), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("0d43c949-ffa0-416b-95dd-07ed1ea59c08"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9967), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("35a251a7-8092-44eb-ad6b-b14df93fb151"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9984), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("3a4b8794-6647-47d2-be9d-fe4e2c8f8cba"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9966), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("63e13a86-3060-45ee-bc71-2a8e2087a750"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9970), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("64132f17-790e-4356-a5bb-acd2ef7b46f4"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(12), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("65c471e8-d95e-4052-98c0-d43611c9d544"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9975), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("67970b3d-5929-4b5f-885c-72c59890a217"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9985), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("703c5a48-45ec-4265-b6ca-bf1962c6ed65"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("71d955c6-1377-4c82-b675-c6b4762f97db"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9974), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("82ec8b36-0b74-4896-9065-98d03728b3f8"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9971), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("88db0e9e-340b-4a25-b0f9-9ef271b80bf7"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9981), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("8fcba81a-0baa-4168-b3f2-83f5cbe45c70"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(9), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("93bb70cd-35b1-407e-8cf4-274970974563"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(14), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("b1b6f995-f766-4282-9613-0358b86cd037"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9993), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("c1c8c585-8978-44c8-8e0d-ee5b088d98b1"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(3), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("cd13a1de-1859-44e3-8a7c-13057667f837"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9959), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("de06ffb1-e88d-400d-81d5-a55ea022f76e"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(11), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("dfbcc740-a437-458b-a602-4b929b8090d2"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9989), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("e249144d-b1dc-473d-9efa-55b2eda0e29c"), new DateTime(2024, 6, 9, 7, 14, 45, 496, DateTimeKind.Utc).AddTicks(5), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("ecff0e24-7f32-4d27-8009-3e7c2e9d090b"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9977), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("f8a7ae2d-2bdd-42ae-9a56-f1ee0c653a21"), new DateTime(2024, 6, 9, 7, 14, 45, 495, DateTimeKind.Utc).AddTicks(9994), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("05bfca65-2a4b-456a-9733-2cad8bb0e9f5"), false, "Santa Rosalía", new Guid("692caebb-1f5a-4305-84aa-9fa476d4b828") },
                    { new Guid("0ecc16a7-490f-4553-bd6c-c6c5b0cec29f"), false, "Neiva", new Guid("8635b7d0-f807-4bc6-80e8-fe7a68c297d3") },
                    { new Guid("110f7d2a-99bb-406d-9ce3-9ddb8bc93b24"), false, "La Paz", new Guid("5d26b7c3-0367-4f9e-9317-e74c2897c3de") },
                    { new Guid("157639ba-61f4-4a49-8043-e4ed8d2c65c1"), false, "Mitú", new Guid("692caebb-1f5a-4305-84aa-9fa476d4b828") },
                    { new Guid("162d83ae-c6af-42bd-ad8b-3e034e0da9b0"), false, "Yavaraté", new Guid("692caebb-1f5a-4305-84aa-9fa476d4b828") },
                    { new Guid("18dbc2d6-8ce8-4b0a-95d3-0aaa7453d719"), false, "Portoviejo", new Guid("878a2ee1-fca1-4bbc-90d8-57deb9abd81b") },
                    { new Guid("1b120bb1-ca75-4a82-a0f7-15d11cdcf945"), false, "Girón", new Guid("479d6baa-c304-42ef-87cc-d31256c94a48") },
                    { new Guid("1c8efa67-abac-4eb5-b325-3596513daf93"), false, "San Miguel de Bolívar", new Guid("85f1567d-d712-42e2-bfb9-44629566e1ee") },
                    { new Guid("1f93fc53-dd9f-4218-be63-ee2f1da5f45e"), false, "Saraguro", new Guid("cff2c94b-6b92-483e-90b6-341ecddc5dd5") },
                    { new Guid("205deba4-1cdd-4447-8e2c-cace2aa2853b"), false, "Aracataca", new Guid("e8584e9b-1dd5-40c6-a3fe-14fe98be098b") },
                    { new Guid("240a9e5e-ccbd-423d-9dc2-572507546bc1"), false, "Ibagué", new Guid("563ef041-4c49-439b-b9c4-b05d726965e7") },
                    { new Guid("25189742-696a-4206-aa95-19afcdab407a"), false, "Pereira", new Guid("d46812b4-0837-495c-9919-cfdf29c3ba2a") },
                    { new Guid("278d2de4-0aa9-4390-89aa-c2f5dba50153"), false, "La Tebaida", new Guid("a9ae4df4-417a-4ed3-8e90-6a982000c334") },
                    { new Guid("2ab73da1-0ab7-4192-a153-9ae35c5ab222"), false, "Manizales", new Guid("d46812b4-0837-495c-9919-cfdf29c3ba2a") },
                    { new Guid("2c32a608-e743-4fe8-b563-8ac3530c2082"), false, "Silvia", new Guid("09fe2dfa-a01e-4fa7-8eed-81d955e08973") },
                    { new Guid("2d7e225e-494e-4763-bf01-5f594a9280e3"), false, "Tunja", new Guid("f661afe4-7b2c-4d9f-847f-d85dad5b6ec9") },
                    { new Guid("2f48630c-c2e8-4abb-9720-9765b9ffc526"), false, "Leticia", new Guid("f0ef3eb5-1785-4321-be25-3aeed9d74933") },
                    { new Guid("30c4b85e-745f-43e8-b865-d9c397d62492"), false, "Novita", new Guid("5f500f5e-4fb6-4aa6-aab4-78dedf2807a7") },
                    { new Guid("30c5cf39-8592-486f-88fa-1e04e2b17222"), false, "Mocoa", new Guid("f7e1dd9d-cdbc-440c-b40e-7c67ea4ccf60") },
                    { new Guid("31e62d1c-ecf6-47fa-8a16-19ffb833ecb8"), false, "Durán", new Guid("8978a6ec-7ee6-4fac-abb8-6776b80b1aba") },
                    { new Guid("34f5683a-e41f-4ed9-8d73-6739ca4ba3fd"), false, "Honda", new Guid("563ef041-4c49-439b-b9c4-b05d726965e7") },
                    { new Guid("3e8dc213-2247-49e1-b875-2e7c151e9c81"), false, "Esmeraldas", new Guid("2a59ca25-19dc-4cc2-bae8-385b95d2db7c") },
                    { new Guid("3f18eeb9-d079-4ad2-a833-d24b3f66b8c4"), false, "Turbo", new Guid("bb66eae0-6494-414e-b791-b3e9ff9115e9") },
                    { new Guid("413355fd-b504-4efe-ba75-f39bf77cd79e"), false, "Florencia", new Guid("2c5afd75-2b8e-4934-abb6-bb9a1cc348ae") },
                    { new Guid("41a91ad0-4759-4ec9-bf3f-b44244f5de36"), false, "Puerto Colombia", new Guid("2e849b12-8413-4c0d-8370-9a1e5c4ed3fa") },
                    { new Guid("45158c27-f9f0-438c-8ad5-9bb459dcd75c"), false, "Bogotá", new Guid("a2a5017d-6a72-431c-a829-84b9cab7f6b4") },
                    { new Guid("47538417-e48b-4d21-90bd-a04651f024db"), false, "Villavicencio", new Guid("c0398a0a-7a42-4657-9a21-c55475ddfd8f") },
                    { new Guid("487895cc-883b-4a80-9363-d900cb5c199d"), false, "Memarí", new Guid("74696ce9-00d5-493a-bbe6-f7030496b9d1") },
                    { new Guid("4b4fa577-5bad-4fea-acf8-40f4fb32c52c"), false, "Otavalo", new Guid("05c10bed-5f0c-4b0f-a17d-c1b775fea34f") },
                    { new Guid("4ceaefc5-ff23-444b-a460-a84773d2ed26"), false, "Inírida", new Guid("74696ce9-00d5-493a-bbe6-f7030496b9d1") },
                    { new Guid("4e04e027-f805-4fe1-a318-405c7a548e4a"), false, "Valledupar", new Guid("5d26b7c3-0367-4f9e-9317-e74c2897c3de") },
                    { new Guid("52984ab2-15aa-4797-9232-ec844aef9f29"), false, "Armero Guayabal", new Guid("563ef041-4c49-439b-b9c4-b05d726965e7") },
                    { new Guid("54ebbd30-1ebe-4720-b6a7-729c80c6d2bd"), false, "Salcedo", new Guid("852530ae-50ff-43c9-8195-4563b8e25f05") },
                    { new Guid("56440b84-7d73-4f1f-9e3f-d2b650b11c18"), false, "Pitalito", new Guid("8635b7d0-f807-4bc6-80e8-fe7a68c297d3") },
                    { new Guid("5761f27d-2365-43d6-aaa9-9e01a62b3867"), false, "Puerto Carreño", new Guid("c95ecd23-027b-4471-8d87-3e00cdc2d643") },
                    { new Guid("5ae2b59d-d42d-4f47-bfc9-f193349884db"), false, "Puerto Asís", new Guid("f7e1dd9d-cdbc-440c-b40e-7c67ea4ccf60") },
                    { new Guid("5b1f510d-9526-4459-84e1-3a7b4020665b"), false, "El Tambo", new Guid("ecf6d972-38d5-4866-859d-215119c5cf1a") },
                    { new Guid("616da0a0-710b-4eb1-a310-34695157d662"), false, "Barranquilla", new Guid("2e849b12-8413-4c0d-8370-9a1e5c4ed3fa") },
                    { new Guid("624c3503-c920-4fce-bd72-cc4998a6d2c7"), false, "Ipiales", new Guid("1f5aba30-14ed-454d-9a5b-1c340de467e6") },
                    { new Guid("6e478fef-aeb0-4d3d-96a2-4fb3aee7e446"), false, "El Guabo", new Guid("eb2efcda-41fc-4bc5-9fb3-c96fd4f61d5c") },
                    { new Guid("6f92cc96-1e01-4842-b5dc-5b4dc68b61d4"), false, "Cuenca", new Guid("479d6baa-c304-42ef-87cc-d31256c94a48") },
                    { new Guid("6f976a7f-03e9-4bd0-8fc6-75b235e544af"), false, "Atacames", new Guid("2a59ca25-19dc-4cc2-bae8-385b95d2db7c") },
                    { new Guid("775d5ff5-0bd4-4be3-8548-517a4186c3f8"), false, "Orito", new Guid("f7e1dd9d-cdbc-440c-b40e-7c67ea4ccf60") },
                    { new Guid("776034bf-3ece-4f64-ae3b-16e3c87255e7"), false, "Yopal", new Guid("75cae8ed-6ad0-4fbb-a9e0-abf9fcf33fa9") },
                    { new Guid("7b268edd-8b03-4ac7-ab0f-fc93c2832a84"), false, "Uribia", new Guid("c0bc2457-b549-4bad-a6ec-3b6f93ceb692") },
                    { new Guid("7bf37666-5738-4424-803e-5465e1f36583"), false, "Cartagena del Chairá", new Guid("05d4771c-63db-4201-9826-a8264cffdb0b") },
                    { new Guid("7e1813c7-13e6-4151-b477-a732ac0990bf"), false, "Loja", new Guid("cff2c94b-6b92-483e-90b6-341ecddc5dd5") },
                    { new Guid("7f58f96f-806f-4a52-8d80-b6e721480816"), false, "Montería", new Guid("8b0c8333-1dee-4c64-8749-a3b5b09e2339") },
                    { new Guid("81a3858f-d9b5-471a-820e-b2760a922071"), false, "Morelia", new Guid("2c5afd75-2b8e-4934-abb6-bb9a1cc348ae") },
                    { new Guid("83e9de11-b454-4f6e-8b8b-105565119461"), false, "Latacunga", new Guid("852530ae-50ff-43c9-8195-4563b8e25f05") },
                    { new Guid("841eebbe-e429-4ae7-aa73-1a694b5b424a"), false, "Sogamoso", new Guid("f661afe4-7b2c-4d9f-847f-d85dad5b6ec9") },
                    { new Guid("85528133-da92-4e8d-a4e1-424f5e7a6a2f"), false, "Arauca", new Guid("0cd76e95-172d-4162-af61-63158c0d7a1b") },
                    { new Guid("85abea90-768f-4cdb-8512-aa974c51ea85"), false, "Garzón", new Guid("8635b7d0-f807-4bc6-80e8-fe7a68c297d3") },
                    { new Guid("8661e6fe-98d9-40bc-81d6-7b940b0f0857"), false, "Sincelejo", new Guid("8b0c8333-1dee-4c64-8749-a3b5b09e2339") },
                    { new Guid("888b8023-c9e8-49c6-8bb8-089b9c8157f3"), false, "Maicao", new Guid("c0bc2457-b549-4bad-a6ec-3b6f93ceb692") },
                    { new Guid("88b9f598-2247-4f29-9540-06e6bc47a951"), false, "Soledad", new Guid("2e849b12-8413-4c0d-8370-9a1e5c4ed3fa") },
                    { new Guid("88c0ea5e-3a59-47ef-bbdd-5542aa8c5a22"), false, "Popayán", new Guid("09fe2dfa-a01e-4fa7-8eed-81d955e08973") },
                    { new Guid("8c1fb72f-1d13-4367-b333-e75af5fd55cb"), false, "Chone", new Guid("878a2ee1-fca1-4bbc-90d8-57deb9abd81b") },
                    { new Guid("8d8dd8cb-0ebf-4319-8a40-31dee7842e76"), false, "Cúcuta", new Guid("a1de1136-5598-4cf8-9437-48c2a434e19a") },
                    { new Guid("91946543-e770-49f6-84b9-a2f6ec489e49"), false, "Santa Helena", new Guid("c95ecd23-027b-4471-8d87-3e00cdc2d643") },
                    { new Guid("91f01f0b-3dfa-4bf6-8920-61fe0e5d594d"), false, "La Primavera", new Guid("c95ecd23-027b-4471-8d87-3e00cdc2d643") },
                    { new Guid("91f19e3d-4fdf-424f-90e8-ee2b3612f627"), false, "Santa Marta", new Guid("e8584e9b-1dd5-40c6-a3fe-14fe98be098b") },
                    { new Guid("97ab5b9d-4b0f-4eb5-9d78-004527085fb5"), false, "Granada", new Guid("c0398a0a-7a42-4657-9a21-c55475ddfd8f") },
                    { new Guid("97f22901-9b81-4859-a901-e5c18880fb1d"), false, "Bucaramanga", new Guid("c2f92343-1d7e-4d25-ab29-aed63297c03c") },
                    { new Guid("9a213258-8117-4b71-b235-5524c198bc14"), false, "Tena", new Guid("49c5cdb0-0d76-4a4e-8c04-be02c2f27b9c") },
                    { new Guid("9af4a846-f29f-4031-a94e-becf141bb518"), false, "Lorica", new Guid("02336e62-bcca-407a-9a37-bdc5ba9f54f4") },
                    { new Guid("9bfa969e-d5ac-45ec-9865-d687cb0385b2"), false, "Riohacha", new Guid("c0bc2457-b549-4bad-a6ec-3b6f93ceb692") },
                    { new Guid("a02a57f8-419c-4da9-9b44-03011da18afd"), false, "Puerto Baquerizo Moreno", new Guid("13065840-a869-47cd-8017-1e8da089a2fe") },
                    { new Guid("a29acf3b-7088-4a3d-8079-7ec7afeca61b"), false, "Soacha", new Guid("a2a5017d-6a72-431c-a829-84b9cab7f6b4") },
                    { new Guid("a40b672f-decc-4ba3-b027-bcf9bf9e09e8"), false, "Montería", new Guid("02336e62-bcca-407a-9a37-bdc5ba9f54f4") },
                    { new Guid("a531096f-9a9d-4f3b-a37c-e99c88a4254b"), false, "San Juan de Pasto", new Guid("1f5aba30-14ed-454d-9a5b-1c340de467e6") },
                    { new Guid("a908fd7f-5757-42d3-9202-bb613e3deed0"), false, "Calarcá", new Guid("a9ae4df4-417a-4ed3-8e90-6a982000c334") },
                    { new Guid("a9c9cc6f-2302-444b-b549-66225e8438d2"), false, "Azogues", new Guid("ecf6d972-38d5-4866-859d-215119c5cf1a") },
                    { new Guid("aac1d876-f222-498e-a4fb-6cfe64cdbe49"), false, "Dosquebradas", new Guid("a9c69a58-a635-43a4-a823-128b94f03ab7") },
                    { new Guid("aac33b31-7f58-43e2-84d8-5926d741fde2"), false, "Fortul", new Guid("0cd76e95-172d-4162-af61-63158c0d7a1b") },
                    { new Guid("aaffeef0-8130-4d45-a05e-c2890f86f9bb"), false, "Armenia", new Guid("a9ae4df4-417a-4ed3-8e90-6a982000c334") },
                    { new Guid("abb318b5-2eef-4c09-b20c-d66b07e3b0b3"), false, "Cereté", new Guid("02336e62-bcca-407a-9a37-bdc5ba9f54f4") },
                    { new Guid("acfd4369-c1ee-4bf8-ab71-ac77a6f88a6d"), false, "Aguazul", new Guid("75cae8ed-6ad0-4fbb-a9e0-abf9fcf33fa9") },
                    { new Guid("af8df5cc-b8fe-4633-ae36-5cf00ff10fd5"), false, "Cartagena del Chairá", new Guid("2c5afd75-2b8e-4934-abb6-bb9a1cc348ae") },
                    { new Guid("af9a8ad6-0468-43fc-9f6c-2b3db15d6160"), false, "Tumaco", new Guid("1f5aba30-14ed-454d-9a5b-1c340de467e6") },
                    { new Guid("b22b943d-61cb-450e-95bd-b6dfdefdb408"), false, "Zipaquirá", new Guid("a2a5017d-6a72-431c-a829-84b9cab7f6b4") },
                    { new Guid("b4a17817-d15f-4761-b9de-a636ed2240b1"), false, "Ciénaga", new Guid("e8584e9b-1dd5-40c6-a3fe-14fe98be098b") },
                    { new Guid("b6c1be41-d62b-48e1-8b25-b7cb0909d66f"), false, "Aguachica", new Guid("5d26b7c3-0367-4f9e-9317-e74c2897c3de") },
                    { new Guid("b910e7a7-ec4a-416b-b932-5bdf5f842088"), false, "Alausí", new Guid("55b9f4ef-53bd-4c36-8e92-53ca189b619d") },
                    { new Guid("bc06df81-c475-43c0-9d74-6f6e2a920eb7"), false, "Saravena", new Guid("0cd76e95-172d-4162-af61-63158c0d7a1b") },
                    { new Guid("bd57e90c-a6da-4554-be4c-5fca89f2a6c2"), false, "Ocaña", new Guid("a1de1136-5598-4cf8-9437-48c2a434e19a") },
                    { new Guid("bfb81ef6-2fb5-4448-837d-271af6f36542"), false, "Santa Rosa de Cabal", new Guid("a9c69a58-a635-43a4-a823-128b94f03ab7") },
                    { new Guid("c5022b36-d7eb-43ab-a25f-be97d272c442"), false, "Pereira", new Guid("a9c69a58-a635-43a4-a823-128b94f03ab7") },
                    { new Guid("c50a3eff-3fde-47dc-b08b-028328313233"), false, "Chinchiná", new Guid("d46812b4-0837-495c-9919-cfdf29c3ba2a") },
                    { new Guid("c5701496-f6f0-4fc0-8e95-63692b9f708a"), false, "Duitama", new Guid("f661afe4-7b2c-4d9f-847f-d85dad5b6ec9") },
                    { new Guid("c6182efb-ecba-41c8-b7c8-22e7b372f570"), false, "Riobamba", new Guid("55b9f4ef-53bd-4c36-8e92-53ca189b619d") },
                    { new Guid("c737d2a2-f7d9-4159-85c1-06bb574be909"), false, "San Cristóbal", new Guid("13065840-a869-47cd-8017-1e8da089a2fe") },
                    { new Guid("ca835e61-13b3-405c-9d0c-6f1f32e34b08"), false, "Manta", new Guid("878a2ee1-fca1-4bbc-90d8-57deb9abd81b") },
                    { new Guid("cc5ee39b-9e5e-435b-9b78-9f9d41475863"), false, "Santa Catalina", new Guid("1b721ce8-cfb0-4c2e-a85f-0d7c2265a918") },
                    { new Guid("ccc5df9e-9559-40c4-90ea-9b7263877036"), false, "Tulcán", new Guid("eb2efcda-41fc-4bc5-9fb3-c96fd4f61d5c") },
                    { new Guid("cd2438cc-8f4b-46c2-9a86-76d80f7952dc"), false, "Apartadó", new Guid("bb66eae0-6494-414e-b791-b3e9ff9115e9") },
                    { new Guid("d2955b07-29df-42a7-b339-29594697a8ea"), false, "Gualaquiza", new Guid("864e29e5-c424-48e5-9e00-6d6e31747732") },
                    { new Guid("d4b08976-cb0e-4203-b876-afb4a158f738"), false, "Cali", new Guid("a607a2f1-1506-43db-9979-a4259d2b6088") },
                    { new Guid("d5992f89-3904-416c-8950-78620251752d"), false, "San José del Guaviare", new Guid("58146754-4d74-4de2-825b-dcd15b6f606d") },
                    { new Guid("d6ffcd0a-27c3-43f9-865b-00c1410db291"), false, "Medellín", new Guid("bb66eae0-6494-414e-b791-b3e9ff9115e9") },
                    { new Guid("d7ea2469-1d60-43fc-9c7f-af21e7f189c5"), false, "Piedecuesta", new Guid("c2f92343-1d7e-4d25-ab29-aed63297c03c") },
                    { new Guid("d8f37c89-9ee8-4485-afc6-030167b5e144"), false, "Istmina", new Guid("5f500f5e-4fb6-4aa6-aab4-78dedf2807a7") },
                    { new Guid("d900a4d7-4779-478d-b239-5be3d6738f5b"), false, "Puerto Inírida", new Guid("74696ce9-00d5-493a-bbe6-f7030496b9d1") },
                    { new Guid("dcb1a970-aae4-4063-8251-eb1e4d716b0b"), false, "Magangué", new Guid("05d4771c-63db-4201-9826-a8264cffdb0b") },
                    { new Guid("dd612971-338f-44e1-a8c6-9191e4bc5ae7"), false, "Pamplona", new Guid("a1de1136-5598-4cf8-9437-48c2a434e19a") },
                    { new Guid("e23b7084-d93c-41f5-9a86-76c43142ef43"), false, "Providencia", new Guid("1b721ce8-cfb0-4c2e-a85f-0d7c2265a918") },
                    { new Guid("e770f558-968e-46dc-aba5-f547730f359f"), false, "Buenaventura", new Guid("a607a2f1-1506-43db-9979-a4259d2b6088") },
                    { new Guid("e7e9ee7c-7076-4fe6-8c0f-0de02890a38a"), false, "Guaranda", new Guid("85f1567d-d712-42e2-bfb9-44629566e1ee") },
                    { new Guid("e83c1cbf-0aa5-4246-87dd-a99a1449d194"), false, "Macas", new Guid("864e29e5-c424-48e5-9e00-6d6e31747732") },
                    { new Guid("eac33e09-7714-48e8-81d4-a977a77a8d60"), false, "El Retén", new Guid("58146754-4d74-4de2-825b-dcd15b6f606d") },
                    { new Guid("ecee3de0-6fbb-4ae5-93dd-2804d34945f7"), false, "Guayaquil", new Guid("8978a6ec-7ee6-4fac-abb8-6776b80b1aba") },
                    { new Guid("ee1cdf1a-caf5-4028-9b7d-c83852e481ff"), false, "Santa Rosa", new Guid("e55ecd4b-e404-411a-a532-55c750a265bb") },
                    { new Guid("f07e9862-9fa6-4d54-a48a-0ab5f9c79c2c"), false, "Cartagena de Indias", new Guid("05d4771c-63db-4201-9826-a8264cffdb0b") },
                    { new Guid("f1117954-1270-468d-9a1e-d070e450f49d"), false, "Calamar", new Guid("58146754-4d74-4de2-825b-dcd15b6f606d") },
                    { new Guid("f3d3a914-1b0a-451f-b0d5-0290a2ea4435"), false, "Tauramena", new Guid("75cae8ed-6ad0-4fbb-a9e0-abf9fcf33fa9") },
                    { new Guid("f789ed8b-4755-4572-8bb7-c8e4ea68636c"), false, "Archidona", new Guid("49c5cdb0-0d76-4a4e-8c04-be02c2f27b9c") },
                    { new Guid("f79018a2-a20b-42c9-8500-1e9438acf98f"), false, "Ibarra", new Guid("05c10bed-5f0c-4b0f-a17d-c1b775fea34f") },
                    { new Guid("f8980b29-4ad8-479b-a2c3-ccddba6e2a9d"), false, "Machala", new Guid("e55ecd4b-e404-411a-a532-55c750a265bb") },
                    { new Guid("f9c3f4b3-fe94-424c-9065-30ab032bea9a"), false, "Corozal", new Guid("8b0c8333-1dee-4c64-8749-a3b5b09e2339") },
                    { new Guid("fa0a02bf-1f6b-4c32-a98f-4711b7ee6feb"), false, "Acacias", new Guid("c0398a0a-7a42-4657-9a21-c55475ddfd8f") },
                    { new Guid("fa5ce103-2014-4ffd-8fe1-671326f15fc1"), false, "Barrancabermeja", new Guid("c2f92343-1d7e-4d25-ab29-aed63297c03c") },
                    { new Guid("fc9292e4-35c7-4dc0-9650-bada7f5c4523"), false, "Santander de Quilichao", new Guid("09fe2dfa-a01e-4fa7-8eed-81d955e08973") },
                    { new Guid("fcce05c2-9f01-4c91-bc9e-4c068f4dcc0c"), false, "Quibdó", new Guid("5f500f5e-4fb6-4aa6-aab4-78dedf2807a7") },
                    { new Guid("fd201301-ca31-442d-adc0-70931d302ee3"), false, "San Andrés", new Guid("1b721ce8-cfb0-4c2e-a85f-0d7c2265a918") },
                    { new Guid("fe0a6700-d84f-4daf-a7d4-18bc56dee9a4"), false, "Palmira", new Guid("a607a2f1-1506-43db-9979-a4259d2b6088") }
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
