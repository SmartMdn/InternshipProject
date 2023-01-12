using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : CrudController<TicketViewModel, TicketDTO, GetTicketViewModel>
{
    public TicketController(ICRUDService<TicketDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override GetTicketViewModel Get(int id)
    {
        var item = MapperOutput.Map<TicketDTO, GetTicketViewModel>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(TicketViewModel item, int id)
    {
        ResultItem = MapperInput.Map<TicketViewModel, TicketDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(TicketViewModel item)
    {
        ResultItem = MapperInput.Map<TicketViewModel, TicketDTO>(item);
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