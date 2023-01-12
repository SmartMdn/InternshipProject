using AutoMapper;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public abstract class DefaultRepository<T> : IRepository<T> where T: DefaultEntity
{
    protected readonly CinemaContext _db;

    protected DefaultRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<T> GetAll()
    {
        return _db.Set<T>();
    }

    public virtual IQueryable<T> GetList(List<int> ids)
    {
        return _db.Set<T>().Where(t => ids.Contains(t.Id));
    }

    public virtual T Get(int id)
    {
        return _db.Set<T>().FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public virtual IQueryable<T> Find(Func<T, bool> predicate)
    {
        return (IQueryable<T>)_db.Set<T>().Where(predicate);
    }

    public void Create(T item)
    {
        _db.Set<T>().Add(item);
    }

    public void Update(T item)
    {        
        var mapper = new MapperConfiguration(cfg => 
            cfg.CreateMap<T, T>()).CreateMapper();
        var resultItem = mapper.Map<T, T>(Get(item.Id));
        _db.Entry(resultItem).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var stadium = _db.Set<T>().Find(id);
        if (stadium != null) _db.Set<T>().Remove(stadium);
    }
}