using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Event> Events { get;}
    IRepository<Hall> Halls { get;}
    IRepository<Place> Places { get;}
    IRepository<Section> Sections { get;}
    IRepository<Stadium> Stadiums { get;}
    IRepository<Ticket> Tickets { get;}
    void Save();
}