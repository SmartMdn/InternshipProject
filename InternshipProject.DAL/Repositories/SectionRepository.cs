using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public class SectionRepository : IRepository<Section>
{
    private readonly CinemaContext _db;

    public IEnumerable<Section> GetAll()
    {
        return _db.Sections;
    }

    public IEnumerable<Section> GetList(List<int> ids)
    {
        return _db.Sections.Where(t => ids.Contains(t.Id)).ToList();
    }

    public Section Get(int id)
    {
        return _db.Sections.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Section> Find(Func<Section, bool> predicate)
    {
        return _db.Sections.Where(predicate).ToList();
    }

    public void Create(Section item)
    {
        _db.Sections.Add(item);
    }

    public void Update(Section item)
    {
        _db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var section = _db.Sections.Find(id);
        if (section != null) _db.Sections.Remove(section);
    }
}