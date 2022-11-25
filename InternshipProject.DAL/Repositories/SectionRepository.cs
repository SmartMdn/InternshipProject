using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.DAL.Repositories;

public class SectionRepository : IRepository<Section>
{
    public IEnumerable<Section> GetAll()
    {
        throw new NotImplementedException();
    }

    public Section Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Section> Find(Func<Section, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(Section item)
    {
        throw new NotImplementedException();
    }

    public void Update(Section item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}