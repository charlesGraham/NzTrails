﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NzTrails.Api.Data;

#nullable disable

namespace NzTrails.Api.Migrations
{
    [DbContext(typeof(NzWalksDbContext))]
    [Migration("20231229035338_Seed Data For Difficulties and Regions")]
    partial class SeedDataForDifficultiesandRegions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NzTrails.Api.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2616c7a2-361e-4bfe-8fb1-7e6b78613110"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("a67fd31c-48b4-4512-af85-a5026b9dc8ac"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("b909e102-859a-403f-ba9e-94630407ca1e"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NzTrails.Api.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f78584b4-ba8e-40e8-82a7-6e4aa86db26d"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "auckland-region-img.jpg"
                        },
                        new
                        {
                            Id = new Guid("739d1a2e-d7a3-4c8d-aa7b-b57087ce001f"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "wellington-region-img.jpg"
                        },
                        new
                        {
                            Id = new Guid("170c6236-1b93-43ee-a27b-9c698c5214d3"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "nelson-region-img.jpg"
                        },
                        new
                        {
                            Id = new Guid("6a12ef70-b748-40a3-8033-307ae17da5fa"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "southland-region-img.jpg"
                        });
                });

            modelBuilder.Entity("NzTrails.Api.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NzTrails.Api.Models.Domain.Walk", b =>
                {
                    b.HasOne("NzTrails.Api.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NzTrails.Api.Models.Domain.Region", "Region")
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