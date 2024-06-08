using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
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
                    { new Guid("00e17bf9-8fb9-4510-b30f-eb1c99071c52"), false, "Chile" },
                    { new Guid("05e313c5-9507-46a9-8c0d-f8a05f416962"), false, "Perú" },
                    { new Guid("1b61090c-c7b4-4572-bcf2-86d68fb76bf7"), false, "Bolivia" },
                    { new Guid("1bf0144b-cb8e-45d6-a878-6aeeae1b5b06"), false, "Guatemala" },
                    { new Guid("1c7d5316-5c2a-46e6-9c57-67d7c44fb041"), false, "Panamá" },
                    { new Guid("316427a7-3a13-4dba-aab8-980df107bf76"), false, "Brasil" },
                    { new Guid("4074f3e3-c907-45f4-ac56-ceae95701b55"), false, "El Salvador" },
                    { new Guid("4645eedd-da25-4cbc-83cd-00550c96ae30"), false, "Belize" },
                    { new Guid("4b701d14-9048-4ab8-a32c-12a3bcae57e9"), false, "Honduras" },
                    { new Guid("6d118f7e-7745-4a9d-a87e-fced17a7d818"), false, "Paraguay" },
                    { new Guid("78ec825c-82dd-4e81-963c-4cfa4f47dbfd"), false, "Argentina" },
                    { new Guid("a3c806f4-8f75-4b55-92e3-f55e176eb451"), false, "México" },
                    { new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Ecuador" },
                    { new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Colombia" },
                    { new Guid("cc548c74-764c-44ac-a166-b4147fabff7c"), false, "Uruguay" },
                    { new Guid("cd8698a5-adb3-47fe-9bd3-4000b56f6f06"), false, "Costa Rica" },
                    { new Guid("d72b298e-d615-4718-a802-b6add66490ce"), false, "Nicaragua" },
                    { new Guid("da2104b7-ef5b-4dba-b9db-56709463a41e"), false, "Venezuela" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("22f62994-5a6d-4f87-a489-d5f23d63f56e"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(866), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("25ad2a38-4f4e-4094-b415-62ccde1ccc88"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(853), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("28d827f6-7f4f-4e57-90f1-d20e948e4094"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(890), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("30e580b5-de46-44ab-85bc-0dc3ff9479e6"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(849), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("3d022162-b6ce-4322-82f4-8475da176ebb"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(870), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("3e0fbef6-bdaa-4f6c-b4fe-db4ea0e3994a"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(894), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("409c96dc-4d63-464b-9ef7-0ea7f029ad1f"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(878), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("624a34e0-b88b-4e87-9c9c-5ffb86839fe9"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(882), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("6960f85b-af13-4420-85ef-b08db68d2d91"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(886), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("7123337c-65b7-46f2-aa95-8d830c224dcc"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(862), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("9cb642e1-6be1-481f-811b-2d8ecabab241"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(898), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("a190addf-24cd-48e3-ac76-3802b1d6583e"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(845), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("c76b3c1d-1225-4fe9-9ef1-4a86a04b1c64"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(857), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("dde52fc4-2e40-4120-98d3-6264d7fd4a9c"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(839), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("f8580244-32f7-4675-8552-f5cef67fe947"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(874), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(472), null, null, false, "Full Stack Developer (C#, Angular)", null },
                    { new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(475), null, null, false, "Back-end Developer (Java, Python)", null },
                    { new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(477), null, null, false, "Front-end Developer (React, Angular)", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(508), null, false, "CSS", null },
                    { new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(513), null, false, "NodeJS", null },
                    { new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(507), null, false, "HTML", null },
                    { new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(506), null, false, "JavaScript", null },
                    { new Guid("51373385-dce2-458c-a06b-9b20625b7702"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(504), null, false, "Java", null },
                    { new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(510), null, false, "NoSQL - MongoDB", null },
                    { new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(501), null, false, "C#", null },
                    { new Guid("76a48392-0e58-496a-ae78-562df47896b7"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(509), null, false, "SQL", null },
                    { new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(512), null, false, "React", null },
                    { new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(505), null, false, "Python", null },
                    { new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(560), null, false, "Spring Boot", null },
                    { new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(511), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("060076de-2049-4047-ac02-c1ddfddb2785"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Vaupés" },
                    { new Guid("0e335cb6-46a9-4357-978c-2f5d2f0ac6de"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Amazonas" },
                    { new Guid("0f3e2774-c747-4e44-b14c-c3f0a16627e4"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Nariño" },
                    { new Guid("113e847f-828a-4d8b-9ec1-0c918aa6d1ab"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Cundinamarca" },
                    { new Guid("125281c1-9bc5-4c43-ac03-de976afb35c5"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "San Andrés y Providencia" },
                    { new Guid("16d1d70a-2c0c-41bc-8dfe-859c519f5d49"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Santander" },
                    { new Guid("22961c2e-9148-4f64-94d3-8f81fd884d95"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Sucre" },
                    { new Guid("2a48cf39-2a16-46f0-a957-7c90a7da4a6e"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Magdalena" },
                    { new Guid("2c6352e2-614f-444c-8bd1-559a4e2b2de6"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Cotopaxi" },
                    { new Guid("306ea84e-f0d6-4506-ad01-3c021ac05761"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Cañar" },
                    { new Guid("36fe1850-a449-45ad-8f94-50957776ed84"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Cesar" },
                    { new Guid("38ece19b-6b0a-4375-8593-24395efc5b58"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Azuay" },
                    { new Guid("42e19e4f-d18c-483b-80ac-d06363f1905c"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Atlántico" },
                    { new Guid("43890e96-4f9d-4316-bc82-ad21b546c22f"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Guayas" },
                    { new Guid("45721019-9ace-4392-8641-0f1592459795"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Manabí" },
                    { new Guid("48648deb-53a8-4b4b-9269-d17e7cfb8af3"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Carchi" },
                    { new Guid("49880fee-a2de-4044-b7af-4f8f6f7bf268"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Loja" },
                    { new Guid("4b8debde-a862-49ce-b7e8-38fcf44ed9a8"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Meta" },
                    { new Guid("50d6a12a-3b6c-4979-9150-19d4d39ed1e1"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Tolima" },
                    { new Guid("544ed951-e98c-428e-962b-0a3227de8d9a"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Vichada" },
                    { new Guid("5ab7a630-cfc9-4423-beec-e92443b9e0a8"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Boyacá" },
                    { new Guid("604510c2-2c0a-43c0-adea-3a776383b502"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Chocó" },
                    { new Guid("66538ae9-8de6-415a-93fe-7a90f54aa45a"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Quindío" },
                    { new Guid("68f600d0-dc67-4b7a-91d9-a3dd549c7a4f"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Esmeraldas" },
                    { new Guid("6cd4d15a-f8b1-44ff-bb55-d8278070cb4a"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Napo" },
                    { new Guid("786baa00-388a-4c8c-a668-66ba36565c76"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Putumayo" },
                    { new Guid("79402fe9-2e83-4c71-bdbc-fedf08f15be4"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Guainía" },
                    { new Guid("7dfa8369-d61c-4c07-b700-3dc3f8b72db8"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Imbabura" },
                    { new Guid("898938e9-3d02-4e40-88b7-84adaf84ebe2"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Cauca" },
                    { new Guid("9e90ba5c-daf6-42a1-8363-ebb049021b0a"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Bolívar" },
                    { new Guid("a4415b8b-599e-4ceb-a677-c932f102c5e6"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Valle del Cauca" },
                    { new Guid("af19fcb0-b731-486b-bdd5-575615749d3e"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "El Oro" },
                    { new Guid("af3a3f67-ab5f-4191-befc-5c2bfad5ee49"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Arauca" },
                    { new Guid("af9163ea-49d6-4868-a2a3-01d6d694c144"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Caldas" },
                    { new Guid("b1906965-f654-41fa-b4ae-100d6920d95a"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Risaralda" },
                    { new Guid("b6365e8a-24db-4b33-9631-410786234ed8"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Huila" },
                    { new Guid("bf5d3243-e55b-463c-9bcb-654bc12a777b"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Córdoba" },
                    { new Guid("cad34b32-58be-49d8-983c-f54b81c1dcdf"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Casanare" },
                    { new Guid("d1088efc-5ca0-432c-8a08-c2243c2948a7"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Galápagos" },
                    { new Guid("d194fada-7771-45fb-94c4-081ecad5987b"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Morona Santiago" },
                    { new Guid("db5ed00b-0e51-4fbc-8824-70572c14ce70"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Antioquia" },
                    { new Guid("e8321fa3-b65f-4f74-847b-86eb000c2a30"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Caquetá" },
                    { new Guid("eb31e44a-8c86-4576-afda-4ac9ca7e5f25"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "La Guajira" },
                    { new Guid("eba3f311-1cc8-48fb-88d2-e7431745ec9e"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Guaviare" },
                    { new Guid("f118dbf3-5449-450e-85fd-eb2428376d04"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Bolívar" },
                    { new Guid("f44e3a53-66c5-4faa-a48c-17f5ef793e1e"), new Guid("bde16890-df6d-45d6-9cfd-00279deaed1c"), false, "Norte de Santander" },
                    { new Guid("f91a0ad5-36ad-40d6-84d7-076f2af85f8c"), new Guid("b097792b-0939-49ef-8d09-a5861bec35c0"), false, "Chimborazo" }
                });

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0d659998-117f-4d2f-9386-076cbb5884c7"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(739), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("0d905ee6-26ba-41e4-bcbc-a9adc7e5107e"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(772), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("12314cdf-c341-443e-9e9d-9a13da9cbc6c"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(728), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("17d5ed89-cccd-4577-b94f-e302e76cab6e"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(764), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("198cffcb-99cc-48dd-a269-5ef79f1cae0e"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(720), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("299e6d86-4ea2-431c-9968-811dac7335f6"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(761), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("2c6312ab-4259-452f-81cf-d5aee19a3a9b"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(754), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("483bdd20-f465-49d1-a0b1-30bf2cc24df7"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(758), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("7470995e-64a1-4f2f-8cdf-26f8059f69b6"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(731), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("9529cdc9-a337-4b84-a19c-c462f39517ed"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(735), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("a9a6a8aa-af88-4e64-ac81-e693a8394ba8"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(714), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("b003acfd-4bdf-4af8-966f-54390817faed"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(746), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("cccd76d1-819e-4748-90be-fa6f4955f8fe"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(750), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("cf7b0104-5891-4026-8678-4b71326973f8"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(724), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("e40181c4-6aa8-49af-9640-cd0aa393d7bf"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(768), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("fcd71f67-604e-4cc3-a702-eaef45699a6d"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(743), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null }
                });

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("00c6eb31-b348-45fa-95d5-35b2b5718a37"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(634), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("061f49d4-4a9f-4f99-bf2b-861a9c523189"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(665), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("0cd92f28-9470-4284-adf0-192428c07833"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(606), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("17d9f88d-c796-49ba-9994-c8e5fd78e352"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(622), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("21b47c52-c372-471c-9c92-a1921b7a71c8"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(684), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("2437e3bc-12e7-4ce6-91e0-81d653a8ba4a"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(642), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("2a44e7fe-0817-4adc-9272-5fcb4ac36ace"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(661), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("2ad60320-efc2-42ea-ab06-96d05f9c9d3a"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(680), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("3c6be918-d5c8-40f8-8a33-493df14ddd2d"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(657), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("627460d7-a98a-4fd1-a44a-4a8c102a8ece"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(615), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("62dd7b6a-4a5b-40db-9cd3-ec1237f8a704"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(598), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("73a74522-7dc6-49f1-b0cc-59c7737c6ef9"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(638), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("8646cc13-04f0-4e91-9a23-878f6cfe74a5"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(653), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("8a245d19-5a3a-41a5-8acf-75ec07466e37"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(669), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("987660e8-d0c6-4f03-8a3c-3e1a76f9aed4"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(619), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("aa8b5a27-72f6-4900-9c62-122db3af71e2"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(630), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("b123c936-54d7-4bb1-a36f-2ea3eb21a242"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(676), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("badfbcf1-e8ff-4788-bbd8-2c278b301da3"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(592), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("cf077086-9ff4-4c67-8d67-b17d6664f715"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(672), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("d9b72491-dabb-46ee-91b7-aba145ae21c5"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(645), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("d9d95e2b-ce75-4b67-9ad2-24b6e4e29164"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(610), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("e5ba7628-53ad-4ffd-8a71-e31a026f0861"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(649), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("f839e0a5-801b-4b63-82ba-c2e94b066cb8"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(626), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("f8c7de4d-30d1-4486-afeb-7475d665b6d4"), new DateTime(2024, 6, 8, 10, 11, 24, 582, DateTimeKind.Utc).AddTicks(602), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("017e0c14-6e98-4674-a4ac-02ce23f86c50"), false, "Inírida", new Guid("79402fe9-2e83-4c71-bdbc-fedf08f15be4") },
                    { new Guid("01e380be-138e-48f8-abd2-03fa3d721b1f"), false, "Portoviejo", new Guid("45721019-9ace-4392-8641-0f1592459795") },
                    { new Guid("067d572f-fce1-47b3-bc19-84cd1c8d8833"), false, "Santa Helena", new Guid("544ed951-e98c-428e-962b-0a3227de8d9a") },
                    { new Guid("06e04017-cb59-4000-a6d4-6ef193e3ea52"), false, "Calarcá", new Guid("66538ae9-8de6-415a-93fe-7a90f54aa45a") },
                    { new Guid("0bf668df-3610-45b2-92a5-6582ce55834b"), false, "Latacunga", new Guid("2c6352e2-614f-444c-8bd1-559a4e2b2de6") },
                    { new Guid("0c4ea21c-41d6-44cc-8287-1462b5b6a7c9"), false, "Santa Rosa de Cabal", new Guid("b1906965-f654-41fa-b4ae-100d6920d95a") },
                    { new Guid("0d37e968-ebaf-4fab-a1ae-b213281c29a4"), false, "Pamplona", new Guid("f44e3a53-66c5-4faa-a48c-17f5ef793e1e") },
                    { new Guid("0dd4e5c3-64f8-4a8f-b459-90437a2c4e96"), false, "Popayán", new Guid("898938e9-3d02-4e40-88b7-84adaf84ebe2") },
                    { new Guid("1137d45f-382c-4826-af35-2d0c9f62fcde"), false, "Morelia", new Guid("e8321fa3-b65f-4f74-847b-86eb000c2a30") },
                    { new Guid("13073c34-070c-4078-aec3-8d2e7ede8fb8"), false, "Aguazul", new Guid("cad34b32-58be-49d8-983c-f54b81c1dcdf") },
                    { new Guid("13dd97e0-f4c2-4e34-a290-1af8dade0ce7"), false, "Aguachica", new Guid("36fe1850-a449-45ad-8f94-50957776ed84") },
                    { new Guid("1478f1f2-be91-4203-917f-7963e8593951"), false, "Puerto Asís", new Guid("786baa00-388a-4c8c-a668-66ba36565c76") },
                    { new Guid("160b8863-1a62-4632-b7b9-ad81a5d9b1ae"), false, "Guayaquil", new Guid("43890e96-4f9d-4316-bc82-ad21b546c22f") },
                    { new Guid("17cc334b-25f0-459f-ad3f-db46e460c462"), false, "Sincelejo", new Guid("22961c2e-9148-4f64-94d3-8f81fd884d95") },
                    { new Guid("19df2b3b-34a7-444d-ab7f-c1470ad77a41"), false, "Girón", new Guid("38ece19b-6b0a-4375-8593-24395efc5b58") },
                    { new Guid("1c5de06f-e075-41db-861d-e68f7ce26211"), false, "Providencia", new Guid("125281c1-9bc5-4c43-ac03-de976afb35c5") },
                    { new Guid("1cce0c7b-1ed8-43b4-8180-9a2c43e1d4f7"), false, "Honda", new Guid("50d6a12a-3b6c-4979-9150-19d4d39ed1e1") },
                    { new Guid("1def1d4d-4674-49f0-8628-ba7368474cf8"), false, "Alausí", new Guid("f91a0ad5-36ad-40d6-84d7-076f2af85f8c") },
                    { new Guid("21e52df3-44dc-42a2-9c24-6348eab8f824"), false, "Buenaventura", new Guid("a4415b8b-599e-4ceb-a677-c932f102c5e6") },
                    { new Guid("24d7ae32-ca4c-4ac7-a7f7-83b30d2cc163"), false, "Bogotá", new Guid("113e847f-828a-4d8b-9ec1-0c918aa6d1ab") },
                    { new Guid("262aee56-203c-410f-b08a-44c13ce3d2df"), false, "Riobamba", new Guid("f91a0ad5-36ad-40d6-84d7-076f2af85f8c") },
                    { new Guid("26582aae-4f91-4d5c-a4b0-dfc359f45c59"), false, "Chinchiná", new Guid("af9163ea-49d6-4868-a2a3-01d6d694c144") },
                    { new Guid("26f08264-f1d0-48c5-b4f8-91c7d173dc5a"), false, "Armero Guayabal", new Guid("50d6a12a-3b6c-4979-9150-19d4d39ed1e1") },
                    { new Guid("2715a2e1-d93d-4416-81d5-4355fe22e6fe"), false, "Puerto Baquerizo Moreno", new Guid("d1088efc-5ca0-432c-8a08-c2243c2948a7") },
                    { new Guid("2b397fa4-152f-4d3b-94b4-35665afc1833"), false, "Guaranda", new Guid("9e90ba5c-daf6-42a1-8363-ebb049021b0a") },
                    { new Guid("2c4107ba-0cb6-40d6-acc1-705e0ac16d74"), false, "Granada", new Guid("4b8debde-a862-49ce-b7e8-38fcf44ed9a8") },
                    { new Guid("30c1f155-3abf-4edc-9a05-a761eed11c4e"), false, "Bucaramanga", new Guid("16d1d70a-2c0c-41bc-8dfe-859c519f5d49") },
                    { new Guid("34931d31-1221-4446-9acf-ac60b89bc5bd"), false, "Sogamoso", new Guid("5ab7a630-cfc9-4423-beec-e92443b9e0a8") },
                    { new Guid("34dca21b-ae61-423b-9086-effaf5639c23"), false, "San Andrés", new Guid("125281c1-9bc5-4c43-ac03-de976afb35c5") },
                    { new Guid("3786fb04-725a-4385-89ae-892600d9f48c"), false, "Turbo", new Guid("db5ed00b-0e51-4fbc-8824-70572c14ce70") },
                    { new Guid("378e7fee-2271-4072-8b67-b0ab981e860a"), false, "Armenia", new Guid("66538ae9-8de6-415a-93fe-7a90f54aa45a") },
                    { new Guid("3907d280-4519-4d85-9ea8-11e818378290"), false, "Apartadó", new Guid("db5ed00b-0e51-4fbc-8824-70572c14ce70") },
                    { new Guid("398106b5-4a58-42c0-aec6-9c746131a73d"), false, "Machala", new Guid("af19fcb0-b731-486b-bdd5-575615749d3e") },
                    { new Guid("3feed04a-14ba-4032-b499-0cea66cd6313"), false, "Memarí", new Guid("79402fe9-2e83-4c71-bdbc-fedf08f15be4") },
                    { new Guid("4056b4a9-cec8-41ec-8f6f-c7ddb38fd994"), false, "Cuenca", new Guid("38ece19b-6b0a-4375-8593-24395efc5b58") },
                    { new Guid("4074daa7-8be8-4e45-a0fe-9fc7649b1dad"), false, "Santa Rosa", new Guid("af19fcb0-b731-486b-bdd5-575615749d3e") },
                    { new Guid("409605fc-4359-4ce8-9c00-814d2840b623"), false, "Tumaco", new Guid("0f3e2774-c747-4e44-b14c-c3f0a16627e4") },
                    { new Guid("418b0e1e-c455-4cbe-a875-219fb158cd09"), false, "Yopal", new Guid("cad34b32-58be-49d8-983c-f54b81c1dcdf") },
                    { new Guid("4addbf67-3dd3-4427-90e1-76fcd3b3cb9e"), false, "Ipiales", new Guid("0f3e2774-c747-4e44-b14c-c3f0a16627e4") },
                    { new Guid("4c72678e-144a-46ef-ba6c-7c8241d3dc5d"), false, "San Cristóbal", new Guid("d1088efc-5ca0-432c-8a08-c2243c2948a7") },
                    { new Guid("51aa600a-8b7b-4c59-a33b-49f8ebffd651"), false, "Cartagena de Indias", new Guid("f118dbf3-5449-450e-85fd-eb2428376d04") },
                    { new Guid("52f3d098-6443-445f-8dbd-0fb2a9608c7c"), false, "Dosquebradas", new Guid("b1906965-f654-41fa-b4ae-100d6920d95a") },
                    { new Guid("56577060-874b-4c35-bada-31a552b13508"), false, "Macas", new Guid("d194fada-7771-45fb-94c4-081ecad5987b") },
                    { new Guid("5809da1d-d4be-496b-96e4-10d430af6249"), false, "Saraguro", new Guid("49880fee-a2de-4044-b7af-4f8f6f7bf268") },
                    { new Guid("5c756f42-efc8-4e82-889b-b0327947243f"), false, "Neiva", new Guid("b6365e8a-24db-4b33-9631-410786234ed8") },
                    { new Guid("63f1a2c8-16cb-4fc2-a4da-754ce919bcd5"), false, "Duitama", new Guid("5ab7a630-cfc9-4423-beec-e92443b9e0a8") },
                    { new Guid("64aa438a-c45d-45e8-aa41-e9808350fb50"), false, "Durán", new Guid("43890e96-4f9d-4316-bc82-ad21b546c22f") },
                    { new Guid("64bd4699-9ed7-4ba8-a3d5-5314a06da7e5"), false, "Atacames", new Guid("68f600d0-dc67-4b7a-91d9-a3dd549c7a4f") },
                    { new Guid("6882e6e3-57dc-4adf-a15a-0ca1de5955f1"), false, "Garzón", new Guid("b6365e8a-24db-4b33-9631-410786234ed8") },
                    { new Guid("6a694602-5691-4388-87d7-031b4186d119"), false, "Leticia", new Guid("0e335cb6-46a9-4357-978c-2f5d2f0ac6de") },
                    { new Guid("6cacf967-130d-4cd0-b166-946603bda43c"), false, "Valledupar", new Guid("36fe1850-a449-45ad-8f94-50957776ed84") },
                    { new Guid("6f1c7900-2af9-4715-9c8c-d4f93574aeee"), false, "Ibagué", new Guid("50d6a12a-3b6c-4979-9150-19d4d39ed1e1") },
                    { new Guid("73247db1-ac7d-4445-ab90-9f93c0225c83"), false, "Palmira", new Guid("a4415b8b-599e-4ceb-a677-c932f102c5e6") },
                    { new Guid("78ca25ee-5547-4162-825a-7e50dbf7188d"), false, "Magangué", new Guid("f118dbf3-5449-450e-85fd-eb2428376d04") },
                    { new Guid("78e2bb10-9768-4403-94f0-6ff248b2c5b5"), false, "Esmeraldas", new Guid("68f600d0-dc67-4b7a-91d9-a3dd549c7a4f") },
                    { new Guid("7bf44428-6fef-4888-8c95-b0ba57f11bc3"), false, "Corozal", new Guid("22961c2e-9148-4f64-94d3-8f81fd884d95") },
                    { new Guid("7dbd39a2-ebb2-4023-bf72-a07881060e46"), false, "Villavicencio", new Guid("4b8debde-a862-49ce-b7e8-38fcf44ed9a8") },
                    { new Guid("80118b8e-7fe7-4bfb-bbdf-59640b908d6c"), false, "Ciénaga", new Guid("2a48cf39-2a16-46f0-a957-7c90a7da4a6e") },
                    { new Guid("8399bebe-411c-436d-9986-26dd19c2dd5f"), false, "Santander de Quilichao", new Guid("898938e9-3d02-4e40-88b7-84adaf84ebe2") },
                    { new Guid("84858d66-e699-48d0-bf62-5bb13bc5a4ac"), false, "Yavaraté", new Guid("060076de-2049-4047-ac02-c1ddfddb2785") },
                    { new Guid("8696bd76-dd6a-41af-a5ed-b3528678c226"), false, "Florencia", new Guid("e8321fa3-b65f-4f74-847b-86eb000c2a30") },
                    { new Guid("882161d5-29e0-4abf-be9d-6cb416215a65"), false, "San Juan de Pasto", new Guid("0f3e2774-c747-4e44-b14c-c3f0a16627e4") },
                    { new Guid("890d11df-448d-49f6-a0c1-b085c60263cb"), false, "Santa Rosalía", new Guid("060076de-2049-4047-ac02-c1ddfddb2785") },
                    { new Guid("8d106a53-6c92-498f-bdfb-48289477e515"), false, "Novita", new Guid("604510c2-2c0a-43c0-adea-3a776383b502") },
                    { new Guid("8e119c5c-d643-49fc-82c4-2f19aa59cd77"), false, "Fortul", new Guid("af3a3f67-ab5f-4191-befc-5c2bfad5ee49") },
                    { new Guid("8ec37602-cc40-4bd7-ae08-a1a38d1fbd07"), false, "Loja", new Guid("49880fee-a2de-4044-b7af-4f8f6f7bf268") },
                    { new Guid("8fa5b2ad-c971-4343-a6df-db2b8a2976dc"), false, "Quibdó", new Guid("604510c2-2c0a-43c0-adea-3a776383b502") },
                    { new Guid("915cb5f3-1145-445d-aae0-672ba88e3beb"), false, "Mitú", new Guid("060076de-2049-4047-ac02-c1ddfddb2785") },
                    { new Guid("944e6f30-53f0-4ceb-a094-9331e4e0118d"), false, "Santa Marta", new Guid("2a48cf39-2a16-46f0-a957-7c90a7da4a6e") },
                    { new Guid("95d8d217-86be-4d75-90bf-23c689a1c7a7"), false, "Tena", new Guid("6cd4d15a-f8b1-44ff-bb55-d8278070cb4a") },
                    { new Guid("9738e885-427b-424a-a508-cdcfae39ed11"), false, "Piedecuesta", new Guid("16d1d70a-2c0c-41bc-8dfe-859c519f5d49") },
                    { new Guid("9a3bfcf4-3708-4f60-af7b-032469ef6000"), false, "Montería", new Guid("22961c2e-9148-4f64-94d3-8f81fd884d95") },
                    { new Guid("9f2c7e4c-4ec4-45be-ae47-19728eb1c91d"), false, "Manta", new Guid("45721019-9ace-4392-8641-0f1592459795") },
                    { new Guid("a0317eca-b36f-4102-a66f-4848d64eef30"), false, "Soledad", new Guid("42e19e4f-d18c-483b-80ac-d06363f1905c") },
                    { new Guid("a0f75a5f-b87c-480a-90b0-6365c05e55ff"), false, "Gualaquiza", new Guid("d194fada-7771-45fb-94c4-081ecad5987b") },
                    { new Guid("a2df1458-49ab-4a52-84d0-9883ac53a80e"), false, "Barranquilla", new Guid("42e19e4f-d18c-483b-80ac-d06363f1905c") },
                    { new Guid("a68a0a6c-6da5-403b-933c-c2cb3b72ed21"), false, "Santa Catalina", new Guid("125281c1-9bc5-4c43-ac03-de976afb35c5") },
                    { new Guid("a6f521f8-3561-41ff-9ec1-9986777732cc"), false, "Istmina", new Guid("604510c2-2c0a-43c0-adea-3a776383b502") },
                    { new Guid("aa81ab7b-88a0-443c-a449-8769443ee404"), false, "Arauca", new Guid("af3a3f67-ab5f-4191-befc-5c2bfad5ee49") },
                    { new Guid("ab9f08e7-0998-45ef-9752-01aaea1ad223"), false, "Tunja", new Guid("5ab7a630-cfc9-4423-beec-e92443b9e0a8") },
                    { new Guid("afe26067-02fc-4dfb-a941-7d04b535d47d"), false, "Riohacha", new Guid("eb31e44a-8c86-4576-afda-4ac9ca7e5f25") },
                    { new Guid("b56b8ed8-5a5f-45a8-a22d-d070939022ef"), false, "Uribia", new Guid("eb31e44a-8c86-4576-afda-4ac9ca7e5f25") },
                    { new Guid("ba6123dc-0595-493b-b602-d67548fae8f2"), false, "Cali", new Guid("a4415b8b-599e-4ceb-a677-c932f102c5e6") },
                    { new Guid("ba96841f-5451-4bbc-8661-9fd0134c44d1"), false, "Mocoa", new Guid("786baa00-388a-4c8c-a668-66ba36565c76") },
                    { new Guid("badc3994-66e8-49c9-a266-70dcb0fac636"), false, "Pereira", new Guid("af9163ea-49d6-4868-a2a3-01d6d694c144") },
                    { new Guid("bb6fa627-d528-4031-80f6-49f41e024e02"), false, "Silvia", new Guid("898938e9-3d02-4e40-88b7-84adaf84ebe2") },
                    { new Guid("bb8689a7-cb8f-47dd-84b0-5f59eb4aa57b"), false, "Soacha", new Guid("113e847f-828a-4d8b-9ec1-0c918aa6d1ab") },
                    { new Guid("bd537aff-2ab9-4971-83ae-95ee8bbc5d15"), false, "San José del Guaviare", new Guid("eba3f311-1cc8-48fb-88d2-e7431745ec9e") },
                    { new Guid("bed4a369-ce34-41b1-8fd0-2e079cca2ebd"), false, "Ibarra", new Guid("7dfa8369-d61c-4c07-b700-3dc3f8b72db8") },
                    { new Guid("c31d1d5f-529e-4a90-8a66-ea58173fda9f"), false, "El Retén", new Guid("eba3f311-1cc8-48fb-88d2-e7431745ec9e") },
                    { new Guid("c61567b8-2d20-4bab-9728-5c7913317fa4"), false, "Puerto Carreño", new Guid("544ed951-e98c-428e-962b-0a3227de8d9a") },
                    { new Guid("c6ebd15c-a44f-47aa-a727-6219007d3bdc"), false, "Acacias", new Guid("4b8debde-a862-49ce-b7e8-38fcf44ed9a8") },
                    { new Guid("c8db178e-5714-441d-b326-3c24a1e94d33"), false, "Cartagena del Chairá", new Guid("f118dbf3-5449-450e-85fd-eb2428376d04") },
                    { new Guid("cad56283-0291-4e2a-a21a-9cdf0da1b197"), false, "Cúcuta", new Guid("f44e3a53-66c5-4faa-a48c-17f5ef793e1e") },
                    { new Guid("ce2c81d0-f933-4b21-8644-b8d199b7b4ec"), false, "La Primavera", new Guid("544ed951-e98c-428e-962b-0a3227de8d9a") },
                    { new Guid("cf108a9c-6eb0-4eb0-98a1-febaa6681edc"), false, "Orito", new Guid("786baa00-388a-4c8c-a668-66ba36565c76") },
                    { new Guid("cf3015ba-a6e0-463c-9ab2-a5a5beff11cb"), false, "Chone", new Guid("45721019-9ace-4392-8641-0f1592459795") },
                    { new Guid("cf867889-d6b2-459d-8e0a-c5065ba0772f"), false, "Calamar", new Guid("eba3f311-1cc8-48fb-88d2-e7431745ec9e") },
                    { new Guid("d1d6920b-85b2-4d5c-9a5b-1ed63e38768e"), false, "Aracataca", new Guid("2a48cf39-2a16-46f0-a957-7c90a7da4a6e") },
                    { new Guid("d599d9d2-b67c-4e3e-b11f-61bd1e5af298"), false, "Saravena", new Guid("af3a3f67-ab5f-4191-befc-5c2bfad5ee49") },
                    { new Guid("d5c5acdf-d40f-4725-9479-5e597b02fd08"), false, "Lorica", new Guid("bf5d3243-e55b-463c-9bcb-654bc12a777b") },
                    { new Guid("d6660417-d11c-4d75-9d7b-027a8d53e0ca"), false, "Azogues", new Guid("306ea84e-f0d6-4506-ad01-3c021ac05761") },
                    { new Guid("d6a06a82-142b-4852-9982-2cb0a8785bd8"), false, "Pereira", new Guid("b1906965-f654-41fa-b4ae-100d6920d95a") },
                    { new Guid("d6e14185-4fc3-4456-8dfe-3d4c5e61a003"), false, "Montería", new Guid("bf5d3243-e55b-463c-9bcb-654bc12a777b") },
                    { new Guid("da7e5d72-5ecc-4cda-9fde-02d2126fe507"), false, "Maicao", new Guid("eb31e44a-8c86-4576-afda-4ac9ca7e5f25") },
                    { new Guid("db8121a0-450b-493e-bf3c-0bbd800a5172"), false, "Salcedo", new Guid("2c6352e2-614f-444c-8bd1-559a4e2b2de6") },
                    { new Guid("dfe7442c-bbf1-4167-a4b3-cf6a132ad5a9"), false, "Ocaña", new Guid("f44e3a53-66c5-4faa-a48c-17f5ef793e1e") },
                    { new Guid("e08ed2b4-1766-46be-a9dd-ecc9c480b98e"), false, "Puerto Inírida", new Guid("79402fe9-2e83-4c71-bdbc-fedf08f15be4") },
                    { new Guid("e2377afb-22d1-4d9e-98e0-2906b839d000"), false, "Manizales", new Guid("af9163ea-49d6-4868-a2a3-01d6d694c144") },
                    { new Guid("e27f4af2-94b6-488f-b473-5e6d7f36a56a"), false, "El Guabo", new Guid("48648deb-53a8-4b4b-9269-d17e7cfb8af3") },
                    { new Guid("e3d299ef-6096-4cc8-acd8-df3ad7e88bcc"), false, "Zipaquirá", new Guid("113e847f-828a-4d8b-9ec1-0c918aa6d1ab") },
                    { new Guid("e478e6ac-efdb-45ba-b0e3-c85833ace2ed"), false, "Cartagena del Chairá", new Guid("e8321fa3-b65f-4f74-847b-86eb000c2a30") },
                    { new Guid("e5f9c0ae-d24f-4eaf-9e93-6ea0d3ae1fc4"), false, "Tauramena", new Guid("cad34b32-58be-49d8-983c-f54b81c1dcdf") },
                    { new Guid("e68b77b4-36d2-496a-ae06-8690596fbe03"), false, "La Paz", new Guid("36fe1850-a449-45ad-8f94-50957776ed84") },
                    { new Guid("e6da6abe-7483-4cc3-b26e-eb2238b69a18"), false, "Medellín", new Guid("db5ed00b-0e51-4fbc-8824-70572c14ce70") },
                    { new Guid("eaa8a126-ec56-4cfb-8bb6-e3bab26a7689"), false, "Tulcán", new Guid("48648deb-53a8-4b4b-9269-d17e7cfb8af3") },
                    { new Guid("ebd7a3fa-069c-4954-a3ee-577be7ce9492"), false, "San Miguel de Bolívar", new Guid("9e90ba5c-daf6-42a1-8363-ebb049021b0a") },
                    { new Guid("ec96c5b2-5c46-424e-831d-e6c2fddf4782"), false, "Cereté", new Guid("bf5d3243-e55b-463c-9bcb-654bc12a777b") },
                    { new Guid("f0face1c-db4d-4bb8-83d7-93dca55e4c9a"), false, "Archidona", new Guid("6cd4d15a-f8b1-44ff-bb55-d8278070cb4a") },
                    { new Guid("f29de8b4-7bbf-432a-aff3-748f5c503fd2"), false, "La Tebaida", new Guid("66538ae9-8de6-415a-93fe-7a90f54aa45a") },
                    { new Guid("f756e3fa-43a8-4d26-b7ee-c1d67e14987a"), false, "Puerto Colombia", new Guid("42e19e4f-d18c-483b-80ac-d06363f1905c") },
                    { new Guid("f9e27531-3cf3-45d2-afd6-6a57e1bbf8b2"), false, "Barrancabermeja", new Guid("16d1d70a-2c0c-41bc-8dfe-859c519f5d49") },
                    { new Guid("f9e67853-43d5-44a5-a99c-116f1e9fd034"), false, "Otavalo", new Guid("7dfa8369-d61c-4c07-b700-3dc3f8b72db8") },
                    { new Guid("fba40e3e-9e0c-466e-9519-85d97b4ae21d"), false, "El Tambo", new Guid("306ea84e-f0d6-4506-ad01-3c021ac05761") },
                    { new Guid("fe60ba64-c832-4643-b6d4-a94cd963d851"), false, "Pitalito", new Guid("b6365e8a-24db-4b33-9631-410786234ed8") }
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
