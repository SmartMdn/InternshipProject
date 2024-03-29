﻿using InternshipProject.DAL.EF;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Repositories;

internal class PlaceRepository : IRepository<Place>
{
    private readonly CinemaContext _db;

    public PlaceRepository(CinemaContext db)
    {
        _db = db;
    }

    public IQueryable<Place> GetAll()
    {
        return _db.Places;
    }

    public IQueryable<Place> GetList(List<int> ids)
    {
        return _db.Places.Where(t => ids.Contains(t.Id));
    }

    public Place Get(int? id)
    {
        return _db.Places.FirstOrDefault(place => place.Id == id) ?? throw new InvalidOperationException();
    }

    public IQueryable<Place> Find(Func<Place, bool> predicate)
    {
        return (IQueryable<Place>)_db.Places.Where(predicate);
    }

    public void Create(Place item)
    {
        _ = _db.Places.Add(item);
    }

    public void Update(Place item)
    {
        Place place = Get(item.Id);
        place.Tickets = item.Tickets;
        place.Type = item.Type;
        _db.Entry(place).State = EntityState.Modified;
    }

    public void Delete(int? id)
    {
        Place? place = _db.Places.Find(id);
        if (place != null)
        {
            _ = _db.Places.Remove(place);
        }
    }
}