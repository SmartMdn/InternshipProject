using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class StadiumRepository : IRepository<Stadium>
{
    private readonly CinemaContext _db;

    public StadiumRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Stadium> GetAll()
    {
        return _db.Stadiums;
    }

    public IQueryable<Stadium> GetList(List<int> ids)
    {
        return _db.Stadiums.Include(e => e.Halls).Where(t => ids.Contains(t.Id));
    }

    public Stadium Get(int id)
    {
        return _db.Stadiums.Include(e => e.Halls).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Stadium> Find(Func<Stadium, bool> predicate)
    {
        return (IQueryable<Stadium>)_db.Stadiums.Include(e => e.Halls).Where(predicate);
    }

    public void Create(Stadium item)
    {
        _db.Stadiums.Add(item);
    }

    public void Update(Stadium item)
    {
        var stadium = Get(item.Id);
        stadium.Address = item.Address;
        stadium.Halls = item.Halls;
        stadium.Name = item.Name;
        _db.Entry(stadium).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var stadium = _db.Stadiums.Find(id);
        if (stadium != null) _db.Stadiums.Remove(stadium);
    }
}