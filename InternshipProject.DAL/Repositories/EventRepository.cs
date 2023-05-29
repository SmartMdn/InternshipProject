using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class EventRepository : IRepository<Event>
{
    private readonly CinemaContext _db;

    public EventRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Event> GetAll()
    {
        return _db.Events;
    }

    public IQueryable<Event> GetList(List<int> ids)
    {
        return _db.Events.Where(t => ids.Contains(t.Id));
    }

    public Event Get(int? id)
    {
        return _db.Events.Find(id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Event> Find(Func<Event, bool> predicate)
    {
        return (IQueryable<Event>)_db.Events.Where(predicate);
    }

    public void Create(Event item)
    {
        _ = _db.Events.Add(item);
    }

    public void Update(Event item)
    {
        Event _event = Get(item.Id);
        _event.Name = item.Name;
        _event.EventDuration = item.EventDuration;
        _event.HallId = item.HallId;
        _event.BookingPeriodDays = item.BookingPeriodDays;
        _db.Entry(_event).State = EntityState.Modified;
    }

    public void Delete(int? id)
    {
        Event? item = _db.Events.Find(id);
        if (item != null)
        {
            _ = _db.Remove(item);
        }
    }
}