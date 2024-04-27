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
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                values: new object[] { new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Colombia" });

            migrationBuilder.InsertData(
                table: "tbl_province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("102b8d7f-3420-4544-92b8-04e556597e74"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Caquetá" },
                    { new Guid("178bf4ee-362d-4e22-87c8-dcd17804eee8"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Amazonas" },
                    { new Guid("199747a7-a723-495c-8e3b-3a6a9391708c"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Valle del Cauca" },
                    { new Guid("1cb26c58-231c-4065-a9ed-2522a62fb269"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Boyacá" },
                    { new Guid("2a81263d-1518-432a-bf62-f16a3ddf842c"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "San Andrés y Providencia" },
                    { new Guid("2bba1068-b596-4f44-90eb-51d4089999d9"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Arauca" },
                    { new Guid("2efa0a2e-7238-479a-9b0b-16515d9b8759"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Córdoba" },
                    { new Guid("381c54fd-5997-4262-97bb-7960dbeb04f2"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Norte de Santander" },
                    { new Guid("4b429e0c-3ab8-417d-995a-701979370707"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Quindío" },
                    { new Guid("4d8292b3-8575-429b-9375-32209daba047"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Sucre" },
                    { new Guid("4dafd4ac-866c-40fd-858e-8de7dad17023"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Vaupés" },
                    { new Guid("4fc92851-e0a5-46da-a840-6306642fcec5"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Atlántico" },
                    { new Guid("55cf75f2-3573-4c4f-bc42-36fc09afd5ae"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Vichada" },
                    { new Guid("57748cbc-2b09-466f-a413-b5e2e2743808"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Magdalena" },
                    { new Guid("69b0772d-040c-415a-92d3-cd63183d5d84"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "La Guajira" },
                    { new Guid("6b65ee0a-d557-4cb5-a628-db58ea89a1d5"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Santander" },
                    { new Guid("6f62af5f-73ee-4654-9aee-175755564675"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Tolima" },
                    { new Guid("70811b29-0686-42c7-b3e4-f07b9f4d69fe"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Guainía" },
                    { new Guid("805b2caa-e09b-4fc7-b501-7258224b18b8"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Chocó" },
                    { new Guid("810e4889-fa8a-4faa-a9b7-e4aeb29f6444"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Putumayo" },
                    { new Guid("9684ba71-6f85-4c15-9797-4506ba87176a"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Bolívar" },
                    { new Guid("9a2c5f35-ffaa-4ed2-bc49-5615c4f35ca3"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Risaralda" },
                    { new Guid("9e8fbd90-1d95-45e3-b36f-66e951163313"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Antioquia" },
                    { new Guid("a299460e-942f-4841-b76f-f025b9a60dfb"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Cundinamarca" },
                    { new Guid("a3ffb181-0c4f-4047-9bcd-97385172e033"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Meta" },
                    { new Guid("b8fbf40c-b837-4e85-b89d-acb9798c5389"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Cesar" },
                    { new Guid("c6fb4930-ec7c-4221-af3f-61fbd64adf3a"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Huila" },
                    { new Guid("c96611b0-00f1-45df-8ee6-53facdf01bdd"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Caldas" },
                    { new Guid("cddc7d93-cc76-42e2-b892-0b51c98a0549"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Cauca" },
                    { new Guid("cfc426dc-8bbc-4c39-a4da-58287d427104"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Nariño" },
                    { new Guid("f3d7f013-7cf4-4c3f-967c-47e43f6209ee"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Casanare" },
                    { new Guid("f824eefc-cd3f-48b9-b328-e8340c3b48c7"), new Guid("b8703f37-1569-4020-bf03-5694121d7c46"), false, "Guaviare" }
                });

            migrationBuilder.InsertData(
                table: "tbl_city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("047f8e22-cc0b-4b77-8bb7-56b17aabfd6b"), false, "Villavicencio", new Guid("a3ffb181-0c4f-4047-9bcd-97385172e033") },
                    { new Guid("064ef34e-7bb8-45b2-8583-934db9887778"), false, "Lorica", new Guid("2efa0a2e-7238-479a-9b0b-16515d9b8759") },
                    { new Guid("065cbf73-ca96-4097-b923-0f84568c1d76"), false, "Calamar", new Guid("f824eefc-cd3f-48b9-b328-e8340c3b48c7") },
                    { new Guid("067f2dc7-0b6d-4667-9392-80f6207e5519"), false, "Armenia", new Guid("4b429e0c-3ab8-417d-995a-701979370707") },
                    { new Guid("0a8648fd-0114-449b-a13c-7bde27e1c0ca"), false, "Valledupar", new Guid("b8fbf40c-b837-4e85-b89d-acb9798c5389") },
                    { new Guid("0beec69e-4149-4a2f-a046-132ba62a1265"), false, "Soacha", new Guid("a299460e-942f-4841-b76f-f025b9a60dfb") },
                    { new Guid("0eb59539-97a7-4354-a9cd-65b9db2a4571"), false, "Maicao", new Guid("69b0772d-040c-415a-92d3-cd63183d5d84") },
                    { new Guid("11243aae-9b95-4331-9453-254d458ac8a6"), false, "Florencia", new Guid("102b8d7f-3420-4544-92b8-04e556597e74") },
                    { new Guid("11bba5cf-1c46-43ce-8ce9-6aa84394b9dc"), false, "Apartadó", new Guid("9e8fbd90-1d95-45e3-b36f-66e951163313") },
                    { new Guid("11d12b4d-71a0-4bc6-8391-8dbb59038acf"), false, "Santander de Quilichao", new Guid("cddc7d93-cc76-42e2-b892-0b51c98a0549") },
                    { new Guid("13b5b12d-011c-431f-95f3-51f8181db6c9"), false, "Palmira", new Guid("199747a7-a723-495c-8e3b-3a6a9391708c") },
                    { new Guid("1539fbb0-9a7f-43e8-aa4f-8ce0c4a4ce53"), false, "Piedecuesta", new Guid("6b65ee0a-d557-4cb5-a628-db58ea89a1d5") },
                    { new Guid("1566dccc-15dc-4ce4-a1c4-966fdfffd96f"), false, "Cartagena del Chairá", new Guid("9684ba71-6f85-4c15-9797-4506ba87176a") },
                    { new Guid("1638069c-dc5c-4fcf-b7d9-778998329a67"), false, "Ipiales", new Guid("cfc426dc-8bbc-4c39-a4da-58287d427104") },
                    { new Guid("16a729a1-ab85-440e-8fa7-9745b9fa06a1"), false, "El Retén", new Guid("f824eefc-cd3f-48b9-b328-e8340c3b48c7") },
                    { new Guid("193a31c1-a9f4-42bd-84c1-52a24242d7ce"), false, "Santa Catalina", new Guid("2a81263d-1518-432a-bf62-f16a3ddf842c") },
                    { new Guid("1a3649e7-3118-4477-b8cf-6283b56133a4"), false, "Chinchiná", new Guid("c96611b0-00f1-45df-8ee6-53facdf01bdd") },
                    { new Guid("1ae13f08-9e88-4fb3-9643-2dde03977539"), false, "Leticia", new Guid("178bf4ee-362d-4e22-87c8-dcd17804eee8") },
                    { new Guid("233c3a5b-01ef-4bf6-b410-e31b0e8d6863"), false, "Duitama", new Guid("1cb26c58-231c-4065-a9ed-2522a62fb269") },
                    { new Guid("243c6b20-a60c-4a56-8231-d3e7567b8552"), false, "Mocoa", new Guid("810e4889-fa8a-4faa-a9b7-e4aeb29f6444") },
                    { new Guid("2742d6c7-59b2-4de6-9a71-20a563730150"), false, "Granada", new Guid("a3ffb181-0c4f-4047-9bcd-97385172e033") },
                    { new Guid("27bf9779-2eed-470b-b490-8181bdd8ce60"), false, "Sogamoso", new Guid("1cb26c58-231c-4065-a9ed-2522a62fb269") },
                    { new Guid("290939cb-02de-490a-830c-6769ef8b08fc"), false, "Neiva", new Guid("c6fb4930-ec7c-4221-af3f-61fbd64adf3a") },
                    { new Guid("29b30a09-f50f-4980-8615-9bb8f20eb9fa"), false, "Santa Rosa de Cabal", new Guid("9a2c5f35-ffaa-4ed2-bc49-5615c4f35ca3") },
                    { new Guid("2dbc2ce5-4187-44e2-a0d1-a0f07a29e9a2"), false, "Bogotá", new Guid("a299460e-942f-4841-b76f-f025b9a60dfb") },
                    { new Guid("2dd4303f-9baa-40ab-bf3e-aa3b46918cf5"), false, "Honda", new Guid("6f62af5f-73ee-4654-9aee-175755564675") },
                    { new Guid("2edc99dc-79d4-4e13-84df-568e1fc4617c"), false, "Pitalito", new Guid("c6fb4930-ec7c-4221-af3f-61fbd64adf3a") },
                    { new Guid("3024507f-e3a7-4ff3-844a-345e77cff80d"), false, "Aguachica", new Guid("b8fbf40c-b837-4e85-b89d-acb9798c5389") },
                    { new Guid("379e9045-95ba-4071-87f1-531e3b2d2756"), false, "Puerto Inírida", new Guid("70811b29-0686-42c7-b3e4-f07b9f4d69fe") },
                    { new Guid("3870eb4a-dc1c-42bc-97b2-7e4b841ff32c"), false, "Magangué", new Guid("9684ba71-6f85-4c15-9797-4506ba87176a") },
                    { new Guid("3bdc1372-f0f8-42d9-a11e-16e33973942e"), false, "Cartagena de Indias", new Guid("9684ba71-6f85-4c15-9797-4506ba87176a") },
                    { new Guid("3c68e166-82ca-4e58-8513-fc669231be38"), false, "Fortul", new Guid("2bba1068-b596-4f44-90eb-51d4089999d9") },
                    { new Guid("3ea728bb-10c6-4db2-aff9-b8e3d58bef77"), false, "Yavaraté", new Guid("4dafd4ac-866c-40fd-858e-8de7dad17023") },
                    { new Guid("3fb8f76e-67d2-426f-8a8f-0efa8ff325b2"), false, "Manizales", new Guid("c96611b0-00f1-45df-8ee6-53facdf01bdd") },
                    { new Guid("4116750f-0634-444c-a311-5663c6b7c9c6"), false, "Turbo", new Guid("9e8fbd90-1d95-45e3-b36f-66e951163313") },
                    { new Guid("41858c0d-6d18-4377-bb4e-0c7736b44ab8"), false, "Buenaventura", new Guid("199747a7-a723-495c-8e3b-3a6a9391708c") },
                    { new Guid("48e4905c-d12e-499a-920b-180e3e2687e5"), false, "Pereira", new Guid("c96611b0-00f1-45df-8ee6-53facdf01bdd") },
                    { new Guid("4ef89d6e-99a2-4009-8a82-a64e0c4d7619"), false, "Saravena", new Guid("2bba1068-b596-4f44-90eb-51d4089999d9") },
                    { new Guid("5961da22-5260-4232-a63b-19261f18e88b"), false, "Popayán", new Guid("cddc7d93-cc76-42e2-b892-0b51c98a0549") },
                    { new Guid("59f45743-a805-4b79-95f0-9f077422dec6"), false, "Armero Guayabal", new Guid("6f62af5f-73ee-4654-9aee-175755564675") },
                    { new Guid("5d96198f-3b0c-413a-970d-20b6a7edae1e"), false, "Puerto Colombia", new Guid("4fc92851-e0a5-46da-a840-6306642fcec5") },
                    { new Guid("5e6c4e2b-743d-4e44-933b-78aa722cd5bb"), false, "Barranquilla", new Guid("4fc92851-e0a5-46da-a840-6306642fcec5") },
                    { new Guid("5e80f7c6-5000-448f-aa91-bd9ea76f64f1"), false, "Silvia", new Guid("cddc7d93-cc76-42e2-b892-0b51c98a0549") },
                    { new Guid("65dc399c-ab0c-4a0c-b7d9-1f8cc4bf6230"), false, "Santa Rosalía", new Guid("4dafd4ac-866c-40fd-858e-8de7dad17023") },
                    { new Guid("662231b3-2d09-4098-b1c4-d6894ddbdd5d"), false, "Novita", new Guid("805b2caa-e09b-4fc7-b501-7258224b18b8") },
                    { new Guid("68cb4c5e-1f49-470b-9735-53de07813214"), false, "Santa Marta", new Guid("57748cbc-2b09-466f-a413-b5e2e2743808") },
                    { new Guid("6c833bd3-d580-48a4-b726-075ac9d5bf34"), false, "Uribia", new Guid("69b0772d-040c-415a-92d3-cd63183d5d84") },
                    { new Guid("6d206cc6-7318-45b9-84de-f09e5ae8a95e"), false, "Quibdó", new Guid("805b2caa-e09b-4fc7-b501-7258224b18b8") },
                    { new Guid("6e1074f6-61d5-496b-a1ac-4d6103929106"), false, "San José del Guaviare", new Guid("f824eefc-cd3f-48b9-b328-e8340c3b48c7") },
                    { new Guid("6e3e444e-e340-4ed6-870b-54441e9ad188"), false, "Mitú", new Guid("4dafd4ac-866c-40fd-858e-8de7dad17023") },
                    { new Guid("75322ebd-3a08-42bc-bb17-8af934001cc8"), false, "Tunja", new Guid("1cb26c58-231c-4065-a9ed-2522a62fb269") },
                    { new Guid("76a07520-85a0-481f-ad22-54774b425995"), false, "Zipaquirá", new Guid("a299460e-942f-4841-b76f-f025b9a60dfb") },
                    { new Guid("76b729d2-09fd-4113-8581-4d0a685256f4"), false, "La Paz", new Guid("b8fbf40c-b837-4e85-b89d-acb9798c5389") },
                    { new Guid("7a38eda1-448c-4f96-9ed3-2cd8dbdf6e2b"), false, "Cali", new Guid("199747a7-a723-495c-8e3b-3a6a9391708c") },
                    { new Guid("7bde547c-2fbd-462c-b6fa-e8edcf325fc2"), false, "Montería", new Guid("4d8292b3-8575-429b-9375-32209daba047") },
                    { new Guid("7d72f8e1-29b5-4dc9-92ee-8631a4a0ecf3"), false, "Arauca", new Guid("2bba1068-b596-4f44-90eb-51d4089999d9") },
                    { new Guid("7f7a8aa4-190e-47d7-a46e-3c30a5709449"), false, "Bucaramanga", new Guid("6b65ee0a-d557-4cb5-a628-db58ea89a1d5") },
                    { new Guid("879321a7-58e0-4a8a-9c4c-ecd6219e7a94"), false, "Dosquebradas", new Guid("9a2c5f35-ffaa-4ed2-bc49-5615c4f35ca3") },
                    { new Guid("8abaa4b7-fa14-4b78-aa4c-3ff5734aadcd"), false, "Istmina", new Guid("805b2caa-e09b-4fc7-b501-7258224b18b8") },
                    { new Guid("8d9136cc-04da-4be2-9b23-efa98f5b1fb4"), false, "San Andrés", new Guid("2a81263d-1518-432a-bf62-f16a3ddf842c") },
                    { new Guid("8fd48b95-2634-44b6-a11d-fce0fa246536"), false, "Tumaco", new Guid("cfc426dc-8bbc-4c39-a4da-58287d427104") },
                    { new Guid("967e088b-0378-4ef1-b703-4600d70846b9"), false, "Cúcuta", new Guid("381c54fd-5997-4262-97bb-7960dbeb04f2") },
                    { new Guid("971ae748-5359-4f84-bd03-58148264476d"), false, "Providencia", new Guid("2a81263d-1518-432a-bf62-f16a3ddf842c") },
                    { new Guid("9a566413-5cc6-4364-b8a2-eb7d3f9e8ee1"), false, "Calarcá", new Guid("4b429e0c-3ab8-417d-995a-701979370707") },
                    { new Guid("9aaccfe2-8a28-4d26-aa9e-7828b8e7ca38"), false, "Soledad", new Guid("4fc92851-e0a5-46da-a840-6306642fcec5") },
                    { new Guid("9ac22e6d-7ea5-4964-8aa4-e953286400b3"), false, "Puerto Carreño", new Guid("55cf75f2-3573-4c4f-bc42-36fc09afd5ae") },
                    { new Guid("9dc5d8b9-bb7a-4554-a8bc-9ae0c474a82c"), false, "Montería", new Guid("2efa0a2e-7238-479a-9b0b-16515d9b8759") },
                    { new Guid("a5a09a1b-7723-4838-a9a1-531ad19de104"), false, "Puerto Asís", new Guid("810e4889-fa8a-4faa-a9b7-e4aeb29f6444") },
                    { new Guid("ace30fe4-6204-4d14-905b-30ddbaec1200"), false, "Ibagué", new Guid("6f62af5f-73ee-4654-9aee-175755564675") },
                    { new Guid("aef6a5a8-851a-4a2b-b868-0b0656ca9157"), false, "Inírida", new Guid("70811b29-0686-42c7-b3e4-f07b9f4d69fe") },
                    { new Guid("b095a33e-e260-4417-a734-c7a624794cf2"), false, "Memarí", new Guid("70811b29-0686-42c7-b3e4-f07b9f4d69fe") },
                    { new Guid("b43fde00-4114-4ed6-afeb-8a0a88a78023"), false, "Pereira", new Guid("9a2c5f35-ffaa-4ed2-bc49-5615c4f35ca3") },
                    { new Guid("b5787356-d9e8-4321-b556-1d543d90788e"), false, "Medellín", new Guid("9e8fbd90-1d95-45e3-b36f-66e951163313") },
                    { new Guid("b682d948-7572-4291-afa0-b193baee2af8"), false, "Aguazul", new Guid("f3d7f013-7cf4-4c3f-967c-47e43f6209ee") },
                    { new Guid("b6db9bd1-5bee-48f0-8684-8b39dc9ae448"), false, "Cartagena del Chairá", new Guid("102b8d7f-3420-4544-92b8-04e556597e74") },
                    { new Guid("b75f2872-7131-4c3a-a3a8-a4c9b021eacf"), false, "Santa Helena", new Guid("55cf75f2-3573-4c4f-bc42-36fc09afd5ae") },
                    { new Guid("b91b8952-5303-478e-a2e2-0ba5e4d14806"), false, "Orito", new Guid("810e4889-fa8a-4faa-a9b7-e4aeb29f6444") },
                    { new Guid("b9fd9d75-b9e7-4c42-accf-bc76410a7add"), false, "Yopal", new Guid("f3d7f013-7cf4-4c3f-967c-47e43f6209ee") },
                    { new Guid("bb31b6e0-06f8-4963-ae84-0a47fe4a2e3c"), false, "La Tebaida", new Guid("4b429e0c-3ab8-417d-995a-701979370707") },
                    { new Guid("bc5ce33a-b9ad-4732-ba48-9b506586feb4"), false, "La Primavera", new Guid("55cf75f2-3573-4c4f-bc42-36fc09afd5ae") },
                    { new Guid("be845aad-10a2-4b31-b0ae-bc81778b22f8"), false, "Ciénaga", new Guid("57748cbc-2b09-466f-a413-b5e2e2743808") },
                    { new Guid("c0fc3fb4-20cb-4a8a-b61a-952d219a6257"), false, "Corozal", new Guid("4d8292b3-8575-429b-9375-32209daba047") },
                    { new Guid("c3b02a37-ed6d-491b-8fe6-42508b719f0b"), false, "Acacias", new Guid("a3ffb181-0c4f-4047-9bcd-97385172e033") },
                    { new Guid("d31c6fb8-67ba-4108-99e6-34b11a712274"), false, "Aracataca", new Guid("57748cbc-2b09-466f-a413-b5e2e2743808") },
                    { new Guid("ddcfbbaf-cdc3-453d-815b-38a7916f4c56"), false, "Sincelejo", new Guid("4d8292b3-8575-429b-9375-32209daba047") },
                    { new Guid("de522c8e-cbc2-47f6-acd7-c3605d31cb8f"), false, "Ocaña", new Guid("381c54fd-5997-4262-97bb-7960dbeb04f2") },
                    { new Guid("e53ed504-c19c-47f8-8017-f05d58ff3eff"), false, "Tauramena", new Guid("f3d7f013-7cf4-4c3f-967c-47e43f6209ee") },
                    { new Guid("e8056238-31d4-4a1d-a071-d75b0d9358cc"), false, "Barrancabermeja", new Guid("6b65ee0a-d557-4cb5-a628-db58ea89a1d5") },
                    { new Guid("ee9a4b53-7d59-474c-898d-fdfdb4a6f9ea"), false, "Riohacha", new Guid("69b0772d-040c-415a-92d3-cd63183d5d84") },
                    { new Guid("eeebc232-f06b-4525-820b-f55acaca0a18"), false, "San Juan de Pasto", new Guid("cfc426dc-8bbc-4c39-a4da-58287d427104") },
                    { new Guid("f831155d-a861-4d62-a568-8fe46c0814d8"), false, "Morelia", new Guid("102b8d7f-3420-4544-92b8-04e556597e74") },
                    { new Guid("f86454d7-f27d-4fe8-abaa-a71378865f48"), false, "Pamplona", new Guid("381c54fd-5997-4262-97bb-7960dbeb04f2") },
                    { new Guid("f9e10ee8-4cf5-4539-aaad-776c7d99c60b"), false, "Garzón", new Guid("c6fb4930-ec7c-4221-af3f-61fbd64adf3a") },
                    { new Guid("fec6ecf9-1e34-4138-9150-69a9a1228794"), false, "Cereté", new Guid("2efa0a2e-7238-479a-9b0b-16515d9b8759") }
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
                name: "IX_tbl_role_rol_name_deleted_at",
                table: "tbl_role",
                columns: new[] { "rol_name", "deleted_at" },
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
