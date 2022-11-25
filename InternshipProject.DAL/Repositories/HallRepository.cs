using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.DAL.Repositories;

public class HallRepository : IRepository<Hall>
{
    public IEnumerable<Hall> GetAll()
    {
        throw new NotImplementedException();
    }

    public Hall Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hall> Find(Func<Hall, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(Hall item)
    {
        throw new NotImplementedException();
    }

    public void Update(Hall item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}