using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Interfaces;
using InternshipProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
internal class EventController : CrudController<Event, EventDTO>
{
    public EventController(ICRUDService<EventDTO> service, ILogger<EventController> logger) : base(service)
    {
    }

    [HttpGet]
    public override Event Get(int id)
    {
        Event item = MapperOutput.Map<EventDTO, Event>(Service.Get(id));
        return item;
    }

    [HttpPost]
    public override IActionResult Add(Event item)
    {
        ResultItem = MapperInput.Map<Event, EventDTO>(item);
        Service.Post(ResultItem);
        return new OkResult();
    }

    [HttpPut]
    public override IActionResult Update(Event item, int id)
    {
        EventDTO resultItem = MapperInput.Map<Event, EventDTO>(item);
        Service.Put(resultItem, id);
        return new OkResult();
    }

    [HttpDelete]
    public override IActionResult Delete(int id)
    {
        Service.Delete(id);
        return new OkResult();
    }
}