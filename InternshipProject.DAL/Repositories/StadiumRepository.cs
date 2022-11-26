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

    public IEnumerable<Stadium> GetAll()
    {
        return _db.Stadiums;
    }

    public Stadium Get(int id)
    {
        return _db.Stadiums.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Stadium> Find(Func<Stadium, bool> predicate)
    {
        return _db.Stadiums.Where(predicate).ToList();
    }

    public void Create(Stadium item)
    {
        _db.Stadiums.Add(item);
    }

    public void Update(Stadium item)
    {
        _db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var stadium = _db.Stadiums.Find(id);
        if (stadium != null) _db.Stadiums.Remove(stadium);
    }
}