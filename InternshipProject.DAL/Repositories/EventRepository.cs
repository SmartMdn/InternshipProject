using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class EventRepository : IRepository<Event>
{
    private readonly CinemaContext _db;

    public EventRepository(CinemaContext db)
    {
        _db = db;
    }

    public IEnumerable<Event>? GetAll()
    {
        return _db.Events;
    }

    public Event Get(int id)
    {
        return _db.Events.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Event> Find(Func<Event, bool> predicate)
    {
        var a =_db.Events.Where(predicate).ToList();
        //var b =_db.Events.Include(e => e.EventHall).Where(predicate).ToList();
        return a;
    }

    public void Create(Event item)
    {
        _db.Events.Add(item);
    }

    public void Update(Event item)
    {
        _db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var item = _db.Events.Find(id);
        if (item != null)
        {
            _db.Remove(item);
        }
    }
}