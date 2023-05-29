using AutoMapper;
using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InternshipProject.WEB")]
namespace InternshipProject.BLL.Services;

internal class BuyTicketService : IBuyTicketService
{
    public BuyTicketService(IUnitOfWork database)
    {
        Database = database;
    }

    private IUnitOfWork Database { get; }

    public IEnumerable<TicketDTO> BuyTickets(List<int> ids)
    {
        List<Ticket> tickets;
        try
        {
            tickets = Database.Tickets.GetList(ids).ToList();
        }
        catch (NullReferenceException)
        {
            return new List<TicketDTO>();
        }

        foreach (Ticket variableTicket in tickets)
        {
            variableTicket.IsBought = true;
            Database.Tickets.Update(variableTicket);
        }

        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
        Database.Save();
        return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(tickets);
    }

    public void Dispose()
    {
        Database.Dispose();
    }
}