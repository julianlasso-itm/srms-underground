﻿// <auto-generated />
using System;
using AccessControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240427033824_Correction23")]
    partial class Correction23
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.RoleModel", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("rol_role_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("rol_description");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("rol_disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("rol_name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("RoleId");

                    b.HasIndex("Name", "DeletedAt")
                        .IsUnique();

                    b.ToTable("tbl_role");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("7981d92c-ced8-448f-b545-7fda62b414b8"),
                            CreatedAt = new DateTime(2024, 4, 27, 3, 38, 24, 754, DateTimeKind.Utc).AddTicks(2441),
                            Description = "Admin role",
                            Disabled = false,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = new Guid("e1c3192a-0268-4f5c-9baf-0f8c46bb6dd7"),
                            CreatedAt = new DateTime(2024, 4, 27, 3, 38, 24, 754, DateTimeKind.Utc).AddTicks(2447),
                            Description = "User role",
                            Disabled = false,
                            Name = "User"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
