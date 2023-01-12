using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Repositories;

internal class PlaceRepository : DefaultRepository<Place>
{
    public override IQueryable<Place> GetList(List<int> ids)
    {
        return Db.Places.Where(t => ids.Contains(t.Id));
    }

    public override Place Get(int id)
    {
        return Db.Places.FirstOrDefault(place => place.Id ==id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Place> Find(Func<Place, bool> predicate)
    {
        return (IQueryable<Place>)Db.Places.Where(predicate);
    }

    public PlaceRepository(CinemaContext db) : base(db)
    {
    }
}