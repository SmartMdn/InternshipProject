using InternshipProject.BLL.DTO;

namespace InternshipProject.BLL.Interfaces;

public interface IBuyTicketService
{
    IEnumerable<TicketDTO> BuyTickets(List<int> ids);
    TicketDTO BuyTicket(int? id);
    void Dispose();
}