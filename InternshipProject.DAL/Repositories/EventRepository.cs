using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Repositories;

internal class EventRepository : DefaultRepository<Event>
{
    public override async Task<IQueryable<Event>> GetListAsync(List<int> ids)
    {
        return Db.Events.Where(t => ids.Contains(t.Id));
    }

    public override async Task<Event> GetAsync(int id)
    {
        return await Db.Events.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Event>> FindAsync(Func<Event, bool> predicate)
    {
        return (IQueryable<Event>)Db.Events.Where(predicate);
    }
    public EventRepository(CinemaContext db) : base(db)
    {
    }
}