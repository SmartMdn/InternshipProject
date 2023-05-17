using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Infrastucture;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class TicketCRUDService : ICRUDService<TicketDTO>
{
    private readonly IUnitOfWork _database;

    public TicketCRUDService(IUnitOfWork database)
    {
        _database = database;
    }

    public TicketDTO Get(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        var ticket = _database.Tickets.Get(id);
        if (ticket == null)
            throw new ValidationException("Билет не найден", "");

        return new TicketDTO { EventId = ticket.EventId, Id = ticket.Id, PlaceId = ticket.PlaceId };
    }

    public IEnumerable<TicketDTO> GetAll()
    {
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
        return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(_database.Tickets.GetAll());
    }

    public void Put(TicketDTO item, int id)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        _database.Tickets.Update(ticket);
        _database.Save();
    }

    public void Post(TicketDTO item)
    {
        if (item == null) return;
        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();
        var ticket = mapper.Map<TicketDTO, Ticket>(item);
        _database.Tickets.Create(ticket);
        _database.Save();
    }

    public void Delete(int id)
    {
        if (id == null)
            throw new ValidationException("Не установлен id билета", "");
        _database.Tickets.Delete(id);
        _database.Save();
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}