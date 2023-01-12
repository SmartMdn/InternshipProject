using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class StadiumRepository : DefaultRepository<Stadium>
{
    public override IQueryable<Stadium> GetList(List<int> ids)
    {
        return _db.Stadiums.Include(e => e.Halls).Where(t => ids.Contains(t.Id));
    }

    public override Stadium Get(int id)
    {
        return _db.Stadiums.Include(e => e.Halls).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Stadium> Find(Func<Stadium, bool> predicate)
    {
        return (IQueryable<Stadium>)_db.Stadiums.Include(e => e.Halls).Where(predicate);
    }

    public StadiumRepository(CinemaContext db) : base(db)
    {
    }
}