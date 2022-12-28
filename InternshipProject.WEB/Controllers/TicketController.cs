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

    [HttpGet]
    public override Ticket Get(int id)
    {
        var item = MapperOutput.Map<TicketDTO, Ticket>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override string Update(Ticket item, int id)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Put(ResultItem, id);
        return "Билет успешно изменён";
        ;
    }

    [HttpPost]
    public override string Add(Ticket item)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Post(ResultItem);
        return "Билет успешно добавлен";
    }

    [HttpDelete]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Билет успешно удалён";
    }
}