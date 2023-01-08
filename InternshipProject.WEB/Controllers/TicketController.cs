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
    public override IActionResult Update(Ticket item, int id)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
        ;
    }

    [HttpPost]
    public override IActionResult Add(Ticket item)
    {
        ResultItem = MapperInput.Map<Ticket, TicketDTO>(item);
        Service.Post(ResultItem);
        return new OkResult();
    }

    [HttpDelete]
    public override IActionResult Delete(int id)
    {
        Service.Delete(id);
        return new OkResult();
    }
}