﻿using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class HallRepository : IRepository<Hall>
{
    private readonly CinemaContext _db;

    public HallRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Hall> GetAll()
    {
        return _db.Halls;
    }

    public IQueryable<Hall> GetList(List<int> ids)
    {
        return _db.Halls.Include(hall => hall.Sections).Where(t => ids.Contains(t.Id));
    }

    public Hall Get(int? id)
    {
        return _db.Halls.Include(hall => hall.Sections).FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Hall> Find(Func<Hall, bool> predicate)
    {
        return (IQueryable<Hall>)_db.Halls.Where(predicate);
    }

    public void Create(Hall item)
    {
        _ = _db.Halls.Add(item);
    }

    public void Update(Hall item)
    {
        Hall hall = Get(item.Id);
        hall.Sections = item.Sections;
        hall.Events = item.Events;
        _db.Entry(hall).State = EntityState.Modified;
    }

    public void Delete(int? id)
    {
        Hall? hall = _db.Halls.Find(id);
        if (hall != null)
        {
            _ = _db.Halls.Remove(hall);
        }
    }
}