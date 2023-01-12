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
    public HallController(ICRUDService<HallDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override GetHallViewModel Get(int id)
    {
        var item = MapperOutput.Map<HallDTO, GetHallViewModel>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(HallViewModel item, int id)
    {
        ResultItem = MapperInput.Map<HallViewModel, HallDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(HallViewModel item)
    {
        ResultItem = MapperInput.Map<HallViewModel, HallDTO>(item);
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