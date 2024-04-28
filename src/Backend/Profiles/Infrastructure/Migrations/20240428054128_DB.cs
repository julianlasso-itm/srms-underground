using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
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
                values: new object[] { new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Colombia" });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("028e2b81-14b9-46c3-9b67-96b12f428556"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Vichada" },
                    { new Guid("1ff053b2-ed78-4e8a-ac16-bf2b6f1ab61a"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Chocó" },
                    { new Guid("21a2ef42-6055-44fb-8fb2-68ef129f45e5"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Sucre" },
                    { new Guid("2af2e45a-70e1-48b0-9715-b658d19204f8"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Casanare" },
                    { new Guid("40c69900-488f-425a-9c29-e617635d5e9c"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Caldas" },
                    { new Guid("44bc2e59-28fa-4ea0-9090-4b1f3b921639"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Amazonas" },
                    { new Guid("527e4da7-9477-411c-8d7e-f4273dc1db94"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Risaralda" },
                    { new Guid("5fad909f-f938-49ae-891d-3124fb3d655c"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "San Andrés y Providencia" },
                    { new Guid("636db916-b3b4-44e3-8975-a3e0c60b7e54"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Bolívar" },
                    { new Guid("67b5225e-2bc4-4c71-b1d5-a7a368f97e57"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Quindío" },
                    { new Guid("6bd22b4b-51df-4ded-a7de-47571cab2415"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Meta" },
                    { new Guid("7da32994-1222-4d9f-a081-9e13c7f950b9"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Huila" },
                    { new Guid("82d97c6f-50c6-49ba-acad-21a3012bc3cf"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Antioquia" },
                    { new Guid("84992391-d834-473a-9668-e5916bee38e9"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Santander" },
                    { new Guid("892fdea7-9342-45f2-894d-99a8a0f31352"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Vaupés" },
                    { new Guid("8dbf9156-19d7-4eaa-910e-d91477333417"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Magdalena" },
                    { new Guid("93ee469c-c551-471a-b4ad-fa07c6766826"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Norte de Santander" },
                    { new Guid("b781dbfc-6ecc-4358-853a-355473a0f1bf"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Córdoba" },
                    { new Guid("b7d01f40-ee3f-4de4-92a7-ff28cc58c5a7"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Cundinamarca" },
                    { new Guid("b98a0962-96a7-4969-bac3-d7739cc92dd7"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "La Guajira" },
                    { new Guid("c68f56c0-7917-4d7b-8e4b-c708ccbb5707"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Arauca" },
                    { new Guid("c891ce57-1fa3-45ab-9c4b-23331666a60b"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Caquetá" },
                    { new Guid("ca5a464b-85bb-4119-b5f4-ebdb699553ef"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Tolima" },
                    { new Guid("ce48216c-7741-4aa6-a2e0-f406d041a5fd"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Valle del Cauca" },
                    { new Guid("d353f98b-071a-429d-827e-37eb583885c5"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Boyacá" },
                    { new Guid("d54a767c-546c-4c35-a01a-c37c2ee95a31"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Atlántico" },
                    { new Guid("df03f378-2b24-4baa-9f15-1e0ad05dc21f"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Guaviare" },
                    { new Guid("e2f65e88-5ad1-416b-92d7-9a911c68adc0"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Cesar" },
                    { new Guid("e784f7dd-0bcc-43f7-971a-94b8811e9078"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Cauca" },
                    { new Guid("ebdf71d3-4aa2-49e9-91ed-e9c0c2a87dfe"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Nariño" },
                    { new Guid("faf9e19f-1776-410d-bc26-bde0ce318569"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Putumayo" },
                    { new Guid("ffd9163f-3a1a-471b-93ea-dd227d6469d7"), new Guid("ff8d98f5-b902-40cf-89a1-7f996f07b15b"), false, "Guainía" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("010c326a-6510-4b43-9973-a715af768b11"), false, "Morelia", new Guid("c891ce57-1fa3-45ab-9c4b-23331666a60b") },
                    { new Guid("01f64691-9c7f-43aa-898e-21237a330a69"), false, "San José del Guaviare", new Guid("df03f378-2b24-4baa-9f15-1e0ad05dc21f") },
                    { new Guid("039cc4f0-50b9-4142-8edd-666e73eeebaa"), false, "Corozal", new Guid("21a2ef42-6055-44fb-8fb2-68ef129f45e5") },
                    { new Guid("0517ca69-7248-45f6-b57c-c8f51521a43a"), false, "Honda", new Guid("ca5a464b-85bb-4119-b5f4-ebdb699553ef") },
                    { new Guid("05b4b3b8-db52-4ec2-8d6a-d0a667021304"), false, "Providencia", new Guid("5fad909f-f938-49ae-891d-3124fb3d655c") },
                    { new Guid("0679a3f6-af6e-4401-a5c2-3bbdb58d5573"), false, "Tumaco", new Guid("ebdf71d3-4aa2-49e9-91ed-e9c0c2a87dfe") },
                    { new Guid("07f8e255-bbc0-43b7-b1d3-e501d0bef77b"), false, "Orito", new Guid("faf9e19f-1776-410d-bc26-bde0ce318569") },
                    { new Guid("0b07eb5e-f8ab-4371-b0e0-9a2436f09a0b"), false, "Yavaraté", new Guid("892fdea7-9342-45f2-894d-99a8a0f31352") },
                    { new Guid("0c51ceb7-9bad-42be-8157-581d578b836f"), false, "Quibdó", new Guid("1ff053b2-ed78-4e8a-ac16-bf2b6f1ab61a") },
                    { new Guid("1052ea79-2674-466a-8622-c66bd078734b"), false, "Valledupar", new Guid("e2f65e88-5ad1-416b-92d7-9a911c68adc0") },
                    { new Guid("13055572-668f-46a7-93c5-dcbe5e70e414"), false, "Duitama", new Guid("d353f98b-071a-429d-827e-37eb583885c5") },
                    { new Guid("1652a0b8-3e4f-437f-98ce-b36f77bb0399"), false, "Manizales", new Guid("40c69900-488f-425a-9c29-e617635d5e9c") },
                    { new Guid("1b52a5e5-a77d-4ab1-aa2a-241dbc3a5974"), false, "Ibagué", new Guid("ca5a464b-85bb-4119-b5f4-ebdb699553ef") },
                    { new Guid("1f444c53-e0a1-4a24-8f65-6812ff8fb185"), false, "Cartagena de Indias", new Guid("636db916-b3b4-44e3-8975-a3e0c60b7e54") },
                    { new Guid("2179180f-fc43-4668-bb2b-5da3aed02df0"), false, "Tauramena", new Guid("2af2e45a-70e1-48b0-9715-b658d19204f8") },
                    { new Guid("21c0b9c3-5f3d-4d03-a286-55341d7ae1eb"), false, "Pereira", new Guid("527e4da7-9477-411c-8d7e-f4273dc1db94") },
                    { new Guid("23f30d1f-e358-47c9-9d74-acded46d822c"), false, "Armero Guayabal", new Guid("ca5a464b-85bb-4119-b5f4-ebdb699553ef") },
                    { new Guid("2aef983f-c35e-4137-94b6-2f6b22167854"), false, "Santa Helena", new Guid("028e2b81-14b9-46c3-9b67-96b12f428556") },
                    { new Guid("30a8da17-d5c1-4adf-9fe0-4db41338de59"), false, "Puerto Colombia", new Guid("d54a767c-546c-4c35-a01a-c37c2ee95a31") },
                    { new Guid("31c779fa-03e7-4adf-977c-4afa141961df"), false, "Cartagena del Chairá", new Guid("636db916-b3b4-44e3-8975-a3e0c60b7e54") },
                    { new Guid("3412e12e-d768-45a5-b0e5-7b699eaa427a"), false, "Ciénaga", new Guid("8dbf9156-19d7-4eaa-910e-d91477333417") },
                    { new Guid("3582f53b-85f4-49fe-9668-facb98670895"), false, "Piedecuesta", new Guid("84992391-d834-473a-9668-e5916bee38e9") },
                    { new Guid("36f64937-ef15-4e2f-b0e6-66f0248126fe"), false, "Cartagena del Chairá", new Guid("c891ce57-1fa3-45ab-9c4b-23331666a60b") },
                    { new Guid("44ddfa90-f688-4cd6-823e-96c34ded99d1"), false, "Aguachica", new Guid("e2f65e88-5ad1-416b-92d7-9a911c68adc0") },
                    { new Guid("4706d49b-fdd4-481e-870c-b69f82203fd6"), false, "San Andrés", new Guid("5fad909f-f938-49ae-891d-3124fb3d655c") },
                    { new Guid("4981ec62-b5dd-4d75-a0d1-0f886020cecb"), false, "Santa Catalina", new Guid("5fad909f-f938-49ae-891d-3124fb3d655c") },
                    { new Guid("4a64f680-d221-47fc-a18a-50931da28d81"), false, "San Juan de Pasto", new Guid("ebdf71d3-4aa2-49e9-91ed-e9c0c2a87dfe") },
                    { new Guid("4b866d82-7286-450f-8715-4765ba3ab4b9"), false, "Calamar", new Guid("df03f378-2b24-4baa-9f15-1e0ad05dc21f") },
                    { new Guid("515d060d-f903-41eb-b09e-d49ccb5d903c"), false, "El Retén", new Guid("df03f378-2b24-4baa-9f15-1e0ad05dc21f") },
                    { new Guid("51d20592-161f-4032-a59c-d03f82f4c203"), false, "Istmina", new Guid("1ff053b2-ed78-4e8a-ac16-bf2b6f1ab61a") },
                    { new Guid("521bda10-fcb6-4116-9b81-86ff5a019dc0"), false, "Leticia", new Guid("44bc2e59-28fa-4ea0-9090-4b1f3b921639") },
                    { new Guid("543b0736-8d46-4c0d-af6a-d829c6baeebe"), false, "Sogamoso", new Guid("d353f98b-071a-429d-827e-37eb583885c5") },
                    { new Guid("54a9a27b-5832-4c9c-b752-4f264bcb67d2"), false, "Cúcuta", new Guid("93ee469c-c551-471a-b4ad-fa07c6766826") },
                    { new Guid("5945008d-61fc-493d-8a95-e4be73210573"), false, "Santa Rosalía", new Guid("892fdea7-9342-45f2-894d-99a8a0f31352") },
                    { new Guid("5b6596b6-881c-4c1f-bea7-3d1cd9d7a26e"), false, "Soacha", new Guid("b7d01f40-ee3f-4de4-92a7-ff28cc58c5a7") },
                    { new Guid("5cc302dc-6da7-4ce6-b6ab-bec49942b165"), false, "Puerto Asís", new Guid("faf9e19f-1776-410d-bc26-bde0ce318569") },
                    { new Guid("5ef9176f-53dc-4f65-85b2-5bf1b1c5a2f5"), false, "Barranquilla", new Guid("d54a767c-546c-4c35-a01a-c37c2ee95a31") },
                    { new Guid("62171865-1c03-46ed-8d6a-5501ea828d61"), false, "Pamplona", new Guid("93ee469c-c551-471a-b4ad-fa07c6766826") },
                    { new Guid("62962a5f-0fb0-4455-b15f-b26383576725"), false, "Novita", new Guid("1ff053b2-ed78-4e8a-ac16-bf2b6f1ab61a") },
                    { new Guid("638f4fa2-0d87-486c-b7fb-9161ed78fa39"), false, "Calarcá", new Guid("67b5225e-2bc4-4c71-b1d5-a7a368f97e57") },
                    { new Guid("6397a680-51bb-4593-86bc-9c7b8257c8b4"), false, "Riohacha", new Guid("b98a0962-96a7-4969-bac3-d7739cc92dd7") },
                    { new Guid("64c4142e-2385-41e6-bcb0-d3b6dfb263fc"), false, "Lorica", new Guid("b781dbfc-6ecc-4358-853a-355473a0f1bf") },
                    { new Guid("67c85875-4ffb-4982-9d2b-e2bbdfb39d1b"), false, "Puerto Carreño", new Guid("028e2b81-14b9-46c3-9b67-96b12f428556") },
                    { new Guid("697de638-21f1-4b34-b67b-a80ee3ae9338"), false, "Palmira", new Guid("ce48216c-7741-4aa6-a2e0-f406d041a5fd") },
                    { new Guid("6bc32ee7-d8b1-437a-8d9d-1ddd0c597806"), false, "La Primavera", new Guid("028e2b81-14b9-46c3-9b67-96b12f428556") },
                    { new Guid("6f353ecf-3672-436b-b73f-45d457cdb7a8"), false, "Bogotá", new Guid("b7d01f40-ee3f-4de4-92a7-ff28cc58c5a7") },
                    { new Guid("701e7a2a-8a43-451c-bf6a-350b7a5ba711"), false, "Bucaramanga", new Guid("84992391-d834-473a-9668-e5916bee38e9") },
                    { new Guid("7127d893-5fac-41eb-a5ad-630d9a666e44"), false, "Uribia", new Guid("b98a0962-96a7-4969-bac3-d7739cc92dd7") },
                    { new Guid("731d36b9-ebca-42a8-aefa-7c7a7f4ef5c4"), false, "Fortul", new Guid("c68f56c0-7917-4d7b-8e4b-c708ccbb5707") },
                    { new Guid("76e4348b-46c1-4992-a622-80abed2ae8ff"), false, "Cereté", new Guid("b781dbfc-6ecc-4358-853a-355473a0f1bf") },
                    { new Guid("7b1e2437-d183-4e67-9608-2a993c16bf5a"), false, "Ipiales", new Guid("ebdf71d3-4aa2-49e9-91ed-e9c0c2a87dfe") },
                    { new Guid("7c1dbd7a-33b2-44c0-939b-db4ea102cce7"), false, "Inírida", new Guid("ffd9163f-3a1a-471b-93ea-dd227d6469d7") },
                    { new Guid("7e03cdca-08c6-473c-9147-72a4405ad08b"), false, "Acacias", new Guid("6bd22b4b-51df-4ded-a7de-47571cab2415") },
                    { new Guid("7fccb9a6-defd-4bd0-988f-79f20e4dd022"), false, "Garzón", new Guid("7da32994-1222-4d9f-a081-9e13c7f950b9") },
                    { new Guid("85e7cb12-8fb4-4a07-a917-5f47eadeb575"), false, "Ocaña", new Guid("93ee469c-c551-471a-b4ad-fa07c6766826") },
                    { new Guid("8798940b-ce97-43da-b1b7-ad2fe5830580"), false, "La Paz", new Guid("e2f65e88-5ad1-416b-92d7-9a911c68adc0") },
                    { new Guid("88b87447-c4e6-4bbd-a596-e41d7d9e50eb"), false, "Mitú", new Guid("892fdea7-9342-45f2-894d-99a8a0f31352") },
                    { new Guid("8b568208-f480-4774-b86a-6b15bf0b0feb"), false, "Zipaquirá", new Guid("b7d01f40-ee3f-4de4-92a7-ff28cc58c5a7") },
                    { new Guid("8ca3dffc-3051-41c5-98e4-e46e5152a5ce"), false, "Florencia", new Guid("c891ce57-1fa3-45ab-9c4b-23331666a60b") },
                    { new Guid("92355673-c1e9-45cf-8b7a-1203cfad6627"), false, "Memarí", new Guid("ffd9163f-3a1a-471b-93ea-dd227d6469d7") },
                    { new Guid("928fd99b-c6fa-421e-97ab-f598940db31f"), false, "Chinchiná", new Guid("40c69900-488f-425a-9c29-e617635d5e9c") },
                    { new Guid("92a0ed70-a3bf-4737-8cd4-e225a63957a2"), false, "Granada", new Guid("6bd22b4b-51df-4ded-a7de-47571cab2415") },
                    { new Guid("94e30f73-d55c-4afd-aa2e-6aba13cdf633"), false, "Saravena", new Guid("c68f56c0-7917-4d7b-8e4b-c708ccbb5707") },
                    { new Guid("97b14ffb-091c-4449-b6c7-2e34b8704bc0"), false, "Santander de Quilichao", new Guid("e784f7dd-0bcc-43f7-971a-94b8811e9078") },
                    { new Guid("99d923ec-c6f1-43ec-9529-98a9c93ae9a6"), false, "Montería", new Guid("21a2ef42-6055-44fb-8fb2-68ef129f45e5") },
                    { new Guid("9db55dca-a764-4951-9246-6f6db5d8a77e"), false, "Montería", new Guid("b781dbfc-6ecc-4358-853a-355473a0f1bf") },
                    { new Guid("9e524ecb-4a95-48b0-89d0-c5d969bc2f52"), false, "Armenia", new Guid("67b5225e-2bc4-4c71-b1d5-a7a368f97e57") },
                    { new Guid("adfd672c-e994-418b-b746-2f9b4c72df8d"), false, "Dosquebradas", new Guid("527e4da7-9477-411c-8d7e-f4273dc1db94") },
                    { new Guid("af268641-8669-4f00-8911-5500e141597e"), false, "Magangué", new Guid("636db916-b3b4-44e3-8975-a3e0c60b7e54") },
                    { new Guid("af2bc28d-003c-4390-9ca8-d7ca71c7d240"), false, "Turbo", new Guid("82d97c6f-50c6-49ba-acad-21a3012bc3cf") },
                    { new Guid("b0ec5e87-ec00-43ae-bd60-594274dc6e12"), false, "Villavicencio", new Guid("6bd22b4b-51df-4ded-a7de-47571cab2415") },
                    { new Guid("b45e53ed-5154-4221-9b9d-04cbb0da49d6"), false, "Medellín", new Guid("82d97c6f-50c6-49ba-acad-21a3012bc3cf") },
                    { new Guid("b5ef159b-4dcd-487f-ba27-8a2ade5c7de9"), false, "Tunja", new Guid("d353f98b-071a-429d-827e-37eb583885c5") },
                    { new Guid("c19c595f-2f4f-461e-91c7-35867874dade"), false, "Santa Rosa de Cabal", new Guid("527e4da7-9477-411c-8d7e-f4273dc1db94") },
                    { new Guid("c2d37ebd-b051-4a0e-87bf-73fcdacdc3f7"), false, "Aguazul", new Guid("2af2e45a-70e1-48b0-9715-b658d19204f8") },
                    { new Guid("c598ebe6-c4e4-4c04-85ad-dda500086b67"), false, "Aracataca", new Guid("8dbf9156-19d7-4eaa-910e-d91477333417") },
                    { new Guid("cae4ecf3-6d6b-4b10-8fc2-ecc6c55becde"), false, "Yopal", new Guid("2af2e45a-70e1-48b0-9715-b658d19204f8") },
                    { new Guid("ce9a554e-9d4b-4991-8e61-594ec9b77cab"), false, "Soledad", new Guid("d54a767c-546c-4c35-a01a-c37c2ee95a31") },
                    { new Guid("d0a6f5c2-359a-4977-b5b8-74ec62e03ae2"), false, "Sincelejo", new Guid("21a2ef42-6055-44fb-8fb2-68ef129f45e5") },
                    { new Guid("d14a3c6d-ee73-4d30-b815-0081eba65fa1"), false, "Neiva", new Guid("7da32994-1222-4d9f-a081-9e13c7f950b9") },
                    { new Guid("d904bc07-3fe5-4b1a-a834-17b4a6616874"), false, "Buenaventura", new Guid("ce48216c-7741-4aa6-a2e0-f406d041a5fd") },
                    { new Guid("daad8b68-0df2-473a-9827-44582a1a706b"), false, "La Tebaida", new Guid("67b5225e-2bc4-4c71-b1d5-a7a368f97e57") },
                    { new Guid("dad9f951-3876-4cb8-a671-872a317041fe"), false, "Santa Marta", new Guid("8dbf9156-19d7-4eaa-910e-d91477333417") },
                    { new Guid("dc4f5cc3-163c-4c9c-8e30-04f87c72e0a1"), false, "Popayán", new Guid("e784f7dd-0bcc-43f7-971a-94b8811e9078") },
                    { new Guid("e07fe0cc-e0a7-4e73-ba5e-e875bd113926"), false, "Puerto Inírida", new Guid("ffd9163f-3a1a-471b-93ea-dd227d6469d7") },
                    { new Guid("e44ec1e5-5418-4e1d-8054-2118423b10cf"), false, "Apartadó", new Guid("82d97c6f-50c6-49ba-acad-21a3012bc3cf") },
                    { new Guid("e4b2ef63-d1f2-4822-aa6c-8752d9c08bf1"), false, "Cali", new Guid("ce48216c-7741-4aa6-a2e0-f406d041a5fd") },
                    { new Guid("ed0f4a67-7de9-4214-8cb5-2789c3c6e317"), false, "Pereira", new Guid("40c69900-488f-425a-9c29-e617635d5e9c") },
                    { new Guid("f184e978-9d7f-443c-a4e7-074de0951545"), false, "Arauca", new Guid("c68f56c0-7917-4d7b-8e4b-c708ccbb5707") },
                    { new Guid("f4bfdadf-6c10-47de-b4b7-1f5497ff9114"), false, "Silvia", new Guid("e784f7dd-0bcc-43f7-971a-94b8811e9078") },
                    { new Guid("f9dbf3fb-bf27-45fd-94ec-36a7c0705473"), false, "Pitalito", new Guid("7da32994-1222-4d9f-a081-9e13c7f950b9") },
                    { new Guid("fc0f0a34-38c4-4674-b655-49c1fe2ed141"), false, "Barrancabermeja", new Guid("84992391-d834-473a-9668-e5916bee38e9") },
                    { new Guid("fce04543-fa35-44e6-8fca-10f7c0534d48"), false, "Maicao", new Guid("b98a0962-96a7-4969-bac3-d7739cc92dd7") },
                    { new Guid("ff857a96-39c6-48ac-9206-3f69e4d25ee2"), false, "Mocoa", new Guid("faf9e19f-1776-410d-bc26-bde0ce318569") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_city_prv_province_id",
                table: "city",
                column: "prv_province_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_prf_email_deleted_at",
                table: "professional",
                columns: new[] { "prf_email", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_province_ctr_country_id",
                table: "province",
                column: "ctr_country_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_rol_name_deleted_at",
                table: "role",
                columns: new[] { "rol_name", "deleted_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_skill_skl_name_deleted_at",
                table: "skill",
                columns: new[] { "skl_name", "deleted_at" },
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
