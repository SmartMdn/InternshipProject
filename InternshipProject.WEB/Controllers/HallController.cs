using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HallController : CrudController<HallViewModel, HallDTO, GetHallViewModel>
{
    public HallController(ICrudService<HallDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetHallViewModel> Get(int id)
    {
        var item = MapperOutput.Map<HallDTO, GetHallViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPut]
    public override async Task<IActionResult> Update(HallViewModel item, int id)
    {
        ResultItem = MapperInput.Map<HallViewModel, HallDTO>(item);
        await Service.UpdateAsync(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override async Task<IActionResult> Add(HallViewModel item)
    {
        ResultItem = MapperInput.Map<HallViewModel, HallDTO>(item);
        await Service.AddAsync(ResultItem);
        return new OkResult();
    }

    [HttpDelete]
    public override async Task<IActionResult> Delete(int id)
    {
        Service.DeleteAsync(id);
        return new OkResult();
    }
}