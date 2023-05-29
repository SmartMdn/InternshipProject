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
        _ = Database.EnsureCreated();
    }

    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<Hall> Halls { get; set; } = default!;
    public DbSet<Place> Places { get; set; } = default!;
    public DbSet<Section> Sections { get; set; } = default!;
    public DbSet<Stadium> Stadiums { get; set; } = default!;
    public DbSet<Ticket> Tickets { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cinemaapidb;Trusted_Connection=True;");
    }
}