﻿// <auto-generated />
using System;
using EasySun.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasySun.Migrations
{
    [DbContext(typeof(SunDbContext))]
    [Migration("20201207070958_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sun")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EasySun.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CountryFK")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10,8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11,8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(88)
                        .HasColumnType("nchar(88)");

                    b.HasKey("Id");

                    b.HasIndex("CountryFK");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EasySun.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EasySun.Models.EventTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CityFK")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Sunrise")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Sunset")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CityFK");

                    b.ToTable("EventTimes");
                });

            modelBuilder.Entity("EasySun.Models.City", b =>
                {
                    b.HasOne("EasySun.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EasySun.Models.EventTime", b =>
                {
                    b.HasOne("EasySun.Models.City", "City")
                        .WithMany("EventTimings")
                        .HasForeignKey("CityFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("EasySun.Models.City", b =>
                {
                    b.Navigation("EventTimings");
                });

            modelBuilder.Entity("EasySun.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
