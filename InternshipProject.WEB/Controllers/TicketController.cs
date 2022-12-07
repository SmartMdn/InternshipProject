using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : CrudController<Ticket, TicketDTO>
{
    public TicketController(ICRUDService<TicketDTO> service) : base(service)
    {
    }

    [HttpGet("Get")]
    public override Ticket Get(int id)
    {
        var item = MapperOutput.Map<TicketDTO, Ticket>(Service.Get(id));
        return item;
    }

    [HttpPut("Update")]
    public override string Put(Ticket item, int id)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Put(ResultItem, id);
        return "Билет успешно изменён";
        ;
    }

    [HttpPost("Add")]
    public override string Post(Ticket item)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Post(ResultItem);
        return "Билет успешно добавлен";
    }

    [HttpDelete("Delete")]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Билет успешно удалён";
    }
}