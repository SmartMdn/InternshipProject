﻿// <auto-generated />
using System;
using InternshipProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternshipProject.DAL.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20221124174513_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternshipProject.DAL.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventDuration")
                        .HasColumnType("int");

                    b.Property<string>("EventHallName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventHallName");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Hall", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("StadiumId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Section", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HallName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("HallName");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Event", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Hall", "EventHall")
                        .WithMany()
                        .HasForeignKey("EventHallName");

                    b.Navigation("EventHall");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Hall", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("StadiumId");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Section", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallName");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Ticket", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("InternshipProject.DAL.Entities.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.Navigation("Event");

                    b.Navigation("Place");
                });
#pragma warning restore 612, 618
        }
    }
}