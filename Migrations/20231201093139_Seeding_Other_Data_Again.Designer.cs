﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NzWalksDbContext))]
    [Migration("20231201093139_Seeding_Other_Data_Again")]
    partial class Seeding_Other_Data_Again
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48efa303-f83c-48cb-b0cc-4159add849f4"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("1cb4b809-95a0-4295-9c21-50c1a0555262"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("0f6d5d40-95df-4643-984f-2648f7e881fa"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionImageURL")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c71cab5c-816e-4fa1-b173-78bd1594b035"),
                            Code = "ID",
                            Name = "Indonesia",
                            RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png"
                        },
                        new
                        {
                            Id = new Guid("00862174-10e6-413f-820c-92f3d52219bf"),
                            Code = "MY",
                            Name = "Malaysia",
                            RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png"
                        },
                        new
                        {
                            Id = new Guid("9662132f-c46c-46d1-855c-7280e6556c01"),
                            Code = "PS",
                            Name = "Palestine",
                            RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png"
                        },
                        new
                        {
                            Id = new Guid("e20c8c35-8220-41fc-b416-9b5726156f3e"),
                            Code = "TG",
                            Name = "Testing"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uuid");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<string>("WalkImageURL")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36eaa8b0-2c0a-4032-a07a-555ad238a56c"),
                            Description = "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.",
                            DifficultyId = new Guid("48efa303-f83c-48cb-b0cc-4159add849f4"),
                            LengthInKm = 3.5,
                            Name = "Mount Victoria Loop",
                            RegionId = new Guid("c71cab5c-816e-4fa1-b173-78bd1594b035"),
                            WalkImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("9d6c4d8a-d2e1-43c2-b656-c56f4279d8ed"),
                            Description = "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.",
                            DifficultyId = new Guid("1cb4b809-95a0-4295-9c21-50c1a0555262"),
                            LengthInKm = 8.1999999999999993,
                            Name = "Makara Beach Walkway",
                            RegionId = new Guid("00862174-10e6-413f-820c-92f3d52219bf"),
                            WalkImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("cb47d5fc-aa88-47ad-8e86-02c3b1fffa2b"),
                            Description = "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.",
                            DifficultyId = new Guid("0f6d5d40-95df-4643-984f-2648f7e881fa"),
                            LengthInKm = 0.0,
                            Name = "Botanic Garden Walk",
                            RegionId = new Guid("9662132f-c46c-46d1-855c-7280e6556c01")
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
