using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class SectionRepository : DefaultRepository<Section>
{

    public override IQueryable<Section> GetList(List<int> ids)
    {
        return _db.Sections.Include(section => section.Places).Where(t => ids.Contains(t.Id)); 
    }

    public override Section Get(int id)
    {
        return _db.Sections.Include(section => section.Places).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public override IQueryable<Section> Find(Func<Section, bool> predicate)
    {
        return (IQueryable<Section>)_db.Sections.Include(section => section.Places).Where(predicate);
    }

    public SectionRepository(CinemaContext db) : base(db)
    {
    }
}