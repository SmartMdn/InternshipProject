using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Repositories;

internal class EventRepository : DefaultRepository<Event>
{
    public override IQueryable<Event> GetList(List<int> ids)
    {
        return _db.Events.Where(t => ids.Contains(t.Id));
    }

    public override Event Get(int id)
    {
        return _db.Events.Find(id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Event> Find(Func<Event, bool> predicate)
    {
        return (IQueryable<Event>)_db.Events.Where(predicate);
    }
    public EventRepository(CinemaContext db) : base(db)
    {
    }
}