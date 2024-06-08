﻿// <auto-generated />
using System;
using AccessControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccessControl.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("be479847-3e9b-43c5-8674-6b4c908f008b"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7233),
                            Description = "Admin role",
                            Disabled = false,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = new Guid("137bcadf-79bb-47f4-8622-e7381c7664ae"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7263),
                            Description = "User role",
                            Disabled = false,
                            Name = "User"
                        },
                        new
                        {
                            RoleId = new Guid("befbf8c0-12b7-4be6-8d9f-206cb28ea342"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7266),
                            Description = "Guest role",
                            Disabled = false,
                            Name = "Guest"
                        },
                        new
                        {
                            RoleId = new Guid("0e5c4cc5-1478-4742-a440-82b4703b27f6"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7268),
                            Description = "SuperAdmin role",
                            Disabled = false,
                            Name = "SuperAdmin"
                        },
                        new
                        {
                            RoleId = new Guid("76aa8403-1a0c-4a33-88f1-89b8afe7a5dc"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7270),
                            Description = "Moderator role",
                            Disabled = false,
                            Name = "Moderator"
                        },
                        new
                        {
                            RoleId = new Guid("3e994edc-a2dd-436b-85dd-17c3f16896a5"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7276),
                            Description = "Editor role",
                            Disabled = false,
                            Name = "Editor"
                        },
                        new
                        {
                            RoleId = new Guid("84547c42-983d-49df-aa46-227f592be6ec"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7278),
                            Description = "Author role",
                            Disabled = false,
                            Name = "Author"
                        },
                        new
                        {
                            RoleId = new Guid("3311a781-bbee-4922-bce5-4d73b4072bfd"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7289),
                            Description = "Contributor role",
                            Disabled = false,
                            Name = "Contributor"
                        },
                        new
                        {
                            RoleId = new Guid("3d6b420d-83d8-4260-8953-ba1034eb3731"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7291),
                            Description = "Subscriber role",
                            Disabled = false,
                            Name = "Subscriber"
                        },
                        new
                        {
                            RoleId = new Guid("c038ad4d-1381-41f7-a869-d09ecdb32cc8"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7294),
                            Description = "Member role",
                            Disabled = false,
                            Name = "Member"
                        },
                        new
                        {
                            RoleId = new Guid("d72a2c4e-6bbb-465b-a909-a79e7d65b402"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7296),
                            Description = "Customer role",
                            Disabled = false,
                            Name = "Customer"
                        },
                        new
                        {
                            RoleId = new Guid("980f5928-35f7-482b-acf1-0ec081c055c9"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7342),
                            Description = "Client role",
                            Disabled = false,
                            Name = "Client"
                        },
                        new
                        {
                            RoleId = new Guid("8c3e752b-2362-453c-9d92-22d71f31c78e"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7344),
                            Description = "Viewer role",
                            Disabled = false,
                            Name = "Viewer"
                        },
                        new
                        {
                            RoleId = new Guid("7ed3ebaf-d36e-4f28-a576-3a295ed8d694"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7346),
                            Description = "Tester role",
                            Disabled = false,
                            Name = "Tester"
                        },
                        new
                        {
                            RoleId = new Guid("1a19359e-c935-48b4-ae8b-362336a9abd5"),
                            CreatedAt = new DateTime(2024, 6, 8, 7, 42, 20, 80, DateTimeKind.Utc).AddTicks(7348),
                            Description = "Developer role",
                            Disabled = false,
                            Name = "Developer"
                        });
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("usr_user_id");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid")
                        .HasColumnName("usr_city_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("usr_disabled");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("usr_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("usr_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("usr_password");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("usr_photo");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("Email", "DeletedAt")
                        .IsUnique();

                    b.HasIndex("Email", "Password");

                    b.ToTable("user");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserPerRoleModel", b =>
                {
                    b.Property<Guid>("UserPerRoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_role_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_user_id");

                    b.HasKey("UserPerRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("user_per_role");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserPerRoleModel", b =>
                {
                    b.HasOne("AccessControl.Infrastructure.Persistence.Models.RoleModel", "Role")
                        .WithMany("UserPerRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AccessControl.Infrastructure.Persistence.Models.UserModel", "User")
                        .WithMany("UserPerRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.RoleModel", b =>
                {
                    b.Navigation("UserPerRoles");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.Navigation("UserPerRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
