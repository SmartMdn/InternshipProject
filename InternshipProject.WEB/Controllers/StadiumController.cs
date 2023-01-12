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
    public StadiumController(ICRUDService<StadiumDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override GetStadiumViewModel Get(int id)
    {
        var item = MapperOutput.Map<StadiumDTO, GetStadiumViewModel>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(StadiumViewModel item, int id)
    {
        ResultItem = MapperInput.Map<StadiumViewModel, StadiumDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(StadiumViewModel item)
    {
        ResultItem = MapperInput.Map<StadiumViewModel, StadiumDTO>(item);
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