using System.Runtime.CompilerServices;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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


    public EFUnitOfWork(string? connectionString)
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

    IRepository<Event> IUnitOfWork.Events
    {
        get { return _eventRepository ??= new EventRepository(_db); }
    }

    IRepository<Hall> IUnitOfWork.Halls
    {
        get { return _hallRepository ??= new HallRepository(_db); }
    }

    IRepository<Place> IUnitOfWork.Places
    {
        get { return _placeRepository ??= new PlaceRepository(_db); }
    }

    IRepository<Section> IUnitOfWork.Sections
    {
        get { return _sectionRepository ??= new SectionRepository(_db); }
    }

    IRepository<Stadium> IUnitOfWork.Stadiums
    {
        get { return _stadiumRepository ??= new StadiumRepository(_db); }
    }

    IRepository<Ticket> IUnitOfWork.Tickets
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