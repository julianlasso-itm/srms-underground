using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesAndSeeds : Migration
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
                    { new Guid("06f3a4b5-0716-4446-bfa5-0c7ad2d74d9b"), false, "México" },
                    { new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Ecuador" },
                    { new Guid("1d8755cc-ecf0-4dbf-b089-535ca1cb02f2"), false, "Argentina" },
                    { new Guid("4a37e802-b20b-4392-95e9-0410208d3334"), false, "Panamá" },
                    { new Guid("537cb3bc-59bc-44cf-971b-fe0135443813"), false, "El Salvador" },
                    { new Guid("5ba23fc3-0a98-4033-b49b-372e87fa3f86"), false, "Chile" },
                    { new Guid("70c0a9ab-4485-4a91-b148-f3f2fb41965c"), false, "Guatemala" },
                    { new Guid("70faee44-0378-414b-81f6-fcfb77bd13c6"), false, "Costa Rica" },
                    { new Guid("8147986e-e753-461b-97f4-d0f791efa836"), false, "Belize" },
                    { new Guid("87a3d760-3df8-4fdd-aae6-292e31fdcb9e"), false, "Honduras" },
                    { new Guid("8a8ea566-0db1-4359-9b6c-0070909a97a8"), false, "Nicaragua" },
                    { new Guid("a32d1f48-9414-4201-9548-a8be5204fd36"), false, "Perú" },
                    { new Guid("a791d695-6892-40d2-9338-7ee3be9ad4a6"), false, "Venezuela" },
                    { new Guid("b5c445d1-7a6a-4441-8f81-540de5a1a839"), false, "Bolivia" },
                    { new Guid("bd091271-729a-4b81-8b06-6ed0c86e5d61"), false, "Brasil" },
                    { new Guid("c54255f8-4772-4bbf-9d54-05258d5a9b76"), false, "Uruguay" },
                    { new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Colombia" },
                    { new Guid("e38f25ee-e63a-4938-9cb2-b52674b4bbc1"), false, "Paraguay" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("11f85ce9-fbbe-4710-a91b-02ed4ed1097b"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9425), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("3bffc7d4-6676-44a5-9dac-d1d55be1f026"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9441), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("40569c7c-7287-4806-9de6-3f5fc3eaaf22"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9417), null, false, "diegogomez@gmail.com", "Diego Gómez", null },
                    { new Guid("56b3e3f3-537f-416f-98b1-4ecb719c4489"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9433), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("602b3199-6a2a-4918-bb85-4636d9c29be5"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9414), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("6196f2a8-30f6-42d3-a4a4-be5bec48a451"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9444), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("66bf83fe-0fe4-40c6-9c43-1eedb0d0443f"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9398), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("7d978578-8c6c-4870-8095-baf7fc1d2853"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9409), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("90b8d862-17aa-4d18-a100-3523123c77ab"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9402), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("9ae32427-a2b9-4f7b-bca0-7e46817a3115"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9421), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("a11352cb-668a-4a76-8a6f-6771162d1671"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9392), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("b8dbba25-43e4-4f67-b905-4fc32f9bf143"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9448), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("c276d7e0-8bd0-426d-bda4-8bf2ce8ddaa3"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9405), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("ca92888f-d3a0-4e41-b4e9-484d2393b19c"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9437), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("d64bd55a-563c-4874-a6da-ee19b30a18be"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9430), null, false, "lauragonzalez@gmail.com", "Laura González", null }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("125b4665-06c6-4dc5-ba06-94c4b15d335b"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9215), null, null, false, "Designer", null },
                    { new Guid("2685c56a-89bc-4377-8c25-6c72ffca41d3"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9254), null, null, false, "Lead Designer", null },
                    { new Guid("6ede8e21-28e2-4085-acac-c356d22481d0"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9239), null, null, false, "Product Owner", null },
                    { new Guid("7eb147e9-3f77-4259-a1aa-4f11f24daa8f"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9250), null, null, false, "Lead Developer", null },
                    { new Guid("8976be6f-69af-48b9-80c9-3b6b3bc288b0"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9235), null, null, false, "UX/UI Designer", null },
                    { new Guid("90b0061e-e2d0-493e-a012-a322bd5dd9b2"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9209), null, null, false, "Developer", null },
                    { new Guid("9ba9f7de-92af-4c60-a028-0200dd57a71a"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9227), null, null, false, "DevOps", null },
                    { new Guid("a1373243-9250-424b-8673-74d7c648ac1c"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9242), null, null, false, "Scrum Master", null },
                    { new Guid("a897d330-3015-4106-a236-c0e4ea05e889"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9232), null, null, false, "Data Scientist", null },
                    { new Guid("b1cfc032-8a93-4ac9-9d23-efbc808e92ec"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9220), null, null, false, "Manager", null },
                    { new Guid("cecc1624-39fd-4371-8d00-b68281f8f0b9"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9247), null, null, false, "Architect", null },
                    { new Guid("e65033b0-0782-4253-a07d-4094c228ca12"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9223), null, null, false, "QA", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("04b9de11-163e-4b34-a77e-f3bab284afc2"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9312), null, false, "Angular", null },
                    { new Guid("0951550f-2815-4ae9-aadc-27e93d6df349"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9298), null, false, "HTML", null },
                    { new Guid("0d8db036-74cb-4018-9c91-0e1e917c5309"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9287), null, false, "Python", null },
                    { new Guid("2c3dc0f5-ea58-4f67-a919-cc2cc72f0983"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9319), null, false, "Vue", null },
                    { new Guid("2f6f0cf5-68f3-4765-bea1-27286ab9f878"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9354), null, false, "Spring Boot", null },
                    { new Guid("3aabd46b-013d-4102-9f2d-6dcdf637c5f3"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9294), null, false, "TypeScript", null },
                    { new Guid("5c729964-1d07-41e8-927c-b0fedfaac84f"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9318), null, false, "React", null },
                    { new Guid("6ce99075-2599-470d-9333-a9cfc64b787a"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9277), null, false, "C#", null },
                    { new Guid("8ea4c051-e77e-499d-8025-c9e91478831d"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9358), null, false, "Hibernate", null },
                    { new Guid("8fb0ed9b-372f-4920-8790-ebd86dccd974"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9305), null, false, "SQL", null },
                    { new Guid("a2254506-31b3-4fce-b067-eb57ee887b7b"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9283), null, false, "Java", null },
                    { new Guid("c1622bbe-1607-48fa-9d5c-3fc79a47ff2b"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9322), null, false, "Node.js", null },
                    { new Guid("dc5e5118-a46b-487d-b927-21d0eb5b4e70"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9301), null, false, "CSS", null },
                    { new Guid("e95ed72b-2c1c-4a7d-97de-b07afecc8966"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9290), null, false, "JavaScript", null },
                    { new Guid("f2335f11-bfe2-486d-a8bd-3de0f0e34225"), new DateTime(2024, 4, 28, 10, 40, 47, 2, DateTimeKind.Utc).AddTicks(9308), null, false, "NoSQL", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("00997a7b-f986-47c5-a2d4-62b2993797b7"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Cotopaxi" },
                    { new Guid("0609ac6f-5a8c-4cdb-ba77-a2c4e468ae95"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Putumayo" },
                    { new Guid("06189287-3dcb-49f0-90c0-fcd95b95e327"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Nariño" },
                    { new Guid("0ec08a72-79fc-4b7e-865c-db1951bfc5d0"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Guainía" },
                    { new Guid("1b586621-1fef-424e-81fa-bec0fb285679"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Valle del Cauca" },
                    { new Guid("1ba2474d-58d2-4e82-8e59-cae097423d56"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Risaralda" },
                    { new Guid("2182384c-72d0-4cd8-8479-168b185cb08a"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Sucre" },
                    { new Guid("220ee83b-77ef-4ae1-a0aa-b7d5d2eabc9d"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "El Oro" },
                    { new Guid("286cd1ec-ee8f-47e6-b17e-88958107298b"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Atlántico" },
                    { new Guid("289c8325-899d-4e9c-bb26-da8a2fbd68b2"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Vichada" },
                    { new Guid("28daa4f8-3dc4-4801-aa1b-057acb3b6f18"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Chimborazo" },
                    { new Guid("2cfcb757-0670-4bb6-99d6-5e9922e7326b"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Norte de Santander" },
                    { new Guid("2fd56de4-45a9-462c-aa44-20d9125f0a13"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Manabí" },
                    { new Guid("31fafa3c-8545-48fc-a248-c70016be95fa"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Chocó" },
                    { new Guid("3d892b15-f5ae-4b61-bcca-5168bf56748d"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Carchi" },
                    { new Guid("3fc8c2e7-d2c3-4a7e-88e5-dd9e0a62e0e6"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Cauca" },
                    { new Guid("40744b42-e290-4596-90f5-b7a8b140236b"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Boyacá" },
                    { new Guid("4c14f504-2bf8-4d25-ba70-e68b16b5a9f5"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Imbabura" },
                    { new Guid("4cfb18bd-fe66-45d8-afcc-edc70dc78d1b"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Cesar" },
                    { new Guid("4e4cdf78-9ff6-4ea5-bfbd-c37bad442e85"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Casanare" },
                    { new Guid("598fd45a-994f-41d9-a403-9c194bc1f3f1"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Loja" },
                    { new Guid("5ddb40a0-df7b-44fd-9596-676db9a50bd4"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Galápagos" },
                    { new Guid("71860591-cf14-48a9-a06f-c68eccb2d8c1"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Arauca" },
                    { new Guid("757ba0c1-d96b-4da3-b2a6-9dc6e300e1cb"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Guayas" },
                    { new Guid("77dc62b7-1b37-4316-bc0f-67901e36cbf3"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Magdalena" },
                    { new Guid("8c028c6e-2626-4ade-b031-a1ea14c56ffc"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Esmeraldas" },
                    { new Guid("8f8a595a-c58d-4ee8-a148-40cbb003c03f"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Santander" },
                    { new Guid("94d89b69-c4c7-4606-b059-63c1a9b656d5"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Huila" },
                    { new Guid("aa85be1f-abe2-4751-8da7-38a2b930b527"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Quindío" },
                    { new Guid("b87f01bd-31ee-42aa-b985-c807c30dd9cb"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Córdoba" },
                    { new Guid("b8a17803-d01b-4142-96b8-5d7c8b2d1958"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Vaupés" },
                    { new Guid("b9ac4bcb-a6e2-494f-a7d8-3500576e5d75"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Meta" },
                    { new Guid("bbe7ef02-cfa6-4bd7-bf26-4246282e13b2"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Tolima" },
                    { new Guid("be362bcd-e59d-4ea3-bf20-cd3bcc17c204"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "San Andrés y Providencia" },
                    { new Guid("c519d256-9f3d-4ad2-a462-c12970f4ee1a"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Napo" },
                    { new Guid("c57330f1-e46e-4902-9de0-438dc52d1174"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Morona Santiago" },
                    { new Guid("c6818890-d8f6-48b5-9cbd-9e12579d6d1a"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "La Guajira" },
                    { new Guid("c77fbe3f-af07-45c7-ad0d-b594760cb97c"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Bolívar" },
                    { new Guid("cd7f27b3-293b-4f44-8136-a466f8ff9525"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Antioquia" },
                    { new Guid("d100d89d-0c05-4131-b940-a850873b0718"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Cañar" },
                    { new Guid("d3427d27-320e-4808-8757-437c856d18ac"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Cundinamarca" },
                    { new Guid("d7450556-7eba-4cf3-8461-318e8b6f7e53"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Caquetá" },
                    { new Guid("db82d3b8-24d5-4ebe-8814-528a8b0948f2"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Guaviare" },
                    { new Guid("e05ddb61-7b4a-4fb0-85f7-fcd8f7c0cb55"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Azuay" },
                    { new Guid("ed5f6e76-e8fa-4e0e-9bbf-9ad362dea113"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Caldas" },
                    { new Guid("fb75bdf5-a843-4761-9aee-2b1200be26d5"), new Guid("dffc9b8f-2244-430a-a9c5-1e241427b7db"), false, "Amazonas" },
                    { new Guid("fedf041f-4b2b-485b-8d33-685e877b6576"), new Guid("0dae59d5-223f-46a4-9bda-7c20548c3d65"), false, "Bolívar" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("05935a88-781d-406e-aac0-5f58b52631e6"), false, "Sogamoso", new Guid("40744b42-e290-4596-90f5-b7a8b140236b") },
                    { new Guid("05e86940-4993-4bb7-90a5-f25ebb586f0d"), false, "Machala", new Guid("220ee83b-77ef-4ae1-a0aa-b7d5d2eabc9d") },
                    { new Guid("06a01308-5542-4c38-942d-94d81305c49d"), false, "Calarcá", new Guid("aa85be1f-abe2-4751-8da7-38a2b930b527") },
                    { new Guid("096c1f12-1514-4cb1-9892-b273432fdf27"), false, "Chinchiná", new Guid("ed5f6e76-e8fa-4e0e-9bbf-9ad362dea113") },
                    { new Guid("0994c22b-6ba3-474a-93d4-c3423ee6d702"), false, "Cartagena del Chairá", new Guid("d7450556-7eba-4cf3-8461-318e8b6f7e53") },
                    { new Guid("0bf42ad8-ea2f-4d3b-838f-685b7062026e"), false, "Maicao", new Guid("c6818890-d8f6-48b5-9cbd-9e12579d6d1a") },
                    { new Guid("0c321aec-617b-441c-9f09-1ef2c1f503bc"), false, "Morelia", new Guid("d7450556-7eba-4cf3-8461-318e8b6f7e53") },
                    { new Guid("0fcf8154-fda3-4f7b-ae68-b53f442fd6d7"), false, "Aracataca", new Guid("77dc62b7-1b37-4316-bc0f-67901e36cbf3") },
                    { new Guid("13b51b44-085a-48ef-8611-321ee7077f29"), false, "Pereira", new Guid("1ba2474d-58d2-4e82-8e59-cae097423d56") },
                    { new Guid("13f1b8b2-bff2-4e80-9490-ef27e5089f20"), false, "Puerto Asís", new Guid("0609ac6f-5a8c-4cdb-ba77-a2c4e468ae95") },
                    { new Guid("165ecc8c-2377-4e63-9a82-60850ee58bdd"), false, "Azogues", new Guid("d100d89d-0c05-4131-b940-a850873b0718") },
                    { new Guid("17940812-5d18-42ac-938a-18c9b8dfe9bd"), false, "Santa Marta", new Guid("77dc62b7-1b37-4316-bc0f-67901e36cbf3") },
                    { new Guid("1a495b17-7a54-4345-8f8d-4ff75555ea64"), false, "Dosquebradas", new Guid("1ba2474d-58d2-4e82-8e59-cae097423d56") },
                    { new Guid("1c2b18b2-abdb-483a-91af-df9d9053e304"), false, "Mitú", new Guid("b8a17803-d01b-4142-96b8-5d7c8b2d1958") },
                    { new Guid("1d462095-5a07-47b4-a167-caa4ceff2632"), false, "Arauca", new Guid("71860591-cf14-48a9-a06f-c68eccb2d8c1") },
                    { new Guid("24207792-1fec-4e86-b5c1-adbeb8ffa401"), false, "Chone", new Guid("2fd56de4-45a9-462c-aa44-20d9125f0a13") },
                    { new Guid("249c6e50-82a7-4fc1-ab5d-52d329dd3a3a"), false, "Neiva", new Guid("94d89b69-c4c7-4606-b059-63c1a9b656d5") },
                    { new Guid("25b0e4e9-8138-49c0-b7b0-e3bea6dabe64"), false, "Leticia", new Guid("fb75bdf5-a843-4761-9aee-2b1200be26d5") },
                    { new Guid("297f93c4-51ad-4a45-9464-1de9b413a89b"), false, "Cartagena de Indias", new Guid("c77fbe3f-af07-45c7-ad0d-b594760cb97c") },
                    { new Guid("2de9ad19-59c8-47b0-bd5d-5971ac7fb20b"), false, "Calamar", new Guid("db82d3b8-24d5-4ebe-8814-528a8b0948f2") },
                    { new Guid("30709fdd-67a5-48c4-81c9-6d5e9ed8d034"), false, "Yopal", new Guid("4e4cdf78-9ff6-4ea5-bfbd-c37bad442e85") },
                    { new Guid("35aa60f2-504c-40bc-b0f1-abebd5b6c0e2"), false, "Turbo", new Guid("cd7f27b3-293b-4f44-8136-a466f8ff9525") },
                    { new Guid("37f2b886-fbad-4286-84bc-728fb923ffd0"), false, "Palmira", new Guid("1b586621-1fef-424e-81fa-bec0fb285679") },
                    { new Guid("413f1350-699d-438a-a377-09238102413d"), false, "Tumaco", new Guid("06189287-3dcb-49f0-90c0-fcd95b95e327") },
                    { new Guid("46559a23-0272-47ef-b1eb-e891caced216"), false, "Buenaventura", new Guid("1b586621-1fef-424e-81fa-bec0fb285679") },
                    { new Guid("4b2bb92e-7791-49f8-8d7c-14c8a0a64f84"), false, "Atacames", new Guid("8c028c6e-2626-4ade-b031-a1ea14c56ffc") },
                    { new Guid("4eb0057b-6de3-433a-bf2e-3df5f814b7d7"), false, "Sincelejo", new Guid("2182384c-72d0-4cd8-8479-168b185cb08a") },
                    { new Guid("4f7ad539-551d-41c4-9a08-a0cbd1e034cd"), false, "El Retén", new Guid("db82d3b8-24d5-4ebe-8814-528a8b0948f2") },
                    { new Guid("4fdf91e7-2efb-4d16-9471-5cb3a9e92ee3"), false, "Tulcán", new Guid("3d892b15-f5ae-4b61-bcca-5168bf56748d") },
                    { new Guid("505d2859-7011-48b2-bf1f-cd5cd82e36c8"), false, "Tauramena", new Guid("4e4cdf78-9ff6-4ea5-bfbd-c37bad442e85") },
                    { new Guid("524d3e97-512a-40ba-b028-1ca5c5702a84"), false, "La Primavera", new Guid("289c8325-899d-4e9c-bb26-da8a2fbd68b2") },
                    { new Guid("53ac9d5e-f686-43ee-ba3d-f89f38523ded"), false, "Manizales", new Guid("ed5f6e76-e8fa-4e0e-9bbf-9ad362dea113") },
                    { new Guid("55dff2dc-1b0b-419d-8380-2ee7a38aec40"), false, "Riobamba", new Guid("28daa4f8-3dc4-4801-aa1b-057acb3b6f18") },
                    { new Guid("56cc4dad-0b07-46bb-9dd9-7bc1fd06fdaf"), false, "Guaranda", new Guid("fedf041f-4b2b-485b-8d33-685e877b6576") },
                    { new Guid("59056932-865d-40f7-835b-5fcb8a4b2989"), false, "Ipiales", new Guid("06189287-3dcb-49f0-90c0-fcd95b95e327") },
                    { new Guid("590afea8-f00b-4057-b7f0-ca4c78db2f6b"), false, "Silvia", new Guid("3fc8c2e7-d2c3-4a7e-88e5-dd9e0a62e0e6") },
                    { new Guid("5c12cd9a-97b5-4387-8bbb-6546c648eed6"), false, "San Andrés", new Guid("be362bcd-e59d-4ea3-bf20-cd3bcc17c204") },
                    { new Guid("5db4bfce-e134-407b-a24c-0497f1539d27"), false, "Portoviejo", new Guid("2fd56de4-45a9-462c-aa44-20d9125f0a13") },
                    { new Guid("5df7dee2-450a-4e52-8526-1891f1f01319"), false, "San Juan de Pasto", new Guid("06189287-3dcb-49f0-90c0-fcd95b95e327") },
                    { new Guid("604df23e-1aa6-4698-b86b-7d19a091ccd4"), false, "San Cristóbal", new Guid("5ddb40a0-df7b-44fd-9596-676db9a50bd4") },
                    { new Guid("6100d10a-7e63-4cc3-aaaf-3423232c39f4"), false, "Santa Rosa", new Guid("220ee83b-77ef-4ae1-a0aa-b7d5d2eabc9d") },
                    { new Guid("61d939cd-64f1-4afb-8894-169795c6b6c5"), false, "Uribia", new Guid("c6818890-d8f6-48b5-9cbd-9e12579d6d1a") },
                    { new Guid("63958570-f4ca-42b3-be69-2cbe4cf12ce0"), false, "Ocaña", new Guid("2cfcb757-0670-4bb6-99d6-5e9922e7326b") },
                    { new Guid("65565762-b61a-44ba-a238-cb501e12687d"), false, "Ibagué", new Guid("bbe7ef02-cfa6-4bd7-bf26-4246282e13b2") },
                    { new Guid("66a79d2c-94f2-4144-a55c-9fe70e597ca6"), false, "Mocoa", new Guid("0609ac6f-5a8c-4cdb-ba77-a2c4e468ae95") },
                    { new Guid("6838f0e8-35f8-44d7-9589-6cc525266bb2"), false, "Bogotá", new Guid("d3427d27-320e-4808-8757-437c856d18ac") },
                    { new Guid("716c1be3-b989-424b-9e58-f49d745a9240"), false, "Guayaquil", new Guid("757ba0c1-d96b-4da3-b2a6-9dc6e300e1cb") },
                    { new Guid("72073614-070c-4287-81c7-8a97e4fcc801"), false, "Santa Helena", new Guid("289c8325-899d-4e9c-bb26-da8a2fbd68b2") },
                    { new Guid("73c0b0a6-6208-4e9a-84da-5a2a3e1ccc7a"), false, "Barranquilla", new Guid("286cd1ec-ee8f-47e6-b17e-88958107298b") },
                    { new Guid("7416886a-7bb1-4627-9678-0f3558ee74c0"), false, "San José del Guaviare", new Guid("db82d3b8-24d5-4ebe-8814-528a8b0948f2") },
                    { new Guid("75161f7c-d135-4a2e-b3db-4038dc437fac"), false, "Archidona", new Guid("c519d256-9f3d-4ad2-a462-c12970f4ee1a") },
                    { new Guid("78350552-a174-47d6-8fd1-37f1a0491dc0"), false, "Barrancabermeja", new Guid("8f8a595a-c58d-4ee8-a148-40cbb003c03f") },
                    { new Guid("7c5b2a3c-b949-4cca-bb50-b6c77dafaaf9"), false, "Fortul", new Guid("71860591-cf14-48a9-a06f-c68eccb2d8c1") },
                    { new Guid("7d926719-0043-419b-a233-971b594a52db"), false, "Esmeraldas", new Guid("8c028c6e-2626-4ade-b031-a1ea14c56ffc") },
                    { new Guid("7dc1bf89-a940-4711-80e8-3a78db10e344"), false, "Otavalo", new Guid("4c14f504-2bf8-4d25-ba70-e68b16b5a9f5") },
                    { new Guid("7de9c2cd-92dc-4f40-ba45-9b4a8bbd7c5f"), false, "Bucaramanga", new Guid("8f8a595a-c58d-4ee8-a148-40cbb003c03f") },
                    { new Guid("80797cb7-520b-42af-b4e8-d68fac195539"), false, "Aguazul", new Guid("4e4cdf78-9ff6-4ea5-bfbd-c37bad442e85") },
                    { new Guid("83b10cf2-88ae-490c-a08d-56669df4639c"), false, "Inírida", new Guid("0ec08a72-79fc-4b7e-865c-db1951bfc5d0") },
                    { new Guid("84ad4043-faae-4d97-b4bc-48e6740c3349"), false, "La Paz", new Guid("4cfb18bd-fe66-45d8-afcc-edc70dc78d1b") },
                    { new Guid("86fbca92-1115-440a-a181-3f694ad3def1"), false, "Villavicencio", new Guid("b9ac4bcb-a6e2-494f-a7d8-3500576e5d75") },
                    { new Guid("8ab1725d-34f7-4bc6-9452-969096cc237b"), false, "Duitama", new Guid("40744b42-e290-4596-90f5-b7a8b140236b") },
                    { new Guid("8afb71e3-0778-4069-8114-a91f44c9b137"), false, "Cúcuta", new Guid("2cfcb757-0670-4bb6-99d6-5e9922e7326b") },
                    { new Guid("8d374b54-8acc-4477-b616-d80d1917b966"), false, "Quibdó", new Guid("31fafa3c-8545-48fc-a248-c70016be95fa") },
                    { new Guid("8ea3eac7-3b85-4f95-9293-53cbb2ec24a0"), false, "Riohacha", new Guid("c6818890-d8f6-48b5-9cbd-9e12579d6d1a") },
                    { new Guid("91ab6c29-21aa-40b0-abec-f79ceb0bda66"), false, "Alausí", new Guid("28daa4f8-3dc4-4801-aa1b-057acb3b6f18") },
                    { new Guid("9b713863-ddf4-4850-9844-9c5114d14c2d"), false, "Montería", new Guid("2182384c-72d0-4cd8-8479-168b185cb08a") },
                    { new Guid("9b84c296-837e-45df-9be0-b08e676c9deb"), false, "Cuenca", new Guid("e05ddb61-7b4a-4fb0-85f7-fcd8f7c0cb55") },
                    { new Guid("a57e241f-d7eb-43a7-a6a7-03a40fe6a267"), false, "Cereté", new Guid("b87f01bd-31ee-42aa-b985-c807c30dd9cb") },
                    { new Guid("a5aa2dd6-3653-4d74-bc3c-ad563043a38b"), false, "Providencia", new Guid("be362bcd-e59d-4ea3-bf20-cd3bcc17c204") },
                    { new Guid("a6252e21-5f78-46cd-868a-cab609b2b419"), false, "Pitalito", new Guid("94d89b69-c4c7-4606-b059-63c1a9b656d5") },
                    { new Guid("a62ece73-ed9a-4145-a707-fe3441966573"), false, "Popayán", new Guid("3fc8c2e7-d2c3-4a7e-88e5-dd9e0a62e0e6") },
                    { new Guid("a6f5135d-7413-471a-beff-ee1b4a5bd593"), false, "Ibarra", new Guid("4c14f504-2bf8-4d25-ba70-e68b16b5a9f5") },
                    { new Guid("a9823fa9-0f24-4930-8370-6c7c191a64e8"), false, "Apartadó", new Guid("cd7f27b3-293b-4f44-8136-a466f8ff9525") },
                    { new Guid("b1319aad-59cb-432f-b06f-dd6444b9da81"), false, "Istmina", new Guid("31fafa3c-8545-48fc-a248-c70016be95fa") },
                    { new Guid("b16fb17f-e7cd-42ef-877c-3cddadd7bc7e"), false, "Florencia", new Guid("d7450556-7eba-4cf3-8461-318e8b6f7e53") },
                    { new Guid("b1b29a62-5293-4a0c-986e-00563abd45f4"), false, "Saravena", new Guid("71860591-cf14-48a9-a06f-c68eccb2d8c1") },
                    { new Guid("b3aea561-23a1-42b8-a7aa-7a8f756a1aca"), false, "Tena", new Guid("c519d256-9f3d-4ad2-a462-c12970f4ee1a") },
                    { new Guid("b61940b2-a3d8-40b8-9edb-dd383f651c93"), false, "Piedecuesta", new Guid("8f8a595a-c58d-4ee8-a148-40cbb003c03f") },
                    { new Guid("b689890e-7076-48e4-8d6e-619c7b629c92"), false, "Valledupar", new Guid("4cfb18bd-fe66-45d8-afcc-edc70dc78d1b") },
                    { new Guid("b7a05aff-a9b4-4efc-b87f-86e778d0c5de"), false, "Corozal", new Guid("2182384c-72d0-4cd8-8479-168b185cb08a") },
                    { new Guid("b94d5107-2532-4f42-8385-a557f67119ba"), false, "Yavaraté", new Guid("b8a17803-d01b-4142-96b8-5d7c8b2d1958") },
                    { new Guid("bc663570-a406-4f13-b590-21813a376c81"), false, "Durán", new Guid("757ba0c1-d96b-4da3-b2a6-9dc6e300e1cb") },
                    { new Guid("bc76c92b-e65c-4a52-aae4-9abe8c868e3b"), false, "Armero Guayabal", new Guid("bbe7ef02-cfa6-4bd7-bf26-4246282e13b2") },
                    { new Guid("be06cff4-90f1-4658-8f3b-aafcb5989734"), false, "Novita", new Guid("31fafa3c-8545-48fc-a248-c70016be95fa") },
                    { new Guid("c229fe3e-a4bc-482e-b13d-fad40ead0234"), false, "Memarí", new Guid("0ec08a72-79fc-4b7e-865c-db1951bfc5d0") },
                    { new Guid("c7599b17-cf04-4bd6-8d45-1bebbf369bb6"), false, "Pereira", new Guid("ed5f6e76-e8fa-4e0e-9bbf-9ad362dea113") },
                    { new Guid("ca15098e-ba0a-42f4-8b8e-765ee69ec5d0"), false, "Puerto Baquerizo Moreno", new Guid("5ddb40a0-df7b-44fd-9596-676db9a50bd4") },
                    { new Guid("ca58d79c-2190-4bb9-8d45-dcd7f24d66c1"), false, "El Guabo", new Guid("3d892b15-f5ae-4b61-bcca-5168bf56748d") },
                    { new Guid("cb26c69f-a115-48b8-a45b-ab7e2f35b5ac"), false, "Puerto Inírida", new Guid("0ec08a72-79fc-4b7e-865c-db1951bfc5d0") },
                    { new Guid("cc03cf35-b83b-4948-9e13-7d8c3b004ab6"), false, "Macas", new Guid("c57330f1-e46e-4902-9de0-438dc52d1174") },
                    { new Guid("cce4259c-2960-4a47-a7c8-02cfb50f1e6c"), false, "Saraguro", new Guid("598fd45a-994f-41d9-a403-9c194bc1f3f1") },
                    { new Guid("cdf39286-925b-4e50-a836-a913d3522973"), false, "Lorica", new Guid("b87f01bd-31ee-42aa-b985-c807c30dd9cb") },
                    { new Guid("d272bfd1-784b-4157-aece-6dc8e1988ce6"), false, "Loja", new Guid("598fd45a-994f-41d9-a403-9c194bc1f3f1") },
                    { new Guid("d324b373-6ca4-4fde-a84d-bd03f0d4563c"), false, "Garzón", new Guid("94d89b69-c4c7-4606-b059-63c1a9b656d5") },
                    { new Guid("d32acf5a-4850-4412-b143-63335262a229"), false, "Latacunga", new Guid("00997a7b-f986-47c5-a2d4-62b2993797b7") },
                    { new Guid("d331b050-7958-4fbe-9075-f2723871c687"), false, "Puerto Colombia", new Guid("286cd1ec-ee8f-47e6-b17e-88958107298b") },
                    { new Guid("d3b577a4-ffa2-493e-b377-dfb822cd149e"), false, "Cali", new Guid("1b586621-1fef-424e-81fa-bec0fb285679") },
                    { new Guid("d5acdcb3-a55d-4f19-a3c6-3ab477ea867d"), false, "Girón", new Guid("e05ddb61-7b4a-4fb0-85f7-fcd8f7c0cb55") },
                    { new Guid("d5bb6c86-6d27-4a5f-8c31-b09cbb0d3257"), false, "Santa Rosa de Cabal", new Guid("1ba2474d-58d2-4e82-8e59-cae097423d56") },
                    { new Guid("da015a1a-2c78-4888-ac00-3d53eeadd3fb"), false, "Ciénaga", new Guid("77dc62b7-1b37-4316-bc0f-67901e36cbf3") },
                    { new Guid("db87a032-d3d7-412b-8c3b-83d969f83887"), false, "Gualaquiza", new Guid("c57330f1-e46e-4902-9de0-438dc52d1174") },
                    { new Guid("dd2a1ae9-c662-454a-a882-afa18b0ca5eb"), false, "Soacha", new Guid("d3427d27-320e-4808-8757-437c856d18ac") },
                    { new Guid("df5d167c-00fb-4e0f-abe3-3761942cdac8"), false, "Pamplona", new Guid("2cfcb757-0670-4bb6-99d6-5e9922e7326b") },
                    { new Guid("dfe5ee3e-f678-4d86-8a2d-bf58fae0eaff"), false, "Puerto Carreño", new Guid("289c8325-899d-4e9c-bb26-da8a2fbd68b2") },
                    { new Guid("e0d9cfab-67f3-4214-89f4-cb1719f94ca0"), false, "Orito", new Guid("0609ac6f-5a8c-4cdb-ba77-a2c4e468ae95") },
                    { new Guid("e0ecba4e-15bc-4fbb-b7c7-130223de4f84"), false, "Armenia", new Guid("aa85be1f-abe2-4751-8da7-38a2b930b527") },
                    { new Guid("e1893eb3-72d2-492b-82e4-9cc15e772294"), false, "Granada", new Guid("b9ac4bcb-a6e2-494f-a7d8-3500576e5d75") },
                    { new Guid("e5f3c29f-b832-4105-a178-f4b4bda4a16c"), false, "Santa Catalina", new Guid("be362bcd-e59d-4ea3-bf20-cd3bcc17c204") },
                    { new Guid("e6f1ffaa-9838-4035-8d30-3597380e028b"), false, "Zipaquirá", new Guid("d3427d27-320e-4808-8757-437c856d18ac") },
                    { new Guid("e6fede83-0e1b-41ab-a4cc-aa72cbbcf866"), false, "Honda", new Guid("bbe7ef02-cfa6-4bd7-bf26-4246282e13b2") },
                    { new Guid("eb5d5d7e-a96f-45db-800e-466f2e670a1b"), false, "Cartagena del Chairá", new Guid("c77fbe3f-af07-45c7-ad0d-b594760cb97c") },
                    { new Guid("eeabbbce-1468-4243-8aba-046c3ed0fc1c"), false, "Salcedo", new Guid("00997a7b-f986-47c5-a2d4-62b2993797b7") },
                    { new Guid("ef3e939f-0e2f-45ee-81d1-f313caa955a2"), false, "Santa Rosalía", new Guid("b8a17803-d01b-4142-96b8-5d7c8b2d1958") },
                    { new Guid("f00486ec-e5db-460c-b5cf-cfcde5f947dc"), false, "Acacias", new Guid("b9ac4bcb-a6e2-494f-a7d8-3500576e5d75") },
                    { new Guid("f2a47fda-514e-4df6-8762-bd5635b879c7"), false, "San Miguel de Bolívar", new Guid("fedf041f-4b2b-485b-8d33-685e877b6576") },
                    { new Guid("f3119965-8cf4-45f9-908e-d9682d3bdfa2"), false, "Magangué", new Guid("c77fbe3f-af07-45c7-ad0d-b594760cb97c") },
                    { new Guid("f3973f38-379c-4b4a-98b6-51b992affcfd"), false, "Montería", new Guid("b87f01bd-31ee-42aa-b985-c807c30dd9cb") },
                    { new Guid("f4a4f00d-d422-414b-8f5b-b9e4a92dbecc"), false, "Santander de Quilichao", new Guid("3fc8c2e7-d2c3-4a7e-88e5-dd9e0a62e0e6") },
                    { new Guid("f7feb7ea-1415-4e08-b991-94b9159ca605"), false, "Medellín", new Guid("cd7f27b3-293b-4f44-8136-a466f8ff9525") },
                    { new Guid("fa600836-98bb-4adf-8db7-d6cde08a132a"), false, "Tunja", new Guid("40744b42-e290-4596-90f5-b7a8b140236b") },
                    { new Guid("fab0b269-8cff-46a2-b309-c96430d8e41f"), false, "El Tambo", new Guid("d100d89d-0c05-4131-b940-a850873b0718") },
                    { new Guid("fbef7cab-ba82-4a82-82a9-d912523be4c2"), false, "Soledad", new Guid("286cd1ec-ee8f-47e6-b17e-88958107298b") },
                    { new Guid("fc2ecf61-6749-4e9c-8bad-1111be4739a9"), false, "Aguachica", new Guid("4cfb18bd-fe66-45d8-afcc-edc70dc78d1b") },
                    { new Guid("fd4b07c0-84b1-48b8-9968-086577956884"), false, "Manta", new Guid("2fd56de4-45a9-462c-aa44-20d9125f0a13") },
                    { new Guid("fe381bd9-736d-4a60-99bf-c36122d08a38"), false, "La Tebaida", new Guid("aa85be1f-abe2-4751-8da7-38a2b930b527") }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "professional");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
