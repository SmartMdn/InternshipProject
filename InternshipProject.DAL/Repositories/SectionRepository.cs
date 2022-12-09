using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class SectionRepository : IRepository<Section>
{
    private readonly CinemaContext _db;

    public SectionRepository(CinemaContext db)
    {
        _db = db;
    }

    public IEnumerable<Section> GetAll()
    {
        return _db.Sections;
    }

    public IEnumerable<Section> GetList(List<int> ids)
    {
        try
        {
            return _db.Sections.Include(section => section.Halls).Include(section => section.Places).Where(t => ids.Contains(t.Id)).ToList();
        }
        catch (Exception e)
        {
            return new List<Section>();
        }
        
    }

    public Section Get(int id)
    {
        return _db.Sections.Include(section => section.Halls).Include(section => section.Places).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Section> Find(Func<Section, bool> predicate)
    {
        return _db.Sections.Include(section => section.Halls).Include(section => section.Places).Where(predicate).ToList();
    }

    public void Create(Section item)
    {
        _db.Sections.Add(item);
    }

    public void Update(Section item)
    {
        var section = Get(item.Id);
        section.Places = item.Places;
        section.Halls = item.Halls;
        section.Name = item.Name;
        _db.Entry(section).State = EntityState.Modified;
        
    }

    public void Delete(int id)
    {
        var section = _db.Sections.Find(id);
        if (section != null) _db.Sections.Remove(section);
    }
}