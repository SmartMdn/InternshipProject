using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.DAL.Repositories;

public class StadiumReposytory : IRepository<Stadium>
{
    public IEnumerable<Stadium> GetAll()
    {
        throw new NotImplementedException();
    }

    public Stadium Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Stadium> Find(Func<Stadium, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(Stadium item)
    {
        throw new NotImplementedException();
    }

    public void Update(Stadium item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}