using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class TicketRepository : IRepository<Ticket>
{
    private readonly CinemaContext _db;

    public TicketRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Ticket> GetAll()
    {
        return _db.Tickets;
    }

    public Ticket Get(int id)
    {
        return _db.Tickets.Find(id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Ticket> Find(Func<Ticket, bool> predicate)
    {
        return (IQueryable<Ticket>)_db.Tickets.Where(predicate);
    }

    public void Create(Ticket item)
    {
        _db.Tickets.Add(item);
    }

    public void Update(Ticket item)
    {
        var ticket = Get(item.Id);
        ticket.EventId = item.EventId;
        ticket.PlaceId = item.PlaceId;
        ticket.IsBought = item.IsBought;
        _db.Entry(ticket).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var ticket = _db.Tickets.Find(id);
        if (ticket != null) _db.Tickets.Remove(ticket);
    }

    public IQueryable<Ticket> GetList(List<int> ids)
    {
        return _db.Tickets.Where(t => ids.Contains(t.Id));
    }
}