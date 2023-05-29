using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Models;
using InternshipProject.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Pages.CRUD.Tickets
{
    internal class IndexModel : BasePage<Ticket, TicketDTO>
    {
        public List<Ticket> Ticket { get; set; } = default!;

        public void OnGet([FromServices] ICRUDService<TicketDTO> Service)
        {
            if (Service.GetAll() != null)
            {
                foreach (TicketDTO item in Service.GetAll())
                {
                    Ticket result = MapperOutput.Map<TicketDTO, Ticket>(item);
                    Ticket.Add(result);
                }
            }
        }
    }
}
