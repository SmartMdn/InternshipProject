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
    public TicketController(ICrudService<TicketDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetTicketViewModel> Get(int id)
    {
        var item = MapperOutput.Map<TicketDTO, GetTicketViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPut]
    public override async Task<IActionResult> Update(TicketViewModel item, int id)
    {
        ResultItem = MapperInput.Map<TicketViewModel, TicketDTO>(item);
        await Service.UpdateAsync(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override async Task<IActionResult> Add(TicketViewModel item)
    {
        ResultItem = MapperInput.Map<TicketViewModel, TicketDTO>(item);
        await Service.AddAsync(ResultItem);
        return new OkResult();
    }

    [HttpDelete]
    public override async Task<IActionResult> Delete(int id)
    {
        await Service.DeleteAsync(id);
        return new OkResult();
    }
}