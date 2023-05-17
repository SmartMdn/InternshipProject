using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class EventCRUDService : ICRUDService<EventDTO>
{
    private readonly IUnitOfWork _database;

    public EventCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public EventDTO Get(int id)
    {
        if (id == null)
        {
            throw new ValidationException("Не установлен id билета", "");
        }
        var _event = _database.Events.Get(id);
        return _event == null ? throw new ValidationException("Билет не найден", "") : new EventDTO
        {
            BookingPeriodDays = _event.BookingPeriodDays,
            Id = _event.Id,
            Name = _event.Name,
            EventDuration = _event.EventDuration,
            HallId = _event.HallId
        };
    }

    public IEnumerable<EventDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Event>, List<EventDTO>>(_database.Events.GetAll());
    }

    public void Put(EventDTO item, int id)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var _event = mapper.Map<EventDTO, Event>(item);
        _event.Id = id;
        _database.Events.Update(_event);
        _database.Save();
    }

    public void Post(EventDTO item)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var _event = mapper.Map<EventDTO, Event>(item);
        _database.Events.Create(_event);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Events.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}