using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_country",
                columns: table => new
                {
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ctr_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_country", x => x.ctr_country_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    rol_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    rol_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    rol_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rol_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rol_deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.rol_role_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_province",
                columns: table => new
                {
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ctr_country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prv_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_province", x => x.prv_province_id);
                    table.ForeignKey(
                        name: "FK_tbl_province_tbl_country_ctr_country_id",
                        column: x => x.ctr_country_id,
                        principalTable: "tbl_country",
                        principalColumn: "ctr_country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_city",
                columns: table => new
                {
                    cty_city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prv_province_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cty_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cty_disabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_city", x => x.cty_city_id);
                    table.ForeignKey(
                        name: "FK_tbl_city_tbl_province_prv_province_id",
                        column: x => x.prv_province_id,
                        principalTable: "tbl_province",
                        principalColumn: "prv_province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_country",
                columns: new[] { "ctr_country_id", "ctr_disabled", "ctr_name" },
                values: new object[] { new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Colombia" });

            migrationBuilder.InsertData(
                table: "tbl_province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("000d3c20-51ab-4f2c-8e5e-7fed465349ed"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Guainía" },
                    { new Guid("0710872a-2b6e-4f75-a115-18db523a42f3"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Caldas" },
                    { new Guid("15132b31-b888-47a5-abfb-22765d976e54"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Quindío" },
                    { new Guid("161c7888-230e-49c0-9a9e-2852507069db"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Santander" },
                    { new Guid("24d43b52-5c8b-4321-a062-d7a97a1c280a"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "San Andrés y Providencia" },
                    { new Guid("26f987d9-af02-4215-8e04-7c044973cb3c"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "La Guajira" },
                    { new Guid("272261ca-42de-4d75-a80f-b1fe0763df76"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Risaralda" },
                    { new Guid("2eb11cff-f444-4441-ac74-4138ae3ab71d"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Atlántico" },
                    { new Guid("32c10d0d-4b2f-4708-b386-b306fe281429"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Huila" },
                    { new Guid("52ae67a3-6d32-477c-91b9-7069f544038f"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Nariño" },
                    { new Guid("7a532de2-b198-4f98-b899-321e1c666be0"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Chocó" },
                    { new Guid("829f4bbf-b228-4311-a6f0-ff16246532a0"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Antioquia" },
                    { new Guid("843c2372-735b-482f-b3fa-1db3d9305d01"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Cesar" },
                    { new Guid("8669ba3a-8948-45ee-80a2-4da1986a3498"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Caquetá" },
                    { new Guid("8a152795-49c0-408a-a359-e9ce79d3af66"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Casanare" },
                    { new Guid("8d1e8fc1-8219-45d8-9e96-9d87f74effd0"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Córdoba" },
                    { new Guid("94a81beb-d8fa-4f14-a7fd-a5050871da23"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Boyacá" },
                    { new Guid("962258d4-f027-42b7-8e13-18e6997ab0db"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Cundinamarca" },
                    { new Guid("9a6f0465-07f8-4b2b-b5a0-88c68bde8d68"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Meta" },
                    { new Guid("9fda204e-6ad8-4282-9fdd-d58853910641"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Magdalena" },
                    { new Guid("a083ee70-5155-4bec-8918-9eb21a51d99a"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Bolívar" },
                    { new Guid("a5654338-8151-497b-847e-ca674269a8ae"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Putumayo" },
                    { new Guid("ae663cc5-9db8-47b3-b326-3c874feea4d1"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Cauca" },
                    { new Guid("b631a60a-11eb-4b2f-a25d-44374558cd3c"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Sucre" },
                    { new Guid("b7e67c76-e4de-4c59-88b4-144c37dadc11"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Guaviare" },
                    { new Guid("bf291904-29a3-4dc4-9e17-2e16ddb791cd"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Arauca" },
                    { new Guid("bfcef0ed-07ae-4112-817b-607d6cca6183"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Amazonas" },
                    { new Guid("c457fc53-07c2-45e4-be76-88e8ed62f192"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Norte de Santander" },
                    { new Guid("daaff97f-5979-43f0-ae0b-8e5a7d44fa17"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Vichada" },
                    { new Guid("de2567c7-c332-45e5-81a7-449d2f753a3b"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Valle del Cauca" },
                    { new Guid("e6f24a6f-f852-4c5d-8d5e-4dc03e5a4214"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Vaupés" },
                    { new Guid("f23cad77-59f9-443f-a5a3-28812c9ba761"), new Guid("f634d003-1fd9-4981-958c-abed8d887f82"), false, "Tolima" }
                });

            migrationBuilder.InsertData(
                table: "tbl_city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("022a899d-023c-4489-8fae-2bb8210c597b"), false, "Santa Helena", new Guid("daaff97f-5979-43f0-ae0b-8e5a7d44fa17") },
                    { new Guid("0954f045-13c4-4d9e-9dc0-b8b01f882516"), false, "San Juan de Pasto", new Guid("52ae67a3-6d32-477c-91b9-7069f544038f") },
                    { new Guid("0a1aad59-f251-41f3-8700-75577de21dd9"), false, "Montería", new Guid("8d1e8fc1-8219-45d8-9e96-9d87f74effd0") },
                    { new Guid("0a1bd930-6d14-4a3d-9448-f5bc59c4c69e"), false, "Barranquilla", new Guid("2eb11cff-f444-4441-ac74-4138ae3ab71d") },
                    { new Guid("0bad1089-f9fe-4494-93fd-aa2e4fb62f28"), false, "Armenia", new Guid("15132b31-b888-47a5-abfb-22765d976e54") },
                    { new Guid("0dfa4803-4804-44fc-8e9b-0ef02a51552d"), false, "Zipaquirá", new Guid("962258d4-f027-42b7-8e13-18e6997ab0db") },
                    { new Guid("0e4963c0-5e8e-497f-97e9-796cb807b62c"), false, "Barrancabermeja", new Guid("161c7888-230e-49c0-9a9e-2852507069db") },
                    { new Guid("0ebc3ea4-d656-4732-aee3-dfe90b8f4720"), false, "Santa Catalina", new Guid("24d43b52-5c8b-4321-a062-d7a97a1c280a") },
                    { new Guid("10d914dd-82f9-401d-b773-449de88f15b9"), false, "Novita", new Guid("7a532de2-b198-4f98-b899-321e1c666be0") },
                    { new Guid("12c2c0db-f3dc-4f46-a2e7-036b82190762"), false, "Cartagena del Chairá", new Guid("8669ba3a-8948-45ee-80a2-4da1986a3498") },
                    { new Guid("1321dd1c-d8af-4fee-a70b-fb93d8222108"), false, "Piedecuesta", new Guid("161c7888-230e-49c0-9a9e-2852507069db") },
                    { new Guid("14f8e95a-ee0e-49bd-bece-40bb677349c8"), false, "Inírida", new Guid("000d3c20-51ab-4f2c-8e5e-7fed465349ed") },
                    { new Guid("1659c5ee-ca51-4cc6-ac42-10640a988491"), false, "Neiva", new Guid("32c10d0d-4b2f-4708-b386-b306fe281429") },
                    { new Guid("16a01522-7a9e-4a0c-a783-d092750ede32"), false, "Yopal", new Guid("8a152795-49c0-408a-a359-e9ce79d3af66") },
                    { new Guid("1799f51f-18cf-44fb-95ec-9dc40f292913"), false, "Santa Rosa de Cabal", new Guid("272261ca-42de-4d75-a80f-b1fe0763df76") },
                    { new Guid("18919f38-0257-4320-a217-0e29433c227e"), false, "Pitalito", new Guid("32c10d0d-4b2f-4708-b386-b306fe281429") },
                    { new Guid("1c9323a4-8a51-45fd-ae30-8063e2abbd48"), false, "Sincelejo", new Guid("b631a60a-11eb-4b2f-a25d-44374558cd3c") },
                    { new Guid("2031264f-4f89-4d62-ac45-2f764099ec3d"), false, "Memarí", new Guid("000d3c20-51ab-4f2c-8e5e-7fed465349ed") },
                    { new Guid("21370b7b-ec72-4a61-b340-af12908f61bf"), false, "Istmina", new Guid("7a532de2-b198-4f98-b899-321e1c666be0") },
                    { new Guid("230f841a-e2cf-4064-9894-0d095898bb27"), false, "Maicao", new Guid("26f987d9-af02-4215-8e04-7c044973cb3c") },
                    { new Guid("2433dde4-8a3c-4490-8996-68685bfe2290"), false, "Santa Rosalía", new Guid("e6f24a6f-f852-4c5d-8d5e-4dc03e5a4214") },
                    { new Guid("256b34a1-7be3-4a7b-a697-c6e0452c64e5"), false, "Leticia", new Guid("bfcef0ed-07ae-4112-817b-607d6cca6183") },
                    { new Guid("2e1768f8-3070-4be9-b2f1-e58cf1daa11a"), false, "Honda", new Guid("f23cad77-59f9-443f-a5a3-28812c9ba761") },
                    { new Guid("2e25cd86-1b77-464c-8ed8-0c1317a57cbd"), false, "Palmira", new Guid("de2567c7-c332-45e5-81a7-449d2f753a3b") },
                    { new Guid("32c9e257-f30c-47f3-8f1b-fb5199d48b3a"), false, "Florencia", new Guid("8669ba3a-8948-45ee-80a2-4da1986a3498") },
                    { new Guid("363347e4-568d-4ab0-b809-473af5f4eb6d"), false, "Manizales", new Guid("0710872a-2b6e-4f75-a115-18db523a42f3") },
                    { new Guid("380aa3e0-d086-47bd-a206-ad7ca70e81dd"), false, "Santa Marta", new Guid("9fda204e-6ad8-4282-9fdd-d58853910641") },
                    { new Guid("38963ebf-daa5-4793-89b4-b7f30710dd55"), false, "Apartadó", new Guid("829f4bbf-b228-4311-a6f0-ff16246532a0") },
                    { new Guid("3c1e5660-cb61-4d73-ae1a-8ef6045b5696"), false, "Arauca", new Guid("bf291904-29a3-4dc4-9e17-2e16ddb791cd") },
                    { new Guid("3d5f3475-b6e4-42fe-a62d-c81788d00dfc"), false, "Pamplona", new Guid("c457fc53-07c2-45e4-be76-88e8ed62f192") },
                    { new Guid("3f26f03b-ddef-4645-8e8f-14f94420b91b"), false, "Corozal", new Guid("b631a60a-11eb-4b2f-a25d-44374558cd3c") },
                    { new Guid("4596ac63-8a5c-43f9-82ae-39f41a0e8c40"), false, "Garzón", new Guid("32c10d0d-4b2f-4708-b386-b306fe281429") },
                    { new Guid("46aa479a-c974-4c1e-994d-f9736fd96c22"), false, "Ocaña", new Guid("c457fc53-07c2-45e4-be76-88e8ed62f192") },
                    { new Guid("4f09ef3d-e530-4079-a1dc-d6730ca45f10"), false, "Granada", new Guid("9a6f0465-07f8-4b2b-b5a0-88c68bde8d68") },
                    { new Guid("4f99f030-9649-47a2-8ad8-5a4b5a7d7260"), false, "Valledupar", new Guid("843c2372-735b-482f-b3fa-1db3d9305d01") },
                    { new Guid("5044bc5d-3940-4699-955a-1668f0d9b3c4"), false, "Providencia", new Guid("24d43b52-5c8b-4321-a062-d7a97a1c280a") },
                    { new Guid("57a3da02-28cb-4f17-98ed-d8a6192c2d78"), false, "Cartagena del Chairá", new Guid("a083ee70-5155-4bec-8918-9eb21a51d99a") },
                    { new Guid("5db3629a-fe7c-455f-8e55-de545665e6ba"), false, "Pereira", new Guid("272261ca-42de-4d75-a80f-b1fe0763df76") },
                    { new Guid("63053a1a-fe00-4497-b1b9-994abceb976b"), false, "Montería", new Guid("b631a60a-11eb-4b2f-a25d-44374558cd3c") },
                    { new Guid("653b739d-47c7-4d26-ab7a-c4bf120d3f00"), false, "Villavicencio", new Guid("9a6f0465-07f8-4b2b-b5a0-88c68bde8d68") },
                    { new Guid("66940d4d-47ae-4dff-bf46-9a882edcdc46"), false, "Orito", new Guid("a5654338-8151-497b-847e-ca674269a8ae") },
                    { new Guid("724fb9bf-1add-4a1e-8f80-d789cad8f3e9"), false, "Magangué", new Guid("a083ee70-5155-4bec-8918-9eb21a51d99a") },
                    { new Guid("756d57eb-8284-40eb-8532-0378012a664f"), false, "Tunja", new Guid("94a81beb-d8fa-4f14-a7fd-a5050871da23") },
                    { new Guid("76787dc4-3e2b-4f4f-9573-df780c4b0bcb"), false, "Puerto Inírida", new Guid("000d3c20-51ab-4f2c-8e5e-7fed465349ed") },
                    { new Guid("791f61c8-8eb0-4810-a164-1920bdbce4bc"), false, "Chinchiná", new Guid("0710872a-2b6e-4f75-a115-18db523a42f3") },
                    { new Guid("7bc89b21-d5fd-4bbe-868b-78b4e14602d9"), false, "La Primavera", new Guid("daaff97f-5979-43f0-ae0b-8e5a7d44fa17") },
                    { new Guid("80050ff5-3e28-471e-8077-0b3ced19b5f8"), false, "San Andrés", new Guid("24d43b52-5c8b-4321-a062-d7a97a1c280a") },
                    { new Guid("904390c6-c73b-430c-8217-303eea9b794d"), false, "Mitú", new Guid("e6f24a6f-f852-4c5d-8d5e-4dc03e5a4214") },
                    { new Guid("91ebd240-6cb0-4b1c-9ae6-1ee4e0c2e7fa"), false, "Duitama", new Guid("94a81beb-d8fa-4f14-a7fd-a5050871da23") },
                    { new Guid("9340d9a2-1c17-4e36-8f52-1edb9b1d1caf"), false, "Bogotá", new Guid("962258d4-f027-42b7-8e13-18e6997ab0db") },
                    { new Guid("9bb5235c-1888-4fd4-9386-ed5467c7833c"), false, "Saravena", new Guid("bf291904-29a3-4dc4-9e17-2e16ddb791cd") },
                    { new Guid("a32e321c-196e-4f4c-bd44-166e1296adf6"), false, "Cúcuta", new Guid("c457fc53-07c2-45e4-be76-88e8ed62f192") },
                    { new Guid("a388515e-2821-4316-9e75-666665b92858"), false, "Pereira", new Guid("0710872a-2b6e-4f75-a115-18db523a42f3") },
                    { new Guid("a6982a2b-9b20-4b53-9ef4-4561e0c37a16"), false, "Cereté", new Guid("8d1e8fc1-8219-45d8-9e96-9d87f74effd0") },
                    { new Guid("a88130f5-2de5-4524-b608-006ade4fd5c6"), false, "Aguachica", new Guid("843c2372-735b-482f-b3fa-1db3d9305d01") },
                    { new Guid("a9e3e91e-a27b-4bae-a191-46f8dabb733e"), false, "Sogamoso", new Guid("94a81beb-d8fa-4f14-a7fd-a5050871da23") },
                    { new Guid("ade00c92-e3bb-43c1-9ca6-fc840b600542"), false, "Buenaventura", new Guid("de2567c7-c332-45e5-81a7-449d2f753a3b") },
                    { new Guid("ae88b544-2640-47aa-9f6f-2ccb9c887412"), false, "Soacha", new Guid("962258d4-f027-42b7-8e13-18e6997ab0db") },
                    { new Guid("afbc444d-1b5c-4289-8471-a4eb01b9c7ed"), false, "Puerto Carreño", new Guid("daaff97f-5979-43f0-ae0b-8e5a7d44fa17") },
                    { new Guid("b7cb49a0-cc41-41f1-be4a-f979ba43b07f"), false, "Soledad", new Guid("2eb11cff-f444-4441-ac74-4138ae3ab71d") },
                    { new Guid("b914186d-89a2-462b-9448-c6daab2113e5"), false, "Cali", new Guid("de2567c7-c332-45e5-81a7-449d2f753a3b") },
                    { new Guid("ba55d887-f4ea-4447-a7a5-f96abb1546c5"), false, "Calarcá", new Guid("15132b31-b888-47a5-abfb-22765d976e54") },
                    { new Guid("bc88fd6a-958f-49ed-9e74-27f849449abd"), false, "San José del Guaviare", new Guid("b7e67c76-e4de-4c59-88b4-144c37dadc11") },
                    { new Guid("be86b1c7-99a8-48a6-bb41-d83d3be45809"), false, "Fortul", new Guid("bf291904-29a3-4dc4-9e17-2e16ddb791cd") },
                    { new Guid("c1ac629f-ad47-4ca7-9551-3b272e7fc302"), false, "Yavaraté", new Guid("e6f24a6f-f852-4c5d-8d5e-4dc03e5a4214") },
                    { new Guid("c35d923f-cf84-4c52-b6c1-f035f1709867"), false, "Puerto Asís", new Guid("a5654338-8151-497b-847e-ca674269a8ae") },
                    { new Guid("c5944a51-0948-4164-a303-5455f698ee59"), false, "Armero Guayabal", new Guid("f23cad77-59f9-443f-a5a3-28812c9ba761") },
                    { new Guid("c8b39358-8e87-460e-926b-6f2745c1d5f0"), false, "Ipiales", new Guid("52ae67a3-6d32-477c-91b9-7069f544038f") },
                    { new Guid("c8d8b061-fc13-4c78-9c27-968018e58d45"), false, "Dosquebradas", new Guid("272261ca-42de-4d75-a80f-b1fe0763df76") },
                    { new Guid("c98cc646-fb83-40cb-8aa7-2810308dffcf"), false, "Santander de Quilichao", new Guid("ae663cc5-9db8-47b3-b326-3c874feea4d1") },
                    { new Guid("cb6cd0e4-5714-4ad9-9df4-e16e37ee7ac5"), false, "El Retén", new Guid("b7e67c76-e4de-4c59-88b4-144c37dadc11") },
                    { new Guid("cd06cc7f-c7a8-4d43-92d2-8be1b435bede"), false, "Turbo", new Guid("829f4bbf-b228-4311-a6f0-ff16246532a0") },
                    { new Guid("d22614d6-cb2f-4e02-8400-9782c759297b"), false, "Uribia", new Guid("26f987d9-af02-4215-8e04-7c044973cb3c") },
                    { new Guid("d400a851-c8a6-4fca-9ef9-bd77336f148f"), false, "Puerto Colombia", new Guid("2eb11cff-f444-4441-ac74-4138ae3ab71d") },
                    { new Guid("d5317b09-8c06-4ec7-b01a-17181753cc03"), false, "Acacias", new Guid("9a6f0465-07f8-4b2b-b5a0-88c68bde8d68") },
                    { new Guid("da1f4d8c-a12a-4a8d-b09d-e773363ba6e3"), false, "Aguazul", new Guid("8a152795-49c0-408a-a359-e9ce79d3af66") },
                    { new Guid("dcde8c23-3eea-40fa-a3bc-94a4a7f5608b"), false, "Ciénaga", new Guid("9fda204e-6ad8-4282-9fdd-d58853910641") },
                    { new Guid("dd7cda2e-8bac-400d-b363-7f9dd50b6567"), false, "Bucaramanga", new Guid("161c7888-230e-49c0-9a9e-2852507069db") },
                    { new Guid("e12bdca9-b19a-4214-a47c-2ecbd54210de"), false, "La Paz", new Guid("843c2372-735b-482f-b3fa-1db3d9305d01") },
                    { new Guid("e1c2757a-8328-4b40-88a3-8e0ce94520c5"), false, "Cartagena de Indias", new Guid("a083ee70-5155-4bec-8918-9eb21a51d99a") },
                    { new Guid("e243acd8-c291-4b6b-91a0-0c52b2974009"), false, "Tumaco", new Guid("52ae67a3-6d32-477c-91b9-7069f544038f") },
                    { new Guid("e95c1f1c-c873-4dd1-8325-85d5771e1b39"), false, "Popayán", new Guid("ae663cc5-9db8-47b3-b326-3c874feea4d1") },
                    { new Guid("e9c02421-160a-448e-b8b0-57eb5d9d59ea"), false, "Mocoa", new Guid("a5654338-8151-497b-847e-ca674269a8ae") },
                    { new Guid("ebb6d771-eb21-4a05-8b37-03c5746ef38b"), false, "Silvia", new Guid("ae663cc5-9db8-47b3-b326-3c874feea4d1") },
                    { new Guid("ec47b3ec-649b-43a2-bc50-7c9fca486247"), false, "Quibdó", new Guid("7a532de2-b198-4f98-b899-321e1c666be0") },
                    { new Guid("edd6c842-1597-4abe-ba12-3940f919821e"), false, "Lorica", new Guid("8d1e8fc1-8219-45d8-9e96-9d87f74effd0") },
                    { new Guid("f0c6829c-a3a9-4223-89c7-9820f16d48ee"), false, "Morelia", new Guid("8669ba3a-8948-45ee-80a2-4da1986a3498") },
                    { new Guid("f1a7c563-ae62-4977-a464-0286a4d75dc5"), false, "Riohacha", new Guid("26f987d9-af02-4215-8e04-7c044973cb3c") },
                    { new Guid("f82a24f4-fc95-45b7-9223-25953c36d16b"), false, "Ibagué", new Guid("f23cad77-59f9-443f-a5a3-28812c9ba761") },
                    { new Guid("f8a6d7e6-27e8-4f24-b33d-9efb2fb4c4fe"), false, "Aracataca", new Guid("9fda204e-6ad8-4282-9fdd-d58853910641") },
                    { new Guid("fc1611f1-e33b-4b77-8cf9-caac151298f6"), false, "Medellín", new Guid("829f4bbf-b228-4311-a6f0-ff16246532a0") },
                    { new Guid("fddf0b25-bad6-4a4d-97a1-1ded9a1598a1"), false, "Tauramena", new Guid("8a152795-49c0-408a-a359-e9ce79d3af66") },
                    { new Guid("fe94d913-065e-4ba5-9834-7807a07c5096"), false, "Calamar", new Guid("b7e67c76-e4de-4c59-88b4-144c37dadc11") },
                    { new Guid("ff554b14-76eb-4ed6-9b03-2cd1897288f1"), false, "La Tebaida", new Guid("15132b31-b888-47a5-abfb-22765d976e54") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_city_prv_province_id",
                table: "tbl_city",
                column: "prv_province_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_province_ctr_country_id",
                table: "tbl_province",
                column: "ctr_country_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_rol_name_rol_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_name", "rol_deleted_at" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_city");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_province");

            migrationBuilder.DropTable(
                name: "tbl_country");
        }
    }
}
