using System.Runtime.CompilerServices;
using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class TicketCRUDService : ICRUDService<TicketDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketCRUDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public TicketDTO Get(int id)
    {
        var ticket = _unitOfWork.Tickets.GetAsync(id).Result;
        if (ticket == null)
            throw new ValidationException("Билет не найден", "");

        return new TicketDTO { EventId = ticket.EventId, Id = ticket.Id, PlaceId = ticket.PlaceId };
    }

    public IEnumerable<TicketDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(_unitOfWork.Tickets.GetAllAsync().Result);
    }

    public void Put(TicketDTO item, int id)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        _unitOfWork.Tickets.UpdateAsync(ticket);
        _unitOfWork.Save();
    }

    public void Post(TicketDTO item)
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        _unitOfWork.Tickets.CreateAsync(ticket);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _unitOfWork.Tickets.DeleteAsync(id);
        _unitOfWork.Save();
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}