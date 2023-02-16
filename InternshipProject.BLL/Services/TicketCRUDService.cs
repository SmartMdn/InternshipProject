using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class TicketCrudService : ICrudService<TicketDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketCrudService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDTO> GetAsync(int id)
    {
        var ticket = await _unitOfWork.Tickets.GetAsync(id);
        if (ticket == null)
            throw new ValidationException("Билет не найден", "");

        return new TicketDTO { EventId = ticket.EventId, Id = ticket.Id, PlaceId = ticket.PlaceId };
    }

    public async Task<IEnumerable<TicketDTO>> GetAllAsync()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(await _unitOfWork.Tickets.GetAllAsync());
    }

    public async Task UpdateAsync(TicketDTO item, int id)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        await _unitOfWork.Tickets.UpdateAsync(ticket);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddAsync(TicketDTO item)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        await _unitOfWork.Tickets.CreateAsync(ticket);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Tickets.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}