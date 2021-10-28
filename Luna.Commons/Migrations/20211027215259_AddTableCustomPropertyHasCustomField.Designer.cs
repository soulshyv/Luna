﻿// <auto-generated />
using System;
using Luna.Commons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Luna.Commons.Migrations
{
    [DbContext(typeof(LunaDbContext))]
    [Migration("20211027215259_AddTableCustomPropertyHasCustomField")]
    partial class AddTableCustomPropertyHasCustomField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Luna.Commons.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RaceId")
                        .HasColumnName("race_id")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_character");
                });

            modelBuilder.Entity("Luna.Commons.Models.CharacterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_character_type");
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_custom_field");
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomSectionId")
                        .HasColumnName("section_id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("RaceId")
                        .HasColumnName("race_id")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CustomSectionId");

                    b.HasIndex("RaceId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_custom_property");
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomPropertyHasCustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<int>("FieldId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<int>("PropertyId")
                        .HasColumnName("type_id")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Valeur")
                        .IsRequired()
                        .HasColumnName("valeur")
                        .HasColumnType("blob");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_custom_property_has_custom_property");
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomPropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_custom_property_type");
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnName("character_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_custom_section");
                });

            modelBuilder.Entity("Luna.Commons.Models.Identity.LunaIdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("luna_identity_roles");
                });

            modelBuilder.Entity("Luna.Commons.Models.Identity.LunaIdentityUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("luna_identity_users");
                });

            modelBuilder.Entity("Luna.Commons.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Description")
                        .HasColumnName("description")
                        .HasColumnType("blob");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("luna_rpg_race");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("luna_identity_roles_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("luna_identity_users_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("luna_identity_users_logins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("luna_identity_users_roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("luna_identity_users_tokens");
                });

            modelBuilder.Entity("Luna.Commons.Models.Character", b =>
                {
                    b.HasOne("Luna.Commons.Models.Race", "Race")
                        .WithMany("Characters")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.CharacterType", "Type")
                        .WithMany("Characters")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CharacterType", b =>
                {
                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CharacterTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomField", b =>
                {
                    b.HasOne("Luna.Commons.Models.CustomPropertyType", "Type")
                        .WithMany("Fields")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CustomFields")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomProperty", b =>
                {
                    b.HasOne("Luna.Commons.Models.CustomSection", "CustomSection")
                        .WithMany("CustomProperties")
                        .HasForeignKey("CustomSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Race", "Race")
                        .WithMany("CustomProperties")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.CustomPropertyType", "Type")
                        .WithMany("CustomProperties")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CustomProperties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomPropertyHasCustomField", b =>
                {
                    b.HasOne("Luna.Commons.Models.CustomField", "CustomField")
                        .WithMany("CustomPropertyHasCustomFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.CustomProperty", "CustomProperty")
                        .WithMany("CustomPropertyHasCustomFields")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CustomPropertyHasCustomFields")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomPropertyType", b =>
                {
                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CustomPropertieTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.CustomSection", b =>
                {
                    b.HasOne("Luna.Commons.Models.Character", "Character")
                        .WithMany("CustomSections")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("CustomSections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luna.Commons.Models.Race", b =>
                {
                    b.HasOne("Luna.Commons.Models.Identity.LunaIdentityUser", "Author")
                        .WithMany("Races")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
