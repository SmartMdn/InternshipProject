using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Repositories;

internal class PlaceRepository : DefaultRepository<Place>
{
    public override async Task<IQueryable<Place>> GetListAsync(List<int> ids)
    {
        return Db.Places.Where(t => ids.Contains(t.Id));
    }

    public override async Task<Place> GetAsync(int id)
    {
        return Db.Places.FirstOrDefault(place => place.Id ==id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Place>> FindAsync(Func<Place, bool> predicate)
    {
        return (IQueryable<Place>)Db.Places.Where(predicate);
    }

    public PlaceRepository(CinemaContext db) : base(db)
    {
    }
}