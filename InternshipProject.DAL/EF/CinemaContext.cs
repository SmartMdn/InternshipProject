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

    public DbSet<Event> Events => null!;
    public DbSet<Hall> Halls => null!;

    public DbSet<Place> Places => null!;

    public DbSet<Section> Sections => null!;

    public DbSet<Stadium> Stadiums => null!;

    public DbSet<Ticket> Tickets => null!;
}