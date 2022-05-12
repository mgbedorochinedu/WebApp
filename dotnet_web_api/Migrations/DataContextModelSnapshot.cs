﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_web_api.Data;

namespace dotnet_web_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("dotnet_web_api.Models.Character", b =>
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
                            Class = 1,
                            Defeats = 0,
                            Defense = 10,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 10,
                            Name = "Frodo",
                            Strength = 15,
                            UserId = 1,
                            Victories = 0
                        },
                        new
                        {
                            Id = 2,
                            Class = 3,
                            Defeats = 0,
                            Defense = 11,
                            Fights = 0,
                            HitPoints = 100,
                            Intelligence = 20,
                            Name = "Raistlin",
                            Strength = 9,
                            UserId = 2,
                            Victories = 0
                        });
                });

            modelBuilder.Entity("dotnet_web_api.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            SkillId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            SkillId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            SkillId = 3
                        });
                });

            modelBuilder.Entity("dotnet_web_api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 30,
                            Name = "Fireball"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 20,
                            Name = "Frenzy"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 40,
                            Name = "Blizzard"
                        });
                });

            modelBuilder.Entity("dotnet_web_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Player");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 94, 137, 197, 194, 130, 5, 232, 175, 200, 220, 108, 177, 75, 50, 74, 46, 91, 159, 191, 220, 66, 131, 194, 125, 233, 193, 6, 19, 205, 75, 17, 194, 117, 82, 131, 15, 181, 244, 167, 101, 85, 183, 232, 105, 86, 134, 199, 144, 251, 12, 129, 188, 37, 152, 170, 125, 152, 70, 2, 169, 220, 221, 207, 128 },
                            PasswordSalt = new byte[] { 3, 51, 160, 150, 228, 53, 237, 187, 93, 195, 10, 151, 21, 50, 151, 112, 182, 208, 76, 227, 105, 227, 2, 238, 130, 140, 162, 234, 143, 227, 127, 80, 93, 7, 239, 116, 230, 176, 25, 37, 50, 197, 6, 49, 134, 133, 30, 117, 219, 150, 58, 70, 204, 99, 45, 142, 64, 66, 197, 40, 249, 135, 2, 30, 117, 211, 37, 3, 22, 97, 33, 91, 240, 15, 132, 192, 104, 38, 64, 210, 212, 205, 59, 23, 197, 168, 43, 72, 163, 61, 116, 251, 114, 127, 232, 10, 17, 126, 77, 11, 26, 56, 110, 183, 164, 39, 15, 89, 9, 40, 232, 33, 197, 204, 8, 119, 198, 126, 238, 195, 133, 119, 62, 234, 239, 239, 210, 209 },
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = new byte[] { 94, 137, 197, 194, 130, 5, 232, 175, 200, 220, 108, 177, 75, 50, 74, 46, 91, 159, 191, 220, 66, 131, 194, 125, 233, 193, 6, 19, 205, 75, 17, 194, 117, 82, 131, 15, 181, 244, 167, 101, 85, 183, 232, 105, 86, 134, 199, 144, 251, 12, 129, 188, 37, 152, 170, 125, 152, 70, 2, 169, 220, 221, 207, 128 },
                            PasswordSalt = new byte[] { 3, 51, 160, 150, 228, 53, 237, 187, 93, 195, 10, 151, 21, 50, 151, 112, 182, 208, 76, 227, 105, 227, 2, 238, 130, 140, 162, 234, 143, 227, 127, 80, 93, 7, 239, 116, 230, 176, 25, 37, 50, 197, 6, 49, 134, 133, 30, 117, 219, 150, 58, 70, 204, 99, 45, 142, 64, 66, 197, 40, 249, 135, 2, 30, 117, 211, 37, 3, 22, 97, 33, 91, 240, 15, 132, 192, 104, 38, 64, 210, 212, 205, 59, 23, 197, 168, 43, 72, 163, 61, 116, 251, 114, 127, 232, 10, 17, 126, 77, 11, 26, 56, 110, 183, 164, 39, 15, 89, 9, 40, 232, 33, 197, 204, 8, 119, 198, 126, 238, 195, 133, 119, 62, 234, 239, 239, 210, 209 },
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("dotnet_web_api.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            Damage = 20,
                            Name = "The Master Sword"
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 2,
                            Damage = 5,
                            Name = "Crystal Wand"
                        });
                });

            modelBuilder.Entity("dotnet_web_api.Models.Character", b =>
                {
                    b.HasOne("dotnet_web_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("dotnet_web_api.Models.CharacterSkill", b =>
                {
                    b.HasOne("dotnet_web_api.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnet_web_api.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("dotnet_web_api.Models.Weapon", b =>
                {
                    b.HasOne("dotnet_web_api.Models.Character", "Character")
                        .WithOne("Weapon")
                        .HasForeignKey("dotnet_web_api.Models.Weapon", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("dotnet_web_api.Models.Character", b =>
                {
                    b.Navigation("CharacterSkills");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("dotnet_web_api.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
