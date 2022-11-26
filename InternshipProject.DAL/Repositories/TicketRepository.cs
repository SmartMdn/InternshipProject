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

    public IEnumerable<Ticket> GetAll()
    {
        return _db.Tickets;
    }

    public Ticket Get(int id)
    {
        return _db.Tickets.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Ticket> Find(Func<Ticket, bool> predicate)
    {
        return _db.Tickets.Where(predicate).ToList();
    }

    public void Create(Ticket item)
    {
        _db.Tickets.Add(item);
    }

    public void Update(Ticket item)
    {
        _db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var ticket = _db.Tickets.Find(id);
        if (ticket != null) _db.Tickets.Remove(ticket);
    }
}