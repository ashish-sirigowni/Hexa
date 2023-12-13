﻿// <auto-generated />
using System;
using BookMyShowProjectNewAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookMyShowProjectNewAPI.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookMyShowProjectNewAPI.Entity.City", b =>
                {
                    b.Property<long>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CityID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CityID");

                    b.HasIndex("CityName")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BookMyShowProjectNewAPI.Entity.Movie", b =>
                {
                    b.Property<long>("MovID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MovID"));

                    b.Property<string>("MovName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("MovID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BookMyShowProjectNewAPI.Entity.MultiplexInfo", b =>
                {
                    b.Property<long>("MulID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MulID"));

                    b.Property<long>("CityID")
                        .HasColumnType("bigint");

                    b.Property<string>("MulName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ScreenNumber")
                        .HasColumnType("int");

                    b.HasKey("MulID");

                    b.ToTable("MultiplexInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
