using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class StadiumRepository : DefaultRepository<Stadium>
{
    public override async Task<IQueryable<Stadium>> GetListAsync(List<int> ids)
    {
        return Db.Stadiums.Include(e => e.Halls).Where(t => ids.Contains(t.Id));
    }

    public override async Task<Stadium> GetAsync(int id)
    {
        return Db.Stadiums.Include(e => e.Halls).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Stadium>> FindAsync(Func<Stadium, bool> predicate)
    {
        return (IQueryable<Stadium>)Db.Stadiums.Include(e => e.Halls).Where(predicate);
    }

    public StadiumRepository(CinemaContext db) : base(db)
    {
    }
}