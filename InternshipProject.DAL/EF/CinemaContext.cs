using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.EF;

public sealed class CinemaContext : DbContext
{
    public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    internal DbSet<Event> Events { get; set; }
    internal DbSet<Hall> Halls { get; set; }
    internal DbSet<Place> Places { get; set; }
    internal DbSet<Section> Sections { get; set; }
    internal DbSet<Stadium> Stadiums { get; set; }
    internal DbSet<Ticket> Tickets { get; set; }
}