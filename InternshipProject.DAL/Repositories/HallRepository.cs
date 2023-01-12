using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class HallRepository : DefaultRepository<Hall>
{
    public override IQueryable<Hall> GetList(List<int> ids)
    {
        return _db.Halls.Include(hall => hall.Sections).Where(t => ids.Contains(t.Id));
    }

    public override Hall Get(int id)
    {
        return _db.Halls.Include(hall => hall.Sections).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Hall> Find(Func<Hall, bool> predicate)
    {
        return (IQueryable<Hall>)_db.Halls.Where(predicate);
    }
    public HallRepository(CinemaContext db) : base(db)
    {
    }
}