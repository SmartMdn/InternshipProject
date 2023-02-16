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
    public EventController(ICrudService<EventDTO> service, ILogger<EventController> logger) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetEventViewModel> Get(int id)
    {
        var item = MapperOutput.Map<EventDTO, GetEventViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPost]
    public override async Task<IActionResult> Add(EventViewModel item)
    {
        ResultItem = MapperInput.Map<EventViewModel, EventDTO>(item);
        await Service.AddAsync(ResultItem);
        return new OkResult();
    }

    [HttpPut]
    public override async Task<IActionResult> Update(EventViewModel item, int id)
    {
        var resultItem = MapperInput.Map<EventViewModel, EventDTO>(item);
        await Service.UpdateAsync(resultItem, id);
        return new OkResult();
    }

    [HttpDelete]
    public override async Task<IActionResult> Delete(int id)
    {
        await Service.DeleteAsync(id);
        return new OkResult();
    }
}