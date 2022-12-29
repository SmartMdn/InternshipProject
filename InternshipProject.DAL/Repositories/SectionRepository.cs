using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class SectionRepository : IRepository<Section>
{
    private readonly CinemaContext _db;

    public SectionRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Section> GetAll()
    {
        return _db.Sections;
    }

    public IQueryable<Section> GetList(List<int> ids)
    {
        return _db.Sections.Include(section => section.Places).Where(t => ids.Contains(t.Id)); 
    }

    public Section Get(int id)
    {
        return _db.Sections.Include(section => section.Places).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Section> Find(Func<Section, bool> predicate)
    {
        return (IQueryable<Section>)_db.Sections.Include(section => section.Places).Where(predicate);
    }

    public void Create(Section item)
    {
        _db.Sections.Add(item);
    }

    public void Update(Section item)
    {
        var section = Get(item.Id);
        section.Places = item.Places;
        section.Name = item.Name;
        _db.Entry(section).State = EntityState.Modified;
        
    }

    public void Delete(int id)
    {
        var section = _db.Sections.Find(id);
        if (section != null) _db.Sections.Remove(section);
    }
}