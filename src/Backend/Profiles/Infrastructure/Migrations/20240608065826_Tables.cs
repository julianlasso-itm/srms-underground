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
                    { new Guid("0dcdeaeb-82fb-4c88-9bcd-e806e0a32be2"), false, "México" },
                    { new Guid("12b1978e-eeef-4cd3-9c0c-5d170083f18a"), false, "El Salvador" },
                    { new Guid("162f823b-8b16-4f17-bf49-5b4dfa92a2d4"), false, "Panamá" },
                    { new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Colombia" },
                    { new Guid("3d07f7a4-a1c8-4db2-a7c7-6cbfe485707b"), false, "Perú" },
                    { new Guid("3f7ac7a4-9be3-4982-b243-c5577e1aefbe"), false, "Belize" },
                    { new Guid("4185704b-df78-42cc-94e4-9ac177676b17"), false, "Brasil" },
                    { new Guid("5f456be7-d447-4b32-8aec-c96cd471ee72"), false, "Guatemala" },
                    { new Guid("86021e3f-73b5-4213-955e-425719381c77"), false, "Bolivia" },
                    { new Guid("96cfda38-b366-4ea6-bff2-071326ff2354"), false, "Nicaragua" },
                    { new Guid("9b115a3e-2ded-4517-930f-d0940ad32997"), false, "Chile" },
                    { new Guid("b0ca4978-89ce-4689-92c8-0ac24514b185"), false, "Costa Rica" },
                    { new Guid("bde6dd9b-ced6-46f9-9bbb-a2341ccc02e3"), false, "Honduras" },
                    { new Guid("bed23c82-95aa-40b4-8e86-f65f27393e81"), false, "Uruguay" },
                    { new Guid("c586e884-907e-4f68-afdc-0ba98898a865"), false, "Argentina" },
                    { new Guid("ef4a591e-7132-4355-b275-612079652d68"), false, "Venezuela" },
                    { new Guid("f833146c-d003-4b76-9199-816bbca5e487"), false, "Paraguay" },
                    { new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Ecuador" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("04e24f34-7565-49f4-9b05-b6b6d571503c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5008), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("1244c27f-c31f-435b-a2a8-cd677bbff825"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4991), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("165b460a-867b-49a7-9811-185f47b208c6"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5013), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("26ccb193-bbc4-4336-8db4-a289169ae174"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4995), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("28e062e3-074a-434d-b3f2-1a7dae50f389"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4978), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("3474ed44-6107-49e5-b844-263d64d10332"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4986), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("49bbf117-9eb6-4546-b67a-6e432e50938e"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5025), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("4b101b85-7bd6-4d0e-8cbe-a63cf93ae2ef"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4972), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("623e045d-9219-483c-bbe6-893f16736367"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5000), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("6a758a66-92a0-472b-a790-029599a3d513"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5021), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("a68e572c-0b22-46d4-b370-3dc4e2238797"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5033), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("b3ad34d2-22da-4d3d-b2e7-6649bef1785c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5017), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("ee47cc50-6d1d-405b-8fe3-037c7527109d"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5029), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("fca6f933-13ac-4e54-8e52-a597808bc938"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(5004), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("fcb66825-c040-40b3-80ff-277871fb58c8"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4982), null, false, "pedrolopez@gmail.com", "Pedro López", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4660), null, null, false, "Full Stack Developer (C#, Angular)", null },
                    { new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4664), null, null, false, "Back-end Developer (Java, Python)", null },
                    { new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4665), null, null, false, "Front-end Developer (React, Angular)", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4694), null, false, "CSS", null },
                    { new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4699), null, false, "NodeJS", null },
                    { new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4692), null, false, "HTML", null },
                    { new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4691), null, false, "JavaScript", null },
                    { new Guid("51373385-dce2-458c-a06b-9b20625b7702"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4689), null, false, "Java", null },
                    { new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4695), null, false, "NoSQL - MongoDB", null },
                    { new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4685), null, false, "C#", null },
                    { new Guid("76a48392-0e58-496a-ae78-562df47896b7"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4694), null, false, "SQL", null },
                    { new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4698), null, false, "React", null },
                    { new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4690), null, false, "Python", null },
                    { new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4700), null, false, "Spring Boot", null },
                    { new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4696), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("06ee5076-a23a-4992-a531-73f28dcc6e0c"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Antioquia" },
                    { new Guid("112e1a7a-61de-4727-ae78-c334a9749c1e"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Cauca" },
                    { new Guid("16b17cf0-a21d-4326-a131-54e65c9d0ba7"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Quindío" },
                    { new Guid("16dcddfa-a07c-41fb-9220-56110eeda8af"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Carchi" },
                    { new Guid("2202b5b0-5a9a-4244-83b2-5f584c630de5"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Magdalena" },
                    { new Guid("2407f862-42b1-4fcd-9dab-942a97619073"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Boyacá" },
                    { new Guid("2f6ad742-5900-420c-a0b8-7ed7bcc96638"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Vaupés" },
                    { new Guid("3144b1d9-290f-44c2-96e6-87c4fc7ef1c0"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Napo" },
                    { new Guid("351dc6b5-0f15-4e10-b629-32c3b8000a63"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Sucre" },
                    { new Guid("36357c75-343c-461d-8dbc-3d322a631318"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Meta" },
                    { new Guid("3e600b2e-6667-4c20-8ec6-9b1c22cd32f6"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "La Guajira" },
                    { new Guid("3f65d6e7-6220-402e-90f5-3f6b35faa640"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Guayas" },
                    { new Guid("403ccec8-01de-4ef4-803e-8b6ce92f4117"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Risaralda" },
                    { new Guid("47cb486b-a9ca-4add-b322-1ae315570148"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Cañar" },
                    { new Guid("4edd6c7d-8d6e-4c8f-b2ef-e6a0ad176452"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Guainía" },
                    { new Guid("566bb592-5b5f-4327-84a3-cc2f460383b0"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Atlántico" },
                    { new Guid("5b8a2436-9e9f-4a5a-b85d-3dc8b0ad824a"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Amazonas" },
                    { new Guid("60fc1cda-fa12-43d2-891d-99e2af98e221"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Chocó" },
                    { new Guid("7382ca5a-91a6-4616-8f6b-5a0a0e8d03f6"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "San Andrés y Providencia" },
                    { new Guid("750608fd-76d7-44da-ae08-846fddaf1326"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Cotopaxi" },
                    { new Guid("753e1d62-f09b-4b1f-b9e9-bf6dc8880067"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Guaviare" },
                    { new Guid("779a8cd3-e00b-4298-b4d2-8831dbe8f213"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Valle del Cauca" },
                    { new Guid("791056c1-56e8-4bdc-a3ee-2146f92fab31"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Córdoba" },
                    { new Guid("83068013-4630-40c9-a666-06f20c6b87d0"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Norte de Santander" },
                    { new Guid("9170f022-6945-4307-8d6c-2814518c4237"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Casanare" },
                    { new Guid("93bfbd38-08f8-4e42-bd67-62f89fde9f5f"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Tolima" },
                    { new Guid("9a0683f4-e2db-4dc4-bff7-9bfa44745da3"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Caquetá" },
                    { new Guid("9d2d444e-974d-4da1-bb65-d3111ff3513b"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Cundinamarca" },
                    { new Guid("9d647871-436c-4371-9452-d02a3362a1ea"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Bolívar" },
                    { new Guid("a1879107-545a-4935-b494-f77dd3c98b69"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Huila" },
                    { new Guid("a33f444d-1fcf-49ab-96d7-215ec7ef9be1"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Santander" },
                    { new Guid("a6743bf0-9027-4e19-aaea-0850ee00b9ac"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Esmeraldas" },
                    { new Guid("ab1146a2-3575-407c-a66c-19938a8176ad"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Imbabura" },
                    { new Guid("ac63e7af-7b57-4bcb-bb7e-a221c7fe5f38"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Bolívar" },
                    { new Guid("adf6db14-25c4-42f7-97d7-6b64d69e8a22"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Loja" },
                    { new Guid("af65e999-32f0-4ab9-92de-af82191d9b01"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Putumayo" },
                    { new Guid("b238e9ee-9613-4bc9-ad7f-3e30b099ee87"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Cesar" },
                    { new Guid("b314baa6-c2ad-4749-9928-82683cfde424"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Vichada" },
                    { new Guid("b778d377-cb70-4f83-9d85-dc0d89b1daf6"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "El Oro" },
                    { new Guid("c6bbc338-12c6-4e7f-827e-a0596fd0bd97"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Chimborazo" },
                    { new Guid("cc6a7504-da13-4cd9-8dfd-2030a62f7883"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Galápagos" },
                    { new Guid("cf19cb9b-6bb1-4339-9cc3-edf9e1f6a9ed"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Nariño" },
                    { new Guid("d51a2fbd-49c7-49f4-8210-c7c87c2a45e8"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Morona Santiago" },
                    { new Guid("d6a00c85-3b78-400e-b960-87caf05d5ee2"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Caldas" },
                    { new Guid("daa5be8b-37ad-4e2d-be24-2d4892d247cc"), new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"), false, "Arauca" },
                    { new Guid("deee9bae-0942-4249-839c-b7fcb925168a"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Manabí" },
                    { new Guid("e58e1957-2c22-46f7-8314-b56f0f510997"), new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"), false, "Azuay" }
                });

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("066e21db-c42f-4479-b118-4913d378126b"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4886), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("1bdde3a9-a6dc-4ba2-ad3c-2bc0bee964c6"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4914), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("36397541-97e4-46dc-88bd-4097679e7e1c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4925), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("3fd72cd7-452a-4610-96e2-7063b62b97df"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4918), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("648bd820-b92b-4a34-a609-82893bfc9556"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4922), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("70da6774-e1b0-4360-b803-1045c657b1b2"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4898), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("7913efd0-2ff9-4bea-a9d5-26d6f8d2681a"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4902), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("8603b324-6e8b-48b6-91c9-30e88d533b41"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4932), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("919fe33d-3f2f-48c1-baf3-8c4e847bc7bf"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4890), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("9eb91402-4a94-4cde-929b-a9ea63d73f6e"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4851), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("b7480af0-a692-4e8f-8740-7ee63bd86856"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4906), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("bf5bfb78-4b02-42f8-8b2a-e35df41045bb"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4894), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("c0a81df5-2c98-45af-9703-4fad44cb8d24"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4910), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("dba2b12f-e9d9-40ba-b26f-8e3225a5fda3"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4936), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("e61d37a5-bbb6-469a-8c65-598bb71cf887"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4939), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("ee676090-4306-454b-8c90-5e65005b04e0"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4929), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null }
                });

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("00faba6c-bd52-4a64-8076-3b04e2137a26"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4772), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("08f7940c-2de2-47ae-94d6-ca2ac07e6c63"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4797), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("1d4ff3df-a5af-4a0f-b315-eea0464e1c91"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4741), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("3d4024c0-4a1b-4617-a85e-4ea94a9f55db"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4786), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("433da17c-b226-4b33-9f3f-6d5bf63fe069"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4729), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("4f064d97-c9bc-42c4-affa-4ffd5aacd649"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4805), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("5a5af5d4-6ba2-4d2b-963f-3f0215769f34"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4775), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("6d4dcc2c-6998-4fda-8a5e-750e2934adc8"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4760), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("6fc27480-0aad-4ac2-8405-12521f36d4e0"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4768), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("73890fe1-e809-411f-85ae-764a2268ac1f"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4793), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("7ce1f509-37c5-4f29-a4b8-9fde926ac38a"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4753), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("84aa39af-de2e-4ef6-b3dc-a19e52872837"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4789), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("86c59807-ca97-4540-8a43-7179e95efe42"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4801), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("8993e851-7b82-46ad-a565-aced30ccad3a"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4748), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("925f2754-c850-4c86-8e38-1f7b5387c9d1"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4737), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("9f1dae97-6695-44dd-b30a-1ce16990624d"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4808), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("a996917f-f353-493b-944c-f55cece87bf5"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4764), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("af8989ba-51f7-442c-bc17-8238264ae3ab"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4819), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("c3a95e51-e57d-4c4c-961a-1be22d7e2c9e"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4756), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("e1f98bb2-6514-4db8-8b8e-0da37a57b84c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4812), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("e24c23a7-72ad-4474-9c0f-65becef4db58"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4779), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("ea326836-5b01-4535-98c1-27a3ecd2f8f4"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4745), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("ec18b0c0-b78e-4847-903a-68e65340b953"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4816), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("f66f9ecb-f5a1-41e1-aa32-b35793ea765c"), new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4782), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("0039987e-1142-458c-9b64-db851d6c9e9a"), false, "Uribia", new Guid("3e600b2e-6667-4c20-8ec6-9b1c22cd32f6") },
                    { new Guid("011ad1ec-f70a-49ae-b5cd-53633f9b59f5"), false, "Ibarra", new Guid("ab1146a2-3575-407c-a66c-19938a8176ad") },
                    { new Guid("0177fa53-a95f-4b90-a242-dd6f83d9fdaf"), false, "Inírida", new Guid("4edd6c7d-8d6e-4c8f-b2ef-e6a0ad176452") },
                    { new Guid("01b47147-31fc-45d5-8f08-66bde755dc85"), false, "San José del Guaviare", new Guid("753e1d62-f09b-4b1f-b9e9-bf6dc8880067") },
                    { new Guid("030aa3ef-9c54-4391-a00a-dec85ab53aec"), false, "San Andrés", new Guid("7382ca5a-91a6-4616-8f6b-5a0a0e8d03f6") },
                    { new Guid("0641e33c-e959-47dd-b559-39d112ebf7bb"), false, "Cereté", new Guid("791056c1-56e8-4bdc-a3ee-2146f92fab31") },
                    { new Guid("08c14c13-e949-492e-b5af-0cbf5f3d51f3"), false, "Tulcán", new Guid("16dcddfa-a07c-41fb-9220-56110eeda8af") },
                    { new Guid("09137ee7-bbcc-4222-abde-c6114913ba7f"), false, "Morelia", new Guid("9a0683f4-e2db-4dc4-bff7-9bfa44745da3") },
                    { new Guid("09d423b0-35c0-4b49-9eaa-eefb84a455c6"), false, "Garzón", new Guid("a1879107-545a-4935-b494-f77dd3c98b69") },
                    { new Guid("0a510b13-043c-45ca-9981-9201801b2788"), false, "Yavaraté", new Guid("2f6ad742-5900-420c-a0b8-7ed7bcc96638") },
                    { new Guid("0b646678-43d5-426a-b3c9-df2d23393ead"), false, "La Paz", new Guid("b238e9ee-9613-4bc9-ad7f-3e30b099ee87") },
                    { new Guid("0c0010fb-6923-4842-a19a-5a57e25fb637"), false, "Ipiales", new Guid("cf19cb9b-6bb1-4339-9cc3-edf9e1f6a9ed") },
                    { new Guid("0c145c68-56c2-4fda-a895-3457e262d7d3"), false, "Puerto Carreño", new Guid("b314baa6-c2ad-4749-9928-82683cfde424") },
                    { new Guid("0fa7445e-4d51-4614-ac39-dfbbd312b667"), false, "Palmira", new Guid("779a8cd3-e00b-4298-b4d2-8831dbe8f213") },
                    { new Guid("10e62ca4-8626-4554-8d2d-210378cb2acf"), false, "Alausí", new Guid("c6bbc338-12c6-4e7f-827e-a0596fd0bd97") },
                    { new Guid("12516965-e0d6-45c2-9e8d-afb2bbb957bc"), false, "Silvia", new Guid("112e1a7a-61de-4727-ae78-c334a9749c1e") },
                    { new Guid("14aa8def-7b9c-44f6-9c7b-f36b0fbc2804"), false, "Cartagena del Chairá", new Guid("9d647871-436c-4371-9452-d02a3362a1ea") },
                    { new Guid("1ba6a3a1-49f3-4a47-bcd5-6f9636d69d7f"), false, "Ibagué", new Guid("93bfbd38-08f8-4e42-bd67-62f89fde9f5f") },
                    { new Guid("1eba19a5-398a-40db-9244-2a7338ad7e95"), false, "Montería", new Guid("791056c1-56e8-4bdc-a3ee-2146f92fab31") },
                    { new Guid("1f3d20c6-b269-4198-aa28-28cf4c56b4ba"), false, "La Tebaida", new Guid("16b17cf0-a21d-4326-a131-54e65c9d0ba7") },
                    { new Guid("1fbde9e7-a00a-4aa6-972e-dcfc674f84ab"), false, "Santa Catalina", new Guid("7382ca5a-91a6-4616-8f6b-5a0a0e8d03f6") },
                    { new Guid("205c2133-b8e9-481b-9c33-563f550a1bbb"), false, "Turbo", new Guid("06ee5076-a23a-4992-a531-73f28dcc6e0c") },
                    { new Guid("231683ed-6382-4e93-a924-a81bb28df409"), false, "Piedecuesta", new Guid("a33f444d-1fcf-49ab-96d7-215ec7ef9be1") },
                    { new Guid("23b66d25-30b3-4dd8-98d0-68fdf99a8286"), false, "Santa Helena", new Guid("b314baa6-c2ad-4749-9928-82683cfde424") },
                    { new Guid("2843d075-04f9-470b-a9bc-a1099b5b341f"), false, "Montería", new Guid("351dc6b5-0f15-4e10-b629-32c3b8000a63") },
                    { new Guid("2d0af8ef-87b3-4151-872a-954e3a3df8c6"), false, "Villavicencio", new Guid("36357c75-343c-461d-8dbc-3d322a631318") },
                    { new Guid("2d8791cc-746b-4cb0-97b6-782016fc7204"), false, "Guaranda", new Guid("ac63e7af-7b57-4bcb-bb7e-a221c7fe5f38") },
                    { new Guid("2de2477e-c870-4d07-9b5c-fb3d1b07d6ce"), false, "Popayán", new Guid("112e1a7a-61de-4727-ae78-c334a9749c1e") },
                    { new Guid("2fdb185e-1924-4afa-99d5-43f8f51f5635"), false, "Latacunga", new Guid("750608fd-76d7-44da-ae08-846fddaf1326") },
                    { new Guid("315a8cd6-7a7a-414e-8f7f-cbab691398d9"), false, "Chone", new Guid("deee9bae-0942-4249-839c-b7fcb925168a") },
                    { new Guid("32012616-6f1d-4b84-a6b6-4a25683060a7"), false, "Sincelejo", new Guid("351dc6b5-0f15-4e10-b629-32c3b8000a63") },
                    { new Guid("32902217-54fc-4085-ac72-d459593b1800"), false, "Neiva", new Guid("a1879107-545a-4935-b494-f77dd3c98b69") },
                    { new Guid("34dcc126-ce69-4059-ae06-6b590d31176e"), false, "Machala", new Guid("b778d377-cb70-4f83-9d85-dc0d89b1daf6") },
                    { new Guid("362938af-08d7-4cd2-b266-a8f0a07efcdf"), false, "Santa Marta", new Guid("2202b5b0-5a9a-4244-83b2-5f584c630de5") },
                    { new Guid("3a02a5e0-3773-442d-a909-e64df600d02b"), false, "Honda", new Guid("93bfbd38-08f8-4e42-bd67-62f89fde9f5f") },
                    { new Guid("3c9e4bb4-5e36-4475-a0ff-4ffe7667b4b9"), false, "Chinchiná", new Guid("d6a00c85-3b78-400e-b960-87caf05d5ee2") },
                    { new Guid("3e2f85de-d721-4399-874d-0f9daa3b8906"), false, "Arauca", new Guid("daa5be8b-37ad-4e2d-be24-2d4892d247cc") },
                    { new Guid("41a03de7-b4a9-4054-8a92-7791c5a05a21"), false, "Soledad", new Guid("566bb592-5b5f-4327-84a3-cc2f460383b0") },
                    { new Guid("434dbc65-3ddc-4034-be24-3b053096bf72"), false, "Maicao", new Guid("3e600b2e-6667-4c20-8ec6-9b1c22cd32f6") },
                    { new Guid("4374fc74-a1f9-4832-9a6a-ee45b636832e"), false, "Santander de Quilichao", new Guid("112e1a7a-61de-4727-ae78-c334a9749c1e") },
                    { new Guid("439bb79b-ed6d-4ab5-ac7d-86bde282c6cc"), false, "Barranquilla", new Guid("566bb592-5b5f-4327-84a3-cc2f460383b0") },
                    { new Guid("461e7094-8a81-4afd-a59a-4934ec9c1418"), false, "Armenia", new Guid("16b17cf0-a21d-4326-a131-54e65c9d0ba7") },
                    { new Guid("46de6866-edf0-4b1a-8842-6a412192f05c"), false, "Cúcuta", new Guid("83068013-4630-40c9-a666-06f20c6b87d0") },
                    { new Guid("478ddf86-8cc5-4f5e-b71e-eef001abe912"), false, "Gualaquiza", new Guid("d51a2fbd-49c7-49f4-8210-c7c87c2a45e8") },
                    { new Guid("4963c1e8-8000-4657-a880-84612a2f899b"), false, "Apartadó", new Guid("06ee5076-a23a-4992-a531-73f28dcc6e0c") },
                    { new Guid("49b5ef9f-5f6e-4037-88cd-9210643013d9"), false, "Medellín", new Guid("06ee5076-a23a-4992-a531-73f28dcc6e0c") },
                    { new Guid("4b6c06db-d007-4842-98a6-9ff99407aed0"), false, "El Retén", new Guid("753e1d62-f09b-4b1f-b9e9-bf6dc8880067") },
                    { new Guid("4f352686-347d-42c4-9ad1-351a6338ff1b"), false, "Guayaquil", new Guid("3f65d6e7-6220-402e-90f5-3f6b35faa640") },
                    { new Guid("56a56d7f-8da8-4828-a9bd-9df7d33a23aa"), false, "San Miguel de Bolívar", new Guid("ac63e7af-7b57-4bcb-bb7e-a221c7fe5f38") },
                    { new Guid("5fa203a1-2074-4f2f-9120-c4b176cf9ebd"), false, "Zipaquirá", new Guid("9d2d444e-974d-4da1-bb65-d3111ff3513b") },
                    { new Guid("5fc93e3f-08c8-4e30-8826-88d223b5a36e"), false, "Girón", new Guid("e58e1957-2c22-46f7-8314-b56f0f510997") },
                    { new Guid("60208469-2a6a-4b8e-9fd6-a50191dd0fd4"), false, "Calamar", new Guid("753e1d62-f09b-4b1f-b9e9-bf6dc8880067") },
                    { new Guid("611ac6b8-bbd4-43fd-8177-4873088b38f3"), false, "Esmeraldas", new Guid("a6743bf0-9027-4e19-aaea-0850ee00b9ac") },
                    { new Guid("64de71d0-b8a2-4397-8213-0f579f135f41"), false, "Novita", new Guid("60fc1cda-fa12-43d2-891d-99e2af98e221") },
                    { new Guid("6504046c-28e9-4a35-91a7-d08457883e60"), false, "San Juan de Pasto", new Guid("cf19cb9b-6bb1-4339-9cc3-edf9e1f6a9ed") },
                    { new Guid("696cf319-1d70-4bcd-af51-24bc16e43687"), false, "Barrancabermeja", new Guid("a33f444d-1fcf-49ab-96d7-215ec7ef9be1") },
                    { new Guid("698af6fa-dfb7-4c76-bd77-5b07f4f23427"), false, "Santa Rosa", new Guid("b778d377-cb70-4f83-9d85-dc0d89b1daf6") },
                    { new Guid("6d1afeae-0d90-4611-8012-620be780f93b"), false, "Riohacha", new Guid("3e600b2e-6667-4c20-8ec6-9b1c22cd32f6") },
                    { new Guid("6dc3cb47-37c5-47ef-98cd-e0b5a6c7cc17"), false, "Providencia", new Guid("7382ca5a-91a6-4616-8f6b-5a0a0e8d03f6") },
                    { new Guid("705d2d8f-ecbb-472b-b7c3-bfaf4b380063"), false, "Buenaventura", new Guid("779a8cd3-e00b-4298-b4d2-8831dbe8f213") },
                    { new Guid("7141fd77-795d-41db-804a-a65243ad6c31"), false, "Calarcá", new Guid("16b17cf0-a21d-4326-a131-54e65c9d0ba7") },
                    { new Guid("71eaa10b-25b0-4a42-9ffc-51c75dcd0d12"), false, "Cuenca", new Guid("e58e1957-2c22-46f7-8314-b56f0f510997") },
                    { new Guid("72d18ee6-b1de-40e0-b8d3-39af9123a0d6"), false, "Fortul", new Guid("daa5be8b-37ad-4e2d-be24-2d4892d247cc") },
                    { new Guid("7406630b-6640-4548-95fb-e81ddc65c270"), false, "Cartagena de Indias", new Guid("9d647871-436c-4371-9452-d02a3362a1ea") },
                    { new Guid("7a0685c1-1fdf-4dbb-b88b-05d98cd99b98"), false, "Loja", new Guid("adf6db14-25c4-42f7-97d7-6b64d69e8a22") },
                    { new Guid("7ce73f99-38fb-40c3-b42e-060e37d02ecb"), false, "Corozal", new Guid("351dc6b5-0f15-4e10-b629-32c3b8000a63") },
                    { new Guid("7e4b11f7-9d0b-4098-929d-e1a0254ea2ed"), false, "Bogotá", new Guid("9d2d444e-974d-4da1-bb65-d3111ff3513b") },
                    { new Guid("7ebdb16b-4fc7-4959-9543-f9e288882fb3"), false, "Manizales", new Guid("d6a00c85-3b78-400e-b960-87caf05d5ee2") },
                    { new Guid("7f8282d8-a0cc-42ee-9035-e27f445a6b8c"), false, "Puerto Inírida", new Guid("4edd6c7d-8d6e-4c8f-b2ef-e6a0ad176452") },
                    { new Guid("82258030-4743-446e-a3b5-1e6ab3ff852a"), false, "Cartagena del Chairá", new Guid("9a0683f4-e2db-4dc4-bff7-9bfa44745da3") },
                    { new Guid("83b60ab5-ad29-460a-ba7a-cfef2c3c4d8e"), false, "Armero Guayabal", new Guid("93bfbd38-08f8-4e42-bd67-62f89fde9f5f") },
                    { new Guid("88204926-6b6f-418f-8380-209c90725950"), false, "Duitama", new Guid("2407f862-42b1-4fcd-9dab-942a97619073") },
                    { new Guid("8c7a90cb-35e3-4592-9fa1-6a5348b9479e"), false, "Puerto Asís", new Guid("af65e999-32f0-4ab9-92de-af82191d9b01") },
                    { new Guid("8c884796-2e57-409c-bdc5-0a8ba0436951"), false, "Mocoa", new Guid("af65e999-32f0-4ab9-92de-af82191d9b01") },
                    { new Guid("900d1d08-57d6-4a44-8743-69c96e6f989b"), false, "Orito", new Guid("af65e999-32f0-4ab9-92de-af82191d9b01") },
                    { new Guid("930a17bd-fb6e-4f73-8c81-f8a416c7d29e"), false, "Azogues", new Guid("47cb486b-a9ca-4add-b322-1ae315570148") },
                    { new Guid("93e4a1a7-b838-4882-8550-c9c9e5312458"), false, "Salcedo", new Guid("750608fd-76d7-44da-ae08-846fddaf1326") },
                    { new Guid("9697a8bd-7a85-4325-9027-5927b9721fff"), false, "Macas", new Guid("d51a2fbd-49c7-49f4-8210-c7c87c2a45e8") },
                    { new Guid("9b0ce14c-6383-424c-90dd-c2b9b2da1a28"), false, "Mitú", new Guid("2f6ad742-5900-420c-a0b8-7ed7bcc96638") },
                    { new Guid("9c874439-fb93-44ca-8e1a-f67321453d46"), false, "Pamplona", new Guid("83068013-4630-40c9-a666-06f20c6b87d0") },
                    { new Guid("9f055959-45f7-444b-abc4-9cae7d65e1d7"), false, "Pereira", new Guid("403ccec8-01de-4ef4-803e-8b6ce92f4117") },
                    { new Guid("a1762d03-86ff-4e4d-ab50-2376c7014e78"), false, "Aracataca", new Guid("2202b5b0-5a9a-4244-83b2-5f584c630de5") },
                    { new Guid("a4c18f64-6e82-4e1f-994c-f0fd1c5cad4e"), false, "Pereira", new Guid("d6a00c85-3b78-400e-b960-87caf05d5ee2") },
                    { new Guid("a6de8905-1c91-476f-b708-b20313f9fb7b"), false, "Puerto Baquerizo Moreno", new Guid("cc6a7504-da13-4cd9-8dfd-2030a62f7883") },
                    { new Guid("a75709ec-9894-48c2-a0c3-d7ee40878152"), false, "Florencia", new Guid("9a0683f4-e2db-4dc4-bff7-9bfa44745da3") },
                    { new Guid("aa99096e-215f-40d6-b42b-62c2250a867d"), false, "El Guabo", new Guid("16dcddfa-a07c-41fb-9220-56110eeda8af") },
                    { new Guid("aaa03997-fe3a-4082-9037-aeed16ada78b"), false, "Tauramena", new Guid("9170f022-6945-4307-8d6c-2814518c4237") },
                    { new Guid("abe69e51-d554-46fd-b628-1edfccfddb7b"), false, "Quibdó", new Guid("60fc1cda-fa12-43d2-891d-99e2af98e221") },
                    { new Guid("b141ae34-2cd5-4065-becf-506001dcc357"), false, "Archidona", new Guid("3144b1d9-290f-44c2-96e6-87c4fc7ef1c0") },
                    { new Guid("b8b21f0c-27a7-46a6-97b7-8250f9f024c8"), false, "Riobamba", new Guid("c6bbc338-12c6-4e7f-827e-a0596fd0bd97") },
                    { new Guid("c0d1d9e6-f56f-4bd7-a04f-e326f9b2d84a"), false, "Memarí", new Guid("4edd6c7d-8d6e-4c8f-b2ef-e6a0ad176452") },
                    { new Guid("c2783500-1a9f-4e0a-a325-cc5ea5f9f604"), false, "Santa Rosalía", new Guid("2f6ad742-5900-420c-a0b8-7ed7bcc96638") },
                    { new Guid("c5ca4a1c-d0c9-442e-a79b-09340e056196"), false, "Leticia", new Guid("5b8a2436-9e9f-4a5a-b85d-3dc8b0ad824a") },
                    { new Guid("c7fa06e8-4725-46b3-aa1b-82f61d09a243"), false, "Bucaramanga", new Guid("a33f444d-1fcf-49ab-96d7-215ec7ef9be1") },
                    { new Guid("c908c726-575a-4dea-82d7-dcdbe83c7d95"), false, "Ciénaga", new Guid("2202b5b0-5a9a-4244-83b2-5f584c630de5") },
                    { new Guid("cc3b6410-c34c-4db7-afa0-20481b4870e0"), false, "Ocaña", new Guid("83068013-4630-40c9-a666-06f20c6b87d0") },
                    { new Guid("ccc19999-f0e9-4ca3-a5f5-a0ad932173b7"), false, "Cali", new Guid("779a8cd3-e00b-4298-b4d2-8831dbe8f213") },
                    { new Guid("cd4712d9-a200-49d2-bc22-91714e09b031"), false, "Aguachica", new Guid("b238e9ee-9613-4bc9-ad7f-3e30b099ee87") },
                    { new Guid("ce5f94ba-b53c-4593-8667-868ceeef11b9"), false, "Atacames", new Guid("a6743bf0-9027-4e19-aaea-0850ee00b9ac") },
                    { new Guid("d223d617-78db-4eb2-bf77-dd509a0e7bdd"), false, "Yopal", new Guid("9170f022-6945-4307-8d6c-2814518c4237") },
                    { new Guid("d24444d8-73b7-4129-b47e-7a6265f7928e"), false, "Portoviejo", new Guid("deee9bae-0942-4249-839c-b7fcb925168a") },
                    { new Guid("d6cf8569-8ea6-4fd0-b5ad-fa82c08d9bad"), false, "Saravena", new Guid("daa5be8b-37ad-4e2d-be24-2d4892d247cc") },
                    { new Guid("d83b1ba2-053c-4097-a7b6-dd375ed705ec"), false, "Manta", new Guid("deee9bae-0942-4249-839c-b7fcb925168a") },
                    { new Guid("d9df1dec-32b2-43f5-94fb-fa09ecee33e8"), false, "Santa Rosa de Cabal", new Guid("403ccec8-01de-4ef4-803e-8b6ce92f4117") },
                    { new Guid("dcccbb09-defa-4c8f-8e3b-686afae9bdf9"), false, "Pitalito", new Guid("a1879107-545a-4935-b494-f77dd3c98b69") },
                    { new Guid("debc4b8a-b7e3-479a-9bc3-d8835a4c2214"), false, "Puerto Colombia", new Guid("566bb592-5b5f-4327-84a3-cc2f460383b0") },
                    { new Guid("e13923f1-c115-4844-b01a-13febbe9f5db"), false, "Tunja", new Guid("2407f862-42b1-4fcd-9dab-942a97619073") },
                    { new Guid("e413a14c-81af-457d-aeb8-1d6aef330aa3"), false, "Granada", new Guid("36357c75-343c-461d-8dbc-3d322a631318") },
                    { new Guid("e516d3e6-bf90-493d-8608-0b0c429c50e4"), false, "Aguazul", new Guid("9170f022-6945-4307-8d6c-2814518c4237") },
                    { new Guid("e70a2464-cefb-42c3-bf63-57b2b3db797b"), false, "Lorica", new Guid("791056c1-56e8-4bdc-a3ee-2146f92fab31") },
                    { new Guid("e8113fb7-8434-4655-8ac3-23e253b37a55"), false, "San Cristóbal", new Guid("cc6a7504-da13-4cd9-8dfd-2030a62f7883") },
                    { new Guid("e842821b-59b2-4c23-9a47-02c87499057f"), false, "Acacias", new Guid("36357c75-343c-461d-8dbc-3d322a631318") },
                    { new Guid("e922ee9c-ea07-48ab-b639-79133e9b5077"), false, "Soacha", new Guid("9d2d444e-974d-4da1-bb65-d3111ff3513b") },
                    { new Guid("e9a441b4-7fa1-42a7-a10c-faa25d155122"), false, "Otavalo", new Guid("ab1146a2-3575-407c-a66c-19938a8176ad") },
                    { new Guid("ed1ebe13-e102-4337-8c6d-6fd47b2be005"), false, "La Primavera", new Guid("b314baa6-c2ad-4749-9928-82683cfde424") },
                    { new Guid("edd62f5b-30ea-4378-806c-5b2850f989e9"), false, "El Tambo", new Guid("47cb486b-a9ca-4add-b322-1ae315570148") },
                    { new Guid("f234d947-627a-4502-88e8-d3fd3dd3e41d"), false, "Durán", new Guid("3f65d6e7-6220-402e-90f5-3f6b35faa640") },
                    { new Guid("f4f000bf-792b-46a2-99ad-8616b3152c1e"), false, "Saraguro", new Guid("adf6db14-25c4-42f7-97d7-6b64d69e8a22") },
                    { new Guid("f6859a7b-7f97-4ea8-b3ad-db15d142e84a"), false, "Tumaco", new Guid("cf19cb9b-6bb1-4339-9cc3-edf9e1f6a9ed") },
                    { new Guid("f6e86aee-a3b9-4e5a-b79e-6d5494bbb2c5"), false, "Sogamoso", new Guid("2407f862-42b1-4fcd-9dab-942a97619073") },
                    { new Guid("f7908f01-552e-430f-946b-6c251fcd812d"), false, "Istmina", new Guid("60fc1cda-fa12-43d2-891d-99e2af98e221") },
                    { new Guid("f87b7694-353e-4c58-9d64-0930831a8467"), false, "Dosquebradas", new Guid("403ccec8-01de-4ef4-803e-8b6ce92f4117") },
                    { new Guid("f9af0678-9025-448e-bbe3-b4a2b02ca23a"), false, "Valledupar", new Guid("b238e9ee-9613-4bc9-ad7f-3e30b099ee87") },
                    { new Guid("fb858622-94e3-421d-9cc3-f1f5812619fb"), false, "Tena", new Guid("3144b1d9-290f-44c2-96e6-87c4fc7ef1c0") },
                    { new Guid("fcab6ea0-e32e-4919-bce5-644fd818897f"), false, "Magangué", new Guid("9d647871-436c-4371-9452-d02a3362a1ea") }
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
