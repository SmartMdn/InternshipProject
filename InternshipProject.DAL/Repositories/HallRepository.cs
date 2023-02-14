using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class HallRepository : DefaultRepository<Hall>
{
    public override async Task<IQueryable<Hall>> GetListAsync(List<int> ids)
    {
        return Db.Halls.Include(hall => hall.Sections).Where(t => ids.Contains(t.Id));
    }

    public override async Task<Hall> GetAsync(int id)
    {
        return Db.Halls.Include(hall => hall.Sections).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Hall>> FindAsync(Func<Hall, bool> predicate)
    {
        return (IQueryable<Hall>)Db.Halls.Where(predicate);
    }
    public HallRepository(CinemaContext db) : base(db)
    {
    }
}