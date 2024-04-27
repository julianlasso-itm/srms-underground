using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Profiles.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_country",
                columns: new[] { "ctr_country_id", "ctr_disabled", "ctr_name" },
                values: new object[] { new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Colombia" });

            migrationBuilder.InsertData(
                table: "tbl_province",
                columns: new[] { "prv_province_id", "ctr_country_id", "prv_disabled", "prv_name" },
                values: new object[,]
                {
                    { new Guid("04fd8da1-4697-40d1-8c36-e19dbec98562"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "San Andrés y Providencia" },
                    { new Guid("090758f1-8666-4bb5-89f0-db8e154cee56"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Putumayo" },
                    { new Guid("099bdbd0-b33f-420b-9a47-7d1981d3b0ea"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Sucre" },
                    { new Guid("11abad68-b73f-48e3-a8ea-3061cf443638"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Vichada" },
                    { new Guid("1b489446-0ac4-466f-ad8b-33401107e38e"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Guaviare" },
                    { new Guid("1bd8ee39-acfc-4698-af69-50482e771bf8"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Bolívar" },
                    { new Guid("20703693-f1e1-47df-aced-f2fb026121f0"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Chocó" },
                    { new Guid("389cc7dd-b657-47cf-91d9-03bb7a07a387"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Caquetá" },
                    { new Guid("58989ded-a4de-4b43-a8af-3edcc83a3a93"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Cundinamarca" },
                    { new Guid("5e1af82f-834e-4caa-bfb7-cd92d08c92d6"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Nariño" },
                    { new Guid("70e699cd-d61b-4442-8dbe-975ac58b5f6a"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Valle del Cauca" },
                    { new Guid("7268d451-86a4-49e0-9720-aae1df9d3381"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Risaralda" },
                    { new Guid("786717f0-a4a6-4610-bf16-8b602f868a66"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Meta" },
                    { new Guid("881810ca-5d93-4a0a-adb6-1938069d7b83"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Córdoba" },
                    { new Guid("8899a64c-cb80-4e17-ae51-6138202c80b1"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Cesar" },
                    { new Guid("9130e757-5e7d-4a02-9177-3740c9d9a1d8"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Guainía" },
                    { new Guid("a5cc110a-3f46-448f-a09e-388b10c0dc7a"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Santander" },
                    { new Guid("b7f674a8-94fe-4ec1-8611-1b5c48ea2e27"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Quindío" },
                    { new Guid("c3b369e5-3eaf-4fdb-8645-ebe737af0a1f"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Tolima" },
                    { new Guid("c51dbd19-e282-478e-bd00-5c0fe649f22c"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "La Guajira" },
                    { new Guid("ccd1f1e8-5362-47f3-b756-45638205937e"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Atlántico" },
                    { new Guid("ccda11b3-cbfc-4039-bf79-8a45e0bd6a3d"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Norte de Santander" },
                    { new Guid("ce5e384b-aba3-419f-b44a-838d14fef4d4"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Amazonas" },
                    { new Guid("d1884472-3261-4d4e-baa4-1e9ab16d7009"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Vaupés" },
                    { new Guid("d58ad120-0875-471b-a094-9bf4f9614501"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Cauca" },
                    { new Guid("d5903001-75aa-4019-b730-77d39df3bc9f"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Huila" },
                    { new Guid("ddc81f77-5305-40c9-af13-c79f5b11651f"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Casanare" },
                    { new Guid("e9a5d171-872f-433a-b2f8-387d4bd0f7da"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Arauca" },
                    { new Guid("f04849cf-b20f-4b68-ba5c-d530860e877a"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Boyacá" },
                    { new Guid("f0abb4fa-14a1-4029-93e4-378bd229e68f"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Magdalena" },
                    { new Guid("f54ef90c-652d-4b02-84bd-a59922663c0d"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Antioquia" },
                    { new Guid("fe6f20de-70e1-4e93-8bf9-1a7a9c52b4e3"), new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"), false, "Caldas" }
                });

            migrationBuilder.InsertData(
                table: "tbl_city",
                columns: new[] { "cty_city_id", "cty_disabled", "cty_name", "prv_province_id" },
                values: new object[,]
                {
                    { new Guid("0800e16d-ff09-4262-9956-68131fc99774"), false, "Santa Rosa de Cabal", new Guid("7268d451-86a4-49e0-9720-aae1df9d3381") },
                    { new Guid("0d3a78b7-9748-4980-881f-ca52e9a4fd44"), false, "Leticia", new Guid("ce5e384b-aba3-419f-b44a-838d14fef4d4") },
                    { new Guid("0fe38acc-f285-45a1-8dfb-35194a2c5ade"), false, "Acacias", new Guid("786717f0-a4a6-4610-bf16-8b602f868a66") },
                    { new Guid("13f5a516-b244-488f-a263-363126e216b3"), false, "Turbo", new Guid("f54ef90c-652d-4b02-84bd-a59922663c0d") },
                    { new Guid("1544c036-b337-4f38-855d-83e58a1000ca"), false, "Lorica", new Guid("881810ca-5d93-4a0a-adb6-1938069d7b83") },
                    { new Guid("158dad12-ea5b-4ff4-b923-70219f582fcf"), false, "Puerto Carreño", new Guid("11abad68-b73f-48e3-a8ea-3061cf443638") },
                    { new Guid("179c0d95-4c35-40ea-8ac4-17ee2bd63cbc"), false, "Saravena", new Guid("e9a5d171-872f-433a-b2f8-387d4bd0f7da") },
                    { new Guid("1b045edd-0593-4cc1-8bc9-10d58063c258"), false, "Barranquilla", new Guid("ccd1f1e8-5362-47f3-b756-45638205937e") },
                    { new Guid("2191c05b-91e1-467b-8479-31b125c9794b"), false, "Memarí", new Guid("9130e757-5e7d-4a02-9177-3740c9d9a1d8") },
                    { new Guid("22785934-2b8b-4c15-8c6b-7cac71e7683d"), false, "Popayán", new Guid("d58ad120-0875-471b-a094-9bf4f9614501") },
                    { new Guid("255cd525-d9f7-4ec0-b80b-3aaa74ef7996"), false, "Tunja", new Guid("f04849cf-b20f-4b68-ba5c-d530860e877a") },
                    { new Guid("25d40856-cf7a-4819-9a0a-a321a43e0991"), false, "Apartadó", new Guid("f54ef90c-652d-4b02-84bd-a59922663c0d") },
                    { new Guid("2c84ddae-25b8-4927-bb54-f8eff025f2df"), false, "San José del Guaviare", new Guid("1b489446-0ac4-466f-ad8b-33401107e38e") },
                    { new Guid("2eaca892-fed7-4cd7-80fa-7d40c6cbb33f"), false, "Ipiales", new Guid("5e1af82f-834e-4caa-bfb7-cd92d08c92d6") },
                    { new Guid("2fba9e64-05ef-4115-a696-cea384b4d316"), false, "Tauramena", new Guid("ddc81f77-5305-40c9-af13-c79f5b11651f") },
                    { new Guid("3028b426-7a77-4104-8add-9e724846e43b"), false, "Calamar", new Guid("1b489446-0ac4-466f-ad8b-33401107e38e") },
                    { new Guid("3280138e-5210-4a36-b5bb-16ee5e2b37aa"), false, "Santander de Quilichao", new Guid("d58ad120-0875-471b-a094-9bf4f9614501") },
                    { new Guid("32a59e02-520b-495a-966c-21840b69efcd"), false, "Maicao", new Guid("c51dbd19-e282-478e-bd00-5c0fe649f22c") },
                    { new Guid("399c336e-0757-4744-b887-28cfe237a122"), false, "La Paz", new Guid("8899a64c-cb80-4e17-ae51-6138202c80b1") },
                    { new Guid("3b08acfc-0f80-4dc3-b6de-22c5355bb396"), false, "Pereira", new Guid("fe6f20de-70e1-4e93-8bf9-1a7a9c52b4e3") },
                    { new Guid("3b6e69fa-f45a-4cc7-b67a-326f8849d162"), false, "Honda", new Guid("c3b369e5-3eaf-4fdb-8645-ebe737af0a1f") },
                    { new Guid("3c5024a1-7af5-4b32-b606-ce14e5119afc"), false, "Morelia", new Guid("389cc7dd-b657-47cf-91d9-03bb7a07a387") },
                    { new Guid("3c5d44b7-5a5e-4f9a-bca7-443f8ac3756c"), false, "Orito", new Guid("090758f1-8666-4bb5-89f0-db8e154cee56") },
                    { new Guid("3cc178c7-6c76-40df-b2cc-1603a9fe3b6e"), false, "Soacha", new Guid("58989ded-a4de-4b43-a8af-3edcc83a3a93") },
                    { new Guid("3f36f6bf-cc28-44f9-a8da-9b2616b3f367"), false, "Pereira", new Guid("7268d451-86a4-49e0-9720-aae1df9d3381") },
                    { new Guid("41229003-6040-43e4-b839-6c3443b3a8c1"), false, "Santa Rosalía", new Guid("d1884472-3261-4d4e-baa4-1e9ab16d7009") },
                    { new Guid("42f44b93-efb1-489d-aa74-60c3cf6260b4"), false, "Villavicencio", new Guid("786717f0-a4a6-4610-bf16-8b602f868a66") },
                    { new Guid("481db274-cb9b-4288-b865-3d1cb4ac8130"), false, "Medellín", new Guid("f54ef90c-652d-4b02-84bd-a59922663c0d") },
                    { new Guid("493f526e-e568-42af-a65f-2b7ffe02c944"), false, "Corozal", new Guid("099bdbd0-b33f-420b-9a47-7d1981d3b0ea") },
                    { new Guid("4d469620-1d69-46bb-ba2f-e079b7ec2522"), false, "Cartagena del Chairá", new Guid("389cc7dd-b657-47cf-91d9-03bb7a07a387") },
                    { new Guid("5173b5a4-208b-4921-9135-ed7350049f4a"), false, "Montería", new Guid("099bdbd0-b33f-420b-9a47-7d1981d3b0ea") },
                    { new Guid("5442606c-2813-4ddf-a8df-c3af215026ab"), false, "Silvia", new Guid("d58ad120-0875-471b-a094-9bf4f9614501") },
                    { new Guid("59cdcd53-7c79-4ee5-a008-838ba369aaa4"), false, "Puerto Inírida", new Guid("9130e757-5e7d-4a02-9177-3740c9d9a1d8") },
                    { new Guid("5b65889b-5cc9-48a2-a2a1-b9009517ea35"), false, "Montería", new Guid("881810ca-5d93-4a0a-adb6-1938069d7b83") },
                    { new Guid("5b843414-f9f6-4ffd-8afb-d227af6d5d8b"), false, "Yavaraté", new Guid("d1884472-3261-4d4e-baa4-1e9ab16d7009") },
                    { new Guid("5dc9907a-36c5-4e82-abd9-505bdfdb340d"), false, "Armero Guayabal", new Guid("c3b369e5-3eaf-4fdb-8645-ebe737af0a1f") },
                    { new Guid("61fc82fb-4666-4475-98a8-b689d4697c32"), false, "Neiva", new Guid("d5903001-75aa-4019-b730-77d39df3bc9f") },
                    { new Guid("620fa1c2-63ee-4f70-b4e0-a65c4f770b1f"), false, "Tumaco", new Guid("5e1af82f-834e-4caa-bfb7-cd92d08c92d6") },
                    { new Guid("64e42a67-a0bc-4c6f-85a3-662c038eea4b"), false, "Santa Helena", new Guid("11abad68-b73f-48e3-a8ea-3061cf443638") },
                    { new Guid("65319d15-395a-40ae-bd7a-8255fc5fa655"), false, "Bogotá", new Guid("58989ded-a4de-4b43-a8af-3edcc83a3a93") },
                    { new Guid("67e6d8c0-fb3a-4ec6-aacc-8db78d63c3de"), false, "Cúcuta", new Guid("ccda11b3-cbfc-4039-bf79-8a45e0bd6a3d") },
                    { new Guid("6b232557-c332-4b64-b29d-3f870495047e"), false, "Palmira", new Guid("70e699cd-d61b-4442-8dbe-975ac58b5f6a") },
                    { new Guid("6fde4c3d-ce52-44f1-be2b-24eb4b9c8685"), false, "Santa Catalina", new Guid("04fd8da1-4697-40d1-8c36-e19dbec98562") },
                    { new Guid("704c67f5-47c7-404e-820a-3a02a111bb54"), false, "Sincelejo", new Guid("099bdbd0-b33f-420b-9a47-7d1981d3b0ea") },
                    { new Guid("72cbd880-fcb1-4545-b4ca-fdcb9b4d621b"), false, "San Juan de Pasto", new Guid("5e1af82f-834e-4caa-bfb7-cd92d08c92d6") },
                    { new Guid("7574eb5f-521c-422c-bc90-5ab108c2b114"), false, "Inírida", new Guid("9130e757-5e7d-4a02-9177-3740c9d9a1d8") },
                    { new Guid("799ef8ad-e489-491a-a9f1-8f87afe95df5"), false, "Puerto Colombia", new Guid("ccd1f1e8-5362-47f3-b756-45638205937e") },
                    { new Guid("7a002051-e080-4cc7-8a18-7f5817384ba0"), false, "El Retén", new Guid("1b489446-0ac4-466f-ad8b-33401107e38e") },
                    { new Guid("7b073ff5-d9c6-404b-9262-e1b57db51fc8"), false, "Barrancabermeja", new Guid("a5cc110a-3f46-448f-a09e-388b10c0dc7a") },
                    { new Guid("7ca6476c-f743-44fb-8315-462255835295"), false, "Novita", new Guid("20703693-f1e1-47df-aced-f2fb026121f0") },
                    { new Guid("7d98eb82-5857-4e54-b11f-fd8d135bab61"), false, "Arauca", new Guid("e9a5d171-872f-433a-b2f8-387d4bd0f7da") },
                    { new Guid("7f778bc0-0cf2-4b1e-93cf-7103d0ca6760"), false, "La Primavera", new Guid("11abad68-b73f-48e3-a8ea-3061cf443638") },
                    { new Guid("805eb4ce-b9f6-490b-9593-d39c1bec8caa"), false, "Mocoa", new Guid("090758f1-8666-4bb5-89f0-db8e154cee56") },
                    { new Guid("81b7f7b0-bb96-444c-8fb2-d021e7fdf820"), false, "Mitú", new Guid("d1884472-3261-4d4e-baa4-1e9ab16d7009") },
                    { new Guid("851c754b-103a-4349-a317-1c3d2945a4fd"), false, "Duitama", new Guid("f04849cf-b20f-4b68-ba5c-d530860e877a") },
                    { new Guid("91c519c4-caeb-4c50-9dde-6732138881ba"), false, "Riohacha", new Guid("c51dbd19-e282-478e-bd00-5c0fe649f22c") },
                    { new Guid("95399b79-1283-4a04-ba1a-dc18ae82e8d7"), false, "Ibagué", new Guid("c3b369e5-3eaf-4fdb-8645-ebe737af0a1f") },
                    { new Guid("96b3e15d-3e64-47b4-ba27-c1a36d11cbef"), false, "Granada", new Guid("786717f0-a4a6-4610-bf16-8b602f868a66") },
                    { new Guid("9c4c67d6-0691-4475-ac9f-3228b7a7f0ec"), false, "Cartagena de Indias", new Guid("1bd8ee39-acfc-4698-af69-50482e771bf8") },
                    { new Guid("9cb18f45-f483-407f-a777-9f5065ea8b96"), false, "Quibdó", new Guid("20703693-f1e1-47df-aced-f2fb026121f0") },
                    { new Guid("a2c932b8-603c-49ef-80fb-c720be803be7"), false, "Cartagena del Chairá", new Guid("1bd8ee39-acfc-4698-af69-50482e771bf8") },
                    { new Guid("a53524a6-fd40-46e7-b65e-e4294711ef7b"), false, "Valledupar", new Guid("8899a64c-cb80-4e17-ae51-6138202c80b1") },
                    { new Guid("a5c64622-8acd-4ae6-8bcb-8c36d79d3468"), false, "Magangué", new Guid("1bd8ee39-acfc-4698-af69-50482e771bf8") },
                    { new Guid("ac638403-2b43-4bc2-a373-458908c81d52"), false, "Fortul", new Guid("e9a5d171-872f-433a-b2f8-387d4bd0f7da") },
                    { new Guid("ae8a1214-a04d-4946-bdba-cfe9a13344a0"), false, "Yopal", new Guid("ddc81f77-5305-40c9-af13-c79f5b11651f") },
                    { new Guid("afabcce2-8dde-4411-989f-671d36333b07"), false, "Sogamoso", new Guid("f04849cf-b20f-4b68-ba5c-d530860e877a") },
                    { new Guid("b027cf51-af86-4d0c-839f-4ad9f90c1d2f"), false, "Istmina", new Guid("20703693-f1e1-47df-aced-f2fb026121f0") },
                    { new Guid("b84a2656-37f9-41d9-96c3-953df1fff6bb"), false, "Soledad", new Guid("ccd1f1e8-5362-47f3-b756-45638205937e") },
                    { new Guid("b92b434c-ff14-426d-b099-49d1b4a098b2"), false, "Dosquebradas", new Guid("7268d451-86a4-49e0-9720-aae1df9d3381") },
                    { new Guid("bcb666c4-ecf7-44bd-814b-b7b93a709018"), false, "Puerto Asís", new Guid("090758f1-8666-4bb5-89f0-db8e154cee56") },
                    { new Guid("bce2166c-4c0e-4a20-8d98-c65440bff943"), false, "Zipaquirá", new Guid("58989ded-a4de-4b43-a8af-3edcc83a3a93") },
                    { new Guid("bf17ce66-76df-40f3-b4a4-ab156f60485d"), false, "Providencia", new Guid("04fd8da1-4697-40d1-8c36-e19dbec98562") },
                    { new Guid("c168b859-799b-461a-b66f-63022df56688"), false, "Piedecuesta", new Guid("a5cc110a-3f46-448f-a09e-388b10c0dc7a") },
                    { new Guid("c2c14bdf-69da-499c-bf83-330606eec7d5"), false, "Santa Marta", new Guid("f0abb4fa-14a1-4029-93e4-378bd229e68f") },
                    { new Guid("c483c76c-764e-4fac-afd4-71e829b7051a"), false, "Ocaña", new Guid("ccda11b3-cbfc-4039-bf79-8a45e0bd6a3d") },
                    { new Guid("c55c1f6f-a272-4d1e-b701-ddec13d9730c"), false, "Pamplona", new Guid("ccda11b3-cbfc-4039-bf79-8a45e0bd6a3d") },
                    { new Guid("ca225c9a-388e-4109-886b-5858c0724e0a"), false, "Cereté", new Guid("881810ca-5d93-4a0a-adb6-1938069d7b83") },
                    { new Guid("cd963eec-60c4-49ec-b889-a843bb05e692"), false, "Pitalito", new Guid("d5903001-75aa-4019-b730-77d39df3bc9f") },
                    { new Guid("d075788c-2dec-4853-b6c7-eee49bffd002"), false, "Aguachica", new Guid("8899a64c-cb80-4e17-ae51-6138202c80b1") },
                    { new Guid("d2a88e9a-56e1-4be2-8b07-8795752f9514"), false, "Aguazul", new Guid("ddc81f77-5305-40c9-af13-c79f5b11651f") },
                    { new Guid("d2d5e823-de27-4c01-94d9-f683aaf2c328"), false, "Florencia", new Guid("389cc7dd-b657-47cf-91d9-03bb7a07a387") },
                    { new Guid("d42352e0-9ddc-4d30-9467-4420dcfc22d9"), false, "Bucaramanga", new Guid("a5cc110a-3f46-448f-a09e-388b10c0dc7a") },
                    { new Guid("dd0865f2-b9fb-4fdc-903c-15a86ba3d174"), false, "Calarcá", new Guid("b7f674a8-94fe-4ec1-8611-1b5c48ea2e27") },
                    { new Guid("e09babeb-337c-49aa-a045-2e5a4306bf1c"), false, "Uribia", new Guid("c51dbd19-e282-478e-bd00-5c0fe649f22c") },
                    { new Guid("e0d9f4f6-531f-41a0-bfc6-92a2a2098ae4"), false, "Armenia", new Guid("b7f674a8-94fe-4ec1-8611-1b5c48ea2e27") },
                    { new Guid("eaf55909-be22-403e-a544-1a429700d690"), false, "San Andrés", new Guid("04fd8da1-4697-40d1-8c36-e19dbec98562") },
                    { new Guid("ed328c11-41f8-43d2-872f-7267e3f118ff"), false, "Buenaventura", new Guid("70e699cd-d61b-4442-8dbe-975ac58b5f6a") },
                    { new Guid("f8540489-9171-4f3a-807b-4818e8019fdc"), false, "Ciénaga", new Guid("f0abb4fa-14a1-4029-93e4-378bd229e68f") },
                    { new Guid("f88bf612-fcbb-4cc8-913d-8c6dd7c5bdd1"), false, "Cali", new Guid("70e699cd-d61b-4442-8dbe-975ac58b5f6a") },
                    { new Guid("fa3cf363-f986-41d0-8c33-c06c923e8651"), false, "Garzón", new Guid("d5903001-75aa-4019-b730-77d39df3bc9f") },
                    { new Guid("fc943944-12a6-4247-a127-6c08fc9cb8ad"), false, "Aracataca", new Guid("f0abb4fa-14a1-4029-93e4-378bd229e68f") },
                    { new Guid("fdfb1d69-7b34-4446-ac7f-0d07d2fbf8f8"), false, "Manizales", new Guid("fe6f20de-70e1-4e93-8bf9-1a7a9c52b4e3") },
                    { new Guid("fe6de2fb-cc0d-4d18-ae16-e7afd31f9f0b"), false, "La Tebaida", new Guid("b7f674a8-94fe-4ec1-8611-1b5c48ea2e27") },
                    { new Guid("ff206d7e-c40d-4a0f-b96c-ef3068c47f2f"), false, "Chinchiná", new Guid("fe6f20de-70e1-4e93-8bf9-1a7a9c52b4e3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0800e16d-ff09-4262-9956-68131fc99774"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0d3a78b7-9748-4980-881f-ca52e9a4fd44"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("0fe38acc-f285-45a1-8dfb-35194a2c5ade"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("13f5a516-b244-488f-a263-363126e216b3"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1544c036-b337-4f38-855d-83e58a1000ca"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("158dad12-ea5b-4ff4-b923-70219f582fcf"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("179c0d95-4c35-40ea-8ac4-17ee2bd63cbc"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("1b045edd-0593-4cc1-8bc9-10d58063c258"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2191c05b-91e1-467b-8479-31b125c9794b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("22785934-2b8b-4c15-8c6b-7cac71e7683d"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("255cd525-d9f7-4ec0-b80b-3aaa74ef7996"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("25d40856-cf7a-4819-9a0a-a321a43e0991"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2c84ddae-25b8-4927-bb54-f8eff025f2df"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2eaca892-fed7-4cd7-80fa-7d40c6cbb33f"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("2fba9e64-05ef-4115-a696-cea384b4d316"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3028b426-7a77-4104-8add-9e724846e43b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3280138e-5210-4a36-b5bb-16ee5e2b37aa"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("32a59e02-520b-495a-966c-21840b69efcd"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("399c336e-0757-4744-b887-28cfe237a122"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3b08acfc-0f80-4dc3-b6de-22c5355bb396"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3b6e69fa-f45a-4cc7-b67a-326f8849d162"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3c5024a1-7af5-4b32-b606-ce14e5119afc"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3c5d44b7-5a5e-4f9a-bca7-443f8ac3756c"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3cc178c7-6c76-40df-b2cc-1603a9fe3b6e"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("3f36f6bf-cc28-44f9-a8da-9b2616b3f367"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("41229003-6040-43e4-b839-6c3443b3a8c1"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("42f44b93-efb1-489d-aa74-60c3cf6260b4"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("481db274-cb9b-4288-b865-3d1cb4ac8130"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("493f526e-e568-42af-a65f-2b7ffe02c944"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("4d469620-1d69-46bb-ba2f-e079b7ec2522"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5173b5a4-208b-4921-9135-ed7350049f4a"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5442606c-2813-4ddf-a8df-c3af215026ab"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("59cdcd53-7c79-4ee5-a008-838ba369aaa4"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5b65889b-5cc9-48a2-a2a1-b9009517ea35"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5b843414-f9f6-4ffd-8afb-d227af6d5d8b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("5dc9907a-36c5-4e82-abd9-505bdfdb340d"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("61fc82fb-4666-4475-98a8-b689d4697c32"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("620fa1c2-63ee-4f70-b4e0-a65c4f770b1f"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("64e42a67-a0bc-4c6f-85a3-662c038eea4b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("65319d15-395a-40ae-bd7a-8255fc5fa655"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("67e6d8c0-fb3a-4ec6-aacc-8db78d63c3de"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6b232557-c332-4b64-b29d-3f870495047e"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("6fde4c3d-ce52-44f1-be2b-24eb4b9c8685"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("704c67f5-47c7-404e-820a-3a02a111bb54"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("72cbd880-fcb1-4545-b4ca-fdcb9b4d621b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7574eb5f-521c-422c-bc90-5ab108c2b114"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("799ef8ad-e489-491a-a9f1-8f87afe95df5"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7a002051-e080-4cc7-8a18-7f5817384ba0"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7b073ff5-d9c6-404b-9262-e1b57db51fc8"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7ca6476c-f743-44fb-8315-462255835295"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7d98eb82-5857-4e54-b11f-fd8d135bab61"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("7f778bc0-0cf2-4b1e-93cf-7103d0ca6760"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("805eb4ce-b9f6-490b-9593-d39c1bec8caa"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("81b7f7b0-bb96-444c-8fb2-d021e7fdf820"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("851c754b-103a-4349-a317-1c3d2945a4fd"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("91c519c4-caeb-4c50-9dde-6732138881ba"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("95399b79-1283-4a04-ba1a-dc18ae82e8d7"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("96b3e15d-3e64-47b4-ba27-c1a36d11cbef"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9c4c67d6-0691-4475-ac9f-3228b7a7f0ec"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("9cb18f45-f483-407f-a777-9f5065ea8b96"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a2c932b8-603c-49ef-80fb-c720be803be7"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a53524a6-fd40-46e7-b65e-e4294711ef7b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("a5c64622-8acd-4ae6-8bcb-8c36d79d3468"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ac638403-2b43-4bc2-a373-458908c81d52"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ae8a1214-a04d-4946-bdba-cfe9a13344a0"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("afabcce2-8dde-4411-989f-671d36333b07"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b027cf51-af86-4d0c-839f-4ad9f90c1d2f"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b84a2656-37f9-41d9-96c3-953df1fff6bb"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("b92b434c-ff14-426d-b099-49d1b4a098b2"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("bcb666c4-ecf7-44bd-814b-b7b93a709018"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("bce2166c-4c0e-4a20-8d98-c65440bff943"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("bf17ce66-76df-40f3-b4a4-ab156f60485d"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c168b859-799b-461a-b66f-63022df56688"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c2c14bdf-69da-499c-bf83-330606eec7d5"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c483c76c-764e-4fac-afd4-71e829b7051a"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("c55c1f6f-a272-4d1e-b701-ddec13d9730c"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ca225c9a-388e-4109-886b-5858c0724e0a"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("cd963eec-60c4-49ec-b889-a843bb05e692"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d075788c-2dec-4853-b6c7-eee49bffd002"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d2a88e9a-56e1-4be2-8b07-8795752f9514"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d2d5e823-de27-4c01-94d9-f683aaf2c328"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("d42352e0-9ddc-4d30-9467-4420dcfc22d9"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("dd0865f2-b9fb-4fdc-903c-15a86ba3d174"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e09babeb-337c-49aa-a045-2e5a4306bf1c"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("e0d9f4f6-531f-41a0-bfc6-92a2a2098ae4"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("eaf55909-be22-403e-a544-1a429700d690"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ed328c11-41f8-43d2-872f-7267e3f118ff"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f8540489-9171-4f3a-807b-4818e8019fdc"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("f88bf612-fcbb-4cc8-913d-8c6dd7c5bdd1"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fa3cf363-f986-41d0-8c33-c06c923e8651"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fc943944-12a6-4247-a127-6c08fc9cb8ad"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fdfb1d69-7b34-4446-ac7f-0d07d2fbf8f8"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("fe6de2fb-cc0d-4d18-ae16-e7afd31f9f0b"));

            migrationBuilder.DeleteData(
                table: "tbl_city",
                keyColumn: "cty_city_id",
                keyValue: new Guid("ff206d7e-c40d-4a0f-b96c-ef3068c47f2f"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("04fd8da1-4697-40d1-8c36-e19dbec98562"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("090758f1-8666-4bb5-89f0-db8e154cee56"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("099bdbd0-b33f-420b-9a47-7d1981d3b0ea"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("11abad68-b73f-48e3-a8ea-3061cf443638"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("1b489446-0ac4-466f-ad8b-33401107e38e"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("1bd8ee39-acfc-4698-af69-50482e771bf8"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("20703693-f1e1-47df-aced-f2fb026121f0"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("389cc7dd-b657-47cf-91d9-03bb7a07a387"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("58989ded-a4de-4b43-a8af-3edcc83a3a93"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("5e1af82f-834e-4caa-bfb7-cd92d08c92d6"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("70e699cd-d61b-4442-8dbe-975ac58b5f6a"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("7268d451-86a4-49e0-9720-aae1df9d3381"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("786717f0-a4a6-4610-bf16-8b602f868a66"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("881810ca-5d93-4a0a-adb6-1938069d7b83"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("8899a64c-cb80-4e17-ae51-6138202c80b1"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("9130e757-5e7d-4a02-9177-3740c9d9a1d8"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("a5cc110a-3f46-448f-a09e-388b10c0dc7a"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("b7f674a8-94fe-4ec1-8611-1b5c48ea2e27"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("c3b369e5-3eaf-4fdb-8645-ebe737af0a1f"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("c51dbd19-e282-478e-bd00-5c0fe649f22c"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ccd1f1e8-5362-47f3-b756-45638205937e"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ccda11b3-cbfc-4039-bf79-8a45e0bd6a3d"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ce5e384b-aba3-419f-b44a-838d14fef4d4"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d1884472-3261-4d4e-baa4-1e9ab16d7009"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d58ad120-0875-471b-a094-9bf4f9614501"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("d5903001-75aa-4019-b730-77d39df3bc9f"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("ddc81f77-5305-40c9-af13-c79f5b11651f"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("e9a5d171-872f-433a-b2f8-387d4bd0f7da"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("f04849cf-b20f-4b68-ba5c-d530860e877a"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("f0abb4fa-14a1-4029-93e4-378bd229e68f"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("f54ef90c-652d-4b02-84bd-a59922663c0d"));

            migrationBuilder.DeleteData(
                table: "tbl_province",
                keyColumn: "prv_province_id",
                keyValue: new Guid("fe6f20de-70e1-4e93-8bf9-1a7a9c52b4e3"));

            migrationBuilder.DeleteData(
                table: "tbl_country",
                keyColumn: "ctr_country_id",
                keyValue: new Guid("39a4f539-8bf5-4fbc-8db8-b09c1d75146f"));
        }
    }
}
