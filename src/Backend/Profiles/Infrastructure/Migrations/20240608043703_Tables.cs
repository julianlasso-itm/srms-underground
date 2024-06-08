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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "ctr_country_id", "ctr_disabled", "ctr_name" },
                values: new object[,]
                {
                    { new Guid("0556ae46-2e51-4337-aa2a-5371c0943778"), false, "Venezuela" },
                    { new Guid("0f08caf4-0cc1-43e7-98ac-4568880d6a79"), false, "Perú" },
                    { new Guid("14767f35-d8dd-44c7-b21f-03e1fa968472"), false, "Brasil" },
                    { new Guid("1eb270ab-1d6a-4d5c-bcf5-7340f9b61de8"), false, "Paraguay" },
                    { new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Colombia" },
                    { new Guid("2053cb06-0490-49ad-a0d9-87a2783a5944"), false, "México" },
                    { new Guid("20fec875-6da7-4ca2-84bb-386199755086"), false, "Chile" },
                    { new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Ecuador" },
                    { new Guid("36936209-99b4-495e-a5eb-e53ea36bfcf0"), false, "Bolivia" },
                    { new Guid("6188d92e-1937-432f-9507-4b36714eaf17"), false, "Uruguay" },
                    { new Guid("651a56df-a1c6-4f4a-a6e6-1bbe06d26e46"), false, "Nicaragua" },
                    { new Guid("8062697a-30e8-4a3b-95e8-5a38f0c9c0b6"), false, "Honduras" },
                    { new Guid("8076d7ca-5427-4f4e-ab26-7c75d68a5f31"), false, "Guatemala" },
                    { new Guid("857d1410-f0ba-4463-8218-f950ac2b6437"), false, "Belize" },
                    { new Guid("d46208ba-9f65-4901-8a29-c2ce82970de4"), false, "Costa Rica" },
                    { new Guid("e03e3bec-4cad-4338-93c6-5edca4c88939"), false, "Panamá" },
                    { new Guid("ee30a0d4-d111-465d-88cf-6ffd7c8dcbb0"), false, "Argentina" },
                    { new Guid("ffac56bf-17a0-4a6f-88e9-b69540e20a24"), false, "El Salvador" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("08d61714-0d32-4c0f-ac54-594bc2347edb"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1124), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("2c75c5e1-9073-4833-869f-3b52d0ce3453"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1119), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("519b07e4-801e-416a-ab8f-a0957a2f1507"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1128), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("7ccf7f5d-2100-4008-a773-f5522a7926b9"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1095), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("8a23906e-aa19-4d6c-895e-2b847af73efb"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1140), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("8a258665-ad51-4860-8952-3e8f59a2ba32"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1132), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("93d3ae01-ca42-4c90-8cb2-5910d8cd9d49"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1099), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("ad358bc5-40de-4c97-a6d9-2fef6a2c9426"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1085), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("b86397ae-9f10-428d-a281-a865c72ad227"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1090), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("bc8903e2-5558-41b2-8398-6108d70fc61e"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1111), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("c234159d-7f6a-40fd-ae29-c8bba88b744e"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1144), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("c4f7ae23-fce9-4e70-b6fe-066b2d6e16d4"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1115), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("e2ec096b-46e2-4865-badb-e09cd06353ef"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1107), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("edb91a7e-8c9f-4f33-bcff-8be9bd68ed8b"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1103), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("f214d225-c48e-42e3-99c6-75ef31fa1a3b"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1136), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("08a9905f-3942-4895-95f4-033e54dd1ed2"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(883), null, null, false, "QA", null },
                    { new Guid("17493f85-81a9-41b7-8bac-d03453138bf9"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(909), null, null, false, "Architect", null },
                    { new Guid("1d4285de-9555-4767-b771-338922ef64bd"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(905), null, null, false, "Scrum Master", null },
                    { new Guid("61f23b17-ae5f-445b-9dc2-f7615fe27f2f"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(917), null, null, false, "Lead Designer", null },
                    { new Guid("6845edbb-b529-492e-8891-2084788818f2"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(896), null, null, false, "UX/UI Designer", null },
                    { new Guid("71d220c7-bda1-43dd-93a5-91fbdfe39ecf"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(875), null, null, false, "Designer", null },
                    { new Guid("75ea02a9-d982-40cc-ae6b-0c56efa17a51"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(869), null, null, false, "Developer", null },
                    { new Guid("9afcfbfb-f424-41fb-bd76-5c13c4a3da87"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(888), null, null, false, "DevOps", null },
                    { new Guid("a266bdd8-5c2f-425e-8261-ef680dac0b94"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(892), null, null, false, "Data Scientist", null },
                    { new Guid("cd5373e7-49a8-4643-902f-10d70c1f4af2"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(879), null, null, false, "Manager", null },
                    { new Guid("d597e53e-85d1-48d7-995f-4efe3a151d03"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(900), null, null, false, "Product Owner", null },
                    { new Guid("fbd30f73-be69-42b6-a4b3-3fb67acc4f34"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(913), null, null, false, "Lead Developer", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1d7674c7-1815-4828-9f20-b45fc44b4846"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(952), null, false, "Python", null },
                    { new Guid("2f481652-55b2-458d-a68e-b24a95c463be"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1046), null, false, "Spring Boot", null },
                    { new Guid("40d954a9-9f13-49c1-a673-34b5414fd883"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(988), null, false, "Vue", null },
                    { new Guid("478b0523-34b0-4907-b4a7-f8c3e84ab7da"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(1050), null, false, "Hibernate", null },
                    { new Guid("4d77a36b-1215-4504-a16f-5d38bcc56c3b"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(941), null, false, "C#", null },
                    { new Guid("575d4020-cb04-4aec-b142-fe315e7ead05"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(948), null, false, "Java", null },
                    { new Guid("67a43e7a-45c9-41bd-9575-41c1987539da"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(968), null, false, "CSS", null },
                    { new Guid("83fe2c45-314f-4fe2-880a-efc220fd38b1"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(992), null, false, "Node.js", null },
                    { new Guid("90b375b6-ce20-4f61-a3ec-fe2e5a162136"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(972), null, false, "SQL", null },
                    { new Guid("b724c457-71de-45ea-ba5d-c1a1d0d072c5"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(960), null, false, "TypeScript", null },
                    { new Guid("cd5cb9f9-11a8-4cf6-b0d3-88b2724459b9"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(956), null, false, "JavaScript", null },
                    { new Guid("dd2247be-e42f-4a6a-88f8-60efd6ae4a89"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(976), null, false, "NoSQL", null },
                    { new Guid("dd518bd5-48a8-459d-aa65-29aca0c3f5ee"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(964), null, false, "HTML", null },
                    { new Guid("dd803fcd-b478-4342-b243-2456bd3c83dc"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(987), null, false, "React", null },
                    { new Guid("e92f72b1-40f9-4d23-986b-00a600388700"), new DateTime(2024, 6, 8, 4, 37, 3, 644, DateTimeKind.Utc).AddTicks(980), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("055aef5a-47a8-4cee-9c8e-9609f3701cea"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Boyacá" },
                    { new Guid("05e22edb-1694-4828-b079-440ea4d49cad"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Córdoba" },
                    { new Guid("0bfbdcbb-f0b9-4587-ab00-48a0ff75d28a"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Cundinamarca" },
                    { new Guid("149f741d-357b-49d0-b08e-28d789eb2e66"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Antioquia" },
                    { new Guid("17797eff-57f0-4717-8087-2adf40b0c0e6"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Santander" },
                    { new Guid("1cd010f3-78a7-405f-bb32-871156a106f2"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Valle del Cauca" },
                    { new Guid("1d6652b5-b071-4774-a040-91c4148ee2dc"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Loja" },
                    { new Guid("3096e523-ff62-4634-af4d-49200229c694"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Magdalena" },
                    { new Guid("34b26e27-b8fa-44b4-a17a-353ab354444a"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Cañar" },
                    { new Guid("365cd5b0-a65e-4c4a-8833-1f75519ed2e7"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Putumayo" },
                    { new Guid("37204e28-16ed-49b9-b4a2-b75406ee5eb6"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "San Andrés y Providencia" },
                    { new Guid("3864444f-2e7a-42be-88fb-dff4b05b3a63"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Morona Santiago" },
                    { new Guid("39e39f8e-0648-4601-93f7-45c05ae0aaf7"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Huila" },
                    { new Guid("3c0f7582-7f3b-4222-a856-33ea2019c29b"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Sucre" },
                    { new Guid("403459bf-8c41-4de9-9a67-a9e065774684"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Bolívar" },
                    { new Guid("4c5cbb38-c803-4306-86cd-3c948c7303b9"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Bolívar" },
                    { new Guid("52599a84-2471-472f-a541-3a6ff2e10ac7"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Quindío" },
                    { new Guid("5428e9ad-c0b1-4bd2-9f68-cdffa64e9b8a"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Vichada" },
                    { new Guid("544675b9-3f99-4a42-a326-da2afe77deee"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Cauca" },
                    { new Guid("671d4cad-8899-4450-8787-c1a034a9ebc2"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Carchi" },
                    { new Guid("83b109d6-6b7f-4664-b874-56a796d1ee80"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Meta" },
                    { new Guid("857d10ab-4aa7-4e82-ba2e-dd8cef545d54"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Azuay" },
                    { new Guid("8865a0bb-c237-425f-94da-38f5350d110f"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Tolima" },
                    { new Guid("9382d430-f376-45a5-9efe-55666fd9d716"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Esmeraldas" },
                    { new Guid("9876392e-c0ad-4d04-9ea5-d9742d8fd5a3"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Imbabura" },
                    { new Guid("99060b8a-66ba-4838-b3da-f76c9a3e0e40"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Manabí" },
                    { new Guid("9b41ec32-7e41-4929-94fe-600e1d1f5294"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Arauca" },
                    { new Guid("a1e3b112-ec35-4648-bf41-84611cdbe571"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Vaupés" },
                    { new Guid("a55922e7-85fc-4fc5-b9d3-6486ee97a41d"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Nariño" },
                    { new Guid("a86d4b73-6e6e-4581-9886-aa7a91778444"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Guainía" },
                    { new Guid("a88ee677-6b20-4a33-8488-31ec389893de"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Norte de Santander" },
                    { new Guid("b3069941-627f-4e09-9523-dd0c72253fae"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Amazonas" },
                    { new Guid("b5094437-86b0-46fe-9d42-1dce44656b97"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Napo" },
                    { new Guid("b605f028-f6e9-4e21-aeb5-79a3068a0b15"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Caldas" },
                    { new Guid("ba768149-8ec4-4824-b681-0531ef20e37c"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "La Guajira" },
                    { new Guid("bb2e0688-d812-444e-98d2-f15376ec8948"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Casanare" },
                    { new Guid("bb9df834-f2e1-49b1-bb6b-570144c8c6cc"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Chimborazo" },
                    { new Guid("cce65031-ee71-4dc0-9130-b03b1a220e7d"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Cesar" },
                    { new Guid("e2c590da-9bf6-4b7d-bd8b-13a454a92931"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Atlántico" },
                    { new Guid("e3eb8706-31f4-47d8-b8e6-5b63e7e020c4"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Galápagos" },
                    { new Guid("eb211039-a47c-468b-b26d-cb1f63bfb477"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Cotopaxi" },
                    { new Guid("f0a80da8-a2c3-4aa8-8c30-8e35f0b81c96"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "Guayas" },
                    { new Guid("f2de2cb3-c911-43e0-99ba-6a287c74e9f9"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Caquetá" },
                    { new Guid("f57fc06e-3987-4aea-8e7e-424bb46f005b"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Risaralda" },
                    { new Guid("f9a3c156-1c03-4765-9eb0-57d0cff04bfe"), new Guid("25e87d92-fd5a-419b-920b-ac4e6a3ff25b"), false, "El Oro" },
                    { new Guid("fcf437ff-6e6d-4dc0-9a5f-740817c9affd"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Guaviare" },
                    { new Guid("fdb0669b-5c04-496b-86ec-07eafd64e20e"), new Guid("1f22f04f-ca5c-454d-9ea8-6019de1be97f"), false, "Chocó" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("00dce668-ccd1-4a28-ab77-40c4d7e9bbc6"), false, "Morelia", new Guid("f2de2cb3-c911-43e0-99ba-6a287c74e9f9") },
                    { new Guid("0126ba72-570c-4348-bd66-32bf4600f8fa"), false, "Cereté", new Guid("05e22edb-1694-4828-b079-440ea4d49cad") },
                    { new Guid("0293dcff-d53b-4c08-aa88-df3ae0d5a6e1"), false, "Santa Catalina", new Guid("37204e28-16ed-49b9-b4a2-b75406ee5eb6") },
                    { new Guid("02a19871-3f67-46d5-97c9-21e722b6b65f"), false, "Montería", new Guid("3c0f7582-7f3b-4222-a856-33ea2019c29b") },
                    { new Guid("0b3b1b52-8776-414f-bc99-ec5d1f6c6d9c"), false, "Silvia", new Guid("544675b9-3f99-4a42-a326-da2afe77deee") },
                    { new Guid("0c595fab-e24b-4775-8086-99d20fecad9d"), false, "San Juan de Pasto", new Guid("a55922e7-85fc-4fc5-b9d3-6486ee97a41d") },
                    { new Guid("0d705584-9063-4298-95e5-7cf44c431880"), false, "Calarcá", new Guid("52599a84-2471-472f-a541-3a6ff2e10ac7") },
                    { new Guid("0faf2024-2b87-48f3-877f-fd3d7b843feb"), false, "Aguazul", new Guid("bb2e0688-d812-444e-98d2-f15376ec8948") },
                    { new Guid("100340ae-1cf2-4a18-bec9-ac37696bc156"), false, "Quibdó", new Guid("fdb0669b-5c04-496b-86ec-07eafd64e20e") },
                    { new Guid("1421abaf-0f28-4294-bb52-f6a88665bd0d"), false, "Bogotá", new Guid("0bfbdcbb-f0b9-4587-ab00-48a0ff75d28a") },
                    { new Guid("159be93b-2554-41eb-8f07-b62d7a013411"), false, "Neiva", new Guid("39e39f8e-0648-4601-93f7-45c05ae0aaf7") },
                    { new Guid("18a2a7f3-661a-4371-a64f-757562f6fa65"), false, "El Retén", new Guid("fcf437ff-6e6d-4dc0-9a5f-740817c9affd") },
                    { new Guid("19c98157-cf62-4564-8e5b-95e6c35336ba"), false, "Arauca", new Guid("9b41ec32-7e41-4929-94fe-600e1d1f5294") },
                    { new Guid("1bf17fe4-537b-4c9f-ae16-30bc2abe8c7f"), false, "Sincelejo", new Guid("3c0f7582-7f3b-4222-a856-33ea2019c29b") },
                    { new Guid("1da2b8f0-165b-49c0-8fda-c3e8a15cb92b"), false, "Esmeraldas", new Guid("9382d430-f376-45a5-9efe-55666fd9d716") },
                    { new Guid("210f241d-5d88-4a1d-8c96-bbc62e7daae5"), false, "Archidona", new Guid("b5094437-86b0-46fe-9d42-1dce44656b97") },
                    { new Guid("21f737c9-d82f-4805-95ef-65d7daf8cb26"), false, "Ciénaga", new Guid("3096e523-ff62-4634-af4d-49200229c694") },
                    { new Guid("224bc6c0-dc0a-48fe-b1ad-dd3369bdf429"), false, "Santa Rosa", new Guid("f9a3c156-1c03-4765-9eb0-57d0cff04bfe") },
                    { new Guid("236a0d01-78a9-45f4-994e-9564658e56ff"), false, "Armero Guayabal", new Guid("8865a0bb-c237-425f-94da-38f5350d110f") },
                    { new Guid("246b0448-c8c7-48d0-aa93-cc1a0f3d57fc"), false, "Buenaventura", new Guid("1cd010f3-78a7-405f-bb32-871156a106f2") },
                    { new Guid("2bca1c74-d439-44fd-856f-c26e542a18bc"), false, "Duitama", new Guid("055aef5a-47a8-4cee-9c8e-9609f3701cea") },
                    { new Guid("2d65354f-790e-4e60-b477-441ea5166af7"), false, "Garzón", new Guid("39e39f8e-0648-4601-93f7-45c05ae0aaf7") },
                    { new Guid("2db51727-d0c2-463c-be39-4378d8c80541"), false, "Guayaquil", new Guid("f0a80da8-a2c3-4aa8-8c30-8e35f0b81c96") },
                    { new Guid("34500fda-6d73-4ceb-be91-ecb43fa60e81"), false, "Azogues", new Guid("34b26e27-b8fa-44b4-a17a-353ab354444a") },
                    { new Guid("39be6cc1-ea2c-4bd7-8ead-4d34aa4f0006"), false, "Popayán", new Guid("544675b9-3f99-4a42-a326-da2afe77deee") },
                    { new Guid("39d244d1-1bc4-4dd2-b777-a23c3f2d81c2"), false, "Puerto Inírida", new Guid("a86d4b73-6e6e-4581-9886-aa7a91778444") },
                    { new Guid("3b8176f0-3772-4bb0-a7ac-7689bc9da513"), false, "Tulcán", new Guid("671d4cad-8899-4450-8787-c1a034a9ebc2") },
                    { new Guid("3c18be4f-5fac-435c-a7c1-4ea636fb6b80"), false, "Bucaramanga", new Guid("17797eff-57f0-4717-8087-2adf40b0c0e6") },
                    { new Guid("3c3a9066-1513-4fa5-9ef7-fc7adc8e8172"), false, "Memarí", new Guid("a86d4b73-6e6e-4581-9886-aa7a91778444") },
                    { new Guid("3c8298ea-ddae-4114-99c1-64d4d00bf613"), false, "Barrancabermeja", new Guid("17797eff-57f0-4717-8087-2adf40b0c0e6") },
                    { new Guid("3c969b03-8e01-4a8a-9fa3-1e3c674bfc30"), false, "Yavaraté", new Guid("a1e3b112-ec35-4648-bf41-84611cdbe571") },
                    { new Guid("3cf0304f-ee5c-4e10-a911-dfb615427eef"), false, "Cali", new Guid("1cd010f3-78a7-405f-bb32-871156a106f2") },
                    { new Guid("3cfd6f7c-dae8-40bf-921c-cf7eac34235d"), false, "Inírida", new Guid("a86d4b73-6e6e-4581-9886-aa7a91778444") },
                    { new Guid("3ea6cbd7-329d-4789-8577-2ed38d687499"), false, "Chone", new Guid("99060b8a-66ba-4838-b3da-f76c9a3e0e40") },
                    { new Guid("40775b13-06d7-40b4-91b6-e76bcf1f33a6"), false, "Calamar", new Guid("fcf437ff-6e6d-4dc0-9a5f-740817c9affd") },
                    { new Guid("4364b0b5-f508-4a5b-baa7-b9c1f2e3b7b8"), false, "Cartagena de Indias", new Guid("4c5cbb38-c803-4306-86cd-3c948c7303b9") },
                    { new Guid("439508d1-95d1-40da-9918-d218a5559678"), false, "San Miguel de Bolívar", new Guid("403459bf-8c41-4de9-9a67-a9e065774684") },
                    { new Guid("477ce0bc-1a68-4dab-9f28-e9c745e1bf6e"), false, "Tauramena", new Guid("bb2e0688-d812-444e-98d2-f15376ec8948") },
                    { new Guid("47caa32e-b854-4fc3-af04-6d910015b02d"), false, "Pitalito", new Guid("39e39f8e-0648-4601-93f7-45c05ae0aaf7") },
                    { new Guid("47f6c774-20da-4416-8b95-c186d6b7f231"), false, "Santander de Quilichao", new Guid("544675b9-3f99-4a42-a326-da2afe77deee") },
                    { new Guid("49c62d12-0532-4330-ad94-9b83afa5d970"), false, "La Primavera", new Guid("5428e9ad-c0b1-4bd2-9f68-cdffa64e9b8a") },
                    { new Guid("4d15fb31-05c1-4ef8-a8ce-3d14b98bfd91"), false, "Tumaco", new Guid("a55922e7-85fc-4fc5-b9d3-6486ee97a41d") },
                    { new Guid("4d5f7322-f576-4287-8032-8f82cdb3d53a"), false, "Riobamba", new Guid("bb9df834-f2e1-49b1-bb6b-570144c8c6cc") },
                    { new Guid("4e4faef6-9165-4213-a677-f28933321fed"), false, "Cúcuta", new Guid("a88ee677-6b20-4a33-8488-31ec389893de") },
                    { new Guid("4ed168b1-47b5-4505-84d1-7d484ed3d739"), false, "El Guabo", new Guid("671d4cad-8899-4450-8787-c1a034a9ebc2") },
                    { new Guid("4f22c4f8-c2d0-4fc6-af79-dcfaf69b5771"), false, "Saravena", new Guid("9b41ec32-7e41-4929-94fe-600e1d1f5294") },
                    { new Guid("5295f9a0-f827-476e-8b56-1873b0049718"), false, "Florencia", new Guid("f2de2cb3-c911-43e0-99ba-6a287c74e9f9") },
                    { new Guid("52bbf7f5-4c51-4ead-8a05-3f6f72d76646"), false, "Soacha", new Guid("0bfbdcbb-f0b9-4587-ab00-48a0ff75d28a") },
                    { new Guid("588731a7-2ee5-4292-8566-a0898e4b8e68"), false, "Istmina", new Guid("fdb0669b-5c04-496b-86ec-07eafd64e20e") },
                    { new Guid("59d3b2f3-5d08-41f9-b363-2ea1deb037e6"), false, "Santa Rosa de Cabal", new Guid("f57fc06e-3987-4aea-8e7e-424bb46f005b") },
                    { new Guid("5a58251b-9369-4fd4-b767-d97e309fe4bf"), false, "Macas", new Guid("3864444f-2e7a-42be-88fb-dff4b05b3a63") },
                    { new Guid("5ce29e1d-976a-4113-be40-5026fb4919ea"), false, "Alausí", new Guid("bb9df834-f2e1-49b1-bb6b-570144c8c6cc") },
                    { new Guid("5d5afda8-cd20-4b99-9e06-a0abd08b0a5c"), false, "Puerto Colombia", new Guid("e2c590da-9bf6-4b7d-bd8b-13a454a92931") },
                    { new Guid("60bade0d-bb59-4e6b-b717-a9a3ddd49143"), false, "Gualaquiza", new Guid("3864444f-2e7a-42be-88fb-dff4b05b3a63") },
                    { new Guid("65e0145f-d449-43b9-9626-5759495d02f2"), false, "Novita", new Guid("fdb0669b-5c04-496b-86ec-07eafd64e20e") },
                    { new Guid("661bc0fe-1224-4514-a3b0-301d91ff1031"), false, "San José del Guaviare", new Guid("fcf437ff-6e6d-4dc0-9a5f-740817c9affd") },
                    { new Guid("676d9023-967d-49c5-8286-dee94255d7db"), false, "Granada", new Guid("83b109d6-6b7f-4664-b874-56a796d1ee80") },
                    { new Guid("6c182de9-13ba-412e-a227-2f1c1cd1e360"), false, "Durán", new Guid("f0a80da8-a2c3-4aa8-8c30-8e35f0b81c96") },
                    { new Guid("6e52efb2-8b17-45e3-a9a6-0c8fc3b6af60"), false, "Ipiales", new Guid("a55922e7-85fc-4fc5-b9d3-6486ee97a41d") },
                    { new Guid("7269374f-b00f-44cd-b8ed-a74732dd7d07"), false, "La Paz", new Guid("cce65031-ee71-4dc0-9130-b03b1a220e7d") },
                    { new Guid("76001be2-f1e6-459d-b16f-bf04e18f60b2"), false, "Aracataca", new Guid("3096e523-ff62-4634-af4d-49200229c694") },
                    { new Guid("7e4ba276-2903-4155-9f3f-d64c9a7b9777"), false, "Tunja", new Guid("055aef5a-47a8-4cee-9c8e-9609f3701cea") },
                    { new Guid("7e68c19e-963c-4d57-9bc3-4ddfd31e512a"), false, "Pereira", new Guid("b605f028-f6e9-4e21-aeb5-79a3068a0b15") },
                    { new Guid("7f191505-2744-4901-bc6a-4badb70c8172"), false, "San Cristóbal", new Guid("e3eb8706-31f4-47d8-b8e6-5b63e7e020c4") },
                    { new Guid("7f86f19b-2508-45f0-8142-71ec277b8cf2"), false, "Leticia", new Guid("b3069941-627f-4e09-9523-dd0c72253fae") },
                    { new Guid("82497b6b-cca5-4344-b14f-57eec6da5321"), false, "Lorica", new Guid("05e22edb-1694-4828-b079-440ea4d49cad") },
                    { new Guid("83b2aa46-3c87-4ece-a50b-1e3e4283519d"), false, "Puerto Baquerizo Moreno", new Guid("e3eb8706-31f4-47d8-b8e6-5b63e7e020c4") },
                    { new Guid("85e1c49f-7f51-4bf1-b9a3-5b011e59a99b"), false, "Pereira", new Guid("f57fc06e-3987-4aea-8e7e-424bb46f005b") },
                    { new Guid("8659e090-08a0-4479-a3b3-dcf27a4085a8"), false, "Aguachica", new Guid("cce65031-ee71-4dc0-9130-b03b1a220e7d") },
                    { new Guid("8a6336ca-0b69-49f6-aa62-adf55c49ea02"), false, "Loja", new Guid("1d6652b5-b071-4774-a040-91c4148ee2dc") },
                    { new Guid("8d03ca45-8e67-40dd-8c0f-54ff16725b81"), false, "Maicao", new Guid("ba768149-8ec4-4824-b681-0531ef20e37c") },
                    { new Guid("8d7eb064-780e-458a-b923-a1915c590e51"), false, "Providencia", new Guid("37204e28-16ed-49b9-b4a2-b75406ee5eb6") },
                    { new Guid("8ead2766-4ae4-4dcc-bd8d-67579244a8f4"), false, "Atacames", new Guid("9382d430-f376-45a5-9efe-55666fd9d716") },
                    { new Guid("8f0e9d91-458c-4f81-91c3-d93db6bec4c4"), false, "Honda", new Guid("8865a0bb-c237-425f-94da-38f5350d110f") },
                    { new Guid("961ef995-5bbf-4fe6-9829-b1fb60b4d2b5"), false, "Turbo", new Guid("149f741d-357b-49d0-b08e-28d789eb2e66") },
                    { new Guid("97b44dae-0594-49c5-b06f-b3c2d3f3d8df"), false, "Zipaquirá", new Guid("0bfbdcbb-f0b9-4587-ab00-48a0ff75d28a") },
                    { new Guid("99081c93-0c66-4484-9c21-a714272d8adc"), false, "Valledupar", new Guid("cce65031-ee71-4dc0-9130-b03b1a220e7d") },
                    { new Guid("9b5f07b9-f73d-48d5-98d8-f97f1242aad1"), false, "Santa Marta", new Guid("3096e523-ff62-4634-af4d-49200229c694") },
                    { new Guid("9c2a5e4a-fd34-4546-b3f5-8f52b68a81fb"), false, "Puerto Carreño", new Guid("5428e9ad-c0b1-4bd2-9f68-cdffa64e9b8a") },
                    { new Guid("9d01b1b7-cd59-4159-baed-28ef551d2784"), false, "Chinchiná", new Guid("b605f028-f6e9-4e21-aeb5-79a3068a0b15") },
                    { new Guid("9fdfb841-f25f-456f-9b23-29cdc0449c67"), false, "Latacunga", new Guid("eb211039-a47c-468b-b26d-cb1f63bfb477") },
                    { new Guid("a3eabdd8-f5c7-41f7-a5d4-5dbb35a54dbc"), false, "Montería", new Guid("05e22edb-1694-4828-b079-440ea4d49cad") },
                    { new Guid("a66a56e3-78e5-40dc-a815-a06cbf322bf0"), false, "Riohacha", new Guid("ba768149-8ec4-4824-b681-0531ef20e37c") },
                    { new Guid("a7236a49-8df1-493a-8ae9-2ba7ff91d551"), false, "Puerto Asís", new Guid("365cd5b0-a65e-4c4a-8833-1f75519ed2e7") },
                    { new Guid("a724bf86-c246-4436-b4ee-b2ad3a620511"), false, "Cartagena del Chairá", new Guid("4c5cbb38-c803-4306-86cd-3c948c7303b9") },
                    { new Guid("a8e585c5-c847-4f61-b2cb-082056207fd1"), false, "Tena", new Guid("b5094437-86b0-46fe-9d42-1dce44656b97") },
                    { new Guid("ab8d8c7f-c878-460c-b05f-98a966a12899"), false, "Yopal", new Guid("bb2e0688-d812-444e-98d2-f15376ec8948") },
                    { new Guid("ada11005-b0fb-4f0b-9eeb-f17f6c0fbea2"), false, "Ibagué", new Guid("8865a0bb-c237-425f-94da-38f5350d110f") },
                    { new Guid("b27653ff-adb0-4125-a882-10f0c046482a"), false, "Sogamoso", new Guid("055aef5a-47a8-4cee-9c8e-9609f3701cea") },
                    { new Guid("b4a98ee9-568d-4004-8321-3fa12527cb2c"), false, "Manta", new Guid("99060b8a-66ba-4838-b3da-f76c9a3e0e40") },
                    { new Guid("b7753fe4-746a-4735-b5eb-c43958fbc27a"), false, "Otavalo", new Guid("9876392e-c0ad-4d04-9ea5-d9742d8fd5a3") },
                    { new Guid("b9115526-2070-4e38-8143-eb8d3604633f"), false, "Santa Rosalía", new Guid("a1e3b112-ec35-4648-bf41-84611cdbe571") },
                    { new Guid("b9214f06-c891-43d7-bcb0-57ad35991c8b"), false, "Medellín", new Guid("149f741d-357b-49d0-b08e-28d789eb2e66") },
                    { new Guid("b9ffbe72-e408-4ac2-bd9c-1ae1a0e4a04d"), false, "Pamplona", new Guid("a88ee677-6b20-4a33-8488-31ec389893de") },
                    { new Guid("ba050f7e-429c-41cc-98c0-4a7302e02fcc"), false, "Cuenca", new Guid("857d10ab-4aa7-4e82-ba2e-dd8cef545d54") },
                    { new Guid("bad1cd27-b7a9-4a98-a0d8-dc51cae18ffe"), false, "Orito", new Guid("365cd5b0-a65e-4c4a-8833-1f75519ed2e7") },
                    { new Guid("bd2c032f-33bd-4dd9-a40d-4a5e86bda818"), false, "Guaranda", new Guid("403459bf-8c41-4de9-9a67-a9e065774684") },
                    { new Guid("bdeb3270-c05b-47d5-ac2b-bff17d0a2f3f"), false, "Manizales", new Guid("b605f028-f6e9-4e21-aeb5-79a3068a0b15") },
                    { new Guid("be1c943e-2b0c-42f9-9d88-87f77aaf011d"), false, "El Tambo", new Guid("34b26e27-b8fa-44b4-a17a-353ab354444a") },
                    { new Guid("be7d36d1-d8e9-4bb7-a94e-418a8076e1d7"), false, "Machala", new Guid("f9a3c156-1c03-4765-9eb0-57d0cff04bfe") },
                    { new Guid("bedcd48c-dea0-4187-9b14-9c832c33c8f5"), false, "Portoviejo", new Guid("99060b8a-66ba-4838-b3da-f76c9a3e0e40") },
                    { new Guid("c0e0c167-3d97-4957-9c56-661160f9ef14"), false, "Magangué", new Guid("4c5cbb38-c803-4306-86cd-3c948c7303b9") },
                    { new Guid("c3c98f33-f385-4005-8af5-da4d06155827"), false, "Saraguro", new Guid("1d6652b5-b071-4774-a040-91c4148ee2dc") },
                    { new Guid("ce1cce32-1fd8-4f85-bd76-854da61518b8"), false, "Mocoa", new Guid("365cd5b0-a65e-4c4a-8833-1f75519ed2e7") },
                    { new Guid("ce713b35-ddcb-41a9-a326-55012651cb79"), false, "Corozal", new Guid("3c0f7582-7f3b-4222-a856-33ea2019c29b") },
                    { new Guid("d08f9288-3e48-40f6-b7db-e5c3dbcc2da5"), false, "Barranquilla", new Guid("e2c590da-9bf6-4b7d-bd8b-13a454a92931") },
                    { new Guid("d68c387e-2919-4221-81c9-b4988b455a43"), false, "Soledad", new Guid("e2c590da-9bf6-4b7d-bd8b-13a454a92931") },
                    { new Guid("dcbbb149-ff30-48dc-8db0-60eeaf5b0ee5"), false, "Santa Helena", new Guid("5428e9ad-c0b1-4bd2-9f68-cdffa64e9b8a") },
                    { new Guid("df355dd5-fca4-4b2e-bc15-b006ef7f066c"), false, "Apartadó", new Guid("149f741d-357b-49d0-b08e-28d789eb2e66") },
                    { new Guid("e01ca171-2d42-4790-a2f9-fc42330d6dfb"), false, "Fortul", new Guid("9b41ec32-7e41-4929-94fe-600e1d1f5294") },
                    { new Guid("e46f7303-4315-4d34-8af6-2db0ecfb3f44"), false, "Villavicencio", new Guid("83b109d6-6b7f-4664-b874-56a796d1ee80") },
                    { new Guid("e997007a-1e7f-4406-b05f-951256710229"), false, "Ocaña", new Guid("a88ee677-6b20-4a33-8488-31ec389893de") },
                    { new Guid("ea344450-dc1d-46e5-8990-1eea1d75331b"), false, "Armenia", new Guid("52599a84-2471-472f-a541-3a6ff2e10ac7") },
                    { new Guid("eaa5a7ee-8a12-4ff3-8785-7f0a784c5e90"), false, "Mitú", new Guid("a1e3b112-ec35-4648-bf41-84611cdbe571") },
                    { new Guid("ebb119de-6885-40d2-b438-c8831ada3e6e"), false, "Uribia", new Guid("ba768149-8ec4-4824-b681-0531ef20e37c") },
                    { new Guid("ed19b397-ec5e-4f66-b517-44f709d0ca51"), false, "Dosquebradas", new Guid("f57fc06e-3987-4aea-8e7e-424bb46f005b") },
                    { new Guid("ee10b593-38f8-4a32-979a-9ebb64cbcbd2"), false, "Piedecuesta", new Guid("17797eff-57f0-4717-8087-2adf40b0c0e6") },
                    { new Guid("f6701621-6cbd-4dea-900a-40572cc916fc"), false, "La Tebaida", new Guid("52599a84-2471-472f-a541-3a6ff2e10ac7") },
                    { new Guid("f76d70d6-b9f7-4240-abef-82a1b9ac8b38"), false, "Salcedo", new Guid("eb211039-a47c-468b-b26d-cb1f63bfb477") },
                    { new Guid("f8d37e70-7ed1-45a5-8416-f46395623c5a"), false, "Palmira", new Guid("1cd010f3-78a7-405f-bb32-871156a106f2") },
                    { new Guid("f9b01027-fba6-4164-9ea7-65d77cb505f1"), false, "Acacias", new Guid("83b109d6-6b7f-4664-b874-56a796d1ee80") },
                    { new Guid("fa1a925f-e607-47c1-ae9f-6fd192a5e757"), false, "Girón", new Guid("857d10ab-4aa7-4e82-ba2e-dd8cef545d54") },
                    { new Guid("fc6b5310-8321-404c-9f55-2e294416a44c"), false, "Ibarra", new Guid("9876392e-c0ad-4d04-9ea5-d9742d8fd5a3") },
                    { new Guid("fd58fb99-fb02-4b09-a71f-609887a49b79"), false, "San Andrés", new Guid("37204e28-16ed-49b9-b4a2-b75406ee5eb6") },
                    { new Guid("ff9391a6-5665-464c-8191-28535d2d0676"), false, "Cartagena del Chairá", new Guid("f2de2cb3-c911-43e0-99ba-6a287c74e9f9") }
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
                name: "assessment");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "role_per_skill");

            migrationBuilder.DropTable(
                name: "subskill");

            migrationBuilder.DropTable(
                name: "professional");

            migrationBuilder.DropTable(
                name: "squad");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
