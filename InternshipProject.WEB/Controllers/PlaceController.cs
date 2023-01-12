using InternshipProject.BLL.DTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.WEB.Abstractions;
using InternshipProject.WEB.ViewModels;
using InternshipProject.WEB.ViewModels.GetViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : CrudController<PlaceViewModel, PlaceDTO, GetPlaceViewModel>
{
    public PlaceController(ICRUDService<PlaceDTO> service) : base(service)
    {
    }

    [HttpGet]
    public override GetPlaceViewModel Get(int id)
    {
        var item = MapperOutput.Map<PlaceDTO, GetPlaceViewModel>(Service.Get(id));
        return item;
    }

    [HttpPut]
    public override IActionResult Update(PlaceViewModel item, int id)
    {
        ResultItem = MapperInput.Map<PlaceViewModel, PlaceDTO>(item);
        Service.Put(ResultItem, id);
        return new OkResult();
    }

    [HttpPost]
    public override IActionResult Add(PlaceViewModel item)
    {
        ResultItem = MapperInput.Map<PlaceViewModel, PlaceDTO>(item);
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