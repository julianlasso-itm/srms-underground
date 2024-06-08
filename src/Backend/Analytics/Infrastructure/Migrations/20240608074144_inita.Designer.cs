﻿// <auto-generated />
using System;
using Analytics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Analytics.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240608074144_inita")]
    partial class inita
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Analytics.Infrastructure.Persistence.Models.LevelModel", b =>
                {
                    b.Property<Guid>("LevelId")
                        .HasColumnType("uuid")
                        .HasColumnName("rol_level_id");

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

                    b.HasKey("LevelId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("level");

                    b.HasData(
                        new
                        {
                            LevelId = new Guid("a0612b52-bb9c-4ea6-be02-2b8965339a08"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5144),
                            Disabled = false,
                            Name = "Backend"
                        },
                        new
                        {
                            LevelId = new Guid("ae7b127e-4074-4e90-8f70-d0a036fa4134"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5150),
                            Disabled = false,
                            Name = "Frontend"
                        },
                        new
                        {
                            LevelId = new Guid("a0c52685-662a-4722-adea-0fb65f2cbf64"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5152),
                            Disabled = false,
                            Name = "Fullstack"
                        },
                        new
                        {
                            LevelId = new Guid("6bed3a66-867f-4880-8cf1-9deb3cfa913d"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5154),
                            Disabled = false,
                            Name = "DevOps"
                        },
                        new
                        {
                            LevelId = new Guid("5d1414f4-3699-4143-b9b8-13801e6118d6"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5191),
                            Disabled = false,
                            Name = "QA"
                        },
                        new
                        {
                            LevelId = new Guid("a3f6bbfe-6db8-42fe-8013-01b90d484cef"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5196),
                            Disabled = false,
                            Name = "UX/UI"
                        },
                        new
                        {
                            LevelId = new Guid("dcea93f0-f262-4148-8d8c-94de0cadeb2b"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5197),
                            Disabled = false,
                            Name = "DataScience"
                        },
                        new
                        {
                            LevelId = new Guid("0008ff53-9070-4e0f-a512-2cf5567d16db"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5206),
                            Disabled = false,
                            Name = "Cybersecurity"
                        },
                        new
                        {
                            LevelId = new Guid("c88c745d-0dbb-4c1f-9060-d59c880d05c6"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5208),
                            Disabled = false,
                            Name = "Product"
                        },
                        new
                        {
                            LevelId = new Guid("2200279d-7d10-4f03-85c2-87e2d23d990b"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5210),
                            Disabled = false,
                            Name = "Project"
                        },
                        new
                        {
                            LevelId = new Guid("521ed0db-f80f-4b79-9f80-d2c78b2c0a53"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5212),
                            Disabled = false,
                            Name = "Management"
                        },
                        new
                        {
                            LevelId = new Guid("de00513e-1d7d-47d6-943f-56511636d4c4"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 41, 43, 481, DateTimeKind.Utc).AddTicks(5214),
                            Disabled = false,
                            Name = "Other"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
