using AutoMapper;
using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

public abstract class DefaultRepository<T> : IRepository<T> where T: DefaultEntity
{
    protected readonly CinemaContext Db;

    protected DefaultRepository(CinemaContext db)
    {
        Db = db;
    }

    public IQueryable<T> GetAll()
    {
        return Db.Set<T>();
    }

    public virtual IQueryable<T> GetList(List<int> ids)
    {
        return Db.Set<T>().Where(t => ids.Contains(t.Id));
    }

    public virtual T Get(int id)
    {
        return Db.Set<T>().FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public virtual IQueryable<T> Find(Func<T, bool> predicate)
    {
        return (IQueryable<T>)Db.Set<T>().Where(predicate);
    }

    public void Create(T item)
    {
        Db.Set<T>().Add(item);
    }

    public void Update(T item)
    {        
        var mapper = new MapperConfiguration(cfg => 
            cfg.CreateMap<T, T>()).CreateMapper();
        var resultItem = mapper.Map<T, T>(Get(item.Id));
        Db.Entry(resultItem).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var stadium = Db.Set<T>().Find(id);
        if (stadium != null) Db.Set<T>().Remove(stadium);
    }
}