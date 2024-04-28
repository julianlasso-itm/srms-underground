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
    [Migration("20240421031744_Correction8")]
    partial class Correction8
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
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("usr_user_id");

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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("usr_password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("Email", "DeletedAt")
                        .IsUnique();

                    b.HasIndex("Email", "Password");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("AccessControl.Infrastructure.Persistence.Models.UserPerRoleModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_role_id");

                    b.Property<Guid>("UserPerRoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("upr_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("tbl_user_per_role");
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