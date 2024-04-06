﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_ef_simple_rpg_web_api.Data;

#nullable disable

namespace dotnet_ef_simple_rpg_web_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("CharacterWeapon", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("CharacterWeapon");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Wisdom")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fights")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Victories")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = 5,
                            Defeats = 0,
                            Defense = 60,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 90,
                            Name = "TestCharacter1",
                            Strength = 60,
                            UserId = 1,
                            Victories = 0
                        },
                        new
                        {
                            Id = 2,
                            Class = 1,
                            Defeats = 0,
                            Defense = 50,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 80,
                            Name = "TestCharacter2",
                            Strength = 50,
                            UserId = 2,
                            Victories = 0
                        },
                        new
                        {
                            Id = 3,
                            Class = 1,
                            Defeats = 0,
                            Defense = 50,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 80,
                            Name = "TestCharacter3",
                            Strength = 50,
                            UserId = 2,
                            Victories = 0
                        });
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Complexity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Player");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 255, 254, 7, 155, 47, 133, 91, 167, 236, 59, 51, 186, 50, 235, 61, 241, 61, 7, 249, 200, 236, 219, 224, 124, 187, 187, 68, 135, 112, 13, 198, 4, 160, 49, 142, 182, 215, 214, 100, 96, 111, 1, 168, 233, 210, 105, 69, 112, 235, 179, 160, 251, 243, 34, 219, 246, 64, 213, 186, 95, 189, 252, 23, 148 },
                            PasswordSalt = new byte[] { 121, 253, 226, 0, 78, 156, 196, 60, 33, 67, 39, 194, 178, 239, 100, 25, 108, 254, 253, 133, 31, 51, 43, 178, 112, 205, 52, 210, 202, 239, 155, 49, 225, 146, 207, 48, 32, 14, 41, 243, 198, 42, 228, 202, 219, 104, 118, 207, 27, 246, 57, 172, 245, 131, 191, 236, 254, 206, 167, 174, 99, 9, 138, 100, 32, 33, 191, 115, 36, 131, 143, 185, 22, 175, 86, 113, 95, 163, 202, 11, 172, 17, 174, 125, 233, 90, 214, 1, 165, 128, 56, 78, 98, 102, 108, 223, 22, 64, 102, 109, 254, 247, 26, 87, 56, 214, 237, 57, 53, 2, 98, 17, 140, 193, 160, 170, 189, 139, 129, 164, 39, 26, 40, 62, 130, 64, 104, 229 },
                            Role = "",
                            Username = "TestUser1"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = new byte[] { 255, 254, 7, 155, 47, 133, 91, 167, 236, 59, 51, 186, 50, 235, 61, 241, 61, 7, 249, 200, 236, 219, 224, 124, 187, 187, 68, 135, 112, 13, 198, 4, 160, 49, 142, 182, 215, 214, 100, 96, 111, 1, 168, 233, 210, 105, 69, 112, 235, 179, 160, 251, 243, 34, 219, 246, 64, 213, 186, 95, 189, 252, 23, 148 },
                            PasswordSalt = new byte[] { 121, 253, 226, 0, 78, 156, 196, 60, 33, 67, 39, 194, 178, 239, 100, 25, 108, 254, 253, 133, 31, 51, 43, 178, 112, 205, 52, 210, 202, 239, 155, 49, 225, 146, 207, 48, 32, 14, 41, 243, 198, 42, 228, 202, 219, 104, 118, 207, 27, 246, 57, 172, 245, 131, 191, 236, 254, 206, 167, 174, 99, 9, 138, 100, 32, 33, 191, 115, 36, 131, 143, 185, 22, 175, 86, 113, 95, 163, 202, 11, 172, 17, 174, 125, 233, 90, 214, 1, 165, 128, 56, 78, 98, 102, 108, 223, 22, 64, 102, 109, 254, 247, 26, 87, 56, 214, 237, 57, 53, 2, 98, 17, 140, 193, 160, 170, 189, 139, 129, 164, 39, 26, 40, 62, 130, 64, 104, 229 },
                            Role = "",
                            Username = "TestUser2"
                        });
                });

            modelBuilder.Entity("dotnet_ef_simple_rpg_web_api.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
