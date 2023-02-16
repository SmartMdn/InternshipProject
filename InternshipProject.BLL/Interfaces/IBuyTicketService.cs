using InternshipProject.BLL.DTO;

namespace InternshipProject.BLL.Interfaces;

public interface IBuyTicketService
{
    Task<IEnumerable<TicketDTO>> BuyTickets(List<int> ids);
    void Dispose();
}