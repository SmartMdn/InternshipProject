using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly CinemaContext _db;

    private bool _disposed;
    private EventRepository? _eventRepository;
    private HallRepository? _hallRepository;
    private PlaceRepository? _placeRepository;
    private SectionRepository? _sectionRepository;
    private StadiumRepository? _stadiumRepository;
    private TicketRepository? _ticketRepository;


    public EFUnitOfWork(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
        var options = optionsBuilder.UseSqlServer(connectionString).Options;
        _db = new CinemaContext(options);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IRepository<Event> Events
    {
        get { return _eventRepository ??= new EventRepository(_db); }
    }

    public IRepository<Hall> Halls
    {
        get { return _hallRepository ??= new HallRepository(_db); }
    }

    public IRepository<Place> Places
    {
        get { return _placeRepository ??= new PlaceRepository(_db); }
    }

    public IRepository<Section> Sections
    {
        get { return _sectionRepository ??= new SectionRepository(); }
    }

    public IRepository<Stadium> Stadiums
    {
        get { return _stadiumRepository ??= new StadiumRepository(_db); }
    }

    public IRepository<Ticket> Tickets
    {
        get { return _ticketRepository ??= new TicketRepository(_db); }
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) _db.Dispose();
        _disposed = true;
    }
}