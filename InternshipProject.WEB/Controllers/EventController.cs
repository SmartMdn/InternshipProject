using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : CrudController<EventViewModel, EventDTO, GetEventViewModel>
{
    public EventController(ICRUDService<EventDTO> service, ILogger<EventController> logger) : base(service)
    {
    }

    [HttpGet]
    public override GetEventViewModel Get(int id)
    {
        var item = MapperOutput.Map<EventDTO, GetEventViewModel>(Service.Get(id));
        return item;
    }

    [HttpPost]
    public override IActionResult Add(EventViewModel item)
    {
        ResultItem = MapperInput.Map<EventViewModel, EventDTO>(item);
        Service.Post(ResultItem);
        return new OkResult();
    }

    [HttpPut]
    public override IActionResult Update(EventViewModel item, int id)
    {
        var resultItem = MapperInput.Map<EventViewModel, EventDTO>(item);
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