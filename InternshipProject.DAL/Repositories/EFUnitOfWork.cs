using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.BLL")]
[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.DAL.Repositories;

internal class EFUnitOfWork : IUnitOfWork
{
    private readonly CinemaContext _db;

    private bool _disposed;
    private EventRepository? _eventRepository;
    private HallRepository? _hallRepository;
    private PlaceRepository? _placeRepository;
    private SectionRepository? _sectionRepository;
    private StadiumRepository? _stadiumRepository;
    private TicketRepository? _ticketRepository;
    private CategoryRepository? _categoryRepository;


    public EFUnitOfWork(string? connectionString)
    {
        DbContextOptionsBuilder<CinemaContext> optionsBuilder = new();
        DbContextOptions<CinemaContext> options = optionsBuilder.UseSqlServer(connectionString).Options;
        _db = new CinemaContext(options);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IRepository<Event> Events => _eventRepository ??= new EventRepository(_db);

    public IRepository<Hall> Halls => _hallRepository ??= new HallRepository(_db);

    public IRepository<Place> Places => _placeRepository ??= new PlaceRepository(_db);

    public IRepository<Section> Sections => _sectionRepository ??= new SectionRepository(_db);

    public IRepository<Stadium> Stadiums => _stadiumRepository ??= new StadiumRepository(_db);

    public IRepository<Ticket> Tickets => _ticketRepository ??= new TicketRepository(_db);

    public IRepository<Category> Categories => _categoryRepository ??= new CategoryRepository(_db);

    public void Save()
    {
        _ = _db.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _db.Dispose();
        }

        _disposed = true;
    }
}