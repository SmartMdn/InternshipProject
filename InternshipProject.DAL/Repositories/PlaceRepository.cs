using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.DAL.Repositories;

public class PlaceRepository : IRepository<Place>
{
    public IEnumerable<Place> GetAll()
    {
        throw new NotImplementedException();
    }

    public Place Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Place> Find(Func<Place, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(Place item)
    {
        throw new NotImplementedException();
    }

    public void Update(Place item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}