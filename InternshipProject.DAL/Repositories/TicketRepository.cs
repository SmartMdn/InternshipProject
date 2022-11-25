using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class TicketRepository : IRepository<Ticket>
{
    public IEnumerable<Ticket> GetAll()
    {
        throw new NotImplementedException();
    }

    public Ticket Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> Find(Func<Ticket, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(Ticket item)
    {
        throw new NotImplementedException();
    }

    public void Update(Ticket item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}