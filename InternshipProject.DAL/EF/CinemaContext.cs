using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.EF;

public sealed class CinemaContext : DbContext
{
    public CinemaContext()
    {
    }

    public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cinemaapidb;Trusted_Connection=True;");
    }
}