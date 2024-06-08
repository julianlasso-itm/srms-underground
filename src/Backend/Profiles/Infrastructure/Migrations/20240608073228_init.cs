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
                    { new Guid("06315128-21ce-48c1-aaa9-4a923521b5f6"), false, "Argentina" },
                    { new Guid("0e3d032d-7070-4fe5-a5a7-14739b5c6982"), false, "Guatemala" },
                    { new Guid("13eab3d6-b4cd-4b5a-a454-b7d631c14974"), false, "Uruguay" },
                    { new Guid("23f6bca3-3309-43d6-b77d-3d45037f65e7"), false, "Nicaragua" },
                    { new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Colombia" },
                    { new Guid("33e936b8-50c5-4894-bc1f-ff18dc4dce52"), false, "Brasil" },
                    { new Guid("3ed5457b-871a-4487-934c-176b5b6bff81"), false, "Venezuela" },
                    { new Guid("46ec666e-0d19-4282-96a5-ba9b6a8b435f"), false, "Costa Rica" },
                    { new Guid("58db3621-01dc-4f21-a49c-1815bbe9f286"), false, "El Salvador" },
                    { new Guid("60f84499-2c1b-4580-9a6d-8a1af3b54658"), false, "Paraguay" },
                    { new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Ecuador" },
                    { new Guid("9bf75e9b-0c90-4108-9bf0-a681c6f9bbde"), false, "Bolivia" },
                    { new Guid("b71673df-87a9-48a7-b238-4b612f9e77e2"), false, "Chile" },
                    { new Guid("c7e64d11-719a-4240-9101-4dffccc57303"), false, "Belize" },
                    { new Guid("cb7f4882-ebf1-4b08-88b4-cfebc02f6842"), false, "Honduras" },
                    { new Guid("e1b7f00e-40e9-4768-aa3d-94ccee663875"), false, "Panamá" },
                    { new Guid("e3293eb5-37fb-48b2-969d-32ae045be891"), false, "Perú" },
                    { new Guid("f48faac9-ab1b-4d15-95aa-ab1fa7c86c66"), false, "México" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("100d8c48-fb81-441b-88ae-ccaf54b455f3"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4602), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("2cb1e70c-d575-4641-9b50-290bf2f6601f"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4574), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("3eb55332-1806-49eb-9277-fed93327de80"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4580), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("40df468f-5260-47e9-8ffb-9767db2ab441"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4590), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("4bd8a66f-263a-4517-a7d6-91c57c965bd8"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4594), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("62ffb8d5-e2e2-4404-9305-87cb8bedfd10"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4606), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("7243f5e4-168a-475a-9ed4-8457202a67c7"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4608), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("76663ed8-f849-49fc-8f05-2d54780a3484"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4600), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("81bbcda5-bf4a-4ae8-87a7-ca49ff60c08f"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4587), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("8738320d-1b47-4783-a27b-d4065071cc44"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4585), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("8797a5ae-5daa-4fa7-912c-371803ac6d4a"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4597), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("a3028ffd-2a94-47c6-aa72-19301127ee10"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4612), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("a6f54957-658e-4dbe-969c-c7b476ec8643"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4592), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("d9a857d2-6323-437c-b167-78a05e9f4144"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4610), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("dd4feef9-d1f6-4fd4-82c1-8bcf086de212"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4578), null, false, "mariagarcia@gmail.com", "María García", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4269), null, null, false, "Full Stack Developer (C#, Angular)", null },
                    { new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4274), null, null, false, "Back-end Developer (Java, Python)", null },
                    { new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4276), null, null, false, "Front-end Developer (React, Angular)", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4322), null, false, "CSS", null },
                    { new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4328), null, false, "NodeJS", null },
                    { new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4320), null, false, "HTML", null },
                    { new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4319), null, false, "JavaScript", null },
                    { new Guid("51373385-dce2-458c-a06b-9b20625b7702"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4316), null, false, "Java", null },
                    { new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4324), null, false, "NoSQL - MongoDB", null },
                    { new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4312), null, false, "C#", null },
                    { new Guid("76a48392-0e58-496a-ae78-562df47896b7"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4323), null, false, "SQL", null },
                    { new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4327), null, false, "React", null },
                    { new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4318), null, false, "Python", null },
                    { new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4329), null, false, "Spring Boot", null },
                    { new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4325), null, false, "Angular", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("046cdc00-2ab1-4653-a428-6092d8c72293"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Manabí" },
                    { new Guid("0a532ba8-f9a7-488d-abbd-33604993c7ce"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Risaralda" },
                    { new Guid("0f517405-cf27-433a-8a28-711d10b09bcd"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Caquetá" },
                    { new Guid("1c0ef522-8bfe-4fb2-9fbf-b42cd7b49e9c"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Magdalena" },
                    { new Guid("1fa79fdd-e6de-49bb-9b6b-9c147d459226"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Valle del Cauca" },
                    { new Guid("2674d122-564e-44de-b557-1225c4d5d5f8"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Loja" },
                    { new Guid("2d7a20c1-0911-4ca6-bd96-69efae242084"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Carchi" },
                    { new Guid("313da735-fa61-4c8e-95cd-a1d416c7fc5a"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Quindío" },
                    { new Guid("33fe87da-faa3-46d3-a95f-dc97968c8d71"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Cañar" },
                    { new Guid("3aa5aaf8-d9fb-4b9b-8779-f480db6e6c09"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Boyacá" },
                    { new Guid("3fe85ca3-ab6c-4970-9f80-723d71ddfe5d"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Antioquia" },
                    { new Guid("45ea01af-4a30-4900-b34d-31bdc5171e61"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Nariño" },
                    { new Guid("4dca6aa8-e238-48e8-8c35-4cdb1e36a643"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Amazonas" },
                    { new Guid("556ad5a3-bb6c-4357-a6bf-9a4e7a378c76"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Azuay" },
                    { new Guid("5700c87a-93f6-4680-bf39-bf0cde9d2312"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Caldas" },
                    { new Guid("5760f0d4-8a9f-4611-9fdc-a3b3cca5c11a"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "La Guajira" },
                    { new Guid("5c407e02-3a78-4fbb-88bf-267a052b7952"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Chimborazo" },
                    { new Guid("637e8280-2782-4c2e-86c7-2169b92d86bb"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Guaviare" },
                    { new Guid("649af7ff-1b59-45de-9cb1-51f2c5b1c629"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Cesar" },
                    { new Guid("65a5ac3f-1306-4b2d-8f69-e3ff5c7edfba"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Arauca" },
                    { new Guid("70a4300f-43a7-4d15-afe7-5b28f5c3c3ac"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Santander" },
                    { new Guid("722ba8ba-5a45-4324-a007-b8d44bab4a8e"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Chocó" },
                    { new Guid("739ee4ba-f5da-451d-a689-6a985436cc4e"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Bolívar" },
                    { new Guid("74c6210f-1c41-4452-b19e-70ed0723b768"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Cotopaxi" },
                    { new Guid("74d5fe74-3e4e-46cc-b5cc-83147a8fac7e"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Vichada" },
                    { new Guid("795e7d88-999c-458d-95b7-9a62dd8a7c55"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Guayas" },
                    { new Guid("7edd6b01-e7f3-4708-ac09-d1ade29c8a67"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Esmeraldas" },
                    { new Guid("8269bd18-613f-41fb-9da1-bed1095b1a34"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Córdoba" },
                    { new Guid("84f638e0-f7fa-456b-90d4-0b0f613c02d8"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Meta" },
                    { new Guid("8b792a35-c726-4418-a0b6-b62bd2ac285e"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Cauca" },
                    { new Guid("8bfcda4a-9476-4db9-9730-3a1571d8ce13"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Cundinamarca" },
                    { new Guid("8ddc002b-68dd-45db-bb25-a8aa40754aa2"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Vaupés" },
                    { new Guid("a053f3b7-8502-40c3-82ba-61cbd3f7da46"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Napo" },
                    { new Guid("a9acb7a0-cfc0-4817-8334-fa64a7d676e8"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Norte de Santander" },
                    { new Guid("ad7d82d4-3cd3-494e-aa4b-d58b5bc3f038"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Putumayo" },
                    { new Guid("b18640b5-072f-4a16-8349-21b5a6af2d3c"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "El Oro" },
                    { new Guid("ba4b5c10-9b56-4d3a-8d72-4cf9fc9fd1b6"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Guainía" },
                    { new Guid("badb2ed7-707e-4792-81a8-059c3fed4f72"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Huila" },
                    { new Guid("bb3da45f-783f-49fb-b4ad-2cfd309b5695"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "San Andrés y Providencia" },
                    { new Guid("d1cc1654-eb91-462e-a30f-1f841800af80"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Morona Santiago" },
                    { new Guid("d31f5bb2-6258-4121-a7da-13e9c0f128d3"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Atlántico" },
                    { new Guid("dfc80a67-f81c-48b6-becd-f5e4dd686680"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Casanare" },
                    { new Guid("e2a81fec-5337-4df7-b5a9-2fc281b034da"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Imbabura" },
                    { new Guid("ede74ef9-2390-4811-a2a7-be9547f4e07e"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Sucre" },
                    { new Guid("f17c0e8e-b6ce-4c47-abaa-6b5f52819df8"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Galápagos" },
                    { new Guid("fa8330ee-c23f-46c0-ae30-00c1e1c0f9c6"), new Guid("7e3ea3e9-9775-4855-806e-5200239c0fca"), false, "Bolívar" },
                    { new Guid("ff1796ea-8ce3-4367-9272-1f6251afb983"), new Guid("2f4553c4-6cd3-45a3-acf9-a45b29e093c5"), false, "Tolima" }
                });

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0ab9515a-8efd-4bef-9335-b2cda9cb52f7"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4530), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("25804b68-d9cf-46d4-b13d-0eff55c1bae9"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4519), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("3d5f6dbf-6901-46fb-84a7-fb16fe23ad72"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4516), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("45c171a0-2603-400f-ba55-16cfa196d8ef"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4527), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("5b14a4c1-0338-4d67-bee5-af6fd952ad02"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4517), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("5e0996aa-d09d-40e3-89b2-6fb1be350d2c"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4511), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("777890db-1e5c-4608-adb0-50444a835ba1"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4508), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("7bd1bf75-deec-470b-96b3-adf682d1b9a5"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4529), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("9ad4f806-1b28-40b9-af6e-892bda0cde82"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4532), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("9c3ee6b5-e1fc-4913-a04e-b7a628e3f467"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4506), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("a160abe1-9fc1-4482-bbce-13996e4bc8ea"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4514), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("aadd46ce-2186-4160-8e1f-5416fef8f875"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4505), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("b391090a-5388-46f4-a2ff-eaee777df7d9"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4524), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("c5f77f75-95cc-4fb3-aca2-4f4e04ac6310"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4523), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("d2b8d6ce-9a3f-4a7c-8c84-f74a64b8ad7b"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4500), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("d2d74b6f-adac-4778-93d0-8bd797374959"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4521), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null }
                });

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("08a221be-de5c-4778-87da-80bdd5080d1e"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4372), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("1eb9f04d-caa1-4bbb-9728-4089d90d630a"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4408), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("276599d9-d72a-4f38-907a-7e3a5005dfda"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4389), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("2c960c6a-f6b2-448d-8d0f-74777202b453"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4369), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("2d7b3708-9f6b-4c9c-a861-ba6e765b0721"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4403), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("3cc795ec-6fe5-4c2e-a74d-3ee41f415e8b"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4394), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("465fa6b5-488c-47e0-b41a-6e7b68df9649"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4409), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("4e66a7c5-5efa-4968-bdc4-3d261ba31e3e"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4383), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("6ba5be9a-5b1b-4db2-82da-1d6acbceca06"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4380), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("8b6a9cf7-b499-4af7-be40-bb14429ffa34"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4399), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("8fcef5a3-3a13-4cba-abaf-ce379a2da8cb"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4379), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("98907a49-21d2-4dfc-a06a-77cf3c8c4360"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4393), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("9c67d5e4-72e4-42af-b767-bc4db65f9ed3"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4364), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("a112bbea-a4d9-4285-a0de-1be6088706ea"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4385), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("a3c4a666-6e59-4204-8131-81a85b2f5f9d"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4387), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("b8b938d1-4097-43c1-8fc6-edaeac41247e"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4401), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("bf226769-de9f-4ee8-91e1-38c4fd5c77e4"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4382), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("c8ba5a76-ffb0-42cd-89c7-9e164d42ee87"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4411), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("cbfe63ba-4afa-465e-b5b1-12eab0622e4c"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4371), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("d27e90ef-74d2-40b7-a827-9b9ce9e75094"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4376), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("d2e8c974-cf66-48ce-a0f0-a90bba839bd4"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4404), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("da5ad58c-7552-47d2-9150-e8a46fb1ad09"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4396), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("db671b49-87cd-4bf0-bf50-d61bdacbbbb8"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4414), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("e1875dab-b1f7-4e39-b393-092a7c9c1c9f"), new DateTime(2024, 6, 8, 7, 32, 28, 390, DateTimeKind.Utc).AddTicks(4398), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("01228fe5-6ff4-4c82-b84c-443dea85ca49"), false, "Duitama", new Guid("3aa5aaf8-d9fb-4b9b-8779-f480db6e6c09") },
                    { new Guid("04f26a9d-95e6-4b46-9b06-3c40749fd891"), false, "Yavaraté", new Guid("8ddc002b-68dd-45db-bb25-a8aa40754aa2") },
                    { new Guid("077242ee-46ac-4841-917e-830104a46f25"), false, "Riobamba", new Guid("5c407e02-3a78-4fbb-88bf-267a052b7952") },
                    { new Guid("0c6e7b82-01c7-41a6-84d7-5cdf0d6a1ac3"), false, "Pamplona", new Guid("a9acb7a0-cfc0-4817-8334-fa64a7d676e8") },
                    { new Guid("0f699465-6046-48ed-9708-125d02e141aa"), false, "Azogues", new Guid("33fe87da-faa3-46d3-a95f-dc97968c8d71") },
                    { new Guid("107ea498-3cff-4714-a690-53e6b2cb1c34"), false, "Zipaquirá", new Guid("8bfcda4a-9476-4db9-9730-3a1571d8ce13") },
                    { new Guid("10bcb17c-7fee-4d94-9002-2ec42f96d93b"), false, "Bogotá", new Guid("8bfcda4a-9476-4db9-9730-3a1571d8ce13") },
                    { new Guid("10d1fa6e-c044-44c9-b20d-b3e235897c86"), false, "Silvia", new Guid("8b792a35-c726-4418-a0b6-b62bd2ac285e") },
                    { new Guid("143e67e3-7883-44e6-8d76-5dca1286a4f2"), false, "Puerto Carreño", new Guid("74d5fe74-3e4e-46cc-b5cc-83147a8fac7e") },
                    { new Guid("146accde-7ce6-4a9d-8640-fd34cd97bc4a"), false, "Palmira", new Guid("1fa79fdd-e6de-49bb-9b6b-9c147d459226") },
                    { new Guid("17560a46-966b-4eb6-b099-9c7e4e215df3"), false, "Aguachica", new Guid("649af7ff-1b59-45de-9cb1-51f2c5b1c629") },
                    { new Guid("17da67eb-b4bf-4575-b7ee-691ace413a00"), false, "La Paz", new Guid("649af7ff-1b59-45de-9cb1-51f2c5b1c629") },
                    { new Guid("18e3d4ca-5626-4c99-b551-8868b67503d7"), false, "Novita", new Guid("722ba8ba-5a45-4324-a007-b8d44bab4a8e") },
                    { new Guid("196d8c08-01fe-4ee3-bd03-dd469d3c0c08"), false, "Buenaventura", new Guid("1fa79fdd-e6de-49bb-9b6b-9c147d459226") },
                    { new Guid("1a82ebba-9f91-4019-b847-2531c61235cc"), false, "Pitalito", new Guid("badb2ed7-707e-4792-81a8-059c3fed4f72") },
                    { new Guid("1ab51020-da01-4be8-9a90-93e6b7033cfd"), false, "Barrancabermeja", new Guid("70a4300f-43a7-4d15-afe7-5b28f5c3c3ac") },
                    { new Guid("1d73cf61-7ae7-4aa9-892b-9c5133c0c278"), false, "Cereté", new Guid("8269bd18-613f-41fb-9da1-bed1095b1a34") },
                    { new Guid("1e361f7d-77d0-4b6e-bea8-cd376be69364"), false, "Otavalo", new Guid("e2a81fec-5337-4df7-b5a9-2fc281b034da") },
                    { new Guid("20ac1799-3e60-4709-97fd-b182e0929c38"), false, "Quibdó", new Guid("722ba8ba-5a45-4324-a007-b8d44bab4a8e") },
                    { new Guid("28e0fbeb-76ac-4be1-9c4e-59ddee4d26a1"), false, "Manizales", new Guid("5700c87a-93f6-4680-bf39-bf0cde9d2312") },
                    { new Guid("2a0f0db1-6497-4494-b9ee-314577b8b29b"), false, "Santa Catalina", new Guid("bb3da45f-783f-49fb-b4ad-2cfd309b5695") },
                    { new Guid("2a21f304-1204-4db1-affa-ba525fa63036"), false, "Saravena", new Guid("65a5ac3f-1306-4b2d-8f69-e3ff5c7edfba") },
                    { new Guid("2bb11a54-ae11-4ef3-b6c6-833d4dbeda38"), false, "Soledad", new Guid("d31f5bb2-6258-4121-a7da-13e9c0f128d3") },
                    { new Guid("2c83dfa0-d6b4-470c-8d48-eff20422e40b"), false, "Garzón", new Guid("badb2ed7-707e-4792-81a8-059c3fed4f72") },
                    { new Guid("2c9c5e23-29fc-4c08-a055-e1827ff46edc"), false, "Loja", new Guid("2674d122-564e-44de-b557-1225c4d5d5f8") },
                    { new Guid("2ce7581c-a6d9-4509-a330-302814d4089f"), false, "Santa Rosa", new Guid("b18640b5-072f-4a16-8349-21b5a6af2d3c") },
                    { new Guid("2ecfecba-6714-4d0a-a3fd-df9f48c120b6"), false, "Cúcuta", new Guid("a9acb7a0-cfc0-4817-8334-fa64a7d676e8") },
                    { new Guid("37ec7c86-0158-4284-8ed8-03b6bc754c66"), false, "Cartagena del Chairá", new Guid("739ee4ba-f5da-451d-a689-6a985436cc4e") },
                    { new Guid("3aec0447-3c15-482d-a893-afcb3ee3ac5a"), false, "Armero Guayabal", new Guid("ff1796ea-8ce3-4367-9272-1f6251afb983") },
                    { new Guid("3e18241c-2fb8-4016-953f-62e26147fb84"), false, "El Retén", new Guid("637e8280-2782-4c2e-86c7-2169b92d86bb") },
                    { new Guid("3f7f8e69-7299-40af-bec6-9226696d8fb6"), false, "Mocoa", new Guid("ad7d82d4-3cd3-494e-aa4b-d58b5bc3f038") },
                    { new Guid("4010ec52-2188-4859-bb0b-08b75f13dfd1"), false, "Acacias", new Guid("84f638e0-f7fa-456b-90d4-0b0f613c02d8") },
                    { new Guid("41f0c6e3-0d6a-4bba-94e2-88f8bb9d01a5"), false, "Chone", new Guid("046cdc00-2ab1-4653-a428-6092d8c72293") },
                    { new Guid("434d430f-756f-44dc-b149-9d2af54da976"), false, "Durán", new Guid("795e7d88-999c-458d-95b7-9a62dd8a7c55") },
                    { new Guid("44c0d2eb-ad51-491c-869f-d8a2969479c0"), false, "Lorica", new Guid("8269bd18-613f-41fb-9da1-bed1095b1a34") },
                    { new Guid("45f80e0c-cc3a-4bb5-a0fe-70799cb0a7ad"), false, "Ocaña", new Guid("a9acb7a0-cfc0-4817-8334-fa64a7d676e8") },
                    { new Guid("46dfd833-aaf4-4578-94e0-6c1721c23678"), false, "Cali", new Guid("1fa79fdd-e6de-49bb-9b6b-9c147d459226") },
                    { new Guid("479e47fc-4498-45a3-8759-c7b6ada67e11"), false, "Archidona", new Guid("a053f3b7-8502-40c3-82ba-61cbd3f7da46") },
                    { new Guid("4beed6bd-ca83-4db4-818d-797222ae7bf2"), false, "San Juan de Pasto", new Guid("45ea01af-4a30-4900-b34d-31bdc5171e61") },
                    { new Guid("4d1241a6-0059-47b1-89b7-079b6a31fa59"), false, "Mitú", new Guid("8ddc002b-68dd-45db-bb25-a8aa40754aa2") },
                    { new Guid("4eb6d53b-45e7-47f5-aa46-3376e6cb13c3"), false, "Tauramena", new Guid("dfc80a67-f81c-48b6-becd-f5e4dd686680") },
                    { new Guid("4eeb5ea1-607f-4e19-96b7-be071cb9101a"), false, "Valledupar", new Guid("649af7ff-1b59-45de-9cb1-51f2c5b1c629") },
                    { new Guid("4f04a563-e2fb-4cce-a744-a16193560b95"), false, "Corozal", new Guid("ede74ef9-2390-4811-a2a7-be9547f4e07e") },
                    { new Guid("5045e955-7ae3-4c2f-8070-b46b51c5754e"), false, "Florencia", new Guid("0f517405-cf27-433a-8a28-711d10b09bcd") },
                    { new Guid("5161f192-8c11-4b7d-892a-be71b020aada"), false, "Cartagena del Chairá", new Guid("0f517405-cf27-433a-8a28-711d10b09bcd") },
                    { new Guid("544f4dcb-4678-43c4-9490-b44bcf422ebe"), false, "Inírida", new Guid("ba4b5c10-9b56-4d3a-8d72-4cf9fc9fd1b6") },
                    { new Guid("570c01a5-7590-4a95-85f2-0170cfe923b8"), false, "Latacunga", new Guid("74c6210f-1c41-4452-b19e-70ed0723b768") },
                    { new Guid("5b4d0639-48ef-4a13-b589-5e933a46dd3b"), false, "Salcedo", new Guid("74c6210f-1c41-4452-b19e-70ed0723b768") },
                    { new Guid("5e20826e-e7ce-4b5c-80f1-6e4c221767b2"), false, "Santa Helena", new Guid("74d5fe74-3e4e-46cc-b5cc-83147a8fac7e") },
                    { new Guid("60364f90-87a5-452f-86ed-b079c748bf35"), false, "Gualaquiza", new Guid("d1cc1654-eb91-462e-a30f-1f841800af80") },
                    { new Guid("6091b9b3-ef40-4e32-affa-63bb424667f9"), false, "Soacha", new Guid("8bfcda4a-9476-4db9-9730-3a1571d8ce13") },
                    { new Guid("63d92cbe-90bb-41ef-8ccf-4aded217eeb9"), false, "Maicao", new Guid("5760f0d4-8a9f-4611-9fdc-a3b3cca5c11a") },
                    { new Guid("68a1981a-cf18-4abf-b8f0-af287e2b4e60"), false, "Aracataca", new Guid("1c0ef522-8bfe-4fb2-9fbf-b42cd7b49e9c") },
                    { new Guid("69b491bc-02c2-4b89-a096-2ac95daf28a6"), false, "Santander de Quilichao", new Guid("8b792a35-c726-4418-a0b6-b62bd2ac285e") },
                    { new Guid("6af79d0c-e18c-4dfc-80bf-9e2249a99892"), false, "Villavicencio", new Guid("84f638e0-f7fa-456b-90d4-0b0f613c02d8") },
                    { new Guid("6f0899c6-7037-4f5c-917f-35e393413d68"), false, "Alausí", new Guid("5c407e02-3a78-4fbb-88bf-267a052b7952") },
                    { new Guid("6f7b8a4c-4eee-477b-9dd6-910c692c0c21"), false, "Tulcán", new Guid("2d7a20c1-0911-4ca6-bd96-69efae242084") },
                    { new Guid("6fade0d2-992e-4f32-af04-48e8e2ecb466"), false, "El Tambo", new Guid("33fe87da-faa3-46d3-a95f-dc97968c8d71") },
                    { new Guid("71699aac-a9ad-4ff3-bf83-229746305a74"), false, "Chinchiná", new Guid("5700c87a-93f6-4680-bf39-bf0cde9d2312") },
                    { new Guid("72c034d4-fb5c-4ae5-9a65-59a46ad24731"), false, "Sogamoso", new Guid("3aa5aaf8-d9fb-4b9b-8779-f480db6e6c09") },
                    { new Guid("76033f3a-1778-4e66-a784-46f71184c8e0"), false, "Tunja", new Guid("3aa5aaf8-d9fb-4b9b-8779-f480db6e6c09") },
                    { new Guid("78cf80ab-3438-498e-a62a-5b98ab5f5f05"), false, "Macas", new Guid("d1cc1654-eb91-462e-a30f-1f841800af80") },
                    { new Guid("7ae717f4-aa14-4141-94a5-9cfff44ab799"), false, "Turbo", new Guid("3fe85ca3-ab6c-4970-9f80-723d71ddfe5d") },
                    { new Guid("7d5fa8b1-f043-471a-810d-be509a5ee0f3"), false, "Arauca", new Guid("65a5ac3f-1306-4b2d-8f69-e3ff5c7edfba") },
                    { new Guid("7de8d363-7010-4220-8aa6-7cea52809225"), false, "Armenia", new Guid("313da735-fa61-4c8e-95cd-a1d416c7fc5a") },
                    { new Guid("7df7e39c-84c7-461a-94d3-206081eaf6de"), false, "Morelia", new Guid("0f517405-cf27-433a-8a28-711d10b09bcd") },
                    { new Guid("7e3e33cf-d0b0-4e38-94fc-01e7a652ada4"), false, "San José del Guaviare", new Guid("637e8280-2782-4c2e-86c7-2169b92d86bb") },
                    { new Guid("7eab68fa-268a-41a2-889b-9b876f84ba14"), false, "Fortul", new Guid("65a5ac3f-1306-4b2d-8f69-e3ff5c7edfba") },
                    { new Guid("7ed80673-151f-410d-81b9-9a5497274a13"), false, "Ibarra", new Guid("e2a81fec-5337-4df7-b5a9-2fc281b034da") },
                    { new Guid("82d0a0ae-c23b-415b-a979-8f013d70147c"), false, "Santa Rosalía", new Guid("8ddc002b-68dd-45db-bb25-a8aa40754aa2") },
                    { new Guid("8d1b3987-a1e3-44fb-a28d-64e580142bb2"), false, "Leticia", new Guid("4dca6aa8-e238-48e8-8c35-4cdb1e36a643") },
                    { new Guid("8dd2fe2b-8227-470c-8e11-e18d8879d915"), false, "Machala", new Guid("b18640b5-072f-4a16-8349-21b5a6af2d3c") },
                    { new Guid("8fa1d5f3-26cc-4a29-a285-008b1104b284"), false, "Guayaquil", new Guid("795e7d88-999c-458d-95b7-9a62dd8a7c55") },
                    { new Guid("9236bc32-4722-4106-89aa-537e9459f74d"), false, "La Tebaida", new Guid("313da735-fa61-4c8e-95cd-a1d416c7fc5a") },
                    { new Guid("974299d4-eb5b-4223-9eca-31670c65a4fd"), false, "Memarí", new Guid("ba4b5c10-9b56-4d3a-8d72-4cf9fc9fd1b6") },
                    { new Guid("976a677b-f3f7-49c2-be40-c593dd15f80b"), false, "Neiva", new Guid("badb2ed7-707e-4792-81a8-059c3fed4f72") },
                    { new Guid("9de45a98-1592-492e-afe9-ac257964e6bb"), false, "Providencia", new Guid("bb3da45f-783f-49fb-b4ad-2cfd309b5695") },
                    { new Guid("9e5b4490-d2b9-444b-8389-8beaecdbd895"), false, "Santa Marta", new Guid("1c0ef522-8bfe-4fb2-9fbf-b42cd7b49e9c") },
                    { new Guid("9fcc5e70-f887-4635-a72b-5f6916b5c880"), false, "Portoviejo", new Guid("046cdc00-2ab1-4653-a428-6092d8c72293") },
                    { new Guid("a38af892-489c-4b56-8ac6-675a3abdde84"), false, "San Andrés", new Guid("bb3da45f-783f-49fb-b4ad-2cfd309b5695") },
                    { new Guid("a3b4fb8c-98c9-4b05-a86a-1f63c7f7ae0f"), false, "San Miguel de Bolívar", new Guid("fa8330ee-c23f-46c0-ae30-00c1e1c0f9c6") },
                    { new Guid("a543ec9c-2efa-4c0d-841c-4cc77e2c2382"), false, "Ibagué", new Guid("ff1796ea-8ce3-4367-9272-1f6251afb983") },
                    { new Guid("a5d9dc0d-3a9a-48cc-a31d-10511a934a3c"), false, "Uribia", new Guid("5760f0d4-8a9f-4611-9fdc-a3b3cca5c11a") },
                    { new Guid("a746a8a1-86fb-4cb7-a058-0456f99c9e61"), false, "Apartadó", new Guid("3fe85ca3-ab6c-4970-9f80-723d71ddfe5d") },
                    { new Guid("a95c7a7d-0a1b-4768-afbc-18e6ee419346"), false, "Sincelejo", new Guid("ede74ef9-2390-4811-a2a7-be9547f4e07e") },
                    { new Guid("ab405ade-9e73-479e-b268-175453af8709"), false, "Yopal", new Guid("dfc80a67-f81c-48b6-becd-f5e4dd686680") },
                    { new Guid("abbdde38-b7f0-4abb-aa5a-a356d6626f5a"), false, "Calarcá", new Guid("313da735-fa61-4c8e-95cd-a1d416c7fc5a") },
                    { new Guid("acc431ae-b755-4dd1-bfb9-e8e3bba2905f"), false, "Montería", new Guid("8269bd18-613f-41fb-9da1-bed1095b1a34") },
                    { new Guid("aee82c3e-5da2-40db-925d-56d924c476a4"), false, "Medellín", new Guid("3fe85ca3-ab6c-4970-9f80-723d71ddfe5d") },
                    { new Guid("afca30a3-6cf9-4f9e-bfde-f4772961a66c"), false, "Puerto Baquerizo Moreno", new Guid("f17c0e8e-b6ce-4c47-abaa-6b5f52819df8") },
                    { new Guid("b2156acb-f754-4cac-817d-6645420127d0"), false, "Esmeraldas", new Guid("7edd6b01-e7f3-4708-ac09-d1ade29c8a67") },
                    { new Guid("b2b68285-d8cb-4e00-96af-cb24f4d1fc02"), false, "Montería", new Guid("ede74ef9-2390-4811-a2a7-be9547f4e07e") },
                    { new Guid("b60e2278-6c33-463c-8e14-3db8f4a9816c"), false, "Pereira", new Guid("5700c87a-93f6-4680-bf39-bf0cde9d2312") },
                    { new Guid("bf206c68-80a4-4a90-aca3-be2f8c011615"), false, "Istmina", new Guid("722ba8ba-5a45-4324-a007-b8d44bab4a8e") },
                    { new Guid("c149a0c5-0b7b-4fd3-b3f2-f07ecc5fe228"), false, "Granada", new Guid("84f638e0-f7fa-456b-90d4-0b0f613c02d8") },
                    { new Guid("c6ea241a-ab71-48b5-a028-fac5e140aa70"), false, "Puerto Asís", new Guid("ad7d82d4-3cd3-494e-aa4b-d58b5bc3f038") },
                    { new Guid("ca0d0030-9ad9-4a46-a050-b736004e87da"), false, "Saraguro", new Guid("2674d122-564e-44de-b557-1225c4d5d5f8") },
                    { new Guid("cb11236f-7158-44ad-a32b-770088f8587a"), false, "Cartagena de Indias", new Guid("739ee4ba-f5da-451d-a689-6a985436cc4e") },
                    { new Guid("ce32a2fb-f82c-4175-91bc-7f139f41738b"), false, "Guaranda", new Guid("fa8330ee-c23f-46c0-ae30-00c1e1c0f9c6") },
                    { new Guid("d0610599-ae02-421c-bacf-748bf1506d36"), false, "Manta", new Guid("046cdc00-2ab1-4653-a428-6092d8c72293") },
                    { new Guid("d1618cf6-ea10-42ac-85a0-514bd0836e90"), false, "Piedecuesta", new Guid("70a4300f-43a7-4d15-afe7-5b28f5c3c3ac") },
                    { new Guid("d1a9616b-428e-4d8d-bb68-541009581750"), false, "Santa Rosa de Cabal", new Guid("0a532ba8-f9a7-488d-abbd-33604993c7ce") },
                    { new Guid("d2a4de01-1d01-4e26-a10a-12af22c3f8a9"), false, "Honda", new Guid("ff1796ea-8ce3-4367-9272-1f6251afb983") },
                    { new Guid("d523452f-c676-43f0-92fe-01fe3c9449c3"), false, "Riohacha", new Guid("5760f0d4-8a9f-4611-9fdc-a3b3cca5c11a") },
                    { new Guid("d5de1210-dd85-467c-8001-85e89a175f48"), false, "Tena", new Guid("a053f3b7-8502-40c3-82ba-61cbd3f7da46") },
                    { new Guid("daa2340c-f77f-46dc-b272-61f2cb126b8f"), false, "Atacames", new Guid("7edd6b01-e7f3-4708-ac09-d1ade29c8a67") },
                    { new Guid("de0233f9-f17d-40f6-90f2-9cd1f04b4e5d"), false, "Calamar", new Guid("637e8280-2782-4c2e-86c7-2169b92d86bb") },
                    { new Guid("df95faa0-9aa8-421e-8969-e4f66224d5ba"), false, "Popayán", new Guid("8b792a35-c726-4418-a0b6-b62bd2ac285e") },
                    { new Guid("e2a4769c-c0fd-4569-8dc4-904fe84d00a0"), false, "Puerto Colombia", new Guid("d31f5bb2-6258-4121-a7da-13e9c0f128d3") },
                    { new Guid("e37990d9-15cf-46ce-8a9b-c3bb91c83d77"), false, "Barranquilla", new Guid("d31f5bb2-6258-4121-a7da-13e9c0f128d3") },
                    { new Guid("e5267699-365c-4922-818d-3a52a67b63ad"), false, "Girón", new Guid("556ad5a3-bb6c-4357-a6bf-9a4e7a378c76") },
                    { new Guid("e6a72c3d-ccf6-4455-bc19-a093c46cafe5"), false, "Aguazul", new Guid("dfc80a67-f81c-48b6-becd-f5e4dd686680") },
                    { new Guid("e6c314fe-d7bb-4239-8574-dd6e4f9616b1"), false, "La Primavera", new Guid("74d5fe74-3e4e-46cc-b5cc-83147a8fac7e") },
                    { new Guid("ea9890a1-5c20-458b-847f-dd8392bf00eb"), false, "Bucaramanga", new Guid("70a4300f-43a7-4d15-afe7-5b28f5c3c3ac") },
                    { new Guid("eba027d2-cde3-4027-88f4-bdaee5a79595"), false, "Ciénaga", new Guid("1c0ef522-8bfe-4fb2-9fbf-b42cd7b49e9c") },
                    { new Guid("f0a196fd-f7d9-47e1-9c04-d3fff8a73640"), false, "Magangué", new Guid("739ee4ba-f5da-451d-a689-6a985436cc4e") },
                    { new Guid("f1800d3b-2876-443b-b8a5-f1056115f0fb"), false, "Cuenca", new Guid("556ad5a3-bb6c-4357-a6bf-9a4e7a378c76") },
                    { new Guid("f1ad1c7c-694d-40f0-a446-cbe2d55ef42b"), false, "Orito", new Guid("ad7d82d4-3cd3-494e-aa4b-d58b5bc3f038") },
                    { new Guid("f20c24b8-da97-42ee-adfa-77ca3ac41cbe"), false, "Puerto Inírida", new Guid("ba4b5c10-9b56-4d3a-8d72-4cf9fc9fd1b6") },
                    { new Guid("f25b5612-e28b-4dee-9a97-ef07873a9c05"), false, "San Cristóbal", new Guid("f17c0e8e-b6ce-4c47-abaa-6b5f52819df8") },
                    { new Guid("f40fde92-073c-48f5-bdca-974e2769ff3b"), false, "Pereira", new Guid("0a532ba8-f9a7-488d-abbd-33604993c7ce") },
                    { new Guid("f8f0d0d1-5754-4803-90ed-f91591af4e3c"), false, "Tumaco", new Guid("45ea01af-4a30-4900-b34d-31bdc5171e61") },
                    { new Guid("faae4caa-63a4-4211-aa16-019a525dfd5f"), false, "El Guabo", new Guid("2d7a20c1-0911-4ca6-bd96-69efae242084") },
                    { new Guid("fed1f2f5-8d44-4cf1-8d15-abec64a2d447"), false, "Dosquebradas", new Guid("0a532ba8-f9a7-488d-abbd-33604993c7ce") },
                    { new Guid("ff53fe0a-04c9-48a8-a323-4f2a587939a8"), false, "Ipiales", new Guid("45ea01af-4a30-4900-b34d-31bdc5171e61") }
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
