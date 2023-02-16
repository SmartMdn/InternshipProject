using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class TicketRepository : DefaultRepository<Ticket>
{

    public override async Task<Ticket> GetAsync(int id)
    {
        return await Db.Tickets.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Ticket>> FindAsync(Func<Ticket, bool> predicate)
    {
        return (IQueryable<Ticket>)Db.Tickets.Where(predicate);
    }

    public override async Task<IQueryable<Ticket>> GetListAsync(List<int> ids)
    {
        return Db.Tickets.Where(t => ids.Contains(t.Id));
    }

    public TicketRepository(CinemaContext db) : base(db)
    {
    }
}