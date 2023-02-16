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

    public async Task<IQueryable<T>> GetAllAsync()
    {
        return Db.Set<T>();
    }

    public virtual async Task<IQueryable<T>> GetListAsync(List<int> ids)
    {
        return Db.Set<T>().Where(t => ids.Contains(t.Id));
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return Db.Set<T>().FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public virtual async Task<IQueryable<T>> FindAsync(Func<T, bool> predicate)
    {
        return (IQueryable<T>)Db.Set<T>().Where(predicate);
    }

    public async Task CreateAsync(T item)
    {
        await Db.Set<T>().AddAsync(item);
    }

    public async Task UpdateAsync(T item)
    {        
        var mapper = new MapperConfiguration(cfg => 
            cfg.CreateMap<T, T>()).CreateMapper();
        var resultItem = mapper.Map<T, T>(GetAsync(item.Id).Result);
        Db.Entry(resultItem).State = EntityState.Modified;
    }

    public async Task DeleteAsync(int id)
    {
        var stadium = await Db.Set<T>().FindAsync(id);
        if (stadium != null) Db.Set<T>().Remove(stadium);
    }
}