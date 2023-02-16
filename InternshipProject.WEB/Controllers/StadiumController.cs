using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class StadiumController : CrudController<StadiumViewModel, StadiumDTO, GetStadiumViewModel>
{
    public StadiumController(ICrudService<StadiumDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override async Task<GetStadiumViewModel> Get(int id)
    {
        var item = MapperOutput.Map<StadiumDTO, GetStadiumViewModel>(await Service.GetAsync(id));
        return item;
    }

    [HttpPut]
    public override async Task<IActionResult> Update(StadiumViewModel item, int id)
    {
        ResultItem = MapperInput.Map<StadiumViewModel, StadiumDTO>(item);
        await Service.UpdateAsync(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override async Task<IActionResult> Add(StadiumViewModel item)
    {
        ResultItem = MapperInput.Map<StadiumViewModel, StadiumDTO>(item);
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