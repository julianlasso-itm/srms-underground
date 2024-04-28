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
                    { new Guid("0c79634a-3f2f-4a1c-9ddb-73ffef49e9fe"), false, "México" },
                    { new Guid("1b74097b-d337-4b93-9c40-228848798059"), false, "Bolivia" },
                    { new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Ecuador" },
                    { new Guid("4f21d457-35a2-4e27-b5ab-4e0f62f1c063"), false, "Brasil" },
                    { new Guid("51bc5fc0-bae4-4f87-84c4-56ee1a654ae0"), false, "Perú" },
                    { new Guid("6c185c0a-b5ba-4f31-ab39-9fcfb7611db8"), false, "Guatemala" },
                    { new Guid("6f988aab-3ae8-4674-a666-4e17c455f7d9"), false, "El Salvador" },
                    { new Guid("7422cd0f-f14f-4ad7-ad14-cd22d5ca1a89"), false, "Belize" },
                    { new Guid("8e56cb5b-c1b3-4250-8a52-0b6fcd76ef1e"), false, "Venezuela" },
                    { new Guid("941a048e-adb1-4649-93f5-bb7a4ef7e6fa"), false, "Nicaragua" },
                    { new Guid("9479a8bd-9860-4723-84e6-71a1c88f8992"), false, "Argentina" },
                    { new Guid("b769945e-4093-446d-8f8e-8f29b99515b2"), false, "Panamá" },
                    { new Guid("c48338df-363a-481d-95c2-093225a51af5"), false, "Honduras" },
                    { new Guid("c4d12202-7987-4897-8660-fbee4c6017d8"), false, "Uruguay" },
                    { new Guid("c6580b4d-8f33-4b73-9db2-a0916db5bf7b"), false, "Paraguay" },
                    { new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Colombia" },
                    { new Guid("e2885292-fbf6-48ce-a74b-bd1e32571efc"), false, "Chile" },
                    { new Guid("e8e3ab36-c348-4b36-b295-83b184c87f6a"), false, "Costa Rica" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "rol_role_id", "created_at", "deleted_at", "rol_description", "rol_disabled", "rol_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("28306dc5-e7f7-4f85-b88f-356c003cbfdc"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1492), null, null, false, "Scrum Master", null },
                    { new Guid("30306e97-a4c3-4e1c-81e3-3741464be848"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1503), null, null, false, "Lead Designer", null },
                    { new Guid("3039f4fb-1216-4c85-99d8-bff0849470a2"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1488), null, null, false, "Product Owner", null },
                    { new Guid("42c2593b-a593-4a2b-a660-74900484aa06"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1496), null, null, false, "Architect", null },
                    { new Guid("56306305-5683-4dd9-a789-38fd54d572cb"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1500), null, null, false, "Lead Developer", null },
                    { new Guid("a772939a-0ed9-408e-84cf-4b74dd376e7f"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1458), null, null, false, "Developer", null },
                    { new Guid("b6baffe1-dbaf-4229-9029-158745b39189"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1464), null, null, false, "Designer", null },
                    { new Guid("bdda38c4-7c13-49ec-acd6-35fafd49da60"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1480), null, null, false, "Data Scientist", null },
                    { new Guid("c34a0f19-a47a-4960-9058-c64dd6056e76"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1484), null, null, false, "UX/UI Designer", null },
                    { new Guid("d7a192a0-f404-489d-870d-4a63b7dd6806"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1472), null, null, false, "QA", null },
                    { new Guid("ed1fc664-7edc-4d8f-8d7a-9f547cb80381"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1468), null, null, false, "Manager", null },
                    { new Guid("f45f43eb-7f84-42e8-8195-9d795ac2ebdf"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1476), null, null, false, "DevOps", null }
                });

            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skl_skill_id", "created_at", "deleted_at", "skl_disabled", "skl_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0cf57048-9993-4743-b69f-c1c25381eb6c"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1571), null, false, "Node.js", null },
                    { new Guid("36620779-6e25-4e8b-bf64-f932b363b9ae"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1526), null, false, "C#", null },
                    { new Guid("42144dbf-8a18-4c5c-8df0-1ab1225cb238"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1568), null, false, "Vue", null },
                    { new Guid("46d49110-639c-4e6f-962b-7fdc4a78aca3"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1553), null, false, "SQL", null },
                    { new Guid("4eb3c4a0-da21-495d-8bcb-f0180b6c5e61"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1578), null, false, "Hibernate", null },
                    { new Guid("529a6efb-0bfe-4978-be4d-1e77cd4f4be0"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1550), null, false, "CSS", null },
                    { new Guid("56271973-e010-40da-b952-912f16210268"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1547), null, false, "HTML", null },
                    { new Guid("8bb2ee8e-3490-481c-ba1a-58e17c20a3e1"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1539), null, false, "JavaScript", null },
                    { new Guid("a63a2ffd-ddf3-4e66-8188-f802b83d1460"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1536), null, false, "Python", null },
                    { new Guid("c5ad0746-ea04-4cf7-8282-bca234c9f27a"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1543), null, false, "TypeScript", null },
                    { new Guid("d566c025-2e9b-4fdd-b909-ba7a37d87e3b"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1561), null, false, "Angular", null },
                    { new Guid("e427d8a0-0c52-475d-bafb-b8110e12e8f9"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1567), null, false, "React", null },
                    { new Guid("ea0423cd-a55a-4cd4-83fa-282b34951860"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1532), null, false, "Java", null },
                    { new Guid("ea0eea34-76df-4eaa-b037-3c5d23813399"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1557), null, false, "NoSQL", null },
                    { new Guid("ecb521d9-f0a7-479d-ba94-36d2542b766b"), new DateTime(2024, 4, 28, 7, 10, 6, 588, DateTimeKind.Utc).AddTicks(1574), null, false, "Spring Boot", null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("034ff5b0-3477-4f1d-b24b-64cee73f6786"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Napo" },
                    { new Guid("0604d89c-779b-4c93-b523-1259f5fce320"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Santander" },
                    { new Guid("17613b0e-4e1f-432f-937d-d056d9ca1d5d"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Meta" },
                    { new Guid("1df45a1c-93dc-48aa-9c42-340f7d590d78"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Caldas" },
                    { new Guid("24a096a3-491c-401c-9a9a-b0300766d9c5"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Bolívar" },
                    { new Guid("283ed97f-cb13-4e61-bd74-9d54b72e7dc6"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Quindío" },
                    { new Guid("30727c65-1169-4ac6-a091-55841eaf5943"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Huila" },
                    { new Guid("31fd44da-a067-452e-baa6-840b70341bd7"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Cauca" },
                    { new Guid("321524fd-0b69-4fa4-9e27-ce0fabc9c756"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Chocó" },
                    { new Guid("3623b694-3df6-4ac6-8aae-fc275c1859d3"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Magdalena" },
                    { new Guid("394b17e2-1ac1-4581-8fe1-f6ad4c8c776d"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Atlántico" },
                    { new Guid("41f90bde-6966-4a5c-a782-1832076e1451"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Putumayo" },
                    { new Guid("4b8217de-b4e1-43f8-9d90-0785abd7c91e"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Tolima" },
                    { new Guid("55ccec6a-eac0-4acd-b034-a81ecba561e8"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Chimborazo" },
                    { new Guid("62332f13-8c5b-4776-891d-be7da87b0482"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Guaviare" },
                    { new Guid("66f03979-f420-4eea-9649-f988bc462a67"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Galápagos" },
                    { new Guid("6b082850-1ad9-421c-9a86-300ab7684ab2"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Vaupés" },
                    { new Guid("70fefe77-783a-496d-81e0-c22e3d4f170b"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Norte de Santander" },
                    { new Guid("719db247-0ab7-46f2-b70a-60280b933e1e"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Cotopaxi" },
                    { new Guid("795bb29d-c62d-42d8-84a5-69d217606c2a"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Imbabura" },
                    { new Guid("7a87b6fb-38f8-4082-9b14-bde49c097574"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Bolívar" },
                    { new Guid("7c44f4bf-6f39-4fbc-b945-0e40c87626e0"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Guainía" },
                    { new Guid("811ad7a5-78c4-44d2-bcba-5e69fe102e9e"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Guayas" },
                    { new Guid("831cab56-37eb-4948-8fec-21eec4fbdf6b"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "El Oro" },
                    { new Guid("90c9a283-038d-47f9-a6f2-57f2cc96722a"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "San Andrés y Providencia" },
                    { new Guid("91f68bc0-21a4-473b-abfc-900bb72663c0"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Cundinamarca" },
                    { new Guid("9434f2e8-139a-40bd-a1a8-0ee9aa74a3e0"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Loja" },
                    { new Guid("951e2027-5855-4abd-9457-fb8cf1c412aa"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Azuay" },
                    { new Guid("959356c6-2126-47d3-8659-9bb9804db3a1"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Cañar" },
                    { new Guid("a09bf111-cb02-4e03-90ca-8c487e694dad"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Cesar" },
                    { new Guid("b0350728-6027-4453-8edb-2d7a3c43e88a"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Morona Santiago" },
                    { new Guid("bcd4fc70-a87a-4b10-8d2f-e887a34a1aa2"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Vichada" },
                    { new Guid("bce31918-0958-4e6f-9325-4ead8e354d7a"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Boyacá" },
                    { new Guid("c0668d59-064a-4940-b466-a2eef4d38295"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Esmeraldas" },
                    { new Guid("c7d3eb19-bd21-4593-bd9a-0368d215d6ed"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Antioquia" },
                    { new Guid("d56eaffa-670c-4943-935c-297e74ae9331"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Amazonas" },
                    { new Guid("d7f1f28a-4751-4f6a-b421-85ec0169de2a"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Risaralda" },
                    { new Guid("dde1feba-1398-46e5-a37f-60947610e77e"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Nariño" },
                    { new Guid("e2d06ab7-5178-42c3-88ae-d66092b70a74"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Valle del Cauca" },
                    { new Guid("e7a97098-ef56-42d3-a1be-31d8e1deb8e4"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Casanare" },
                    { new Guid("e7ac56f2-a3cd-451e-aaeb-61f06f76fdd8"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Carchi" },
                    { new Guid("e9ee3e7e-43ba-4034-954c-1c50458d49ef"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Caquetá" },
                    { new Guid("ea0b3ed3-1adf-4c26-a957-f2bf6e3649fd"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "La Guajira" },
                    { new Guid("eaf285a2-cb5c-457a-a1f0-5d6e71b24bd6"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Sucre" },
                    { new Guid("f51847b9-a71e-4e6c-96c5-e0bd05aad056"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Córdoba" },
                    { new Guid("f8f50d16-c1fe-4e07-8bc3-48c691bfe464"), new Guid("d7d958e8-92d0-48d8-ae80-4d1403ca09f9"), false, "Arauca" },
                    { new Guid("f992668d-28db-4f34-93e0-9a150f2e8ed3"), new Guid("29b9a28e-50c1-446f-8518-a42957afdd76"), false, "Manabí" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("0051d609-916f-4cb2-b39e-1509e140fe44"), false, "Saravena", new Guid("f8f50d16-c1fe-4e07-8bc3-48c691bfe464") },
                    { new Guid("005d80dc-a442-4ae5-b525-acf5641d506b"), false, "Pitalito", new Guid("30727c65-1169-4ac6-a091-55841eaf5943") },
                    { new Guid("02f38f5d-9f20-4f81-90f7-55b785356217"), false, "Piedecuesta", new Guid("0604d89c-779b-4c93-b523-1259f5fce320") },
                    { new Guid("04ddb361-5199-4764-948a-bf682840401a"), false, "San Andrés", new Guid("90c9a283-038d-47f9-a6f2-57f2cc96722a") },
                    { new Guid("0585f91c-b2a7-4c73-8447-5b14dba3f189"), false, "Novita", new Guid("321524fd-0b69-4fa4-9e27-ce0fabc9c756") },
                    { new Guid("08235056-f08c-4c65-af1a-e664df391aa7"), false, "Riohacha", new Guid("ea0b3ed3-1adf-4c26-a957-f2bf6e3649fd") },
                    { new Guid("08df68db-1317-4004-b1b2-6396e6cc1e28"), false, "Armenia", new Guid("283ed97f-cb13-4e61-bd74-9d54b72e7dc6") },
                    { new Guid("0bb7f5da-7b92-4a01-9905-c0795178fdeb"), false, "Ibarra", new Guid("795bb29d-c62d-42d8-84a5-69d217606c2a") },
                    { new Guid("0c68da34-11bd-4f20-922c-68af3f367682"), false, "El Retén", new Guid("62332f13-8c5b-4776-891d-be7da87b0482") },
                    { new Guid("12440e4b-48e6-41f7-a978-5a74fe5c1ece"), false, "Girón", new Guid("951e2027-5855-4abd-9457-fb8cf1c412aa") },
                    { new Guid("13724291-0f73-47f8-ba57-34d25f6e0bc8"), false, "Tulcán", new Guid("e7ac56f2-a3cd-451e-aaeb-61f06f76fdd8") },
                    { new Guid("16e59dd9-e44d-458a-b6ac-1b7af5d61881"), false, "Bogotá", new Guid("91f68bc0-21a4-473b-abfc-900bb72663c0") },
                    { new Guid("18630679-7909-46f4-88d8-24f37385a9cd"), false, "Bucaramanga", new Guid("0604d89c-779b-4c93-b523-1259f5fce320") },
                    { new Guid("1b3ab298-d0b6-4510-94f5-08d0162a6e23"), false, "Loja", new Guid("9434f2e8-139a-40bd-a1a8-0ee9aa74a3e0") },
                    { new Guid("1ce62f43-06e4-4010-89f9-77fd048b192b"), false, "Barranquilla", new Guid("394b17e2-1ac1-4581-8fe1-f6ad4c8c776d") },
                    { new Guid("1e0ae603-84a7-4c88-af9c-95422fe6c22b"), false, "Magangué", new Guid("7a87b6fb-38f8-4082-9b14-bde49c097574") },
                    { new Guid("1e16fe60-84d0-46ab-bcf3-51d0c3cd2917"), false, "Florencia", new Guid("e9ee3e7e-43ba-4034-954c-1c50458d49ef") },
                    { new Guid("23107ddb-f36b-4701-ba0e-00c9ac557183"), false, "Guayaquil", new Guid("811ad7a5-78c4-44d2-bcba-5e69fe102e9e") },
                    { new Guid("25ce32ac-1213-46de-9209-50fdaef7b494"), false, "Palmira", new Guid("e2d06ab7-5178-42c3-88ae-d66092b70a74") },
                    { new Guid("2a276e5d-77f4-4eee-ad00-64392563fd23"), false, "Chone", new Guid("f992668d-28db-4f34-93e0-9a150f2e8ed3") },
                    { new Guid("2ccdd524-707e-42d1-9275-00ff5c584f51"), false, "Riobamba", new Guid("55ccec6a-eac0-4acd-b034-a81ecba561e8") },
                    { new Guid("2d1ef6ef-b4dc-4374-baa2-a3eb85b6232b"), false, "Duitama", new Guid("bce31918-0958-4e6f-9325-4ead8e354d7a") },
                    { new Guid("2da72ec7-8d9a-49c7-a50a-59822e48f5b9"), false, "Puerto Asís", new Guid("41f90bde-6966-4a5c-a782-1832076e1451") },
                    { new Guid("2f4f4627-b360-4af0-89fa-5103964d5b5f"), false, "Zipaquirá", new Guid("91f68bc0-21a4-473b-abfc-900bb72663c0") },
                    { new Guid("31d885f0-5267-494c-b23e-401622f2d120"), false, "Tauramena", new Guid("e7a97098-ef56-42d3-a1be-31d8e1deb8e4") },
                    { new Guid("34f98fe5-83d2-4f60-9ae0-522f30bfefe7"), false, "Leticia", new Guid("d56eaffa-670c-4943-935c-297e74ae9331") },
                    { new Guid("3961ab5d-d535-4a3b-85a5-806dd89cd21a"), false, "Alausí", new Guid("55ccec6a-eac0-4acd-b034-a81ecba561e8") },
                    { new Guid("3e16ccc7-d443-40d9-a76a-d6ebb693569a"), false, "Tunja", new Guid("bce31918-0958-4e6f-9325-4ead8e354d7a") },
                    { new Guid("3e281520-6a33-48fe-983d-354d9ddbb9fd"), false, "Istmina", new Guid("321524fd-0b69-4fa4-9e27-ce0fabc9c756") },
                    { new Guid("413b3444-5a15-4299-a90f-93c90dca2e0e"), false, "Aracataca", new Guid("3623b694-3df6-4ac6-8aae-fc275c1859d3") },
                    { new Guid("422268b6-7a1e-4db6-85c5-ab78dc9b36db"), false, "Macas", new Guid("b0350728-6027-4453-8edb-2d7a3c43e88a") },
                    { new Guid("4294fa02-8f00-44ae-b977-443ef61409c1"), false, "Portoviejo", new Guid("f992668d-28db-4f34-93e0-9a150f2e8ed3") },
                    { new Guid("4541574b-9ffb-42fd-992e-d6cc34b5d3f3"), false, "Durán", new Guid("811ad7a5-78c4-44d2-bcba-5e69fe102e9e") },
                    { new Guid("468caf22-c467-4e41-b806-fa877f82e3eb"), false, "Barrancabermeja", new Guid("0604d89c-779b-4c93-b523-1259f5fce320") },
                    { new Guid("48044946-0671-4da7-b590-18ea2978b781"), false, "Medellín", new Guid("c7d3eb19-bd21-4593-bd9a-0368d215d6ed") },
                    { new Guid("4a1add0f-a4ee-4dd3-bb32-22f9467484f0"), false, "Santa Helena", new Guid("bcd4fc70-a87a-4b10-8d2f-e887a34a1aa2") },
                    { new Guid("4be5508c-8a04-49cb-a0f4-8a1de7e7ef8c"), false, "Corozal", new Guid("eaf285a2-cb5c-457a-a1f0-5d6e71b24bd6") },
                    { new Guid("4bf855be-faac-4b63-b9b5-bbae142e062d"), false, "La Tebaida", new Guid("283ed97f-cb13-4e61-bd74-9d54b72e7dc6") },
                    { new Guid("5293c219-e6e6-47b5-994a-0d595af13d69"), false, "Ciénaga", new Guid("3623b694-3df6-4ac6-8aae-fc275c1859d3") },
                    { new Guid("53011920-d31e-4ef8-87d4-bf37f0b752a7"), false, "Inírida", new Guid("7c44f4bf-6f39-4fbc-b945-0e40c87626e0") },
                    { new Guid("582c312d-7d46-4dd6-918d-e0e9bf35f969"), false, "El Tambo", new Guid("959356c6-2126-47d3-8659-9bb9804db3a1") },
                    { new Guid("59170cf3-25d2-4a4a-830e-8cb9c2eaf0bf"), false, "Turbo", new Guid("c7d3eb19-bd21-4593-bd9a-0368d215d6ed") },
                    { new Guid("5bca6bd2-b93d-4352-8be8-705ed20a76b0"), false, "Pereira", new Guid("1df45a1c-93dc-48aa-9c42-340f7d590d78") },
                    { new Guid("5c285f63-8a93-4cba-8eda-0ba118ddf58f"), false, "Cartagena del Chairá", new Guid("e9ee3e7e-43ba-4034-954c-1c50458d49ef") },
                    { new Guid("5d6ae58d-3272-42f0-9e5b-1055837b0a4d"), false, "Calarcá", new Guid("283ed97f-cb13-4e61-bd74-9d54b72e7dc6") },
                    { new Guid("5e86cbb5-7c47-4a4c-9085-beefc7e614fa"), false, "Azogues", new Guid("959356c6-2126-47d3-8659-9bb9804db3a1") },
                    { new Guid("60412eb2-4ec2-44c3-b04d-a40791fa7911"), false, "Calamar", new Guid("62332f13-8c5b-4776-891d-be7da87b0482") },
                    { new Guid("60689017-eaf7-4ab2-9e0e-9597887954d8"), false, "Ipiales", new Guid("dde1feba-1398-46e5-a37f-60947610e77e") },
                    { new Guid("614064bf-23be-4f27-bc9f-a656d9690fd1"), false, "Cuenca", new Guid("951e2027-5855-4abd-9457-fb8cf1c412aa") },
                    { new Guid("62bb4f47-b017-43ed-8c9d-90c2ef089b71"), false, "Sincelejo", new Guid("eaf285a2-cb5c-457a-a1f0-5d6e71b24bd6") },
                    { new Guid("65ba9334-b6d1-4803-be9d-b47f8e4a6b71"), false, "Lorica", new Guid("f51847b9-a71e-4e6c-96c5-e0bd05aad056") },
                    { new Guid("674e016a-f96c-4726-a7ff-f402faebb3a3"), false, "Acacias", new Guid("17613b0e-4e1f-432f-937d-d056d9ca1d5d") },
                    { new Guid("67eee4b7-2742-49f8-9d71-afd47123df29"), false, "Mocoa", new Guid("41f90bde-6966-4a5c-a782-1832076e1451") },
                    { new Guid("6840a433-4633-47d5-8e8b-04d5b0772247"), false, "Uribia", new Guid("ea0b3ed3-1adf-4c26-a957-f2bf6e3649fd") },
                    { new Guid("68a4f970-b85b-4350-89d1-ff7f435f6179"), false, "Mitú", new Guid("6b082850-1ad9-421c-9a86-300ab7684ab2") },
                    { new Guid("68c33859-71d3-4736-b085-db002fe32e1f"), false, "El Guabo", new Guid("e7ac56f2-a3cd-451e-aaeb-61f06f76fdd8") },
                    { new Guid("6cb37a28-e028-4556-97df-a200477eeabf"), false, "San José del Guaviare", new Guid("62332f13-8c5b-4776-891d-be7da87b0482") },
                    { new Guid("70112beb-7ba2-4c39-a812-42e5ed80cc23"), false, "Cartagena de Indias", new Guid("7a87b6fb-38f8-4082-9b14-bde49c097574") },
                    { new Guid("70238b6a-2f81-41a3-af0b-90f776e9985b"), false, "Apartadó", new Guid("c7d3eb19-bd21-4593-bd9a-0368d215d6ed") },
                    { new Guid("71825669-0637-478a-bb76-833f6b0c264e"), false, "Santa Rosalía", new Guid("6b082850-1ad9-421c-9a86-300ab7684ab2") },
                    { new Guid("721143ae-408c-4ad0-8c77-aa4bf8754b81"), false, "Montería", new Guid("eaf285a2-cb5c-457a-a1f0-5d6e71b24bd6") },
                    { new Guid("7556126c-6c75-475f-bba6-027e427d7b1e"), false, "Valledupar", new Guid("a09bf111-cb02-4e03-90ca-8c487e694dad") },
                    { new Guid("75b88e6c-42e6-40cc-9125-61ae5eb6781b"), false, "Memarí", new Guid("7c44f4bf-6f39-4fbc-b945-0e40c87626e0") },
                    { new Guid("770a1589-e024-4d96-84c5-9f67814410fc"), false, "Garzón", new Guid("30727c65-1169-4ac6-a091-55841eaf5943") },
                    { new Guid("78a3c8b1-1fc8-4d5c-93a6-eb0458c25736"), false, "Gualaquiza", new Guid("b0350728-6027-4453-8edb-2d7a3c43e88a") },
                    { new Guid("79f42bb0-95eb-40c8-8124-aff72aa678a0"), false, "Montería", new Guid("f51847b9-a71e-4e6c-96c5-e0bd05aad056") },
                    { new Guid("7d072ba8-214c-430b-b940-69212582c542"), false, "Cereté", new Guid("f51847b9-a71e-4e6c-96c5-e0bd05aad056") },
                    { new Guid("80db81f7-4507-4cdf-bd67-9cb13aec8f05"), false, "Manizales", new Guid("1df45a1c-93dc-48aa-9c42-340f7d590d78") },
                    { new Guid("81c24218-90c3-4264-9d57-3dddd6d3f787"), false, "San Juan de Pasto", new Guid("dde1feba-1398-46e5-a37f-60947610e77e") },
                    { new Guid("8241065a-34ba-4e53-a375-1a92e23f9eb7"), false, "Neiva", new Guid("30727c65-1169-4ac6-a091-55841eaf5943") },
                    { new Guid("82a9e72e-b542-4d62-a603-09a082bb3d21"), false, "Aguazul", new Guid("e7a97098-ef56-42d3-a1be-31d8e1deb8e4") },
                    { new Guid("84a5846b-f83c-4228-af0f-dbd1497d5a3d"), false, "Sogamoso", new Guid("bce31918-0958-4e6f-9325-4ead8e354d7a") },
                    { new Guid("85e6f591-e180-4f4c-8e0e-32bfa3a678dc"), false, "Santa Rosa de Cabal", new Guid("d7f1f28a-4751-4f6a-b421-85ec0169de2a") },
                    { new Guid("8aedac79-1e97-4c46-88bf-7cffb95f1f8f"), false, "Puerto Colombia", new Guid("394b17e2-1ac1-4581-8fe1-f6ad4c8c776d") },
                    { new Guid("92929be1-ec41-4695-b18e-b0256ae71ed2"), false, "Salcedo", new Guid("719db247-0ab7-46f2-b70a-60280b933e1e") },
                    { new Guid("92e83c59-5f54-4a30-b0b0-9d0a6808ec7b"), false, "Fortul", new Guid("f8f50d16-c1fe-4e07-8bc3-48c691bfe464") },
                    { new Guid("94fe4ea7-8f2a-4065-83db-92ad0850746e"), false, "Manta", new Guid("f992668d-28db-4f34-93e0-9a150f2e8ed3") },
                    { new Guid("95903544-24d2-4a45-af58-38c5f3787bf5"), false, "San Cristóbal", new Guid("66f03979-f420-4eea-9649-f988bc462a67") },
                    { new Guid("95b7d9a4-607b-44b5-9a4c-73d7d93105c9"), false, "Guaranda", new Guid("24a096a3-491c-401c-9a9a-b0300766d9c5") },
                    { new Guid("96072156-a282-4e88-9080-58850de814a9"), false, "Dosquebradas", new Guid("d7f1f28a-4751-4f6a-b421-85ec0169de2a") },
                    { new Guid("988fc3df-97ef-4a99-9b19-e9ec67e8c2a5"), false, "Yopal", new Guid("e7a97098-ef56-42d3-a1be-31d8e1deb8e4") },
                    { new Guid("9a5c04ae-d14c-4530-aefd-986dc9f90be4"), false, "Latacunga", new Guid("719db247-0ab7-46f2-b70a-60280b933e1e") },
                    { new Guid("9c3e5702-8b5c-4637-bd21-a62ac38f9b10"), false, "Aguachica", new Guid("a09bf111-cb02-4e03-90ca-8c487e694dad") },
                    { new Guid("9f375357-e260-4972-b361-dbf185ab2d85"), false, "Archidona", new Guid("034ff5b0-3477-4f1d-b24b-64cee73f6786") },
                    { new Guid("9fff27b4-9143-4c34-ba55-76cbd6a7a839"), false, "Tumaco", new Guid("dde1feba-1398-46e5-a37f-60947610e77e") },
                    { new Guid("a2591b26-8ff8-4e91-96d7-557c93ff1dc1"), false, "Atacames", new Guid("c0668d59-064a-4940-b466-a2eef4d38295") },
                    { new Guid("a6a2a183-53c2-431a-946c-d0c57b5ce1f5"), false, "Soacha", new Guid("91f68bc0-21a4-473b-abfc-900bb72663c0") },
                    { new Guid("a783ac0b-4e36-4c98-b431-9305c125d589"), false, "Villavicencio", new Guid("17613b0e-4e1f-432f-937d-d056d9ca1d5d") },
                    { new Guid("b1266d33-0b16-4746-b64a-f439849a083b"), false, "Arauca", new Guid("f8f50d16-c1fe-4e07-8bc3-48c691bfe464") },
                    { new Guid("b2a21dc1-495e-4dcb-a9e0-b0b630f9713e"), false, "Cartagena del Chairá", new Guid("7a87b6fb-38f8-4082-9b14-bde49c097574") },
                    { new Guid("b3885494-68c5-4a76-be11-32cd00e0917a"), false, "Armero Guayabal", new Guid("4b8217de-b4e1-43f8-9d90-0785abd7c91e") },
                    { new Guid("b693e968-51ca-4771-830d-162ee3186947"), false, "Puerto Baquerizo Moreno", new Guid("66f03979-f420-4eea-9649-f988bc462a67") },
                    { new Guid("b7a33086-2aa4-4a0d-a896-5bbae1675e97"), false, "Honda", new Guid("4b8217de-b4e1-43f8-9d90-0785abd7c91e") },
                    { new Guid("b9869749-be04-4564-8f38-237de6a51d4d"), false, "Pereira", new Guid("d7f1f28a-4751-4f6a-b421-85ec0169de2a") },
                    { new Guid("bae0a9c7-9c30-496f-ba0f-d722d19447eb"), false, "Tena", new Guid("034ff5b0-3477-4f1d-b24b-64cee73f6786") },
                    { new Guid("bae4e22c-74ee-4018-b49b-a79c5110b981"), false, "Buenaventura", new Guid("e2d06ab7-5178-42c3-88ae-d66092b70a74") },
                    { new Guid("bf2d2fea-344e-4f1c-8758-5e6e245587d2"), false, "Puerto Carreño", new Guid("bcd4fc70-a87a-4b10-8d2f-e887a34a1aa2") },
                    { new Guid("c0291cb8-646d-4989-94c8-e8b606a6bae9"), false, "Pamplona", new Guid("70fefe77-783a-496d-81e0-c22e3d4f170b") },
                    { new Guid("c0ca2524-2b55-43c2-8f1f-c95bcbedca6d"), false, "Cúcuta", new Guid("70fefe77-783a-496d-81e0-c22e3d4f170b") },
                    { new Guid("c14e11f4-045e-44df-b53f-52b4f9d5e63f"), false, "Otavalo", new Guid("795bb29d-c62d-42d8-84a5-69d217606c2a") },
                    { new Guid("c3946c1d-cfdb-4fa2-99b7-41a9a7335864"), false, "Santa Catalina", new Guid("90c9a283-038d-47f9-a6f2-57f2cc96722a") },
                    { new Guid("cd56234c-5e45-475f-befb-645db8253f91"), false, "Cali", new Guid("e2d06ab7-5178-42c3-88ae-d66092b70a74") },
                    { new Guid("cd69f501-87e4-43c8-8bde-57ca1793adbb"), false, "Maicao", new Guid("ea0b3ed3-1adf-4c26-a957-f2bf6e3649fd") },
                    { new Guid("d0beb06b-2374-4a6f-a9a4-1d0d6d043b1e"), false, "Providencia", new Guid("90c9a283-038d-47f9-a6f2-57f2cc96722a") },
                    { new Guid("d1b1128d-5026-4f95-a7c7-6606a510f9ad"), false, "Puerto Inírida", new Guid("7c44f4bf-6f39-4fbc-b945-0e40c87626e0") },
                    { new Guid("d1e885a9-599e-41c3-a305-d8c9f0122a0a"), false, "Saraguro", new Guid("9434f2e8-139a-40bd-a1a8-0ee9aa74a3e0") },
                    { new Guid("d2469350-05d0-497d-8c47-8e2f8506bdd4"), false, "Yavaraté", new Guid("6b082850-1ad9-421c-9a86-300ab7684ab2") },
                    { new Guid("d6f40320-ef59-4a93-abe0-a7fdb2e2f0de"), false, "Santander de Quilichao", new Guid("31fd44da-a067-452e-baa6-840b70341bd7") },
                    { new Guid("d8604a69-d831-478a-8d78-492d7aa9aaa4"), false, "Chinchiná", new Guid("1df45a1c-93dc-48aa-9c42-340f7d590d78") },
                    { new Guid("dd171f54-004c-48d1-97c5-346924576958"), false, "Quibdó", new Guid("321524fd-0b69-4fa4-9e27-ce0fabc9c756") },
                    { new Guid("e1901104-baf8-47ff-986f-7749fbf96573"), false, "Esmeraldas", new Guid("c0668d59-064a-4940-b466-a2eef4d38295") },
                    { new Guid("e283ed21-5cd5-4fc1-bab8-6104d7797d1c"), false, "Machala", new Guid("831cab56-37eb-4948-8fec-21eec4fbdf6b") },
                    { new Guid("e3a0b82f-88a0-4803-b827-1b4c1fd32fba"), false, "San Miguel de Bolívar", new Guid("24a096a3-491c-401c-9a9a-b0300766d9c5") },
                    { new Guid("e8b33a3e-1f79-4122-992b-667b5793bbe0"), false, "Santa Rosa", new Guid("831cab56-37eb-4948-8fec-21eec4fbdf6b") },
                    { new Guid("eb685644-ca6f-4206-910f-96bb200983d3"), false, "Popayán", new Guid("31fd44da-a067-452e-baa6-840b70341bd7") },
                    { new Guid("ec6c4a65-4f81-4078-8f8a-8c45700d0b8e"), false, "Ocaña", new Guid("70fefe77-783a-496d-81e0-c22e3d4f170b") },
                    { new Guid("ed8f40c4-549f-439e-9de6-d50a9e1af34f"), false, "La Paz", new Guid("a09bf111-cb02-4e03-90ca-8c487e694dad") },
                    { new Guid("eed53364-497e-4616-9994-4b7b71362ffd"), false, "Granada", new Guid("17613b0e-4e1f-432f-937d-d056d9ca1d5d") },
                    { new Guid("f0ff8382-74fe-45c3-ae46-21403e675130"), false, "Santa Marta", new Guid("3623b694-3df6-4ac6-8aae-fc275c1859d3") },
                    { new Guid("f4f072dd-cd7a-4342-bcfa-5f8151d044fa"), false, "Silvia", new Guid("31fd44da-a067-452e-baa6-840b70341bd7") },
                    { new Guid("f60f6346-f3d5-4085-ba8f-a1ae5e4c07c7"), false, "Soledad", new Guid("394b17e2-1ac1-4581-8fe1-f6ad4c8c776d") },
                    { new Guid("f750875f-8d49-4d96-95b1-e1692040bdaa"), false, "Orito", new Guid("41f90bde-6966-4a5c-a782-1832076e1451") },
                    { new Guid("f8266fe1-f3a7-496a-b0b0-d2eac6a660e8"), false, "La Primavera", new Guid("bcd4fc70-a87a-4b10-8d2f-e887a34a1aa2") },
                    { new Guid("fcf8950e-c2ec-463b-99f1-ef8f82f8e786"), false, "Morelia", new Guid("e9ee3e7e-43ba-4034-954c-1c50458d49ef") },
                    { new Guid("ff8552b3-1933-46c6-9f4e-3d5891186179"), false, "Ibagué", new Guid("4b8217de-b4e1-43f8-9d90-0785abd7c91e") }
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
