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
    [Migration("20240411160439_AddDescriptionToRole")]
    partial class AddDescriptionToRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("rol_role_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rol_created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rol_deleted_at");

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
                        .HasColumnName("rol_updated_at");

                    b.HasKey("RoleId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoleId", "DeletedAt")
                        .IsUnique();

                    b.ToTable("tbl_role");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("usr_user_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_deleted_at");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("usr_disabled");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("usr_email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("usr_password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("usr_updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserId", "DeletedAt")
                        .IsUnique();

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserPerRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_role_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("upr_created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("upr_deleted_at");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId", "DeletedAt")
                        .IsUnique();

                    b.ToTable("tbl_user_per_role");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserPerRole", b =>
                {
                    b.HasOne("AccessControl.Infrastructure.Persistence.Models.Role", "Role")
                        .WithMany("UserPerRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AccessControl.Infrastructure.Persistence.Models.User", "User")
                        .WithMany("UserPerRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.Role", b =>
                {
                    b.Navigation("UserPerRoles");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.User", b =>
                {
                    b.Navigation("UserPerRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
