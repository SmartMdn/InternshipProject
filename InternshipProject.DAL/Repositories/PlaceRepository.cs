using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class PlaceRepository : IRepository<Place>
{
    private readonly CinemaContext _db;

    public PlaceRepository(CinemaContext db)
    {
        _db = db;
    }

    public IEnumerable<Place> GetAll()
    {
        return _db.Places;
    }

    public Place Get(int id)
    {
        return _db.Places.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Place> Find(Func<Place, bool> predicate)
    {
        return _db.Places.Where(predicate).ToList();
    }

    public void Create(Place item)
    {
        _db.Places.Add(item);
    }

    public void Update(Place item)
    {
        _db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var place = _db.Places.Find(id);
        if (place != null) _db.Places.Remove(place);
    }
}