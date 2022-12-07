using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class HallRepository : IRepository<Hall>
{
    private readonly CinemaContext _db;

    public HallRepository(CinemaContext db)
    {
        _db = db;
    }

    public IEnumerable<Hall> GetAll()
    {
        return _db.Halls;
    }

    public IEnumerable<Hall> GetList(List<int> ids)
    {
        return _db.Halls.Include(hall => hall.Stadiums).Include(hall => hall.Sections).Where(t => ids.Contains(t.Id)).ToList();
    }

    public Hall Get(int id)
    {
        return _db.Halls.Include(hall => hall.Stadiums).Include(hall => hall.Sections).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Hall> Find(Func<Hall, bool> predicate)
    {
        return _db.Halls.Where(predicate).ToList();
    }

    public void Create(Hall item)
    {
        _db.Halls.Add(item);
    }

    public void Update(Hall item)
    {
        var hall = Get(item.Id);
        hall.Sections = item.Sections;
        hall.Stadiums = item.Stadiums;
        hall.Events = item.Events;
        _db.Entry(hall).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var hall = _db.Halls.Find(id);
        if (hall != null) _db.Halls.Remove(hall);
    }
}