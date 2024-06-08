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
                    { new Guid("05447922-05c2-4493-8692-55aa2e128e62"), false, "Brasil" },
                    { new Guid("0560cc93-05d4-4560-ac35-4c3273d8d2f7"), false, "Belize" },
                    { new Guid("0c5438c6-88f6-4f40-8c3a-92ca0fd77fa0"), false, "Guatemala" },
                    { new Guid("17b9f73e-54d9-4d88-a205-b7c19e45cffc"), false, "Perú" },
                    { new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Ecuador" },
                    { new Guid("267c889a-414e-4a8c-9615-defa70730cd1"), false, "Venezuela" },
                    { new Guid("2ab9785d-1dc7-4722-8e44-ce176ca3e666"), false, "Panamá" },
                    { new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Colombia" },
                    { new Guid("58d00d84-9e9e-40cf-aa25-c7cea37bdecd"), false, "Nicaragua" },
                    { new Guid("85252b8c-3eac-4e3b-9fd6-a269e7546815"), false, "El Salvador" },
                    { new Guid("9dce4008-8006-4e4e-b12e-5d8dfa49ee02"), false, "Chile" },
                    { new Guid("b8c23550-59ab-4d2d-9e8e-18d5decd835a"), false, "Bolivia" },
                    { new Guid("c2ad2be1-fc82-47d9-a369-d3f07c31e98b"), false, "Argentina" },
                    { new Guid("c314ad3f-002f-4256-8ba8-78e279f48f04"), false, "Paraguay" },
                    { new Guid("d0c1adc8-092a-46ed-aee0-d2e18e30f97d"), false, "Costa Rica" },
                    { new Guid("d0d34c3f-fad7-4205-b001-de989db421af"), false, "Uruguay" },
                    { new Guid("dec48fd2-d568-472a-bcad-90636ec1fefb"), false, "Honduras" },
                    { new Guid("f6ff1d7a-72ba-420f-9152-1954e095daad"), false, "México" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("08cd8bb8-8f8e-44ca-bb67-ecac500d170a"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7085), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("0f8aaebe-d0c2-4319-ab44-66309cdf5bbe"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7074), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("1b1160b9-6090-4bde-82e2-0f31295a4f38"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7065), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("1f8d99d6-9fd3-4118-9395-6609b0d21cf9"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7104), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("32dda917-7e4b-4cdb-b2c9-7728234ef374"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7097), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("3ef1a9fc-df06-4b68-9a23-effac3c330ce"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7062), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("7914a0f1-4020-4c2e-840d-a389cbdafb8b"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7093), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("862edcda-3d9c-436d-b804-2d5a3444fa38"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7052), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("8d0e207d-4ae1-4695-829d-a65d0da28637"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7077), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("a08f9a78-4853-4542-8378-a788fff5ee38"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7100), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("a56ad525-83db-42c7-a9eb-ead1b23dc2f6"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7108), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("b982dc75-976a-49e6-8eae-295f3ed51d30"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7058), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("de7d1824-28b0-4dad-bf49-92bd68e83579"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7081), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("e04e1904-83dd-4e0d-97ac-480f968a8fe9"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7089), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("f087fb4f-7c42-4bfb-9e7c-2d11939289d3"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(7069), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("23dd81e4-0d67-43d0-b236-d2e4341574ef"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6918), null, null, false, "Lead Designer", null },
                    { new Guid("4ef97d56-b67b-45d1-b5b8-f51d2d159396"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6868), null, null, false, "Developer", null },
                    { new Guid("732986a3-5923-4799-ab34-e866b6ec1f44"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6891), null, null, false, "DevOps", null },
                    { new Guid("792fd8ad-5d88-4a4a-ba83-01edfc13973b"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6914), null, null, false, "Lead Developer", null },
                    { new Guid("9c1fa9b2-41a9-4c82-9348-8779df44b7b5"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6879), null, null, false, "Designer", null },
                    { new Guid("ab4b6739-49b3-486e-9b0b-0626943631ce"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6887), null, null, false, "QA", null },
                    { new Guid("c21da06e-9edc-4082-a526-276ab7000ca7"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6903), null, null, false, "Product Owner", null },
                    { new Guid("d1eb0ee7-7341-4019-8524-80b9c5b478dc"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6906), null, null, false, "Scrum Master", null },
                    { new Guid("d28600cb-eb0d-419d-841a-47adcb5debff"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6899), null, null, false, "UX/UI Designer", null },
                    { new Guid("e282d090-0cd3-411c-838a-a78746aa5d78"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6911), null, null, false, "Architect", null },
                    { new Guid("ed8e1c3e-1ae9-4d06-867a-86c9f2bf5968"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6883), null, null, false, "Manager", null },
                    { new Guid("ef6f3038-725f-466b-95af-df0616ca2282"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6895), null, null, false, "Data Scientist", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("177127c7-0073-46f3-bac4-1c864df4073c"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6946), null, false, "Java", null },
                    { new Guid("35ecef44-aa03-43b1-8f3e-f83b9cd38c85"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6973), null, false, "NoSQL", null },
                    { new Guid("4821fb22-612c-4665-9ed4-df3cf5d9fa08"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6940), null, false, "C#", null },
                    { new Guid("4b5c5993-0b25-4ae9-ba62-202fc15edeb5"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6966), null, false, "CSS", null },
                    { new Guid("4f196ca3-6239-4006-936b-e3529c17bd40"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6988), null, false, "Node.js", null },
                    { new Guid("78e1a3e5-fa3f-4e3a-bf38-7778c7713ced"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6950), null, false, "Python", null },
                    { new Guid("8c48f59d-8c2a-4b58-96d5-a59fcbc1c725"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6962), null, false, "HTML", null },
                    { new Guid("a71ad0df-f8e6-45d9-9a57-8e50e6c95301"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6984), null, false, "React", null },
                    { new Guid("b2b78da4-873b-49cf-8dc7-cb31fc1f1218"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6995), null, false, "Hibernate", null },
                    { new Guid("b5b84739-2c46-49ea-a73a-f02a53731ba6"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6977), null, false, "Angular", null },
                    { new Guid("c0b4678b-d297-4ab7-a53c-03c2c9e11ffa"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6991), null, false, "Spring Boot", null },
                    { new Guid("c78142fa-834f-4f3b-bec7-1063076a1f00"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6958), null, false, "TypeScript", null },
                    { new Guid("cf3865b3-2b79-409c-96cd-1c0971b40a0a"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6969), null, false, "SQL", null },
                    { new Guid("e6423792-7924-4ce7-8c5f-0a4dbe0c5bf9"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6984), null, false, "Vue", null },
                    { new Guid("e93c6419-d2db-44ef-83b8-c45481639864"), new DateTime(2024, 6, 8, 2, 57, 55, 700, DateTimeKind.Utc).AddTicks(6954), null, false, "JavaScript", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("04bccc12-133f-4ea4-bf00-28a0024d1c36"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Vaupés" },
                    { new Guid("0b0d286b-21c2-4d1d-9745-17d9c2e529f7"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Atlántico" },
                    { new Guid("1e0db1d1-9a57-4322-a623-35bc676df01b"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Morona Santiago" },
                    { new Guid("1e73edf9-f423-475e-a9eb-d400485e7c60"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "San Andrés y Providencia" },
                    { new Guid("209e5d47-00ed-4249-959d-f89d6749160a"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Meta" },
                    { new Guid("27599624-570d-43ba-9cea-ff41a017fe07"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Risaralda" },
                    { new Guid("329b9370-522b-4919-982f-0702b9fc965f"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Napo" },
                    { new Guid("35d56e0d-03b3-4a19-8757-9a32f2b5723b"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Guayas" },
                    { new Guid("3700be94-0cb0-493d-bd59-38a72b1cc5b4"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Tolima" },
                    { new Guid("3a76b9cf-39ec-48c9-9508-50f17df3b382"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Putumayo" },
                    { new Guid("3b9322e8-e71f-477c-a51b-7d57092d5576"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Sucre" },
                    { new Guid("40425c6e-abe2-439a-aa3a-b4fba23eb116"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Antioquia" },
                    { new Guid("40d8ebf1-ad2c-4ae1-987c-09280f659383"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Norte de Santander" },
                    { new Guid("4503b414-9297-4d41-9d34-43002159eab7"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Cundinamarca" },
                    { new Guid("49782e32-f95a-4917-9861-0085faaa7b50"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Guaviare" },
                    { new Guid("4b9c2826-84f5-4bff-a941-d5387f54f5d7"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Loja" },
                    { new Guid("4ea7cf1e-51b9-485d-bf6e-8fc2f6775e7c"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Guainía" },
                    { new Guid("4fbe7a63-ce0d-485e-b360-d94aa7a3c23e"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Boyacá" },
                    { new Guid("5463bf9a-732a-4602-a13a-953e41d83619"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Santander" },
                    { new Guid("58a11708-f5ed-4884-8366-46e06dc72f63"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Cañar" },
                    { new Guid("60ad0eca-a433-4952-aedd-a5af106257e5"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Arauca" },
                    { new Guid("662befe1-f710-4694-9c85-b9c29dc05fa0"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Caldas" },
                    { new Guid("7d20ff47-fb82-4bec-9c91-cb3c0e28a9ec"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Chocó" },
                    { new Guid("822cac7a-c804-4ba1-8d73-abfeaf566272"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Cauca" },
                    { new Guid("82308b5d-7eb2-418c-bfa5-ccb118bfa337"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Valle del Cauca" },
                    { new Guid("83535988-f964-4b9d-9588-baca6c784626"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Galápagos" },
                    { new Guid("8f5d4d86-b4aa-4866-94ad-e5e97687a007"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Amazonas" },
                    { new Guid("99a295e3-9403-41c2-bc92-f52ef186e7e3"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Cesar" },
                    { new Guid("9f363aca-fb3f-4708-aef7-659190d7c141"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Huila" },
                    { new Guid("a367ce45-d4a6-4520-9906-1870d5849ab8"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Magdalena" },
                    { new Guid("a800fe30-6d9c-4a67-a47f-6a4eda3ddf44"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Esmeraldas" },
                    { new Guid("aa2d2d92-3024-427f-81b9-6aec0b305a8a"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Bolívar" },
                    { new Guid("aec548aa-8d4e-4558-a99b-ef67e6eb338a"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Manabí" },
                    { new Guid("b8f089af-8038-4b8b-ad22-b189ec19aefc"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "La Guajira" },
                    { new Guid("bf9117f5-6bce-486f-85ad-4de512cfe53d"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Azuay" },
                    { new Guid("c3039b7b-8f5a-44d1-ba4d-baf273109172"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Carchi" },
                    { new Guid("ca6c39e0-7fa8-42a7-9239-e9c0fb648c72"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Vichada" },
                    { new Guid("d0f96ade-df12-46c7-9c82-cd63377b99e2"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Cotopaxi" },
                    { new Guid("d68a25e8-59b0-4754-a240-5982fe7d773d"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Quindío" },
                    { new Guid("deaa059e-a368-4592-8ad9-2fc9a710fb4f"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Córdoba" },
                    { new Guid("e877f38c-67e2-41e8-ab85-3ced74d81b85"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Imbabura" },
                    { new Guid("eda9dc13-c0fe-42eb-ad4c-c5a7573ca4cf"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Caquetá" },
                    { new Guid("efc9342f-749d-4529-ac1c-22733c4b61c3"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Bolívar" },
                    { new Guid("f34f9f4c-44a2-40b0-a391-17182d6fcc67"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Casanare" },
                    { new Guid("f8c6d5db-408f-4792-b5c2-dc7902174404"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "El Oro" },
                    { new Guid("f951b8bb-bda3-4b02-af6a-2fb4e6cd22b6"), new Guid("1e1dcb29-8d4b-4e26-9678-a51735898a61"), false, "Chimborazo" },
                    { new Guid("f9e082fa-0dee-41eb-aa67-02fddb3a0b3d"), new Guid("4e67acf7-8f38-48b1-af88-5df6451fa4c6"), false, "Nariño" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("00d72140-cdaa-4baf-8c80-6c82ac827f86"), false, "Neiva", new Guid("9f363aca-fb3f-4708-aef7-659190d7c141") },
                    { new Guid("00fe986c-7a2d-4df7-9117-90b7d97640c2"), false, "Puerto Baquerizo Moreno", new Guid("83535988-f964-4b9d-9588-baca6c784626") },
                    { new Guid("02c81ef9-1454-4e47-b4fc-7d1a03174e22"), false, "Palmira", new Guid("82308b5d-7eb2-418c-bfa5-ccb118bfa337") },
                    { new Guid("07f2076d-f0c7-4679-acb0-858e6640bdd9"), false, "Sincelejo", new Guid("3b9322e8-e71f-477c-a51b-7d57092d5576") },
                    { new Guid("0ebad736-47c0-405f-bd14-7c79d59c1da5"), false, "Guayaquil", new Guid("35d56e0d-03b3-4a19-8757-9a32f2b5723b") },
                    { new Guid("11ee36be-c308-41b3-8959-12e18b6b0905"), false, "Manta", new Guid("aec548aa-8d4e-4558-a99b-ef67e6eb338a") },
                    { new Guid("15335391-d37f-4a3c-bc96-5e617bf51dae"), false, "Cúcuta", new Guid("40d8ebf1-ad2c-4ae1-987c-09280f659383") },
                    { new Guid("1a93a42a-1b3e-498f-811a-ec5263fbf8c1"), false, "San Miguel de Bolívar", new Guid("efc9342f-749d-4529-ac1c-22733c4b61c3") },
                    { new Guid("1af6389c-de63-4269-96f6-684701aaed3b"), false, "Atacames", new Guid("a800fe30-6d9c-4a67-a47f-6a4eda3ddf44") },
                    { new Guid("1d0d7908-e074-4a50-b052-2317217d45d5"), false, "Pamplona", new Guid("40d8ebf1-ad2c-4ae1-987c-09280f659383") },
                    { new Guid("279a1cb3-03d2-434f-ab33-4beabbdda034"), false, "Soacha", new Guid("4503b414-9297-4d41-9d34-43002159eab7") },
                    { new Guid("285c1155-7cf6-4479-aac1-7373832811a1"), false, "Fortul", new Guid("60ad0eca-a433-4952-aedd-a5af106257e5") },
                    { new Guid("291d777f-b85e-4a0e-9083-661c953a1739"), false, "Lorica", new Guid("deaa059e-a368-4592-8ad9-2fc9a710fb4f") },
                    { new Guid("2ba73d98-cb1f-4521-9975-aa47f5c4edcc"), false, "Novita", new Guid("7d20ff47-fb82-4bec-9c91-cb3c0e28a9ec") },
                    { new Guid("2c1a5cc0-24e1-4fe5-87ae-675dd4fcd0bb"), false, "Mitú", new Guid("04bccc12-133f-4ea4-bf00-28a0024d1c36") },
                    { new Guid("300d49d5-2704-4966-9047-4698962e4a6a"), false, "Acacias", new Guid("209e5d47-00ed-4249-959d-f89d6749160a") },
                    { new Guid("34a9c78d-82a7-4487-8ae0-30789803df63"), false, "Tulcán", new Guid("c3039b7b-8f5a-44d1-ba4d-baf273109172") },
                    { new Guid("355d19bf-c03f-4feb-a747-473ff93ca9aa"), false, "Loja", new Guid("4b9c2826-84f5-4bff-a941-d5387f54f5d7") },
                    { new Guid("35a86551-b845-47d9-95ac-dc23b14246c8"), false, "Silvia", new Guid("822cac7a-c804-4ba1-8d73-abfeaf566272") },
                    { new Guid("4024b1a5-2059-460e-ab5b-d582bd885c8c"), false, "Turbo", new Guid("40425c6e-abe2-439a-aa3a-b4fba23eb116") },
                    { new Guid("42a61ce2-5e01-4caf-b261-ebc8491196ee"), false, "Calarcá", new Guid("d68a25e8-59b0-4754-a240-5982fe7d773d") },
                    { new Guid("4553f716-0047-4a36-86f6-54d66716c366"), false, "Girón", new Guid("bf9117f5-6bce-486f-85ad-4de512cfe53d") },
                    { new Guid("47a0a287-52cb-460b-9f33-4025b47ba771"), false, "Tauramena", new Guid("f34f9f4c-44a2-40b0-a391-17182d6fcc67") },
                    { new Guid("47f950ce-6e93-4ff5-a92e-0e334fd05bc0"), false, "Portoviejo", new Guid("aec548aa-8d4e-4558-a99b-ef67e6eb338a") },
                    { new Guid("4b59a662-738a-4f73-aad7-f5cebaab5d48"), false, "Pitalito", new Guid("9f363aca-fb3f-4708-aef7-659190d7c141") },
                    { new Guid("4e977c21-8c15-4b6a-906f-24f80ad88daf"), false, "Armenia", new Guid("d68a25e8-59b0-4754-a240-5982fe7d773d") },
                    { new Guid("5102c375-a52f-447e-9e3c-6da75c033ebe"), false, "Apartadó", new Guid("40425c6e-abe2-439a-aa3a-b4fba23eb116") },
                    { new Guid("53da6ea1-f9a1-4b6c-a6f5-48133d0e99dd"), false, "Montería", new Guid("deaa059e-a368-4592-8ad9-2fc9a710fb4f") },
                    { new Guid("5624d836-c8ac-4d93-91fc-2ee931989599"), false, "Cereté", new Guid("deaa059e-a368-4592-8ad9-2fc9a710fb4f") },
                    { new Guid("56dc6f8f-c13c-4217-95c6-7880439b46f2"), false, "Yavaraté", new Guid("04bccc12-133f-4ea4-bf00-28a0024d1c36") },
                    { new Guid("5884024c-5366-4cd3-b3fa-e41a8f1234ba"), false, "Santa Helena", new Guid("ca6c39e0-7fa8-42a7-9239-e9c0fb648c72") },
                    { new Guid("5a5140f5-6932-4f98-ad0c-dc6b2945f093"), false, "Alausí", new Guid("f951b8bb-bda3-4b02-af6a-2fb4e6cd22b6") },
                    { new Guid("5e30eb43-d01a-446c-99d0-f653cc080b64"), false, "Yopal", new Guid("f34f9f4c-44a2-40b0-a391-17182d6fcc67") },
                    { new Guid("5e89c1f8-dea0-4568-9fbc-bf3059ae1c7f"), false, "Mocoa", new Guid("3a76b9cf-39ec-48c9-9508-50f17df3b382") },
                    { new Guid("5ec86bb0-a3a8-4762-9dd3-f091a4b8b7ae"), false, "Aguachica", new Guid("99a295e3-9403-41c2-bc92-f52ef186e7e3") },
                    { new Guid("5f94a23e-1b29-4953-8f16-15d9b76b5e1e"), false, "Santa Catalina", new Guid("1e73edf9-f423-475e-a9eb-d400485e7c60") },
                    { new Guid("64d14d20-23f3-417b-80f6-3dc9f135514f"), false, "Cartagena de Indias", new Guid("aa2d2d92-3024-427f-81b9-6aec0b305a8a") },
                    { new Guid("699e5c05-634c-4774-80e7-e634d1dcacd1"), false, "Morelia", new Guid("eda9dc13-c0fe-42eb-ad4c-c5a7573ca4cf") },
                    { new Guid("6a7b93e5-a7f8-4f1c-b3ba-8cefe96ab38a"), false, "Guaranda", new Guid("efc9342f-749d-4529-ac1c-22733c4b61c3") },
                    { new Guid("6bd8ed28-fbd1-47bd-8479-3321b1abb9d4"), false, "Calamar", new Guid("49782e32-f95a-4917-9861-0085faaa7b50") },
                    { new Guid("6be2afca-a890-4b01-af73-206f47274708"), false, "Salcedo", new Guid("d0f96ade-df12-46c7-9c82-cd63377b99e2") },
                    { new Guid("6c44ac90-43be-4775-9833-6e5b5adfd976"), false, "Uribia", new Guid("b8f089af-8038-4b8b-ad22-b189ec19aefc") },
                    { new Guid("6d57907c-9277-4b4c-b29e-d1d81ce52640"), false, "Inírida", new Guid("4ea7cf1e-51b9-485d-bf6e-8fc2f6775e7c") },
                    { new Guid("6e3b484d-b559-4256-8ff7-5cccbfcf4571"), false, "Chone", new Guid("aec548aa-8d4e-4558-a99b-ef67e6eb338a") },
                    { new Guid("71623e0a-a26d-4f65-a270-b8a9355eea35"), false, "La Tebaida", new Guid("d68a25e8-59b0-4754-a240-5982fe7d773d") },
                    { new Guid("72f5f57f-cd3f-4797-beb7-f9ee1df44cc9"), false, "Sogamoso", new Guid("4fbe7a63-ce0d-485e-b360-d94aa7a3c23e") },
                    { new Guid("74faff0d-6e8b-4f52-a723-e95ca352bfee"), false, "Memarí", new Guid("4ea7cf1e-51b9-485d-bf6e-8fc2f6775e7c") },
                    { new Guid("79683241-c743-47ff-b417-5079192af532"), false, "Santa Marta", new Guid("a367ce45-d4a6-4520-9906-1870d5849ab8") },
                    { new Guid("79ab8d32-f2ef-42d5-b80a-dd92ac61add7"), false, "Santander de Quilichao", new Guid("822cac7a-c804-4ba1-8d73-abfeaf566272") },
                    { new Guid("7ec9d0d6-c5a5-4f90-8c4c-5ecbe6d210eb"), false, "Barrancabermeja", new Guid("5463bf9a-732a-4602-a13a-953e41d83619") },
                    { new Guid("7f5358f2-a49f-40a9-9e9c-e9132a9c176a"), false, "Cuenca", new Guid("bf9117f5-6bce-486f-85ad-4de512cfe53d") },
                    { new Guid("804b3784-b89b-455e-bb84-4b6f3754d418"), false, "Otavalo", new Guid("e877f38c-67e2-41e8-ab85-3ced74d81b85") },
                    { new Guid("814716bb-78f9-4f5c-af5b-ff1f1fd281fb"), false, "Armero Guayabal", new Guid("3700be94-0cb0-493d-bd59-38a72b1cc5b4") },
                    { new Guid("81919357-bb36-4a90-b044-3330daa6d904"), false, "Ibagué", new Guid("3700be94-0cb0-493d-bd59-38a72b1cc5b4") },
                    { new Guid("826278e2-cbeb-454e-93b9-85ee824450a8"), false, "Corozal", new Guid("3b9322e8-e71f-477c-a51b-7d57092d5576") },
                    { new Guid("835acef0-74b6-40c7-9da4-e37536f1e237"), false, "Manizales", new Guid("662befe1-f710-4694-9c85-b9c29dc05fa0") },
                    { new Guid("8413c7bc-7b41-48ce-8a5d-ffb7d8ab7f93"), false, "Puerto Carreño", new Guid("ca6c39e0-7fa8-42a7-9239-e9c0fb648c72") },
                    { new Guid("8647b653-d58c-42b2-ba80-4df110cafe8a"), false, "Villavicencio", new Guid("209e5d47-00ed-4249-959d-f89d6749160a") },
                    { new Guid("8972349d-e55a-4bd9-8133-1bc756b961fe"), false, "Puerto Colombia", new Guid("0b0d286b-21c2-4d1d-9745-17d9c2e529f7") },
                    { new Guid("8ed69b27-3bd7-4ac6-9278-41d2ca756121"), false, "El Tambo", new Guid("58a11708-f5ed-4884-8366-46e06dc72f63") },
                    { new Guid("8fb5f0d2-aedf-42f3-944f-7d4a3ae29c21"), false, "Tumaco", new Guid("f9e082fa-0dee-41eb-aa67-02fddb3a0b3d") },
                    { new Guid("9037104d-bb09-4002-84d9-5289720c3dcb"), false, "La Primavera", new Guid("ca6c39e0-7fa8-42a7-9239-e9c0fb648c72") },
                    { new Guid("9039321f-b78a-4e48-b1fa-935c86e7bfe8"), false, "Leticia", new Guid("8f5d4d86-b4aa-4866-94ad-e5e97687a007") },
                    { new Guid("9051e15a-4df0-4832-b42f-bdf220118905"), false, "La Paz", new Guid("99a295e3-9403-41c2-bc92-f52ef186e7e3") },
                    { new Guid("915c6fcc-b4bf-4aae-91b1-8d1f30f5a1b5"), false, "Ocaña", new Guid("40d8ebf1-ad2c-4ae1-987c-09280f659383") },
                    { new Guid("925f2b24-5d8e-4d75-9013-cd18047d3d79"), false, "San Andrés", new Guid("1e73edf9-f423-475e-a9eb-d400485e7c60") },
                    { new Guid("96402fe4-6820-41e8-8c1b-a9dbb978d7dc"), false, "Magangué", new Guid("aa2d2d92-3024-427f-81b9-6aec0b305a8a") },
                    { new Guid("98b0e775-a45e-4164-a55f-c1149982a636"), false, "Dosquebradas", new Guid("27599624-570d-43ba-9cea-ff41a017fe07") },
                    { new Guid("99229636-9537-4851-8e7b-4bfd1dc14c17"), false, "Honda", new Guid("3700be94-0cb0-493d-bd59-38a72b1cc5b4") },
                    { new Guid("9a63273e-6e5b-46ce-833a-7b7cdf56d5ce"), false, "Riobamba", new Guid("f951b8bb-bda3-4b02-af6a-2fb4e6cd22b6") },
                    { new Guid("9b279167-741d-46a6-8a5d-f4df72c62876"), false, "El Guabo", new Guid("c3039b7b-8f5a-44d1-ba4d-baf273109172") },
                    { new Guid("9d63c49d-2a42-4d12-bc2b-39f49e526ed0"), false, "Zipaquirá", new Guid("4503b414-9297-4d41-9d34-43002159eab7") },
                    { new Guid("9ede208a-22bb-40d3-af1c-4a5a5cdce485"), false, "Machala", new Guid("f8c6d5db-408f-4792-b5c2-dc7902174404") },
                    { new Guid("a0182ba2-97ea-4358-8707-36a2e516448a"), false, "Montería", new Guid("3b9322e8-e71f-477c-a51b-7d57092d5576") },
                    { new Guid("a0a181bb-e070-4131-9df3-959ebe53410e"), false, "Chinchiná", new Guid("662befe1-f710-4694-9c85-b9c29dc05fa0") },
                    { new Guid("a42970a2-ae87-43d5-9a23-18577390ea0f"), false, "Santa Rosa", new Guid("f8c6d5db-408f-4792-b5c2-dc7902174404") },
                    { new Guid("a557af9f-7ebe-4332-b2ff-13e2596e77b2"), false, "Granada", new Guid("209e5d47-00ed-4249-959d-f89d6749160a") },
                    { new Guid("a58b3009-619e-4997-854a-cba87fdddb03"), false, "Orito", new Guid("3a76b9cf-39ec-48c9-9508-50f17df3b382") },
                    { new Guid("a6f0dfec-57a2-407f-8064-6c32456bb7fb"), false, "Ipiales", new Guid("f9e082fa-0dee-41eb-aa67-02fddb3a0b3d") },
                    { new Guid("a85036b4-2bad-4408-982d-e3345ded617a"), false, "Quibdó", new Guid("7d20ff47-fb82-4bec-9c91-cb3c0e28a9ec") },
                    { new Guid("b02a3b3e-3f44-4c4e-a063-a7cebfce6ac1"), false, "Arauca", new Guid("60ad0eca-a433-4952-aedd-a5af106257e5") },
                    { new Guid("b3647420-ba95-4785-948f-3c8f68ed8aa0"), false, "Latacunga", new Guid("d0f96ade-df12-46c7-9c82-cd63377b99e2") },
                    { new Guid("b3dd69ef-c6c3-409e-8606-64cd8280251c"), false, "Puerto Inírida", new Guid("4ea7cf1e-51b9-485d-bf6e-8fc2f6775e7c") },
                    { new Guid("b81f73d5-b654-4535-a2ed-8634651aa36c"), false, "Archidona", new Guid("329b9370-522b-4919-982f-0702b9fc965f") },
                    { new Guid("b884efa7-efea-4118-8cf0-3651fe8cba46"), false, "Azogues", new Guid("58a11708-f5ed-4884-8366-46e06dc72f63") },
                    { new Guid("ba153edd-5d6e-4513-a6b7-86de605feac9"), false, "Bogotá", new Guid("4503b414-9297-4d41-9d34-43002159eab7") },
                    { new Guid("bac2f6e8-d80c-491f-8b92-c0b8516e1166"), false, "Providencia", new Guid("1e73edf9-f423-475e-a9eb-d400485e7c60") },
                    { new Guid("be7270e3-411c-4afa-93de-ef519ee877d8"), false, "Pereira", new Guid("27599624-570d-43ba-9cea-ff41a017fe07") },
                    { new Guid("c002b03e-ea2a-4d3c-ba8a-85c7d4da3eaa"), false, "San José del Guaviare", new Guid("49782e32-f95a-4917-9861-0085faaa7b50") },
                    { new Guid("c1125531-5bc8-47c8-9df0-a81838b26aa5"), false, "Piedecuesta", new Guid("5463bf9a-732a-4602-a13a-953e41d83619") },
                    { new Guid("c2a06c70-df14-4c96-a730-7e0942a830d9"), false, "Ibarra", new Guid("e877f38c-67e2-41e8-ab85-3ced74d81b85") },
                    { new Guid("c45abb3c-a7ab-4a27-9bb6-0456cb5d31d6"), false, "Garzón", new Guid("9f363aca-fb3f-4708-aef7-659190d7c141") },
                    { new Guid("c79fc35e-40b8-48d1-96a4-c1845b6f3835"), false, "Maicao", new Guid("b8f089af-8038-4b8b-ad22-b189ec19aefc") },
                    { new Guid("c8c47225-4ebf-4a36-a1c2-c81247d5670d"), false, "Durán", new Guid("35d56e0d-03b3-4a19-8757-9a32f2b5723b") },
                    { new Guid("cc8193f4-f0f5-42c2-85f2-fe57b28f9ab1"), false, "Florencia", new Guid("eda9dc13-c0fe-42eb-ad4c-c5a7573ca4cf") },
                    { new Guid("cce88514-1a7a-494a-b41d-27098c329f2c"), false, "Puerto Asís", new Guid("3a76b9cf-39ec-48c9-9508-50f17df3b382") },
                    { new Guid("cee7985f-fca2-4277-b849-8eafcf2521e4"), false, "Aguazul", new Guid("f34f9f4c-44a2-40b0-a391-17182d6fcc67") },
                    { new Guid("ceeafd04-be9b-44b0-a3d7-ba6e37a821ed"), false, "Gualaquiza", new Guid("1e0db1d1-9a57-4322-a623-35bc676df01b") },
                    { new Guid("cf0580a4-26b0-4cb4-8a18-66f58204191e"), false, "Tunja", new Guid("4fbe7a63-ce0d-485e-b360-d94aa7a3c23e") },
                    { new Guid("cf4708ac-78d8-4de1-9766-e4bc61044e6f"), false, "Cartagena del Chairá", new Guid("aa2d2d92-3024-427f-81b9-6aec0b305a8a") },
                    { new Guid("d10cc2b7-7a42-459e-836b-e13071b44bc1"), false, "Popayán", new Guid("822cac7a-c804-4ba1-8d73-abfeaf566272") },
                    { new Guid("d22d9893-fbd5-4722-a573-50981eb275d1"), false, "Buenaventura", new Guid("82308b5d-7eb2-418c-bfa5-ccb118bfa337") },
                    { new Guid("d2bc1ce3-d9c7-4fe4-a743-765dfc94a62d"), false, "Soledad", new Guid("0b0d286b-21c2-4d1d-9745-17d9c2e529f7") },
                    { new Guid("d5965130-6cb2-41fb-af13-9164667cf0c0"), false, "San Cristóbal", new Guid("83535988-f964-4b9d-9588-baca6c784626") },
                    { new Guid("d86d70aa-ab8b-4e3c-bd32-b9610f65aad8"), false, "Riohacha", new Guid("b8f089af-8038-4b8b-ad22-b189ec19aefc") },
                    { new Guid("da7528d2-4b30-4c94-9069-8810b1b80786"), false, "San Juan de Pasto", new Guid("f9e082fa-0dee-41eb-aa67-02fddb3a0b3d") },
                    { new Guid("dd196bca-8114-40ba-b512-f779a55a0711"), false, "Istmina", new Guid("7d20ff47-fb82-4bec-9c91-cb3c0e28a9ec") },
                    { new Guid("de9c90ac-66e9-468f-ac28-afa7e686003b"), false, "Aracataca", new Guid("a367ce45-d4a6-4520-9906-1870d5849ab8") },
                    { new Guid("debb3353-58f3-4f88-97d4-7c3d0cf01f2f"), false, "Ciénaga", new Guid("a367ce45-d4a6-4520-9906-1870d5849ab8") },
                    { new Guid("e0789df1-f055-4d6c-a048-2c8d89cfc8e3"), false, "Bucaramanga", new Guid("5463bf9a-732a-4602-a13a-953e41d83619") },
                    { new Guid("e2719014-95a7-4703-9f6e-8b69d0e79e87"), false, "Macas", new Guid("1e0db1d1-9a57-4322-a623-35bc676df01b") },
                    { new Guid("e5be225a-860b-4657-874f-3f7c155790c0"), false, "Cartagena del Chairá", new Guid("eda9dc13-c0fe-42eb-ad4c-c5a7573ca4cf") },
                    { new Guid("e846a9d4-601e-49c6-85ba-9e47a92d3eb7"), false, "Santa Rosalía", new Guid("04bccc12-133f-4ea4-bf00-28a0024d1c36") },
                    { new Guid("e8676e7f-0294-4952-b3f6-c9f790e15447"), false, "Saravena", new Guid("60ad0eca-a433-4952-aedd-a5af106257e5") },
                    { new Guid("ea5ee31a-8b85-4a10-80b1-e506e79a1868"), false, "Medellín", new Guid("40425c6e-abe2-439a-aa3a-b4fba23eb116") },
                    { new Guid("ea7ed149-4f87-4c94-93c7-8c239338c27d"), false, "El Retén", new Guid("49782e32-f95a-4917-9861-0085faaa7b50") },
                    { new Guid("eae94c57-365f-4132-8dd0-eb85d5996216"), false, "Saraguro", new Guid("4b9c2826-84f5-4bff-a941-d5387f54f5d7") },
                    { new Guid("eb732d1a-f794-43ff-a121-abec2b49e659"), false, "Santa Rosa de Cabal", new Guid("27599624-570d-43ba-9cea-ff41a017fe07") },
                    { new Guid("f2ead246-6c29-4554-aff9-18155e906bd7"), false, "Pereira", new Guid("662befe1-f710-4694-9c85-b9c29dc05fa0") },
                    { new Guid("f60b00b4-8ad2-4cb2-a7eb-edf3cb2fb849"), false, "Duitama", new Guid("4fbe7a63-ce0d-485e-b360-d94aa7a3c23e") },
                    { new Guid("f955b475-aa16-4916-822a-25c9cb48f6d8"), false, "Esmeraldas", new Guid("a800fe30-6d9c-4a67-a47f-6a4eda3ddf44") },
                    { new Guid("f960c663-5459-4339-a591-a19dd6013417"), false, "Barranquilla", new Guid("0b0d286b-21c2-4d1d-9745-17d9c2e529f7") },
                    { new Guid("fcb2570e-a518-49f3-a93b-d982dd035c5a"), false, "Valledupar", new Guid("99a295e3-9403-41c2-bc92-f52ef186e7e3") },
                    { new Guid("fdc18df1-1b0c-4bf0-9e86-044d192945f0"), false, "Cali", new Guid("82308b5d-7eb2-418c-bfa5-ccb118bfa337") },
                    { new Guid("ff65e481-3745-4153-b625-0d9b9c2cc9af"), false, "Tena", new Guid("329b9370-522b-4919-982f-0702b9fc965f") }
                });

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
                name: "professional");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "squad");

            migrationBuilder.DropTable(
                name: "subskill");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
