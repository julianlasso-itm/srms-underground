using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_per_skill_role_rol_role_id",
                table: "role_per_skill");

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0039987e-1142-458c-9b64-db851d6c9e9a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("011ad1ec-f70a-49ae-b5cd-53633f9b59f5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0177fa53-a95f-4b90-a242-dd6f83d9fdaf"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("01b47147-31fc-45d5-8f08-66bde755dc85"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("030aa3ef-9c54-4391-a00a-dec85ab53aec"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0641e33c-e959-47dd-b559-39d112ebf7bb"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("08c14c13-e949-492e-b5af-0cbf5f3d51f3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("09137ee7-bbcc-4222-abde-c6114913ba7f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("09d423b0-35c0-4b49-9eaa-eefb84a455c6"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0a510b13-043c-45ca-9981-9201801b2788"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0b646678-43d5-426a-b3c9-df2d23393ead"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0c0010fb-6923-4842-a19a-5a57e25fb637"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0c145c68-56c2-4fda-a895-3457e262d7d3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0fa7445e-4d51-4614-ac39-dfbbd312b667"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("10e62ca4-8626-4554-8d2d-210378cb2acf"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("12516965-e0d6-45c2-9e8d-afb2bbb957bc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("14aa8def-7b9c-44f6-9c7b-f36b0fbc2804"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1ba6a3a1-49f3-4a47-bcd5-6f9636d69d7f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1eba19a5-398a-40db-9244-2a7338ad7e95"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1f3d20c6-b269-4198-aa28-28cf4c56b4ba"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1fbde9e7-a00a-4aa6-972e-dcfc674f84ab"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("205c2133-b8e9-481b-9c33-563f550a1bbb"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("231683ed-6382-4e93-a924-a81bb28df409"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("23b66d25-30b3-4dd8-98d0-68fdf99a8286"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2843d075-04f9-470b-a9bc-a1099b5b341f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2d0af8ef-87b3-4151-872a-954e3a3df8c6"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2d8791cc-746b-4cb0-97b6-782016fc7204"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2de2477e-c870-4d07-9b5c-fb3d1b07d6ce"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2fdb185e-1924-4afa-99d5-43f8f51f5635"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("315a8cd6-7a7a-414e-8f7f-cbab691398d9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("32012616-6f1d-4b84-a6b6-4a25683060a7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("32902217-54fc-4085-ac72-d459593b1800"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("34dcc126-ce69-4059-ae06-6b590d31176e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("362938af-08d7-4cd2-b266-a8f0a07efcdf"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3a02a5e0-3773-442d-a909-e64df600d02b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3c9e4bb4-5e36-4475-a0ff-4ffe7667b4b9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3e2f85de-d721-4399-874d-0f9daa3b8906"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("41a03de7-b4a9-4054-8a92-7791c5a05a21"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("434dbc65-3ddc-4034-be24-3b053096bf72"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4374fc74-a1f9-4832-9a6a-ee45b636832e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("439bb79b-ed6d-4ab5-ac7d-86bde282c6cc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("461e7094-8a81-4afd-a59a-4934ec9c1418"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("46de6866-edf0-4b1a-8842-6a412192f05c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("478ddf86-8cc5-4f5e-b71e-eef001abe912"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4963c1e8-8000-4657-a880-84612a2f899b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("49b5ef9f-5f6e-4037-88cd-9210643013d9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4b6c06db-d007-4842-98a6-9ff99407aed0"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4f352686-347d-42c4-9ad1-351a6338ff1b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("56a56d7f-8da8-4828-a9bd-9df7d33a23aa"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5fa203a1-2074-4f2f-9120-c4b176cf9ebd"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5fc93e3f-08c8-4e30-8826-88d223b5a36e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("60208469-2a6a-4b8e-9fd6-a50191dd0fd4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("611ac6b8-bbd4-43fd-8177-4873088b38f3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("64de71d0-b8a2-4397-8213-0f579f135f41"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6504046c-28e9-4a35-91a7-d08457883e60"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("696cf319-1d70-4bcd-af51-24bc16e43687"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("698af6fa-dfb7-4c76-bd77-5b07f4f23427"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6d1afeae-0d90-4611-8012-620be780f93b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6dc3cb47-37c5-47ef-98cd-e0b5a6c7cc17"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("705d2d8f-ecbb-472b-b7c3-bfaf4b380063"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7141fd77-795d-41db-804a-a65243ad6c31"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("71eaa10b-25b0-4a42-9ffc-51c75dcd0d12"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("72d18ee6-b1de-40e0-b8d3-39af9123a0d6"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7406630b-6640-4548-95fb-e81ddc65c270"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7a0685c1-1fdf-4dbb-b88b-05d98cd99b98"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7ce73f99-38fb-40c3-b42e-060e37d02ecb"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7e4b11f7-9d0b-4098-929d-e1a0254ea2ed"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7ebdb16b-4fc7-4959-9543-f9e288882fb3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7f8282d8-a0cc-42ee-9035-e27f445a6b8c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("82258030-4743-446e-a3b5-1e6ab3ff852a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("83b60ab5-ad29-460a-ba7a-cfef2c3c4d8e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("88204926-6b6f-418f-8380-209c90725950"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8c7a90cb-35e3-4592-9fa1-6a5348b9479e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8c884796-2e57-409c-bdc5-0a8ba0436951"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("900d1d08-57d6-4a44-8743-69c96e6f989b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("930a17bd-fb6e-4f73-8c81-f8a416c7d29e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("93e4a1a7-b838-4882-8550-c9c9e5312458"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9697a8bd-7a85-4325-9027-5927b9721fff"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9b0ce14c-6383-424c-90dd-c2b9b2da1a28"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9c874439-fb93-44ca-8e1a-f67321453d46"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9f055959-45f7-444b-abc4-9cae7d65e1d7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a1762d03-86ff-4e4d-ab50-2376c7014e78"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a4c18f64-6e82-4e1f-994c-f0fd1c5cad4e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a6de8905-1c91-476f-b708-b20313f9fb7b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a75709ec-9894-48c2-a0c3-d7ee40878152"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("aa99096e-215f-40d6-b42b-62c2250a867d"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("aaa03997-fe3a-4082-9037-aeed16ada78b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("abe69e51-d554-46fd-b628-1edfccfddb7b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b141ae34-2cd5-4065-becf-506001dcc357"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b8b21f0c-27a7-46a6-97b7-8250f9f024c8"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c0d1d9e6-f56f-4bd7-a04f-e326f9b2d84a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c2783500-1a9f-4e0a-a325-cc5ea5f9f604"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c5ca4a1c-d0c9-442e-a79b-09340e056196"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c7fa06e8-4725-46b3-aa1b-82f61d09a243"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c908c726-575a-4dea-82d7-dcdbe83c7d95"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cc3b6410-c34c-4db7-afa0-20481b4870e0"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ccc19999-f0e9-4ca3-a5f5-a0ad932173b7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cd4712d9-a200-49d2-bc22-91714e09b031"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ce5f94ba-b53c-4593-8667-868ceeef11b9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d223d617-78db-4eb2-bf77-dd509a0e7bdd"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d24444d8-73b7-4129-b47e-7a6265f7928e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d6cf8569-8ea6-4fd0-b5ad-fa82c08d9bad"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d83b1ba2-053c-4097-a7b6-dd375ed705ec"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d9df1dec-32b2-43f5-94fb-fa09ecee33e8"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("dcccbb09-defa-4c8f-8e3b-686afae9bdf9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("debc4b8a-b7e3-479a-9bc3-d8835a4c2214"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e13923f1-c115-4844-b01a-13febbe9f5db"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e413a14c-81af-457d-aeb8-1d6aef330aa3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e516d3e6-bf90-493d-8608-0b0c429c50e4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e70a2464-cefb-42c3-bf63-57b2b3db797b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e8113fb7-8434-4655-8ac3-23e253b37a55"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e842821b-59b2-4c23-9a47-02c87499057f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e922ee9c-ea07-48ab-b639-79133e9b5077"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e9a441b4-7fa1-42a7-a10c-faa25d155122"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ed1ebe13-e102-4337-8c6d-6fd47b2be005"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("edd62f5b-30ea-4378-806c-5b2850f989e9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f234d947-627a-4502-88e8-d3fd3dd3e41d"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f4f000bf-792b-46a2-99ad-8616b3152c1e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f6859a7b-7f97-4ea8-b3ad-db15d142e84a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f6e86aee-a3b9-4e5a-b79e-6d5494bbb2c5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f7908f01-552e-430f-946b-6c251fcd812d"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f87b7694-353e-4c58-9d64-0930831a8467"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f9af0678-9025-448e-bbe3-b4a2b02ca23a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fb858622-94e3-421d-9cc3-f1f5812619fb"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fcab6ea0-e32e-4919-bce5-644fd818897f"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("0dcdeaeb-82fb-4c88-9bcd-e806e0a32be2"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("12b1978e-eeef-4cd3-9c0c-5d170083f18a"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("162f823b-8b16-4f17-bf49-5b4dfa92a2d4"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("3d07f7a4-a1c8-4db2-a7c7-6cbfe485707b"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("3f7ac7a4-9be3-4982-b243-c5577e1aefbe"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("4185704b-df78-42cc-94e4-9ac177676b17"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("5f456be7-d447-4b32-8aec-c96cd471ee72"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("86021e3f-73b5-4213-955e-425719381c77"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("96cfda38-b366-4ea6-bff2-071326ff2354"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("9b115a3e-2ded-4517-930f-d0940ad32997"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("b0ca4978-89ce-4689-92c8-0ac24514b185"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("bde6dd9b-ced6-46f9-9bbb-a2341ccc02e3"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("bed23c82-95aa-40b4-8e86-f65f27393e81"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("c586e884-907e-4f68-afdc-0ba98898a865"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("ef4a591e-7132-4355-b275-612079652d68"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("f833146c-d003-4b76-9199-816bbca5e487"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("04e24f34-7565-49f4-9b05-b6b6d571503c"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("1244c27f-c31f-435b-a2a8-cd677bbff825"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("165b460a-867b-49a7-9811-185f47b208c6"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("26ccb193-bbc4-4336-8db4-a289169ae174"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("28e062e3-074a-434d-b3f2-1a7dae50f389"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("3474ed44-6107-49e5-b844-263d64d10332"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("49bbf117-9eb6-4546-b67a-6e432e50938e"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("4b101b85-7bd6-4d0e-8cbe-a63cf93ae2ef"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("623e045d-9219-483c-bbe6-893f16736367"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("6a758a66-92a0-472b-a790-029599a3d513"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("a68e572c-0b22-46d4-b370-3dc4e2238797"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("b3ad34d2-22da-4d3d-b2e7-6649bef1785c"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("ee47cc50-6d1d-405b-8fe3-037c7527109d"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("fca6f933-13ac-4e54-8e52-a597808bc938"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("fcb66825-c040-40b3-80ff-277871fb58c8"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("066e21db-c42f-4479-b118-4913d378126b"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("1bdde3a9-a6dc-4ba2-ad3c-2bc0bee964c6"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("36397541-97e4-46dc-88bd-4097679e7e1c"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("3fd72cd7-452a-4610-96e2-7063b62b97df"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("648bd820-b92b-4a34-a609-82893bfc9556"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("70da6774-e1b0-4360-b803-1045c657b1b2"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("7913efd0-2ff9-4bea-a9d5-26d6f8d2681a"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("8603b324-6e8b-48b6-91c9-30e88d533b41"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("919fe33d-3f2f-48c1-baf3-8c4e847bc7bf"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("9eb91402-4a94-4cde-929b-a9ea63d73f6e"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("b7480af0-a692-4e8f-8740-7ee63bd86856"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("bf5bfb78-4b02-42f8-8b2a-e35df41045bb"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("c0a81df5-2c98-45af-9703-4fad44cb8d24"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("dba2b12f-e9d9-40ba-b26f-8e3225a5fda3"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("e61d37a5-bbb6-469a-8c65-598bb71cf887"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("ee676090-4306-454b-8c90-5e65005b04e0"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("00faba6c-bd52-4a64-8076-3b04e2137a26"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("08f7940c-2de2-47ae-94d6-ca2ac07e6c63"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("1d4ff3df-a5af-4a0f-b315-eea0464e1c91"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("3d4024c0-4a1b-4617-a85e-4ea94a9f55db"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("433da17c-b226-4b33-9f3f-6d5bf63fe069"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("4f064d97-c9bc-42c4-affa-4ffd5aacd649"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("5a5af5d4-6ba2-4d2b-963f-3f0215769f34"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("6d4dcc2c-6998-4fda-8a5e-750e2934adc8"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("6fc27480-0aad-4ac2-8405-12521f36d4e0"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("73890fe1-e809-411f-85ae-764a2268ac1f"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("7ce1f509-37c5-4f29-a4b8-9fde926ac38a"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("84aa39af-de2e-4ef6-b3dc-a19e52872837"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("86c59807-ca97-4540-8a43-7179e95efe42"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("8993e851-7b82-46ad-a565-aced30ccad3a"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("925f2754-c850-4c86-8e38-1f7b5387c9d1"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("9f1dae97-6695-44dd-b30a-1ce16990624d"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("a996917f-f353-493b-944c-f55cece87bf5"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("af8989ba-51f7-442c-bc17-8238264ae3ab"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("c3a95e51-e57d-4c4c-961a-1be22d7e2c9e"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("e1f98bb2-6514-4db8-8b8e-0da37a57b84c"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("e24c23a7-72ad-4474-9c0f-65becef4db58"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("ea326836-5b01-4535-98c1-27a3ecd2f8f4"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("ec18b0c0-b78e-4847-903a-68e65340b953"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("f66f9ecb-f5a1-41e1-aa32-b35793ea765c"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("06ee5076-a23a-4992-a531-73f28dcc6e0c"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("112e1a7a-61de-4727-ae78-c334a9749c1e"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("16b17cf0-a21d-4326-a131-54e65c9d0ba7"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("16dcddfa-a07c-41fb-9220-56110eeda8af"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("2202b5b0-5a9a-4244-83b2-5f584c630de5"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("2407f862-42b1-4fcd-9dab-942a97619073"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("2f6ad742-5900-420c-a0b8-7ed7bcc96638"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("3144b1d9-290f-44c2-96e6-87c4fc7ef1c0"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("351dc6b5-0f15-4e10-b629-32c3b8000a63"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("36357c75-343c-461d-8dbc-3d322a631318"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("3e600b2e-6667-4c20-8ec6-9b1c22cd32f6"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("3f65d6e7-6220-402e-90f5-3f6b35faa640"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("403ccec8-01de-4ef4-803e-8b6ce92f4117"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("47cb486b-a9ca-4add-b322-1ae315570148"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("4edd6c7d-8d6e-4c8f-b2ef-e6a0ad176452"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("566bb592-5b5f-4327-84a3-cc2f460383b0"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("5b8a2436-9e9f-4a5a-b85d-3dc8b0ad824a"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("60fc1cda-fa12-43d2-891d-99e2af98e221"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("7382ca5a-91a6-4616-8f6b-5a0a0e8d03f6"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("750608fd-76d7-44da-ae08-846fddaf1326"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("753e1d62-f09b-4b1f-b9e9-bf6dc8880067"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("779a8cd3-e00b-4298-b4d2-8831dbe8f213"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("791056c1-56e8-4bdc-a3ee-2146f92fab31"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("83068013-4630-40c9-a666-06f20c6b87d0"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("9170f022-6945-4307-8d6c-2814518c4237"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("93bfbd38-08f8-4e42-bd67-62f89fde9f5f"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("9a0683f4-e2db-4dc4-bff7-9bfa44745da3"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("9d2d444e-974d-4da1-bb65-d3111ff3513b"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("9d647871-436c-4371-9452-d02a3362a1ea"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a1879107-545a-4935-b494-f77dd3c98b69"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a33f444d-1fcf-49ab-96d7-215ec7ef9be1"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a6743bf0-9027-4e19-aaea-0850ee00b9ac"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ab1146a2-3575-407c-a66c-19938a8176ad"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ac63e7af-7b57-4bcb-bb7e-a221c7fe5f38"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("adf6db14-25c4-42f7-97d7-6b64d69e8a22"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("af65e999-32f0-4ab9-92de-af82191d9b01"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b238e9ee-9613-4bc9-ad7f-3e30b099ee87"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b314baa6-c2ad-4749-9928-82683cfde424"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b778d377-cb70-4f83-9d85-dc0d89b1daf6"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("c6bbc338-12c6-4e7f-827e-a0596fd0bd97"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("cc6a7504-da13-4cd9-8dfd-2030a62f7883"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("cf19cb9b-6bb1-4339-9cc3-edf9e1f6a9ed"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d51a2fbd-49c7-49f4-8210-c7c87c2a45e8"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d6a00c85-3b78-400e-b960-87caf05d5ee2"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("daa5be8b-37ad-4e2d-be24-2d4892d247cc"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("deee9bae-0942-4249-839c-b7fcb925168a"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e58e1957-2c22-46f7-8314-b56f0f510997"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("1a16a39b-bb63-4dc6-87a2-5958e7066839"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("f9c2e9fe-f224-4d9f-bae1-fd399b83a1a6"));

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "ctr_country_id", "ctr_disabled", "ctr_name" },
                values: new object[,]
                {
                    { new Guid("0a9df348-f746-4350-8e38-f687cd4b9ff2"), false, "Guatemala" },
                    { new Guid("23877360-9b50-4bd3-9f24-0535530cbe1e"), false, "Honduras" },
                    { new Guid("504fcf10-c9f6-41de-92ca-b0469e42328f"), false, "Paraguay" },
                    { new Guid("52d7190c-4a88-4b7b-9b04-a8606a59135d"), false, "Perú" },
                    { new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Colombia" },
                    { new Guid("5f690cce-e54b-4fff-bbc5-da952bb65fb6"), false, "El Salvador" },
                    { new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Ecuador" },
                    { new Guid("80d8ad30-4629-42b9-af72-e0ab933fcaf3"), false, "Nicaragua" },
                    { new Guid("82d94bd1-68bf-4bde-adff-ffa21bde77ad"), false, "Brasil" },
                    { new Guid("8a9b201c-0dc4-4fdf-b6de-4c95e167fd41"), false, "Costa Rica" },
                    { new Guid("999efb09-e2eb-4db0-a28b-6bdf07b5a2f8"), false, "Argentina" },
                    { new Guid("a0482172-62b8-4d3e-a680-58abc3edb08a"), false, "Venezuela" },
                    { new Guid("a6b4a572-7ef6-4ddb-816c-9457b6ccf642"), false, "Belize" },
                    { new Guid("bc0a0c4e-838d-4f5f-925c-e22c71696c89"), false, "Chile" },
                    { new Guid("d29d76d1-e962-47fb-b8e5-c84d2596646f"), false, "Panamá" },
                    { new Guid("d6366e89-e086-4e68-87f1-1f22b5ca1766"), false, "Uruguay" },
                    { new Guid("e8d288a5-544b-4608-a488-fbc6d48335b0"), false, "México" },
                    { new Guid("f04df949-1387-4867-832b-e7de93fd014a"), false, "Bolivia" }
                });

            migrationBuilder.InsertData(
                table: "professional",
                columns: new[] { "prf_professional_id", "created_at", "deleted_at", "prf_disabled", "prf_email", "prf_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("05c00d70-41ae-4c19-b1ab-a9b0e09ef7b3"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4720), null, false, "sandramoreno@gmail.com", "Sandra Moreno", null },
                    { new Guid("06853bce-066e-473f-8c65-1a8be26d716e"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4724), null, false, "andresfernandez@gmail.com", "Andrés Fernández", null },
                    { new Guid("10ec0c01-2267-4149-a7c0-399e1060d61b"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4699), null, false, "pedrolopez@gmail.com", "Pedro López", null },
                    { new Guid("298581c8-cd5c-40e8-a09a-cc67db0a2356"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4744), null, false, "aliciaruis@gmail.com", "Alicia Ruiz", null },
                    { new Guid("324cf7e5-20e7-4ca2-a2da-9eb3254f7666"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4708), null, false, "carlosrodriguez@gmail.com", "Carlos Rodríguez", null },
                    { new Guid("34cead83-5b24-4aaa-8880-ab02d0f273f8"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4748), null, false, "luisvazquez@gmail.com", "Luis Vázquez", null },
                    { new Guid("34cf07f8-08d1-4780-abba-f58322ef833c"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4737), null, false, "patriciablanco@gmail.com", "Patricia Blanco", null },
                    { new Guid("3d18af04-490f-496c-b2b3-ad2f6260e869"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4740), null, false, "josegutierrez@gmail.com", "José Gutiérrez", null },
                    { new Guid("49763cd9-bf73-42f3-9a87-7303fc1ea69b"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4695), null, false, "mariagarcia@gmail.com", "María García", null },
                    { new Guid("66a8ca52-b0fc-495b-bec6-6e5a1a5224ed"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4689), null, false, "juanperez@gmail.com", "Juan Pérez", null },
                    { new Guid("7293dae9-a725-454c-a8a6-9ebc2cefc9a6"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4704), null, false, "anasanchez@gmail.com", "Ana Sánchez", null },
                    { new Guid("9e54fcac-0af1-45c1-9ffa-22c6e30a9f30"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4729), null, false, "lauragonzalez@gmail.com", "Laura González", null },
                    { new Guid("cbde9a30-2580-42ae-a735-3ae3d875f568"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4712), null, false, "isabelmartinez@gmail.com", "Isabel Martínez", null },
                    { new Guid("daf48579-238b-464e-90cf-1c648a46e353"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4733), null, false, "javiermunoz@gmail.com", "Javier Muñoz", null },
                    { new Guid("f2de305c-37ae-4c8a-8870-ec6ba15983b5"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4716), null, false, "diegogomez@gmail.com", "Diego Gómez", null }
                });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.InsertData(
                table: "role_per_skill",
                columns: new[] { "rps_role_per_skill_id", "created_at", "deleted_at", "rol_role_id", "ski_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("040c34cd-d64f-431e-8bfa-d0259f0510ab"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4605), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("18d82dfc-bd54-4610-88dc-80b53718fd10"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4650), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("2cae65a1-b543-448e-9aff-f63d24917c97"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4617), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("2f18dd4f-0457-4825-9945-d0d542f5d3d2"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4599), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("30eb88b4-76f6-4772-a2d7-0d223cd7a569"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4640), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("39c3d18e-4ffa-420b-847d-7f6d41509e20"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4632), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("58603a64-676c-4d97-a2f7-e9c1a4584456"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4657), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("884cb7bd-27f8-4e1c-ad23-9d5fcd9c8572"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4636), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("8f062ec5-29e5-46f5-ba4d-a09c781697f2"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4625), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("9e6992c8-117e-4bb7-95ff-c651262381ef"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4621), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("9f0c27b4-9c14-47ba-aa7e-4b98add69eac"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4613), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("a429a248-28e6-46cd-bfe6-ebd2cc71ae27"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4654), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("acc22df5-57ba-4bc7-a4ea-b9cdcb312997"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4647), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("c09d1373-a112-4d80-858b-23f86a91047e"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4609), null, new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"), new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("e2c5c13c-c5d7-4ff3-9386-3bb6bb23094d"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4628), null, new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"), new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("edcd3918-aaa1-4ce1-b559-bdfdd568fa38"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4643), null, new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"), new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null }
                });

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("10a818a6-b3df-41de-a69a-b451380343e5"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("51373385-dce2-458c-a06b-9b20625b7702"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("76a48392-0e58-496a-ae78-562df47896b7"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("f1ffa467-0220-487c-8afe-66ca42328365"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.InsertData(
                table: "subskill",
                columns: new[] { "sbskl_subskill_id", "created_at", "deleted_at", "sbskl_disabled", "sbskl_name", "skl_skill_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("03901a90-2f0d-49e0-9c65-b5b2bde4cc60"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4477), null, false, "Django", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("08810558-ef00-405c-bccc-1dd607756cc2"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4514), null, false, "Comprensión de la estructura de una base de datos NoSQL, incluyendo colecciones y documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("0f102e24-b6d1-4ac0-8f2a-c12aee76fa7d"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4540), null, false, "Uso de Node.js para crear aplicaciones web, incluyendo la creación de rutas, la gestión de peticiones, y la comunicación con bases de datos.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("128ae522-b7de-4305-bde5-f56aa124f31d"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4496), null, false, "Uso de elementos HTML para estructurar contenido, como párrafos (<p>), encabezados (<h1> a <h6>), listas (<ul>, <ol>, <li>), y enlaces (<a>).", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("561a602b-688a-432f-8f30-1b0c2579c8bf"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4488), null, false, "ES6", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null },
                    { new Guid("5928fcd0-4dbf-4d3e-862d-4753677293e9"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4469), null, false, "Conceptos básicos de programación", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("5a5b0dd5-fe11-4478-bfa5-d97175403bbe"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4547), null, false, "Uso de Spring Boot para crear aplicaciones web, incluyendo la creación de controladores, la gestión de servicios, y la comunicación con bases de datos.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("5ac18a01-89e1-4691-b674-d71ff1e905f7"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4507), null, false, "Comprensión de la estructura de una base de datos relacional, incluyendo tablas, columnas, y claves primarias y foráneas.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("5c0c458e-8d0a-4a66-afcc-5f1b8c0ec4c6"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4503), null, false, "Uso de estilos CSS para controlar la apariencia de un documento HTML, incluyendo colores, márgenes, padding, y la posición de elementos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("67efb65a-9e20-460b-992a-33ea0e550fd3"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4481), null, false, "Flask", new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"), null },
                    { new Guid("7106eb3e-3262-4273-aa34-e61ad67b76ca"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4510), null, false, "Uso de SQL para realizar consultas en una base de datos relacional, incluyendo la selección, inserción, actualización, y eliminación de datos.", new Guid("76a48392-0e58-496a-ae78-562df47896b7"), null },
                    { new Guid("72d8c7e8-e4c3-40dd-9817-a7f2879ccd91"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4458), null, false, "Conceptos básicos de programación", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("76090f2e-2ba5-45db-802a-a08dee6bd6c9"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4518), null, false, "Uso de MongoDB para realizar operaciones CRUD en una base de datos NoSQL, incluyendo la selección, inserción, actualización, y eliminación de documentos.", new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"), null },
                    { new Guid("78621e0e-083a-433a-b7eb-091d2b48194d"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4492), null, false, "Comprensión de la estructura fundamental de un documento HTML, incluyendo <!DOCTYPE>, <html>, <head>, y <body>.", new Guid("10a818a6-b3df-41de-a69a-b451380343e5"), null },
                    { new Guid("93123992-7cc9-4b86-8638-cf5c0f629a50"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4533), null, false, "Uso de React para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de estado, y la comunicación con servicios.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("9a3d7350-e1e8-436b-a3aa-4061534e85f7"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4543), null, false, "Comprende la estructura de un proyecto Spring Boot, incluyendo controladores, servicios, y repositorios.", new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"), null },
                    { new Guid("aeeb225e-424f-4433-a576-65470b2e7df4"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4536), null, false, "Comprende la estructura de un proyecto Node.js, incluyendo módulos, rutas, y middleware.", new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"), null },
                    { new Guid("b2a82e65-7d4a-44fa-9ea8-4a7f563759af"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4465), null, false, "Programación orientada a objetos", new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"), null },
                    { new Guid("b545b488-50fb-4650-aaf1-8efb4a9f2210"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4500), null, false, "Comprensión de la sintaxis básica de CSS para definir estilos, incluyendo la selección de elementos, las propiedades, los valores, y la aplicación de estilos.", new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"), null },
                    { new Guid("bb96c716-ad61-4f99-a6c9-387efbcbfb69"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4521), null, false, "Comprende la estructura de un proyecto Angular, incluyendo módulos, componentes, servicios, y rutas.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("ce6b06d5-80a8-4efb-9b8b-b066273bef79"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4529), null, false, "Comprende la estructura de un proyecto React, incluyendo componentes, props, y estado.", new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"), null },
                    { new Guid("d09fe232-eaac-4cf9-a7c7-3f71b4ea12fa"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4473), null, false, "Play Framework", new Guid("51373385-dce2-458c-a06b-9b20625b7702"), null },
                    { new Guid("faf25f05-adf0-4baf-9ff9-f2a70e35e4b3"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4525), null, false, "Uso de Angular para crear aplicaciones web interactivas, incluyendo la creación de componentes, la gestión de rutas, y la comunicación con servicios.", new Guid("f1ffa467-0220-487c-8afe-66ca42328365"), null },
                    { new Guid("fc8b3fa8-4523-4346-ae94-73cd41cc6c44"), new DateTime(2024, 6, 8, 7, 52, 45, 744, DateTimeKind.Utc).AddTicks(4485), null, false, "Async/Await", new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"), null }
                });

            migrationBuilder.InsertData(
                table: "province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("0115b347-7bec-419d-9331-15f85672753e"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Casanare" },
                    { new Guid("05648c68-062a-4c8f-bbad-045e584267dc"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Chocó" },
                    { new Guid("0abf211e-9507-4110-b1ce-4bec573ece9e"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Boyacá" },
                    { new Guid("0defb544-f8d6-4920-8d8c-e7a0db8a0d46"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Napo" },
                    { new Guid("10d33409-162d-49c8-b500-22f7c35446b4"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Atlántico" },
                    { new Guid("1340033b-8beb-40fd-b313-1e2d2c3c242c"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Santander" },
                    { new Guid("21f59bbf-7bd5-4db7-8fb7-ab15f434b5c0"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Risaralda" },
                    { new Guid("23d9570f-e7b4-4f80-8812-0d19071130cb"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Manabí" },
                    { new Guid("2b96ddee-90ae-47ed-a691-5a981007b0bc"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Bolívar" },
                    { new Guid("2c712ac6-7b1d-41f4-821e-971a192040aa"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Caquetá" },
                    { new Guid("3f455fee-246c-4838-b3dd-445bccf4322e"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Norte de Santander" },
                    { new Guid("4a4a3aa6-32af-421f-90f5-ec2fd637be28"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Amazonas" },
                    { new Guid("4e264baa-658a-432b-a6a3-9a1bdf2d7a1d"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Nariño" },
                    { new Guid("525cad8f-19a4-4e24-bc45-861d715f92ed"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Antioquia" },
                    { new Guid("53b7eae2-3c62-49a1-8ef3-dba1728ee2ca"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Guaviare" },
                    { new Guid("6056ee1b-458a-448d-ba95-ea5216e29cd1"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Guainía" },
                    { new Guid("632d2dfa-98b5-4710-b354-5d5060865850"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Córdoba" },
                    { new Guid("64ad43ac-216d-4543-a4d7-1bccca896f94"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Meta" },
                    { new Guid("6d1db36d-4565-4a4a-9a5f-236dde9453d8"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Galápagos" },
                    { new Guid("75a4ae6f-4b91-472a-acc4-344292758b09"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "El Oro" },
                    { new Guid("7c6f4aa3-9884-438c-a821-7380e02a787f"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Quindío" },
                    { new Guid("857c24dd-e4e7-4709-87d9-df5b9f295eb7"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Cauca" },
                    { new Guid("85d4d157-8619-462b-b6f2-e99224e75091"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Morona Santiago" },
                    { new Guid("8e7799bb-fd1e-453e-ab04-4052e600d5bf"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Cotopaxi" },
                    { new Guid("983288a2-18f9-460e-86c1-c3f87db8a51b"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Azuay" },
                    { new Guid("a14a2304-b14f-4f14-92e1-a7b932ec3639"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Huila" },
                    { new Guid("a24ac1e2-23c5-411b-8a27-a67bd55e4fe5"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Sucre" },
                    { new Guid("a4d9c307-3ca1-43ce-8148-994946fb2f52"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Caldas" },
                    { new Guid("a5c7359c-0da2-4074-a2a7-cbadb78a21a4"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Tolima" },
                    { new Guid("a651035f-82b2-42b2-b0b6-5e53bb0d51be"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Carchi" },
                    { new Guid("aaa7024b-0861-41b8-aee2-ebd590f5758d"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Vichada" },
                    { new Guid("b03a0691-5d97-4b13-a11c-752f7f285a14"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Arauca" },
                    { new Guid("b4d3e73d-2e0d-4ec5-9c43-2ba3e0c421f1"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "San Andrés y Providencia" },
                    { new Guid("b6ed4c14-1148-4487-a84c-485bffe21a02"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "La Guajira" },
                    { new Guid("c61e0a4d-541d-4a6a-9a18-7365851bcbd0"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Imbabura" },
                    { new Guid("cb2692a1-18e6-4fb4-bb5a-55ae3c1842b2"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Cesar" },
                    { new Guid("cc46a64e-6f32-4aab-b327-0822a69431db"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Bolívar" },
                    { new Guid("d27ee3c7-b659-4c12-9f5d-65cd8d34f4a9"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Loja" },
                    { new Guid("d5050771-db4e-43b6-a265-ce365265c370"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Vaupés" },
                    { new Guid("e00911cb-fa8e-4ecb-a1f0-38484547126b"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Magdalena" },
                    { new Guid("e078f6ba-3200-473b-8fa0-02bd72b3d5a6"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Valle del Cauca" },
                    { new Guid("e2ea2aa1-cdc7-4051-973e-64d42b7767f3"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Putumayo" },
                    { new Guid("e43dde3f-5b6b-473c-8c6b-6e8558192beb"), new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"), false, "Cundinamarca" },
                    { new Guid("e70dd775-516d-4ab9-89a9-8b2edce4a439"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Esmeraldas" },
                    { new Guid("efaffe6f-e67b-42a3-8ca7-1fe1f22a00a7"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Chimborazo" },
                    { new Guid("f4e7ca6e-b240-4c5f-bb0e-ba5bab705fb9"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Cañar" },
                    { new Guid("fb8617ab-3822-49c8-a656-f743e9e48313"), new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"), false, "Guayas" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("00e0f9f2-07a7-4a12-ac3d-b281eb95b58a"), false, "Montería", new Guid("a24ac1e2-23c5-411b-8a27-a67bd55e4fe5") },
                    { new Guid("01c2e5db-d0e0-453f-9d1e-c0a67802f6ba"), false, "Santa Helena", new Guid("aaa7024b-0861-41b8-aee2-ebd590f5758d") },
                    { new Guid("01e38e0a-3929-4d42-825f-6952dc92e5c5"), false, "Esmeraldas", new Guid("e70dd775-516d-4ab9-89a9-8b2edce4a439") },
                    { new Guid("06b4f7bb-8ada-4ed9-b1fa-8e1fa9eb47fc"), false, "Cartagena del Chairá", new Guid("cc46a64e-6f32-4aab-b327-0822a69431db") },
                    { new Guid("086f3318-bc0b-413a-8d06-7994a79c5be0"), false, "Soacha", new Guid("e43dde3f-5b6b-473c-8c6b-6e8558192beb") },
                    { new Guid("0c7571a3-3579-476b-bedf-91b19cfcaf37"), false, "Arauca", new Guid("b03a0691-5d97-4b13-a11c-752f7f285a14") },
                    { new Guid("11bed062-33c8-4b0f-a918-9c2821a06504"), false, "Garzón", new Guid("a14a2304-b14f-4f14-92e1-a7b932ec3639") },
                    { new Guid("1377f270-26d3-472b-bd6d-2b0b5030c63c"), false, "Buenaventura", new Guid("e078f6ba-3200-473b-8fa0-02bd72b3d5a6") },
                    { new Guid("14579a6f-d040-459e-bff3-f67070a0fb4d"), false, "La Primavera", new Guid("aaa7024b-0861-41b8-aee2-ebd590f5758d") },
                    { new Guid("16618055-2ebc-4097-b1e2-40d833b5e72c"), false, "Yopal", new Guid("0115b347-7bec-419d-9331-15f85672753e") },
                    { new Guid("172fe3d1-a84c-4782-a110-1e56cf0a256b"), false, "Silvia", new Guid("857c24dd-e4e7-4709-87d9-df5b9f295eb7") },
                    { new Guid("18ab840e-044e-492b-a583-cd01960d78a1"), false, "Barrancabermeja", new Guid("1340033b-8beb-40fd-b313-1e2d2c3c242c") },
                    { new Guid("18b961c1-f2b6-465d-84c2-951d50a2c029"), false, "Tena", new Guid("0defb544-f8d6-4920-8d8c-e7a0db8a0d46") },
                    { new Guid("1e27b3c2-ba0a-419b-abb0-168f092a5255"), false, "Riobamba", new Guid("efaffe6f-e67b-42a3-8ca7-1fe1f22a00a7") },
                    { new Guid("1ebe0d59-268d-4387-ad6a-0641578c1a22"), false, "San José del Guaviare", new Guid("53b7eae2-3c62-49a1-8ef3-dba1728ee2ca") },
                    { new Guid("224381e2-8de2-477e-bf42-a445f2788cd1"), false, "Soledad", new Guid("10d33409-162d-49c8-b500-22f7c35446b4") },
                    { new Guid("2340f982-0020-4c77-9768-7ceb54973fc5"), false, "San Andrés", new Guid("b4d3e73d-2e0d-4ec5-9c43-2ba3e0c421f1") },
                    { new Guid("23ac7b34-ce98-461f-b8fc-d61ddff07ed5"), false, "Salcedo", new Guid("8e7799bb-fd1e-453e-ab04-4052e600d5bf") },
                    { new Guid("23e0a3c1-da4c-4cf5-a3b4-d5f77851809c"), false, "Fortul", new Guid("b03a0691-5d97-4b13-a11c-752f7f285a14") },
                    { new Guid("2b078c6f-98db-40b9-aa75-3861d69c4c61"), false, "Cúcuta", new Guid("3f455fee-246c-4838-b3dd-445bccf4322e") },
                    { new Guid("2c169a99-0ff3-4106-af29-1afc0cdacc0e"), false, "Cartagena del Chairá", new Guid("2c712ac6-7b1d-41f4-821e-971a192040aa") },
                    { new Guid("2d9f1e85-3146-4534-8a2f-35f6276f3404"), false, "Istmina", new Guid("05648c68-062a-4c8f-bbad-045e584267dc") },
                    { new Guid("31c3d4a4-1a18-4516-99ba-394104260dd5"), false, "Leticia", new Guid("4a4a3aa6-32af-421f-90f5-ec2fd637be28") },
                    { new Guid("3278097e-8f98-4462-98c1-e56780f401ba"), false, "San Cristóbal", new Guid("6d1db36d-4565-4a4a-9a5f-236dde9453d8") },
                    { new Guid("3742c0e3-d14d-4345-8f88-35ddec6d0d9f"), false, "El Tambo", new Guid("f4e7ca6e-b240-4c5f-bb0e-ba5bab705fb9") },
                    { new Guid("38e7ab11-df5c-4890-a1e5-1e8b7656897f"), false, "Corozal", new Guid("a24ac1e2-23c5-411b-8a27-a67bd55e4fe5") },
                    { new Guid("3b5029c2-2719-4bbd-95b7-dab7a7c65b8f"), false, "Cereté", new Guid("632d2dfa-98b5-4710-b354-5d5060865850") },
                    { new Guid("3ce343dc-cf89-406d-a53d-17e8377c1546"), false, "Inírida", new Guid("6056ee1b-458a-448d-ba95-ea5216e29cd1") },
                    { new Guid("3e11f47c-2555-42b4-a2f9-63d788c612ce"), false, "Tumaco", new Guid("4e264baa-658a-432b-a6a3-9a1bdf2d7a1d") },
                    { new Guid("3ec5e7a1-8b4c-49b7-bcaa-d617f52612c0"), false, "Pereira", new Guid("21f59bbf-7bd5-4db7-8fb7-ab15f434b5c0") },
                    { new Guid("3f44b1b4-cab7-4e9b-a327-28fe0ede1d84"), false, "Novita", new Guid("05648c68-062a-4c8f-bbad-045e584267dc") },
                    { new Guid("4112f2a6-e4a8-4981-a121-b42f38495394"), false, "Calamar", new Guid("53b7eae2-3c62-49a1-8ef3-dba1728ee2ca") },
                    { new Guid("443bacd0-846d-4986-aefa-015bc6dbcc92"), false, "Santander de Quilichao", new Guid("857c24dd-e4e7-4709-87d9-df5b9f295eb7") },
                    { new Guid("4605b823-9405-4e87-8f16-288ad82f4f28"), false, "Mocoa", new Guid("e2ea2aa1-cdc7-4051-973e-64d42b7767f3") },
                    { new Guid("462120a7-15bc-45f5-bf23-e059752c36fe"), false, "Puerto Inírida", new Guid("6056ee1b-458a-448d-ba95-ea5216e29cd1") },
                    { new Guid("49918b05-14c5-4aee-976b-34da2ec70216"), false, "Popayán", new Guid("857c24dd-e4e7-4709-87d9-df5b9f295eb7") },
                    { new Guid("4b7f0fe9-0884-4d4b-b23c-c5a88d9757e9"), false, "Puerto Carreño", new Guid("aaa7024b-0861-41b8-aee2-ebd590f5758d") },
                    { new Guid("4e7755da-15f9-4ca3-8ab2-d73b44b49f41"), false, "Armero Guayabal", new Guid("a5c7359c-0da2-4074-a2a7-cbadb78a21a4") },
                    { new Guid("503890ba-8bb1-4140-9ae5-22f43b32cc53"), false, "Apartadó", new Guid("525cad8f-19a4-4e24-bc45-861d715f92ed") },
                    { new Guid("51545f09-e339-4f75-a9ca-caa96077d8b2"), false, "La Tebaida", new Guid("7c6f4aa3-9884-438c-a821-7380e02a787f") },
                    { new Guid("567c06e6-f832-42b8-8e66-4b0f2aa0f6f5"), false, "Villavicencio", new Guid("64ad43ac-216d-4543-a4d7-1bccca896f94") },
                    { new Guid("57f4c33e-d0b4-4b4d-85b0-db021a09d1bc"), false, "Cartagena de Indias", new Guid("cc46a64e-6f32-4aab-b327-0822a69431db") },
                    { new Guid("5a075eae-e066-422d-b4fa-72a995953818"), false, "Duitama", new Guid("0abf211e-9507-4110-b1ce-4bec573ece9e") },
                    { new Guid("5cbf9570-57ac-494b-875f-2f5751a71192"), false, "Puerto Baquerizo Moreno", new Guid("6d1db36d-4565-4a4a-9a5f-236dde9453d8") },
                    { new Guid("5dc32a07-728b-4b36-8591-a7034a65f87e"), false, "Granada", new Guid("64ad43ac-216d-4543-a4d7-1bccca896f94") },
                    { new Guid("5ff54718-d930-42d1-8334-15b7da300b9e"), false, "Ibagué", new Guid("a5c7359c-0da2-4074-a2a7-cbadb78a21a4") },
                    { new Guid("6c529ad4-774a-450f-9d1d-c29017869bbe"), false, "Barranquilla", new Guid("10d33409-162d-49c8-b500-22f7c35446b4") },
                    { new Guid("6d4e7a33-1190-47a7-ac39-eea2414c3f2a"), false, "Atacames", new Guid("e70dd775-516d-4ab9-89a9-8b2edce4a439") },
                    { new Guid("6df26252-c3ba-499b-b1f8-3550b43202e5"), false, "Cuenca", new Guid("983288a2-18f9-460e-86c1-c3f87db8a51b") },
                    { new Guid("702a1d0f-83e0-43bf-bc38-3b325cbe53a0"), false, "Pitalito", new Guid("a14a2304-b14f-4f14-92e1-a7b932ec3639") },
                    { new Guid("714719b6-9bf5-4edb-8c4d-8b1388157e8c"), false, "Ciénaga", new Guid("e00911cb-fa8e-4ecb-a1f0-38484547126b") },
                    { new Guid("7227b8f9-12d2-4782-b05b-f5b52806d834"), false, "Bucaramanga", new Guid("1340033b-8beb-40fd-b313-1e2d2c3c242c") },
                    { new Guid("730ad8d6-4c15-4608-bf21-f5e6e64a38e1"), false, "Calarcá", new Guid("7c6f4aa3-9884-438c-a821-7380e02a787f") },
                    { new Guid("73a5bcf1-d596-4052-8b06-2052a5e244ca"), false, "Mitú", new Guid("d5050771-db4e-43b6-a265-ce365265c370") },
                    { new Guid("760ccb19-6636-4765-8003-4a6423cdd4c4"), false, "Chone", new Guid("23d9570f-e7b4-4f80-8812-0d19071130cb") },
                    { new Guid("78640393-9f3b-4a59-8578-d0bf18b5c4e8"), false, "Machala", new Guid("75a4ae6f-4b91-472a-acc4-344292758b09") },
                    { new Guid("79834635-3b5f-405c-a391-6a913efaea11"), false, "Saravena", new Guid("b03a0691-5d97-4b13-a11c-752f7f285a14") },
                    { new Guid("7b789c4b-416b-413c-a8c4-f7980cd256b2"), false, "Pereira", new Guid("a4d9c307-3ca1-43ce-8148-994946fb2f52") },
                    { new Guid("7ca32ba5-4874-4502-a1c8-17b3c973c3bd"), false, "Santa Rosa", new Guid("75a4ae6f-4b91-472a-acc4-344292758b09") },
                    { new Guid("7ee47e93-2df0-40e1-a433-ae611a6d7aa1"), false, "Durán", new Guid("fb8617ab-3822-49c8-a656-f743e9e48313") },
                    { new Guid("7f2c47e6-34c3-4dce-9965-c379425382ed"), false, "Piedecuesta", new Guid("1340033b-8beb-40fd-b313-1e2d2c3c242c") },
                    { new Guid("8079aa33-9761-40e2-8b17-dff64fec0e0b"), false, "El Guabo", new Guid("a651035f-82b2-42b2-b0b6-5e53bb0d51be") },
                    { new Guid("8132bbbc-3ec8-4b49-8da6-179fbea89d6a"), false, "Tauramena", new Guid("0115b347-7bec-419d-9331-15f85672753e") },
                    { new Guid("8420769d-289f-42ab-b72f-14ec99af3587"), false, "Santa Marta", new Guid("e00911cb-fa8e-4ecb-a1f0-38484547126b") },
                    { new Guid("84d3dedf-5622-4070-9431-cab95f3173cf"), false, "Santa Rosalía", new Guid("d5050771-db4e-43b6-a265-ce365265c370") },
                    { new Guid("87d8b617-889d-42a6-9de3-583beb027152"), false, "Morelia", new Guid("2c712ac6-7b1d-41f4-821e-971a192040aa") },
                    { new Guid("88b30884-823a-431d-a61b-120e9f2a9b93"), false, "Montería", new Guid("632d2dfa-98b5-4710-b354-5d5060865850") },
                    { new Guid("88f4d474-2436-44cf-b883-3775dd5c6741"), false, "Providencia", new Guid("b4d3e73d-2e0d-4ec5-9c43-2ba3e0c421f1") },
                    { new Guid("8a851a3c-3c8d-4692-95a0-5f676a4e1bca"), false, "Sincelejo", new Guid("a24ac1e2-23c5-411b-8a27-a67bd55e4fe5") },
                    { new Guid("8afac3cc-c340-4b9b-8d24-8f5d1b3693fc"), false, "Maicao", new Guid("b6ed4c14-1148-4487-a84c-485bffe21a02") },
                    { new Guid("8d18209b-2a8b-40e3-b09c-c308b99395fa"), false, "Magangué", new Guid("cc46a64e-6f32-4aab-b327-0822a69431db") },
                    { new Guid("8fbde3f0-46cc-49d6-b61b-054f155e3a04"), false, "Palmira", new Guid("e078f6ba-3200-473b-8fa0-02bd72b3d5a6") },
                    { new Guid("91208621-bcc2-45bf-9008-5cd1f626bf50"), false, "Guaranda", new Guid("2b96ddee-90ae-47ed-a691-5a981007b0bc") },
                    { new Guid("91b8846b-a869-4438-86e7-e97446dd8228"), false, "Azogues", new Guid("f4e7ca6e-b240-4c5f-bb0e-ba5bab705fb9") },
                    { new Guid("93757864-d895-49ad-bfec-54f171f2059e"), false, "Acacias", new Guid("64ad43ac-216d-4543-a4d7-1bccca896f94") },
                    { new Guid("9389cd85-ebba-4ecf-a75b-edf991a4ce16"), false, "Medellín", new Guid("525cad8f-19a4-4e24-bc45-861d715f92ed") },
                    { new Guid("94d613ed-d27f-4951-914e-dc8eb5cf67e3"), false, "Manizales", new Guid("a4d9c307-3ca1-43ce-8148-994946fb2f52") },
                    { new Guid("95246f24-cce7-4952-916e-b12f656f83fc"), false, "Macas", new Guid("85d4d157-8619-462b-b6f2-e99224e75091") },
                    { new Guid("9552a70b-5013-4d31-b755-750e03b6c81b"), false, "Aguachica", new Guid("cb2692a1-18e6-4fb4-bb5a-55ae3c1842b2") },
                    { new Guid("999e38b7-3f60-47b0-8643-3b713e5235e7"), false, "Florencia", new Guid("2c712ac6-7b1d-41f4-821e-971a192040aa") },
                    { new Guid("9a4ecd98-22cc-4059-a34a-76762e97b390"), false, "Uribia", new Guid("b6ed4c14-1148-4487-a84c-485bffe21a02") },
                    { new Guid("9ae462cf-682f-4a53-8d28-0515aa375ee2"), false, "Riohacha", new Guid("b6ed4c14-1148-4487-a84c-485bffe21a02") },
                    { new Guid("9f438d68-c17b-484b-a504-5d401b80d4be"), false, "Girón", new Guid("983288a2-18f9-460e-86c1-c3f87db8a51b") },
                    { new Guid("9fba767b-1450-4e27-bb61-662d60baba84"), false, "Memarí", new Guid("6056ee1b-458a-448d-ba95-ea5216e29cd1") },
                    { new Guid("9fc141ac-2c44-4690-a0ed-0433c3c04faa"), false, "Otavalo", new Guid("c61e0a4d-541d-4a6a-9a18-7365851bcbd0") },
                    { new Guid("9fec6661-8bb2-48fe-a65c-9c9a4f02cceb"), false, "Puerto Colombia", new Guid("10d33409-162d-49c8-b500-22f7c35446b4") },
                    { new Guid("a15bbfa9-822f-4a7c-b0f9-c31c2a4d60f1"), false, "San Miguel de Bolívar", new Guid("2b96ddee-90ae-47ed-a691-5a981007b0bc") },
                    { new Guid("a4d55f39-c365-4050-9bff-00012aba292a"), false, "El Retén", new Guid("53b7eae2-3c62-49a1-8ef3-dba1728ee2ca") },
                    { new Guid("aa41e1c8-48ef-42d2-8e2c-5276b11dd972"), false, "Santa Catalina", new Guid("b4d3e73d-2e0d-4ec5-9c43-2ba3e0c421f1") },
                    { new Guid("ac408bf2-72a1-4549-90a7-b517ef5bec1e"), false, "Tunja", new Guid("0abf211e-9507-4110-b1ce-4bec573ece9e") },
                    { new Guid("adb701a2-7e26-41b6-862e-dcf84bcf736e"), false, "Alausí", new Guid("efaffe6f-e67b-42a3-8ca7-1fe1f22a00a7") },
                    { new Guid("af2b8e3b-3293-4971-a2c8-2002b7014a44"), false, "Aguazul", new Guid("0115b347-7bec-419d-9331-15f85672753e") },
                    { new Guid("b10a3872-ea68-43d5-a99a-be8873a06dd8"), false, "Aracataca", new Guid("e00911cb-fa8e-4ecb-a1f0-38484547126b") },
                    { new Guid("b142a583-eae9-4672-8906-7050984d970f"), false, "Manta", new Guid("23d9570f-e7b4-4f80-8812-0d19071130cb") },
                    { new Guid("b6066a53-9f59-4517-9191-1c1ee5398d03"), false, "Bogotá", new Guid("e43dde3f-5b6b-473c-8c6b-6e8558192beb") },
                    { new Guid("b6a11146-ebd5-4d6c-8e49-c0ffba27b370"), false, "Turbo", new Guid("525cad8f-19a4-4e24-bc45-861d715f92ed") },
                    { new Guid("b826e576-b3be-415a-b227-b2aab8c4d1b9"), false, "Orito", new Guid("e2ea2aa1-cdc7-4051-973e-64d42b7767f3") },
                    { new Guid("b9136e3f-0474-4879-a9d8-5ab4e5185890"), false, "Cali", new Guid("e078f6ba-3200-473b-8fa0-02bd72b3d5a6") },
                    { new Guid("c027058a-d6b1-4563-8893-15e42aed3659"), false, "Gualaquiza", new Guid("85d4d157-8619-462b-b6f2-e99224e75091") },
                    { new Guid("c0a9319c-ab2f-402c-acbc-ef3cd138ba53"), false, "Portoviejo", new Guid("23d9570f-e7b4-4f80-8812-0d19071130cb") },
                    { new Guid("c1699429-d0a4-4945-8123-23f54351c742"), false, "Valledupar", new Guid("cb2692a1-18e6-4fb4-bb5a-55ae3c1842b2") },
                    { new Guid("c1b47984-33f4-4d4b-b237-57230208804b"), false, "Armenia", new Guid("7c6f4aa3-9884-438c-a821-7380e02a787f") },
                    { new Guid("c558d799-560d-4682-a4b3-1a7158bf5d6c"), false, "Saraguro", new Guid("d27ee3c7-b659-4c12-9f5d-65cd8d34f4a9") },
                    { new Guid("c9d195ae-7613-4382-a7a4-92b4aca3f836"), false, "La Paz", new Guid("cb2692a1-18e6-4fb4-bb5a-55ae3c1842b2") },
                    { new Guid("cb2fa36a-eb6f-43b6-8aae-64229c3b4b00"), false, "Pamplona", new Guid("3f455fee-246c-4838-b3dd-445bccf4322e") },
                    { new Guid("cc0b9a1e-001b-426d-b1e4-411864868f09"), false, "Neiva", new Guid("a14a2304-b14f-4f14-92e1-a7b932ec3639") },
                    { new Guid("cd19fe30-75fc-4627-a353-c2ac5b986285"), false, "Sogamoso", new Guid("0abf211e-9507-4110-b1ce-4bec573ece9e") },
                    { new Guid("ceed0294-95fc-4b0a-b4d4-8d948f1a6ad3"), false, "Santa Rosa de Cabal", new Guid("21f59bbf-7bd5-4db7-8fb7-ab15f434b5c0") },
                    { new Guid("d0927284-c3e8-4ac7-91d8-70a7feabeeac"), false, "Latacunga", new Guid("8e7799bb-fd1e-453e-ab04-4052e600d5bf") },
                    { new Guid("d1d79857-e991-4729-8e1b-cd89f3a61c7e"), false, "Ipiales", new Guid("4e264baa-658a-432b-a6a3-9a1bdf2d7a1d") },
                    { new Guid("d4761ff5-c968-4134-84eb-7d130927083a"), false, "Ocaña", new Guid("3f455fee-246c-4838-b3dd-445bccf4322e") },
                    { new Guid("d60993a0-f1bf-4ea0-96fc-a9a0ab9535dd"), false, "Guayaquil", new Guid("fb8617ab-3822-49c8-a656-f743e9e48313") },
                    { new Guid("d7c7b0a8-9193-4c8b-b618-35f2cbfec8e8"), false, "Tulcán", new Guid("a651035f-82b2-42b2-b0b6-5e53bb0d51be") },
                    { new Guid("d9cc8140-b79d-463a-8a0f-664b2bf3dc52"), false, "Puerto Asís", new Guid("e2ea2aa1-cdc7-4051-973e-64d42b7767f3") },
                    { new Guid("debc4789-7746-423c-ad23-01bcd141c5b6"), false, "Honda", new Guid("a5c7359c-0da2-4074-a2a7-cbadb78a21a4") },
                    { new Guid("df179c4e-f11b-43bb-9604-457fb6a251e4"), false, "Yavaraté", new Guid("d5050771-db4e-43b6-a265-ce365265c370") },
                    { new Guid("e13f1c3f-126e-4fa7-afd0-747b972d74a6"), false, "Chinchiná", new Guid("a4d9c307-3ca1-43ce-8148-994946fb2f52") },
                    { new Guid("e4efdd89-0c05-49f7-a6e0-134f94940d17"), false, "Dosquebradas", new Guid("21f59bbf-7bd5-4db7-8fb7-ab15f434b5c0") },
                    { new Guid("e4fa6e19-1936-4fb9-a82f-4219e6941547"), false, "Lorica", new Guid("632d2dfa-98b5-4710-b354-5d5060865850") },
                    { new Guid("e8b379a2-5238-41e4-8087-2acb9333e6bd"), false, "San Juan de Pasto", new Guid("4e264baa-658a-432b-a6a3-9a1bdf2d7a1d") },
                    { new Guid("ea14e332-4261-423f-9360-301d1bac0250"), false, "Ibarra", new Guid("c61e0a4d-541d-4a6a-9a18-7365851bcbd0") },
                    { new Guid("efd8592b-6c8a-4203-9fa3-743eb32436a4"), false, "Loja", new Guid("d27ee3c7-b659-4c12-9f5d-65cd8d34f4a9") },
                    { new Guid("f03116e4-b887-4652-a99d-3df0c8206a57"), false, "Quibdó", new Guid("05648c68-062a-4c8f-bbad-045e584267dc") },
                    { new Guid("f1064c44-bf05-413d-89a0-fbc9fb31442d"), false, "Archidona", new Guid("0defb544-f8d6-4920-8d8c-e7a0db8a0d46") },
                    { new Guid("f56c0cae-60ae-42f6-8ae7-be2eff1a1f68"), false, "Zipaquirá", new Guid("e43dde3f-5b6b-473c-8c6b-6e8558192beb") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_role_per_skill_role_rol_role_id",
                table: "role_per_skill",
                column: "rol_role_id",
                principalTable: "role",
                principalColumn: "rol_role_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_per_skill_role_rol_role_id",
                table: "role_per_skill");

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("00e0f9f2-07a7-4a12-ac3d-b281eb95b58a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("01c2e5db-d0e0-453f-9d1e-c0a67802f6ba"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("01e38e0a-3929-4d42-825f-6952dc92e5c5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("06b4f7bb-8ada-4ed9-b1fa-8e1fa9eb47fc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("086f3318-bc0b-413a-8d06-7994a79c5be0"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0c7571a3-3579-476b-bedf-91b19cfcaf37"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("11bed062-33c8-4b0f-a918-9c2821a06504"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1377f270-26d3-472b-bd6d-2b0b5030c63c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("14579a6f-d040-459e-bff3-f67070a0fb4d"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("16618055-2ebc-4097-b1e2-40d833b5e72c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("172fe3d1-a84c-4782-a110-1e56cf0a256b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("18ab840e-044e-492b-a583-cd01960d78a1"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("18b961c1-f2b6-465d-84c2-951d50a2c029"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1e27b3c2-ba0a-419b-abb0-168f092a5255"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1ebe0d59-268d-4387-ad6a-0641578c1a22"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("224381e2-8de2-477e-bf42-a445f2788cd1"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2340f982-0020-4c77-9768-7ceb54973fc5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("23ac7b34-ce98-461f-b8fc-d61ddff07ed5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("23e0a3c1-da4c-4cf5-a3b4-d5f77851809c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2b078c6f-98db-40b9-aa75-3861d69c4c61"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2c169a99-0ff3-4106-af29-1afc0cdacc0e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2d9f1e85-3146-4534-8a2f-35f6276f3404"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("31c3d4a4-1a18-4516-99ba-394104260dd5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3278097e-8f98-4462-98c1-e56780f401ba"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3742c0e3-d14d-4345-8f88-35ddec6d0d9f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("38e7ab11-df5c-4890-a1e5-1e8b7656897f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3b5029c2-2719-4bbd-95b7-dab7a7c65b8f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3ce343dc-cf89-406d-a53d-17e8377c1546"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3e11f47c-2555-42b4-a2f9-63d788c612ce"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3ec5e7a1-8b4c-49b7-bcaa-d617f52612c0"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3f44b1b4-cab7-4e9b-a327-28fe0ede1d84"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4112f2a6-e4a8-4981-a121-b42f38495394"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("443bacd0-846d-4986-aefa-015bc6dbcc92"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4605b823-9405-4e87-8f16-288ad82f4f28"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("462120a7-15bc-45f5-bf23-e059752c36fe"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("49918b05-14c5-4aee-976b-34da2ec70216"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4b7f0fe9-0884-4d4b-b23c-c5a88d9757e9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4e7755da-15f9-4ca3-8ab2-d73b44b49f41"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("503890ba-8bb1-4140-9ae5-22f43b32cc53"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("51545f09-e339-4f75-a9ca-caa96077d8b2"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("567c06e6-f832-42b8-8e66-4b0f2aa0f6f5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("57f4c33e-d0b4-4b4d-85b0-db021a09d1bc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5a075eae-e066-422d-b4fa-72a995953818"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5cbf9570-57ac-494b-875f-2f5751a71192"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5dc32a07-728b-4b36-8591-a7034a65f87e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5ff54718-d930-42d1-8334-15b7da300b9e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6c529ad4-774a-450f-9d1d-c29017869bbe"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6d4e7a33-1190-47a7-ac39-eea2414c3f2a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6df26252-c3ba-499b-b1f8-3550b43202e5"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("702a1d0f-83e0-43bf-bc38-3b325cbe53a0"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("714719b6-9bf5-4edb-8c4d-8b1388157e8c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7227b8f9-12d2-4782-b05b-f5b52806d834"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("730ad8d6-4c15-4608-bf21-f5e6e64a38e1"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("73a5bcf1-d596-4052-8b06-2052a5e244ca"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("760ccb19-6636-4765-8003-4a6423cdd4c4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("78640393-9f3b-4a59-8578-d0bf18b5c4e8"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("79834635-3b5f-405c-a391-6a913efaea11"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7b789c4b-416b-413c-a8c4-f7980cd256b2"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7ca32ba5-4874-4502-a1c8-17b3c973c3bd"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7ee47e93-2df0-40e1-a433-ae611a6d7aa1"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7f2c47e6-34c3-4dce-9965-c379425382ed"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8079aa33-9761-40e2-8b17-dff64fec0e0b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8132bbbc-3ec8-4b49-8da6-179fbea89d6a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8420769d-289f-42ab-b72f-14ec99af3587"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("84d3dedf-5622-4070-9431-cab95f3173cf"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("87d8b617-889d-42a6-9de3-583beb027152"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("88b30884-823a-431d-a61b-120e9f2a9b93"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("88f4d474-2436-44cf-b883-3775dd5c6741"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8a851a3c-3c8d-4692-95a0-5f676a4e1bca"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8afac3cc-c340-4b9b-8d24-8f5d1b3693fc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8d18209b-2a8b-40e3-b09c-c308b99395fa"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("8fbde3f0-46cc-49d6-b61b-054f155e3a04"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("91208621-bcc2-45bf-9008-5cd1f626bf50"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("91b8846b-a869-4438-86e7-e97446dd8228"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("93757864-d895-49ad-bfec-54f171f2059e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9389cd85-ebba-4ecf-a75b-edf991a4ce16"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("94d613ed-d27f-4951-914e-dc8eb5cf67e3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("95246f24-cce7-4952-916e-b12f656f83fc"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9552a70b-5013-4d31-b755-750e03b6c81b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("999e38b7-3f60-47b0-8643-3b713e5235e7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9a4ecd98-22cc-4059-a34a-76762e97b390"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9ae462cf-682f-4a53-8d28-0515aa375ee2"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9f438d68-c17b-484b-a504-5d401b80d4be"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9fba767b-1450-4e27-bb61-662d60baba84"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9fc141ac-2c44-4690-a0ed-0433c3c04faa"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9fec6661-8bb2-48fe-a65c-9c9a4f02cceb"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a15bbfa9-822f-4a7c-b0f9-c31c2a4d60f1"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a4d55f39-c365-4050-9bff-00012aba292a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("aa41e1c8-48ef-42d2-8e2c-5276b11dd972"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ac408bf2-72a1-4549-90a7-b517ef5bec1e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("adb701a2-7e26-41b6-862e-dcf84bcf736e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("af2b8e3b-3293-4971-a2c8-2002b7014a44"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b10a3872-ea68-43d5-a99a-be8873a06dd8"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b142a583-eae9-4672-8906-7050984d970f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b6066a53-9f59-4517-9191-1c1ee5398d03"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b6a11146-ebd5-4d6c-8e49-c0ffba27b370"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b826e576-b3be-415a-b227-b2aab8c4d1b9"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b9136e3f-0474-4879-a9d8-5ab4e5185890"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c027058a-d6b1-4563-8893-15e42aed3659"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c0a9319c-ab2f-402c-acbc-ef3cd138ba53"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c1699429-d0a4-4945-8123-23f54351c742"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c1b47984-33f4-4d4b-b237-57230208804b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c558d799-560d-4682-a4b3-1a7158bf5d6c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c9d195ae-7613-4382-a7a4-92b4aca3f836"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cb2fa36a-eb6f-43b6-8aae-64229c3b4b00"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cc0b9a1e-001b-426d-b1e4-411864868f09"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cd19fe30-75fc-4627-a353-c2ac5b986285"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ceed0294-95fc-4b0a-b4d4-8d948f1a6ad3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d0927284-c3e8-4ac7-91d8-70a7feabeeac"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d1d79857-e991-4729-8e1b-cd89f3a61c7e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d4761ff5-c968-4134-84eb-7d130927083a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d60993a0-f1bf-4ea0-96fc-a9a0ab9535dd"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d7c7b0a8-9193-4c8b-b618-35f2cbfec8e8"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d9cc8140-b79d-463a-8a0f-664b2bf3dc52"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("debc4789-7746-423c-ad23-01bcd141c5b6"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("df179c4e-f11b-43bb-9604-457fb6a251e4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e13f1c3f-126e-4fa7-afd0-747b972d74a6"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e4efdd89-0c05-49f7-a6e0-134f94940d17"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e4fa6e19-1936-4fb9-a82f-4219e6941547"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e8b379a2-5238-41e4-8087-2acb9333e6bd"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ea14e332-4261-423f-9360-301d1bac0250"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("efd8592b-6c8a-4203-9fa3-743eb32436a4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f03116e4-b887-4652-a99d-3df0c8206a57"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f1064c44-bf05-413d-89a0-fbc9fb31442d"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f56c0cae-60ae-42f6-8ae7-be2eff1a1f68"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("0a9df348-f746-4350-8e38-f687cd4b9ff2"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("23877360-9b50-4bd3-9f24-0535530cbe1e"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("504fcf10-c9f6-41de-92ca-b0469e42328f"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("52d7190c-4a88-4b7b-9b04-a8606a59135d"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("5f690cce-e54b-4fff-bbc5-da952bb65fb6"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("80d8ad30-4629-42b9-af72-e0ab933fcaf3"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("82d94bd1-68bf-4bde-adff-ffa21bde77ad"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("8a9b201c-0dc4-4fdf-b6de-4c95e167fd41"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("999efb09-e2eb-4db0-a28b-6bdf07b5a2f8"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("a0482172-62b8-4d3e-a680-58abc3edb08a"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("a6b4a572-7ef6-4ddb-816c-9457b6ccf642"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("bc0a0c4e-838d-4f5f-925c-e22c71696c89"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("d29d76d1-e962-47fb-b8e5-c84d2596646f"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("d6366e89-e086-4e68-87f1-1f22b5ca1766"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("e8d288a5-544b-4608-a488-fbc6d48335b0"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("f04df949-1387-4867-832b-e7de93fd014a"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("05c00d70-41ae-4c19-b1ab-a9b0e09ef7b3"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("06853bce-066e-473f-8c65-1a8be26d716e"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("10ec0c01-2267-4149-a7c0-399e1060d61b"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("298581c8-cd5c-40e8-a09a-cc67db0a2356"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("324cf7e5-20e7-4ca2-a2da-9eb3254f7666"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("34cead83-5b24-4aaa-8880-ab02d0f273f8"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("34cf07f8-08d1-4780-abba-f58322ef833c"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("3d18af04-490f-496c-b2b3-ad2f6260e869"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("49763cd9-bf73-42f3-9a87-7303fc1ea69b"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("66a8ca52-b0fc-495b-bec6-6e5a1a5224ed"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("7293dae9-a725-454c-a8a6-9ebc2cefc9a6"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("9e54fcac-0af1-45c1-9ffa-22c6e30a9f30"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("cbde9a30-2580-42ae-a735-3ae3d875f568"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("daf48579-238b-464e-90cf-1c648a46e353"));

            migrationBuilder.DeleteData(
                table: "professional",
                keyColumn: "prf_professional_id",
                keyValue: new Guid("f2de305c-37ae-4c8a-8870-ec6ba15983b5"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("040c34cd-d64f-431e-8bfa-d0259f0510ab"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("18d82dfc-bd54-4610-88dc-80b53718fd10"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("2cae65a1-b543-448e-9aff-f63d24917c97"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("2f18dd4f-0457-4825-9945-d0d542f5d3d2"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("30eb88b4-76f6-4772-a2d7-0d223cd7a569"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("39c3d18e-4ffa-420b-847d-7f6d41509e20"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("58603a64-676c-4d97-a2f7-e9c1a4584456"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("884cb7bd-27f8-4e1c-ad23-9d5fcd9c8572"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("8f062ec5-29e5-46f5-ba4d-a09c781697f2"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("9e6992c8-117e-4bb7-95ff-c651262381ef"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("9f0c27b4-9c14-47ba-aa7e-4b98add69eac"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("a429a248-28e6-46cd-bfe6-ebd2cc71ae27"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("acc22df5-57ba-4bc7-a4ea-b9cdcb312997"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("c09d1373-a112-4d80-858b-23f86a91047e"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("e2c5c13c-c5d7-4ff3-9386-3bb6bb23094d"));

            migrationBuilder.DeleteData(
                table: "role_per_skill",
                keyColumn: "rps_role_per_skill_id",
                keyValue: new Guid("edcd3918-aaa1-4ce1-b559-bdfdd568fa38"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("03901a90-2f0d-49e0-9c65-b5b2bde4cc60"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("08810558-ef00-405c-bccc-1dd607756cc2"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("0f102e24-b6d1-4ac0-8f2a-c12aee76fa7d"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("128ae522-b7de-4305-bde5-f56aa124f31d"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("561a602b-688a-432f-8f30-1b0c2579c8bf"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("5928fcd0-4dbf-4d3e-862d-4753677293e9"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("5a5b0dd5-fe11-4478-bfa5-d97175403bbe"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("5ac18a01-89e1-4691-b674-d71ff1e905f7"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("5c0c458e-8d0a-4a66-afcc-5f1b8c0ec4c6"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("67efb65a-9e20-460b-992a-33ea0e550fd3"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("7106eb3e-3262-4273-aa34-e61ad67b76ca"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("72d8c7e8-e4c3-40dd-9817-a7f2879ccd91"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("76090f2e-2ba5-45db-802a-a08dee6bd6c9"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("78621e0e-083a-433a-b7eb-091d2b48194d"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("93123992-7cc9-4b86-8638-cf5c0f629a50"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("9a3d7350-e1e8-436b-a3aa-4061534e85f7"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("aeeb225e-424f-4433-a576-65470b2e7df4"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("b2a82e65-7d4a-44fa-9ea8-4a7f563759af"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("b545b488-50fb-4650-aaf1-8efb4a9f2210"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("bb96c716-ad61-4f99-a6c9-387efbcbfb69"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("ce6b06d5-80a8-4efb-9b8b-b066273bef79"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("d09fe232-eaac-4cf9-a7c7-3f71b4ea12fa"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("faf25f05-adf0-4baf-9ff9-f2a70e35e4b3"));

            migrationBuilder.DeleteData(
                table: "subskill",
                keyColumn: "sbskl_subskill_id",
                keyValue: new Guid("fc8b3fa8-4523-4346-ae94-73cd41cc6c44"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("0115b347-7bec-419d-9331-15f85672753e"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("05648c68-062a-4c8f-bbad-045e584267dc"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("0abf211e-9507-4110-b1ce-4bec573ece9e"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("0defb544-f8d6-4920-8d8c-e7a0db8a0d46"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("10d33409-162d-49c8-b500-22f7c35446b4"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("1340033b-8beb-40fd-b313-1e2d2c3c242c"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("21f59bbf-7bd5-4db7-8fb7-ab15f434b5c0"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("23d9570f-e7b4-4f80-8812-0d19071130cb"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("2b96ddee-90ae-47ed-a691-5a981007b0bc"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("2c712ac6-7b1d-41f4-821e-971a192040aa"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("3f455fee-246c-4838-b3dd-445bccf4322e"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("4a4a3aa6-32af-421f-90f5-ec2fd637be28"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("4e264baa-658a-432b-a6a3-9a1bdf2d7a1d"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("525cad8f-19a4-4e24-bc45-861d715f92ed"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("53b7eae2-3c62-49a1-8ef3-dba1728ee2ca"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("6056ee1b-458a-448d-ba95-ea5216e29cd1"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("632d2dfa-98b5-4710-b354-5d5060865850"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("64ad43ac-216d-4543-a4d7-1bccca896f94"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("6d1db36d-4565-4a4a-9a5f-236dde9453d8"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("75a4ae6f-4b91-472a-acc4-344292758b09"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("7c6f4aa3-9884-438c-a821-7380e02a787f"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("857c24dd-e4e7-4709-87d9-df5b9f295eb7"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("85d4d157-8619-462b-b6f2-e99224e75091"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("8e7799bb-fd1e-453e-ab04-4052e600d5bf"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("983288a2-18f9-460e-86c1-c3f87db8a51b"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a14a2304-b14f-4f14-92e1-a7b932ec3639"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a24ac1e2-23c5-411b-8a27-a67bd55e4fe5"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a4d9c307-3ca1-43ce-8148-994946fb2f52"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a5c7359c-0da2-4074-a2a7-cbadb78a21a4"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a651035f-82b2-42b2-b0b6-5e53bb0d51be"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("aaa7024b-0861-41b8-aee2-ebd590f5758d"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b03a0691-5d97-4b13-a11c-752f7f285a14"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b4d3e73d-2e0d-4ec5-9c43-2ba3e0c421f1"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b6ed4c14-1148-4487-a84c-485bffe21a02"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("c61e0a4d-541d-4a6a-9a18-7365851bcbd0"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("cb2692a1-18e6-4fb4-bb5a-55ae3c1842b2"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("cc46a64e-6f32-4aab-b327-0822a69431db"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d27ee3c7-b659-4c12-9f5d-65cd8d34f4a9"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d5050771-db4e-43b6-a265-ce365265c370"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e00911cb-fa8e-4ecb-a1f0-38484547126b"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e078f6ba-3200-473b-8fa0-02bd72b3d5a6"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e2ea2aa1-cdc7-4051-973e-64d42b7767f3"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e43dde3f-5b6b-473c-8c6b-6e8558192beb"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e70dd775-516d-4ab9-89a9-8b2edce4a439"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("efaffe6f-e67b-42a3-8ca7-1fe1f22a00a7"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("f4e7ca6e-b240-4c5f-bb0e-ba5bab705fb9"));

            migrationBuilder.DeleteData(
                table: "province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("fb8617ab-3822-49c8-a656-f743e9e48313"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("56dc0a3d-d739-466b-8fa9-b198eb13820b"));

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("67906c85-9199-4bf0-bbdb-adbb7c976556"));

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

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("359edb6c-cfdf-4a5c-9cd7-f07418f4719c"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("9186211b-adf4-4b18-bfe2-4516f5cdbb1c"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "rol_role_id",
                keyValue: new Guid("a4fa468c-8837-48a1-b5fd-b21354eb0eb4"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4665));

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

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("0b3c088e-7185-4af6-94e5-bf11e29ce628"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("0d63d379-f630-4064-bc9b-70bde09d3801"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("10a818a6-b3df-41de-a69a-b451380343e5"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("51137603-5df7-4d2d-8f30-799ef5a7dc12"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("51373385-dce2-458c-a06b-9b20625b7702"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("60537445-cb83-45d0-8c80-bf7368bc90c9"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("6098473e-8156-4328-a5bc-ef7f5af422de"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("76a48392-0e58-496a-ae78-562df47896b7"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("81d1012f-7b0a-421f-86b9-4d47ad266574"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("b2d2b1b0-c634-4a22-953e-45227a9af902"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "skill",
                keyColumn: "skl_skill_id",
                keyValue: new Guid("f1ffa467-0220-487c-8afe-66ca42328365"),
                column: "created_at",
                value: new DateTime(2024, 6, 8, 6, 58, 25, 966, DateTimeKind.Utc).AddTicks(4696));

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

            migrationBuilder.AddForeignKey(
                name: "FK_role_per_skill_role_rol_role_id",
                table: "role_per_skill",
                column: "rol_role_id",
                principalTable: "role",
                principalColumn: "rol_role_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
