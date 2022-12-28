using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : CrudController<Event, EventDTO>
{
    public EventController(ICRUDService<EventDTO> service, ILogger<EventController> logger) : base(service)
    {
    }

    [HttpGet]
    public override Event Get(int id)
    {
        var item = MapperOutput.Map<EventDTO, Event>(Service.Get(id));
        return item;
    }

    [HttpPost]
    public override string Add(Event item)
    {
        ResultItem = MapperInput.Map<Event, EventDTO>(item);
        Service.Post(ResultItem);
        return "Ивент успешно изменён";
    }

    [HttpPut]
    public override string Update(Event item, int id)
    {
        var resultItem = MapperInput.Map<Event, EventDTO>(item);
        Service.Put(resultItem, id);
        return "Ивент успешно добавлен";
    }

    [HttpDelete]
    public override string Delete(int id)
    {
        Service.Delete(id);
        return "Ивент успешно удалён";
    }
}