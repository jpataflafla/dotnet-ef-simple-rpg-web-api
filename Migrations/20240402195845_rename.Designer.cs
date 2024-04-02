﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_ef_simple_rpg_web_api.Data;

#nullable disable

namespace dotnet_ef_simple_rpg_web_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240402195845_rename")]
    partial class rename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("CharacterWeapon", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("CharacterWeapon");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wisdom")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Fights")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Complexity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Complexity = 90,
                            Name = "Healing"
                        },
                        new
                        {
                            Id = 2,
                            Complexity = 70,
                            Name = "Law"
                        },
                        new
                        {
                            Id = 3,
                            Complexity = 40,
                            Name = "Poetry"
                        },
                        new
                        {
                            Id = 4,
                            Complexity = 22,
                            Name = "Swimming"
                        },
                        new
                        {
                            Id = 5,
                            Complexity = 15,
                            Name = "Dancing"
                        },
                        new
                        {
                            Id = 6,
                            Complexity = 99,
                            Name = "Teleportation"
                        },
                        new
                        {
                            Id = 7,
                            Complexity = 80,
                            Name = "Herbalism"
                        });
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 30,
                            Name = "Hammer"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 40,
                            Name = "Axe"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 40,
                            Name = "Bow"
                        },
                        new
                        {
                            Id = 4,
                            Damage = 42,
                            Name = "Crossbow"
                        },
                        new
                        {
                            Id = 5,
                            Damage = 55,
                            Name = "Wand"
                        },
                        new
                        {
                            Id = 6,
                            Damage = 30,
                            Name = "Whip"
                        },
                        new
                        {
                            Id = 7,
                            Damage = 10,
                            Name = "Hot Potato"
                        });
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterWeapon", b =>
                {
                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Book", b =>
                {
                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.Character", "Character")
                        .WithOne("Book")
                        .HasForeignKey("dotnet_ef_simple_rpg_web_api.Models.Book", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Character", b =>
                {
                    b.HasOne("dotnet_ef_simple_rpg_web_api.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Character", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
