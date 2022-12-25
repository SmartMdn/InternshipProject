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

    public IQueryable<Place> GetAll()
    {
        return _db.Places;
    }

    public IQueryable<Place> GetList(List<int> ids)
    {
        return _db.Places.Include(p=>p.Sections).Where(t => ids.Contains(t.Id));
    }

    public Place Get(int id)
    {
        return _db.Places.Include(p=>p.Sections).FirstOrDefault(place => place.Id ==id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Place> Find(Func<Place, bool> predicate)
    {
        return (IQueryable<Place>)_db.Places.Where(predicate);
    }

    public void Create(Place item)
    {
        _db.Places.Add(item);
    }

    public void Update(Place item)
    {
        var place = Get(item.Id);
        place.Sections = item.Sections;
        place.Tickets = item.Tickets;
        place.Type = item.Type;
        _db.Entry(place).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var place = _db.Places.Find(id);
        if (place != null) _db.Places.Remove(place);
    }
}