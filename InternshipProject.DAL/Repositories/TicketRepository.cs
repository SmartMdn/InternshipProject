using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class TicketRepository : DefaultRepository<Ticket>
{

    public override Ticket Get(int id)
    {
        return _db.Tickets.Find(id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Ticket> Find(Func<Ticket, bool> predicate)
    {
        return (IQueryable<Ticket>)_db.Tickets.Where(predicate);
    }

    public override IQueryable<Ticket> GetList(List<int> ids)
    {
        return _db.Tickets.Where(t => ids.Contains(t.Id));
    }

    public TicketRepository(CinemaContext db) : base(db)
    {
    }
}