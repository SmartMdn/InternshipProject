using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.EF;

public class CinemaContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
    public CinemaContext()
    {
        //    Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}