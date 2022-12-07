﻿// <auto-generated />
using InternshipProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternshipProject.DAL.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HallSection", b =>
                {
                    b.Property<int>("HallsId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsId")
                        .HasColumnType("int");

                    b.HasKey("HallsId", "SectionsId");

                    b.HasIndex("SectionsId");

                    b.ToTable("HallSection");
                });

            modelBuilder.Entity("HallStadium", b =>
                {
                    b.Property<int>("HallsId")
                        .HasColumnType("int");

                    b.Property<int>("StadiumsId")
                        .HasColumnType("int");

                    b.HasKey("HallsId", "StadiumsId");

                    b.HasIndex("StadiumsId");

                    b.ToTable("HallStadium");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingPeriodDays")
                        .HasColumnType("int");

                    b.Property<int>("EventDuration")
                        .HasColumnType("int");

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<string>("Name")
                        .IsRequired()
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

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBought")
                        .HasColumnType("bit");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("PlaceSection", b =>
                {
                    b.Property<int>("PlacesId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsId")
                        .HasColumnType("int");

                    b.HasKey("PlacesId", "SectionsId");

                    b.HasIndex("SectionsId");

                    b.ToTable("PlaceSection");
                });

            modelBuilder.Entity("HallSection", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Hall", null)
                        .WithMany()
                        .HasForeignKey("HallsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipProject.DAL.Entities.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HallStadium", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Hall", null)
                        .WithMany()
                        .HasForeignKey("HallsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipProject.DAL.Entities.Stadium", null)
                        .WithMany()
                        .HasForeignKey("StadiumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Event", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Hall", "EventHall")
                        .WithMany("Events")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventHall");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Ticket", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Event", "Event")
                        .WithMany("EventTickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipProject.DAL.Entities.Place", "Place")
                        .WithMany("Tickets")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("PlaceSection", b =>
                {
                    b.HasOne("InternshipProject.DAL.Entities.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipProject.DAL.Entities.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Event", b =>
                {
                    b.Navigation("EventTickets");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Hall", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("InternshipProject.DAL.Entities.Place", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
