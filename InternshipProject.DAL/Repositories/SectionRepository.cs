using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class SectionRepository : DefaultRepository<Section>
{

    public override async Task<IQueryable<Section>> GetListAsync(List<int> ids)
    {
        return Db.Sections.Include(section => section.Places).Where(t => ids.Contains(t.Id)); 
    }

    public override async Task<Section> GetAsync(int id)
    {
        return await Db.Sections.Include(section => section.Places).FirstOrDefaultAsync(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override async Task<IQueryable<Section>> FindAsync(Func<Section, bool> predicate)
    {
        return (IQueryable<Section>)Db.Sections.Include(section => section.Places).Where(predicate);
    }

    public SectionRepository(CinemaContext db) : base(db)
    {
    }
}