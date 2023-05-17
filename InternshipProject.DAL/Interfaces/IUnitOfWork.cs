using InternshipProject.DAL.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.BLL")]
[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.DAL.Interfaces;

internal interface IUnitOfWork : IDisposable
{
    IRepository<Event> Events { get; }
    IRepository<Hall> Halls { get; }
    IRepository<Place> Places { get; }
    IRepository<Section> Sections { get; }
    IRepository<Stadium> Stadiums { get; }
    IRepository<Ticket> Tickets { get; }
    IRepository<Category> Categories { get; }
    void Save();
}