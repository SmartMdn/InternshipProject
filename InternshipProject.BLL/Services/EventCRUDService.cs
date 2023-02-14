using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class EventCRUDService : ICRUDService<EventDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public EventCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public EventDTO Get(int id)
    {
        var resultEvent = _unitOfWork.Events.GetAsync(id).Result;
        if (resultEvent == null)
            throw new ValidationException("Билет не найден", "");

        return new EventDTO
        {
            BookingPeriodDays = resultEvent.BookingPeriodDays, Id = resultEvent.Id, Name = resultEvent.Name,
            EventDuration = resultEvent.EventDuration, HallId = resultEvent.HallId
        };
    }

    public IEnumerable<EventDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Event>, List<EventDTO>>(_unitOfWork.Events.GetAllAsync().Result);
    }

    public void Put(EventDTO item, int id)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var resultEvent = mapper.Map<EventDTO, Event>(item);
        resultEvent.Id = id;
        _unitOfWork.Events.UpdateAsync(resultEvent);
        _unitOfWork.Save();
    }

    public void Post(EventDTO item)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var resultEvent = mapper.Map<EventDTO, Event>(item);
        _unitOfWork.Events.CreateAsync(resultEvent);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Events.DeleteAsync(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}