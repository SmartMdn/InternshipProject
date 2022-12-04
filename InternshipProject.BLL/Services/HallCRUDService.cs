﻿using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services;

public class HallCRUDService : ICRUDService<HallDTO>
{
    private readonly IUnitOfWork _database;

    public HallCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public HallDTO Get(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        var hall = _database.Halls.Get(id);
        if (hall == null)
            throw new ValidationException("Билет не найден", "");

        return new HallDTO { Id = hall.Id, Name = hall.Name };
    }

    public IEnumerable<HallDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hall, HallDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Hall>, List<HallDTO>>(_database.Halls.GetAll());
    }

    public void Put(HallDTO item, int id)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HallDTO, Hall>()).CreateMapper();
        var hall = mapper.Map<HallDTO, Hall>(item);
        _database.Halls.Update(hall);
        _database.Save();
    }

    public void Post(HallDTO item)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HallDTO, Hall>()).CreateMapper();
        var hall = mapper.Map<HallDTO, Hall>(item);
        _database.Halls.Create(hall);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Halls.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}