using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class EventCRUDService : ICrudService<EventDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public EventCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EventDTO> GetAsync(int id)
    {
        var resultEvent = await _unitOfWork.Events.GetAsync(id);
        if (resultEvent == null)
            throw new ValidationException("Билет не найден", "");

        return new EventDTO
        {
            BookingPeriodDays = resultEvent.BookingPeriodDays, Id = resultEvent.Id, Name = resultEvent.Name,
            EventDuration = resultEvent.EventDuration, HallId = resultEvent.HallId
        };
    }

    public async Task<IEnumerable<EventDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Event>, List<EventDTO>>(await _unitOfWork.Events.GetAllAsync());
    }

    public async Task UpdateAsync(EventDTO item, int id)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var resultEvent = mapper.Map<EventDTO, Event>(item);
        resultEvent.Id = id;
        await _unitOfWork.Events.UpdateAsync(resultEvent);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(EventDTO item)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
        var resultEvent = mapper.Map<EventDTO, Event>(item);
        await _unitOfWork.Events.CreateAsync(resultEvent);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Events.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}